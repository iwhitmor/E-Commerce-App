using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

        public async Task<List> OnGetAsync()
        {
            shoppingCart = await cartRepository.
        }
    }
}
