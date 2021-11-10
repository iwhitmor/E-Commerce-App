using System;
using System.ComponentModel.DataAnnotations;

namespace ECommerceApp.Models.Identity
{
    public class LoginData
    {
        [Required]
        public string Username { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
