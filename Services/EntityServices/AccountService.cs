using System;
using AutoMapper;
using BudgetBucketsAPI.Entities;
using BudgetBucketsAPI.Helpers;
using BudgetBucketsAPI.Models.Users;

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

        public List<Account> GetAllAccountsByUserId(int user_id)
        {
            var accounts = _context.Accounts.Where(account => account.UserId == user_id).ToList();
            if (accounts == null) throw new KeyNotFoundException("Accounts not found");
            return accounts;
        }


        private Account getAccount(int id)
        {
            var account = _context.Accounts.Find(id);
            if (account == null) throw new KeyNotFoundException("Account not found");
            return account;
        }

    }

}