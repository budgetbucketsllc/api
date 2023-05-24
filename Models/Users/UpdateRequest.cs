using System;
using BudgetBucketsAPI.Entities;
using System.ComponentModel.DataAnnotations;

namespace BudgetBucketsAPI.Models.Users
{
    public class UpdateRequest
    {

        [EnumDataType(typeof(Role))]
        public string Role { get; set; } = String.Empty;

        [EmailAddress]
        public string EmailAddress { get; set; } = String.Empty;

        public DateTime UpdatedAt { get; set; }

        // treat empty string as null for password fields to 
        // make them optional in front end apps
        private string _password;

        [MinLength(6)]
        public string Password
        {
            get => _password;
            set => _password = replaceEmptyWithNull(value);
        }

        private string _confirmPassword;
        [Compare("Password")]
        public string ConfirmPassword
        {
            get => _confirmPassword;
            set => _confirmPassword = replaceEmptyWithNull(value);
        }

        // helpers

        private string replaceEmptyWithNull(string value)
        {
            // replace empty string with null to make field optional
            return string.IsNullOrEmpty(value) ? null : value;
        }
    }
}

