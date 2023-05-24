﻿using System;
using BudgetBucketsAPI.Entities;
using Microsoft.EntityFrameworkCore;

namespace BudgetBucketsAPI.Helpers
{
    public class DataContext : DbContext
    {
        protected readonly IConfiguration Configuration;

        public DataContext(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            // in memory database used for simplicity, change to a real db for production applications
            options.UseInMemoryDatabase("TestDb");
        }

        public DbSet<Account> Accounts {get; set;}
        public DbSet<Bucket> Buckets {get; set;}
        public DbSet<Budget> Budgets {get; set;}
        public DbSet<Category> Categories {get; set;}
        public DbSet<CategoryBucket> CategoryBuckets {get; set;}
        public DbSet<CategorySavings> CategorySavings {get; set;}
        public DbSet<Income> Incomes {get; set;}
        public DbSet<IncomeSource> IncomeSources {get; set;}
        public DbSet<Profile> Profiles {get; set;}
        public DbSet<Savings> Savings {get; set;}
        public DbSet<SplitTransaction> SplitTransactions {get; set;}
        public DbSet<Subcategory> Subcategories {get; set;}
        public DbSet<Transaction> Transactions {get; set;}
        public DbSet<User> Users { get; set; }
    }
}

