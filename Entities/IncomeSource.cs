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
		public int AmountPlanned {get; set;}
		public int AmountReceived {get; set;}
		public int AmountRemaining {get; set;}
		public string Note {get; set;} = String.Empty;
	}
}

