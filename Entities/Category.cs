using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace BudgetBucketsAPI.Entities
{
	public class Category
	{
		public int Id {get; set;}
		[ForeignKey("Budget")]
		public int BudgetId {get; set;}
		public string Name {get; set;} = String.Empty;
		public decimal AmountPlanned {get; set;}
		public decimal AmountSpent {get; set;}
		[NotMapped]
		public decimal AmountRemaining {get; set;}
	}
}

