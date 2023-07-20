using System;
using AutoMapper;
using BudgetBucketsAPI.Entities;
using BudgetBucketsAPI.Helpers;
using BudgetBucketsAPI.Models.Bucket;

namespace BudgetBucketsAPI.Services.EntityServices
{
    public interface IBucketService
    {
        IEnumerable<Bucket> GetAll();
        Bucket GetById(int id);
        List<Bucket> GetALlBucketsByAccountId(int accountId);
        void Create(CreateRequestBucket model, int accountId);
        void Update(UpdateRequestBucket model, int id, int accountId);
        void Delete(int id);
        void AddIncome(int id, decimal amount);
        void AddExpense(int id, decimal amount);
        String GetBucketName(int id);
    }

    public class BucketService : IBucketService
    {
        private DataContext _context;
        private readonly IMapper _mapper;

        public BucketService(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public IEnumerable<Bucket> GetAll()
        {
            return _context.Buckets;
        }

        public Bucket GetById(int id)
        {
            return getBucket(id);
        }

        public List<Bucket> GetALlBucketsByAccountId(int accountId)
        {
            return getBucketsByAccountId(accountId);
        }

        public void Create(CreateRequestBucket model, int accountId)
        {
            if (checkIfNotSavingsAccount(accountId) == true ) throw new InvalidDataException("Buckets can only be created for Savings accounts");

            Bucket bucket = _mapper.Map<Bucket>(model);
            bucket.AccountId = accountId;

            if (checkOverLimit(bucket.AmountTotal, accountId) == false) throw new InvalidDataException("Amount of bucket is over remaining unsorted account total");

            _context.Buckets.Add(bucket);

            _context.SaveChanges();
        }

        public void Update(UpdateRequestBucket model, int id, int accountId)
        {
            if (checkIfNotSavingsAccount(accountId) == true ) throw new InvalidDataException("Buckets can only be created for Savings accounts");
            
            Bucket bucket = getBucket(id);

            _mapper.Map(model, bucket);
            bucket.AccountId = accountId;

            if (checkOverLimit(bucket.AmountTotal, accountId) == false) throw new InvalidDataException("Amount of bucket is over remaining unsorted account total");
            
            _context.Buckets.Update(bucket);

            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            Bucket bucket = getBucket(id);
            _context.Buckets.Remove(bucket);
            _context.SaveChanges();
        }

        private Boolean checkIfNotSavingsAccount(int accountId) {
            return _context.Accounts.Find(accountId)?.Type != AccountType.Savings;
        }

        private Boolean checkOverLimit(decimal amount, int accountId) {
            decimal? accountAmount = _context.Accounts.Find(accountId)?.AmountTotal;
            decimal? amountUsed = getBucketsByAccountId(accountId).Select(a => accountAmount).Sum();
            decimal? accountRemaining = accountAmount - amountUsed;
            if (accountRemaining == null) {
                return false;
            }
            if (amount > accountRemaining) {
                return false;
            }
            return true;
        }

        private List<Bucket> getBucketsByAccountId(int accountId)
        {
            List<Bucket> buckets = _context.Buckets.Where(bucket => bucket.AccountId == accountId).ToList();
            if (buckets == null) throw new KeyNotFoundException("Buckets not found");
            return buckets;
        }

        private Bucket getBucket(int id)
        {
            Bucket? bucket = _context.Buckets.Find(id);
            if (bucket == null) throw new KeyNotFoundException("Bucket not found");
            return bucket;
        }

        public void AddIncome(int id, decimal amount)
        {
            Bucket bucket = getBucket(id);

            bucket.AmountTotal += amount;

            _context.Buckets.Update(bucket);

            _context.SaveChanges();
        }

        public void AddExpense(int id, decimal amount)
        {
            Bucket bucket = getBucket(id);

            decimal newTotal = bucket.AmountTotal - amount; 
            if (newTotal < 0) {
                newTotal = 0;
            }
            bucket.AmountTotal = newTotal;
            _context.Buckets.Update(bucket);
            _context.SaveChanges();
        }

        public string GetBucketName(int id)
        {
            return getBucket(id).Name;
        }
    }
}