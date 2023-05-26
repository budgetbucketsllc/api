using System;
using BudgetBucketsAPI.Entities;
using System.ComponentModel.DataAnnotations;

namespace BudgetBucketsAPI.Models.Account
{
	public class UpdateRequestAccount
	{
		public string Name { get; set; } = String.Empty;

		public int AmountTotal { get; set; }

		[EnumDataType(typeof(AccountType))]
		public string Type { get; set; } = String.Empty;
	}
}

