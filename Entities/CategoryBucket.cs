using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace BudgetBucketsAPI.Entities
{
	public class CategoryBucket
	{
		public int Id {get; set;}
		[ForeignKey("CategorySavings")]
		public int CategorySavingsId {get; set;}
        [ForeignKey("Bucket")]
        public int BucketId {get; set;}
		public string Name {get; set;} = String.Empty;
		public decimal AmountPlanned {get; set;}
		public decimal AmountSpent {get; set;}
		[NotMapped]
		public decimal AmountRemaining {get; set;}
	}
}

