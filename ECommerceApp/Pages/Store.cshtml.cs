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
    public class StoreModel : PageModel

    {
        private readonly IProductRepository productRepository;
        private readonly ICartRepository cartRepository;

        public StoreModel(IProductRepository productRepository, ICartRepository cartRepository)
        {
            this.productRepository = productRepository;
            this.cartRepository = cartRepository;
        }

        public Product Product { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Product = await productRepository.GetById(id);

            if (Product == null)
            {
                return NotFound();
            }

            return Page();
        }

        public async Task<IActionResult> OnPost(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            await cartRepository.AddToCart(id.Value, 1);

            return RedirectToAction(nameof(Index));
        }

        public IList<Product> Products { get; set; }

        public async Task OnGetAsync()
        {
            Products = await productRepository.GetAll();
        }
    }

}

