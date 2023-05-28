using System;
using System.ComponentModel.DataAnnotations;

namespace BudgetBucketsAPI.Models.Profile
{
	public class CreateRequestProfile
	{
		[Required]
		public string FirstName { get; set; } = String.Empty;

		[Required]
		public string LastName { get; set; } = String.Empty;

        [Required]
        public string PhoneNumber { get; set; } = String.Empty;

        [Required]
        public string Gender { get; set; } = String.Empty;
    }
}

