using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ECommerceApp.Models;
using ECommerceApp.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ECommerceApp.Pages
{
    public class ShoppingCartModel : PageModel
    {
        private readonly ICartRepository cartRepository;

        public ShoppingCartModel(ICartRepository cartRepository)
        {
            this.cartRepository = cartRepository;
        }

        public List<CartItem> CartItems { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            CartItems = await cartRepository.ShoppingCart();

            return Page();
        }

        public async Task<IActionResult> OnPost(int productId, int qty)
        {
            await cartRepository.UpdatedCartProduct(productId, qty);

            return Page();
        }
    }
}
