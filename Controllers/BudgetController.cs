using System;
using AutoMapper;
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

	}
}

