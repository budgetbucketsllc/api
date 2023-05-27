using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace BudgetBucketsAPI.Entities
{
	public class Subcategory
	{
		public int Id {get; set;}
		[ForeignKey("Category")]
		public int CategoryId {get; set;}
		public string Name {get; set;} = String.Empty;
		public decimal AmountPlanned {get; set;}
		public decimal AmountSpent {get; set;}
		[NotMapped]
		public decimal AmountRemaining {get; set;}
		public bool IsFavorite {get; set;}
		public string Note {get; set;} = String.Empty;
		public DateOnly DueDate {get; set;}
	}
}

