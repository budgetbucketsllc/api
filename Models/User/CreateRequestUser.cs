using System;
using BudgetBucketsAPI.Entities;
using System.ComponentModel.DataAnnotations;

namespace BudgetBucketsAPI.Models.Users
{
    public class CreateRequestUser
    {
        [Required]
        public string EmailAddress { get; set; } = String.Empty;

        [Required]
        public DateTime CreatedAt { get; set; }

        [Required]
        public DateTime UpdatedAt { get; set; }

        [Required]
        [EnumDataType(typeof(Role))]
        public string Role { get; set; } = String.Empty;

        [Required]
        [MinLength(6)]
        public string Password { get; set; } = String.Empty;

        [Required]
        [Compare("Password")]
        public string ConfirmPassword { get; set; } = String.Empty;
    }
}

