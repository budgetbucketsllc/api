using System;
using AutoMapper;
using BudgetBucketsAPI.Models.Budget;
using BudgetBucketsAPI.Services.EntityServices;
using Microsoft.AspNetCore.Mvc;

namespace BudgetBucketsAPI.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class BudgetController : ControllerBase
	{
		private IBudgetService _budgetService;
		private IMapper _mapper; 
		public BudgetController(
			IBudgetService budgetService,
			IMapper mapper)
		{
			_budgetService = budgetService;
			_mapper = mapper;
		}

		[HttpGet]
		public IActionResult GetAll()
		{
			var budgets = _budgetService.GetAll();
			return Ok(budgets);
		}

		[HttpGet("id/{id}")]
		public IActionResult GetById(int id)
		{
			var budget = _budgetService.GetById(id);
			return Ok(budget);
		}

		[HttpGet("userid/{userid}")]
		public IActionResult GetBudgetsByUserId(int userid)
		{
			var budgets = _budgetService.GetAllBudgetsByUserId(userid);
			return Ok(budgets);
		}

		[HttpGet("userid/{userid}/{date}")]
		public IActionResult GetUserBudgetByDate(int userid, DateOnly date)
		{
			var budget = _budgetService.GetUserBudgetForDate(userid, date);
			return Ok(budget);
		}

		[HttpPost]
		public IActionResult Create(CreateRequestBudget model, int userid) {
			_budgetService.Create(model, userid);
			return Ok(new {message = $"Budget created for the month of {model.Timeframe.ToString("MMMM")}"});
		}

		[HttpPatch("update/{userid}/{id}")]
		public IActionResult Update(int userid, int id, UpdateRequestBudget model) {
			_budgetService.Update(userid, id, model);
			return Ok(new {message = "Budget updated"});
		}

		[HttpDelete("{id}")]
		public IActionResult Delete(int id)
		{
			_budgetService.Delete(id);
			return Ok(new {message = "Budget deleted"});
		}

	}
}

