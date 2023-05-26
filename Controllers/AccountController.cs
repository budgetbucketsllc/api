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

		[HttpGet("id/{id}")]
		public IActionResult GetById(int id)
		{
			var account = _accountService.GetById(id);
			return Ok(account);
		}

		[HttpGet("userid/{userid}")]
		public IActionResult GetAllAccountsByUserId(int userid)
		{
			var accounts = _accountService.GetAllAccountsByUserId(userid);
			return Ok(accounts);
		}

		[HttpPost]
		public IActionResult Create(CreateRequestAccount model, int userid)
		{
			_accountService.Create(model, userid);
			return Ok(new { message = "Account created" });
		}

		[HttpPut("update/{userid}/{id}")]
		public IActionResult Update(int userid, int id, UpdateRequestAccount model)
		{
			_accountService.Update(userid, id, model);
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

