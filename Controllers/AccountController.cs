using System;
using AutoMapper;
using BudgetBucketsAPI.Models.Account;
using BudgetBucketsAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace BudgetBucketsAPI.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class AccountController : ControllerBase
	{
		private IAccountService _accountService;
		private IMapper _mapper;

		public AccountController(
			IAccountService accountService,
			IMapper mapper)
		{
			_accountService = accountService;
			_mapper = mapper;
		}

		[HttpGet]
		public IActionResult GetAll()
		{
			var accounts = _accountService.GetAll();
			return Ok(accounts);
		}

		[HttpGet("{id}")]
		public IActionResult GetById(int id)
		{
			var account = _accountService.GetById(id);
			return Ok(account);
		}

		[HttpGet("{userid}")]
		public IActionResult GetAllAccountsByUserId(int userId)
		{
			var accounts = _accountService.GetAllAccountsByUserId(userId);
			return Ok(accounts);
		}

		[HttpPost]
		public IActionResult Create(CreateRequestAccount model, int userId)
		{
			_accountService.Create(model, userId);
			return Ok(new { message = "Account created" });
		}

		[HttpPut("{userid}/{id}")]
		public IActionResult Update(int userId, int id, UpdateRequestAccount model)
		{
			_accountService.Update(userId, id, model);
			return Ok(new { message = "Account updated" });
		}

		[HttpDelete("{id}")]
		public IActionResult Delete(int id)
		{
			_accountService.Delete(id);
			return Ok(new { message = "Account deleted" });
		}

	}
}

