using System;
using AutoMapper;
using BudgetBucketsAPI.Entities;
using BudgetBucketsAPI.Helpers;
using BudgetBucketsAPI.Models.Account;

namespace BudgetBucketsAPI.Services
{
    public interface IAccountService
    {

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
            List<Account> accounts = getAccountsByUserId(userId);

            if (accounts.Any(x => x.Name == model.Name))
                throw new AppException("Adccount with the name '" + model.Name + "' already exists");

            Account account = _mapper.Map<Account>(model);

            _context.Accounts.Add(account);
            _context.SaveChangesAsync();
        }

        public void Update(int id, UpdateRequestAccount model, int userId)
        {
            Account account = getAccount(id);

            List<Account> accounts = getAccountsByUserId(userId);

            if (accounts.Any(x => x.Name == model.Name))
                throw new AppException("Adccount with the name '" + model.Name + "' already exists");

            _mapper.Map(model, account);

            _context.Accounts.Update(account);
            _context.SaveChangesAsync();
        }

        public void Delete (int id)
        {
            Account account = getAccount(id);
            _context.Accounts.Remove(account);
            _context.SaveChangesAsync();
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