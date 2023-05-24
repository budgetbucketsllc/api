using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace BudgetBucketsAPI.Entities
{
	public class Transaction
	{
		public int Id {get; set;}
		[ForeignKey("Account")]
		public int AccountId {get; set;}
		public TransactionType Type {get; set;}
		public DateTime Timeframe {get; set;}
		public int TotalAmount {get; set;}
		public string Merchant {get; set;} = String.Empty;
		public string Note {get; set;} = String.Empty;
	}
}

