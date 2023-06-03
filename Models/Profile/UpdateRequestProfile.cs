using System;
namespace BudgetBucketsAPI.Models.Profile
{
	public class UpdateRequestProfile
	{
        public string FirstName { get; set; } = String.Empty;
        public string LastName { get; set; } = String.Empty;
        public string PhoneNumber { get; set; } = String.Empty;
        public string Gender { get; set; } = String.Empty;
    }
}

