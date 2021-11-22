using System;
using System.Threading.Tasks;
using ECommerceApp.Services;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceApp.Components
{
    public class CartCount : ViewComponent
    {
        private readonly ICartRepository cartRepository;

        public CartCount(ICartRepository cartRepository)
        {
            this.cartRepository = cartRepository;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            int cartQuantity = await cartRepository.GetCartQuantity();
            return View(cartQuantity);
        }
    }
}
