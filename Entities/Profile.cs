using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace BudgetBucketsAPI.Entities
{
	public class Profile
	{
		public int Id { get; set; }
		[ForeignKey("User")]
		public int UserId { get; set; }
		public string FirstName { get; set; } = String.Empty;
		public string LastName { get; set; } = String.Empty;
		public string PhoneNumber { get; set; } = String.Empty;
		public string Gender { get; set; } = String.Empty;
	}
}

