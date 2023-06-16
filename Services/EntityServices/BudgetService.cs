using System;
using AutoMapper;
using BudgetBucketsAPI.Entities;
using BudgetBucketsAPI.Helpers;
using BudgetBucketsAPI.Models.Budget;

namespace BudgetBucketsAPI.Services.EntityServices
{
	public interface IBudgetService
	{
		IEnumerable<Budget> GetAll();
		Budget GetById(int id);
		List<Budget> GetAllBudgetsByUserId(int userId);
        Budget GetUserBudgetForDate(int userId, DateOnly date);
		void Create(CreateRequestBudget model, int userId);
		void Update(int userId, int id, UpdateRequestBudget model);
		void Delete(int id);
	}
    public class BudgetService : IBudgetService
    {
        private DataContext _context;
        private readonly IMapper _mapper;

        public BudgetService(
            DataContext context,
            IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public void Create(CreateRequestBudget model, int userId)
        {
            Budget budget = _mapper.Map<Budget>(model);
            budget.UserId = userId;

            _context.Budgets.Add(budget);

            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            Budget budget = getBudget(id);
            _context.Budgets.Remove(budget);

            _context.SaveChanges();
        }

        public IEnumerable<Budget> GetAll()
        {
            return _context.Budgets;
        }

        public List<Budget> GetAllBudgetsByUserId(int userId)
        {
            return getBudgetsByUserId(userId);
        }

        public Budget GetUserBudgetForDate(int userId, DateOnly date)
        {
            List<Budget> budgets = getBudgetsByUserId(userId);
            Budget budget = (Budget) budgets.Where(b => b.Timeframe == date);
            return budget;
        }

        public Budget GetById(int id)
        {
            return getBudget(id);
        }

        public void Update(int userId, int id, UpdateRequestBudget model)
        {
            Budget budget = getBudget(id);

            _mapper.Map(model, budget);
            budget.UserId = userId;

            _context.Budgets.Update(budget);

            _context.SaveChanges();
        }

        private List<Budget> getBudgetsByUserId(int userId)
        {
            List<Budget> budgets = _context.Budgets.Where(budget => budget.UserId == userId).ToList();
            if (budgets == null) throw new KeyNotFoundException("Budgets not found");
            return budgets;
        }

        private Budget getBudget(int id)
        {
            Budget? budget = _context.Budgets.Find(id);
            if (budget == null) throw new KeyNotFoundException("Budget not found)");
            return budget;
        }
    }
}

