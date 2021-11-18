using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ECommerceApp.Models;
using ECommerceApp.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ECommerceApp.Pages
{
    public class ProductModel : PageModel
    {
        private readonly IProductRepository productRepository;
        private readonly ICartRepository cartRepository;

        public ProductModel(IProductRepository productRepository, ICartRepository cartRepository)
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

        public CartItem CartItem { get; set; }

        //public async Task<IActionResult> OnPost(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    await cartRepository.AddToCart(id.Value);

        //    return RedirectToAction(nameof(Index));
        //}
    }
    }