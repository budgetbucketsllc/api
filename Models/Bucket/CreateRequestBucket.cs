using System;
using System.ComponentModel.DataAnnotations;

namespace BudgetBucketsAPI.Models.Bucket
{
	public class CreateRequestBucket
	{
        [Required]
		public string Name {get; set;} = String.Empty;
        [Required]
		public decimal AmountTotal {get; set;}
        [Required]
		public string Note {get; set;} = String.Empty;
	}
}

