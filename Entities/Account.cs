using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace BudgetBucketsAPI.Entities
{
	public class Account
	{
		public int Id { get; set; }
		[ForeignKey("User")]
		public int UserId { get; set; }
		public string Name { get; set; } = String.Empty;
		public decimal AmountTotal { get; set; }
		public AccountType Type { get; set; }
	}
}

