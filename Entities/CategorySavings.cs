using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace BudgetBucketsAPI.Entities
{
	public class CategorySavings
	{
		public int Id {get; set;}
		[ForeignKey("Budget")]
		public int BudgetId {get; set;}
        [ForeignKey("Account")]
        public int AccountId {get; set;}
		public string Name {get; set;} = String.Empty;
		public int AmountPlanned {get; set;}
		public int AmountSpent {get; set;}
		[NotMapped]
		public int AmountRemaining {get; set;}
	}
}

