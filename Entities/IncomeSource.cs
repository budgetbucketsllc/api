using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace BudgetBucketsAPI.Entities
{
	public class IncomeSource
	{
		public int Id {get; set;}
		[ForeignKey("Income")]
		public int IncomeId {get; set;}
		public string Name {get; set;} = String.Empty;
		public decimal AmountPlanned {get; set;}
		public decimal AmountReceived {get; set;}
		public string Note {get; set;} = String.Empty;
	}
}

