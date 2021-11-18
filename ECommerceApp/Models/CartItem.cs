using System;
using ECommerceApp.Models.Identity;
using Microsoft.AspNetCore.Identity;

namespace ECommerceApp.Models
{
    public class CartItem
    {
        public int ProductId { get; set; }

        public string UserId { get; set; }

        public int Quantity { get; set; }


        //Foreign Keys
        public Product Product { get; set; }

        public IdentityUser User { get; set; }
    }
}
