using System;
using System.ComponentModel.DataAnnotations;
using BudgetBucketsAPI.Entities;

namespace BudgetBucketsAPI.Models.Account
{
	public class CreateRequestAccount
	{
		[Required]
		public string Name { get; set; } = String.Empty;

		[Required]
		public decimal AmountTotal { get; set; }

		[Required]
		[EnumDataType(typeof(AccountType))]
		public string Type { get; set; } = String.Empty;
	}
}

