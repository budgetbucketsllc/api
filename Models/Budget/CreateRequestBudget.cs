using System;
using System.ComponentModel.DataAnnotations;

namespace BudgetBucketsAPI.Models.Budget
{
	public class CreateRequestBudget
	{
		[Required]
		public DateOnly Timeframe { get; set; }
	}
}

