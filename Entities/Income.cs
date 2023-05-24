using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace BudgetBucketsAPI.Entities
{
	public class Income
	{
		public int Id {get; set;}
		[ForeignKey("Budget")]
		public int BudgetId {get; set;}
		public string Name {get; set;} = String.Empty;
		public int AmountPlanned {get; set;}
		public int AmountReceived {get; set;}
		[NotMapped]
		public int AmountRemaining {get; set;}
	}
}

