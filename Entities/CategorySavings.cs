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
		public decimal AmountPlanned {get; set;}
		public decimal AmountReceived {get; set;}
		[NotMapped]
		public decimal LeftToReceive {get; set;}
	}
}

