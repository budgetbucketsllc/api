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
		public BudgetController()
		{
		}
	}
}

