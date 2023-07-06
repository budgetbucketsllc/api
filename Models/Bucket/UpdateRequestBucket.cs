using System;
namespace BudgetBucketsAPI.Models.Bucket
{
	public class UpdateRequestBucket
	{
		public string Name {get; set;} = String.Empty;
		public decimal AmountTotal {get; set;}
		public string Note {get; set;} = String.Empty;
	}
}

