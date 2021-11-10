using System;
using System.ComponentModel.DataAnnotations;

namespace ECommerceApp.Models
{
    public class LoginData
    {
        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
