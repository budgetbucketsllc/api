using System;
using System.Text.Json.Serialization;

namespace BudgetBucketsAPI.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string EmailAddress { get; set; } = String.Empty;
        public string Password { get; set; } = String.Empty;
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public Role Role { get; set; }
    }
}

