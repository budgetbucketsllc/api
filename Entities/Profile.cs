﻿using System;
namespace BudgetBucketsAPI.Entities
{
	public class Profile
	{
		public int Id { get; set; }
		public int UserId { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string PhoneNumber { get; set; }
		public string Gender { get; set; }
	}
}

