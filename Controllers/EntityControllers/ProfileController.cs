using System;
using AutoMapper;
using BudgetBucketsAPI.Services.EntityServices;
using BudgetBucketsAPI.Models.Profile;
using Microsoft.AspNetCore.Mvc;

namespace BudgetBucketsAPI.Controllers
{
	[ApiController]
    [Route("[controller]")]
    public class ProfileController : ControllerBase
	{
		private IProfileService _profileSerivce;
		private IMapper _mapper;

		public ProfileController(
			IProfileService profileService,
			IMapper mapper)
		{
			_profileSerivce = profileService;
			_mapper = mapper;
		}

		[HttpGet]
		public IActionResult GetAll()
		{
			var profiles = _profileSerivce.GetAll();
			return Ok(profiles);
		}

		[HttpGet("id/{id}")]
		public IActionResult GetById(int id)
		{
			var profile = _profileSerivce.GetById(id);
			return Ok(profile);
		}

		[HttpGet("userid/{userid}")]
		public IActionResult GetProfileByUserId(int userid)
		{
			var profile = _profileSerivce.GetProfileByUserId(userid);
			return Ok(profile);
		}

		[HttpPost]
		public IActionResult Create(CreateRequestProfile model, int userid)
		{
			_profileSerivce.Create(model, userid);
			return Ok(new { message = "Profile created" });
		}

		[HttpPatch("update/{userid}/{id}")]
		public IActionResult Update(int userid, int id, UpdateRequestProfile model)
		{
			_profileSerivce.Update(userid, id, model);
			return Ok(new { message = "Profile updated" });
		}

		[HttpDelete("{id}")]
		public IActionResult Delete(int id)
		{
			_profileSerivce.Delete(id);
			return Ok(new { message = "Profile deleted" });
		}

	}
}

