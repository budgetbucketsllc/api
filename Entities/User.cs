using System;
using System.Text.Json.Serialization;

namespace BudgetBucketsAPI.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string EmailAddress { get; set; }
        public string Password { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public Role Role { get; set; }

    }
}

