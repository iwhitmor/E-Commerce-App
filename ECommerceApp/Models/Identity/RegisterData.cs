using System;
using System.ComponentModel.DataAnnotations;

namespace ECommerceApp.Models.Identity
{
    public class RegisterData
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Username { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public bool AcceptedTerms { get; set; }
    }
}
