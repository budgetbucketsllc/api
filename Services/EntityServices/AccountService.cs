using System;
using AutoMapper;
using BudgetBucketsAPI.Entities;
using BudgetBucketsAPI.Helpers;
using BudgetBucketsAPI.Models.Account;

namespace BudgetBucketsAPI.Services.EntityServices
{
    public interface IAccountService
    {
        IEnumerable<Account> GetAll();
        Account GetById(int id);
        List<Account> GetAllAccountsByUserId(int userId);
        void Create(CreateRequestAccount model, int userId);
        void Update(int userId, int id, UpdateRequestAccount model);
        void Delete(int id);
    }

    public class AccountService : IAccountService
    {
        private DataContext _context;
        private readonly IMapper _mapper;

        public AccountService(
            DataContext context,
            IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public IEnumerable<Account> GetAll()
        {
            return _context.Accounts;
        }

        public Account GetById(int id)
        {
            return getAccount(id);
        }

        public List<Account> GetAllAccountsByUserId(int userId)
        {
            return getAccountsByUserId(userId);
        }

        public void Create(CreateRequestAccount model, int userId)
        {
            UserService userService = new UserService(_context, _mapper);
            User user = userService.GetById(userId);
            if (user == null)
            {
                throw new AppException("Account cannot be created. User does not exist.");
            }

            List<Account> accounts = getAccountsByUserId(userId);

            if (accounts.Any(x => x.Name == model.Name))
                throw new AppException("Account with the name '" + model.Name + "' already exists");

            Account account = _mapper.Map<Account>(model);
            account.UserId = userId;
            account.AmountTotal = Math.Round(model.AmountTotal, 2);

            _context.Accounts.Add(account);

            _context.SaveChanges();
        }

        public void Update(int userId, int id, UpdateRequestAccount model)
        {
            Account account = getAccount(id);

            List<Account> accounts = getAccountsByUserId(userId);

            if (accounts.Any(x => x.Name == model.Name))
                throw new AppException("Adccount with the name '" + model.Name + "' already exists");

            _mapper.Map(model, account);
            account.UserId = userId;
            account.AmountTotal = Math.Round(model.AmountTotal, 2);

            _context.Accounts.Update(account);

            _context.SaveChanges();

        }

        public void Delete (int id)
        {
            Account account = getAccount(id);
            _context.Accounts.Remove(account);

            _context.SaveChanges();

        }

        private List<Account> getAccountsByUserId(int userId)
        {
            List<Account> accounts = _context.Accounts.Where(account => account.UserId == userId).ToList();
            if (accounts == null) throw new KeyNotFoundException("Accounts not found");
            return accounts;
        }


        private Account getAccount(int id)
        {
            Account? account = _context.Accounts.Find(id);
            if (account == null) throw new KeyNotFoundException("Account not found");
            return account;
        }

    }

}