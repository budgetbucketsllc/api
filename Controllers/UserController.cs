﻿using AutoMapper;
using BudgetBucketsAPI.Models.Users;
using BudgetBucketsAPI.Services.EntityServices;
using Microsoft.AspNetCore.Mvc;

namespace BudgetBucketsAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private IUserService _userService;
        private IMapper _mapper;

        public UserController(
            IUserService userService,
            IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var users = _userService.GetAll();
            return Ok(users);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var user = _userService.GetById(id);
            return Ok(user);
        }

        [HttpPost]
        public IActionResult Create(CreateRequestUser model)
        {
            _userService.Create(model);
            return Ok(new { message = "User created" });
        }

        [HttpPatch("{id}")]
        public IActionResult Update(int id, UpdateRequestUser model)
        {
            _userService.Update(id, model);
            return Ok(new { message = "User updated" });
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _userService.Delete(id);
            return Ok(new { message = "User deleted" });
        }
    }
}