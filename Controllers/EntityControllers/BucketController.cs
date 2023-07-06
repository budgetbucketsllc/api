using System;
using AutoMapper;
using BudgetBucketsAPI.Models.Bucket;
using BudgetBucketsAPI.Services.EntityServices;
using Microsoft.AspNetCore.Mvc;

namespace BudgetBucketsAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BucketController : ControllerBase
    {
        private IBucketService _bucketService;
        private IMapper _mapper;
        public BucketController(IBucketService bucketService, IMapper mapper)
        {
            _bucketService = bucketService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var buckets = _bucketService.GetAll();
            return Ok(buckets);
        }

        [HttpGet("id/{id}")]
        public IActionResult GetById(int id)
        {
            var bucket = _bucketService.GetById(id);
            return Ok(bucket);
        }

        [HttpGet("accountid/{accountid}")]
        public IActionResult GetBucketsByAccountId(int accountId)
        {
            var buckets = _bucketService.GetALlBucketsByAccountId(accountId);
            return Ok(buckets);
        }

        [HttpPost]
        public IActionResult Create(CreateRequestBucket model, int accountId)
        {
            _bucketService.Create(model, accountId);
            return Ok(new {message = $"{model.Name} bucket created"});
        }

        [HttpPatch("update/{id}/{accountid}")]
        public IActionResult Update(UpdateRequestBucket model, int id, int accountId)
        {
            _bucketService.Update(model, id, accountId);
            string name = _bucketService.GetBucketName(id);
            return Ok(new {message = $"{name} bucket updated"});
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _bucketService.Delete(id);
            string name = _bucketService.GetBucketName(id);
            return Ok(new {message = $"{name} bucket deleted"});
        }

        [HttpPatch("addIncome/{id}/{amount}")]
        public IActionResult AddIncome(int id, decimal amount)
        {
            _bucketService.AddIncome(id, amount);
            string name = _bucketService.GetBucketName(id);
            return Ok(new {message = $"${amount} added to {name} bucket"});

        }
        [HttpPatch("addExpense/{id}/{amount}")]
        public IActionResult AddExpense(int id, decimal amount)
        {
            _bucketService.AddExpense(id, amount);
            string name = _bucketService.GetBucketName(id);
            return Ok(new {message = $"${amount} subtracted from the {name} bucket"});
        }
    }
}