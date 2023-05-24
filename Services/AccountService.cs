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

    }

}