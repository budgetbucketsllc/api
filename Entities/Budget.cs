using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace BudgetBucketsAPI.Entities
{
	public class Budget
	{
		public int Id {get; set;}
		[ForeignKey("User")]
		public int UserId {get; set;}
		public DateTime Timeframe {get; set;}
	}
}

