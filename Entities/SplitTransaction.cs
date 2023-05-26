using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace BudgetBucketsAPI.Entities
{
	public class SplitTransaction
	{
		public int Id {get; set;}
		[ForeignKey("Transaction")]
		public int TransactionId {get; set;}
		[ForeignKey("Subcategory")]
		public int SubcategoryId {get; set;}
		[ForeignKey("IncomeSource")]
		public int IncomeSourceId {get; set;}
		[ForeignKey("Bucket")]
		public int BucketId {get; set;}
		[ForeignKey("CategoryBucket")]
		public int CategoryBucketId {get; set;}
		public int SplitAmount {get; set;}
	}
}

