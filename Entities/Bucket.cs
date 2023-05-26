using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace BudgetBucketsAPI.Entities
{
	public class Bucket
	{
		public int Id {get; set;}
		[ForeignKey("Account")]
		public int AccountId {get; set;}
		public string Name {get; set;} = String.Empty;
		public int AmountTotal {get; set;}
		public string Note {get; set;} = String.Empty;
	}
}

