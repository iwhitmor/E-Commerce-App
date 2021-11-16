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
    public class IndexModel : PageModel
    {
        private readonly ICategoryRepository categoryRepository;
        private readonly IProductRepository productRepository;

        public IndexModel(ICategoryRepository categoryRepository, IProductRepository productRepository)
        {
            this.categoryRepository = categoryRepository;
            this.productRepository = productRepository;
        }

        public IList<Category> Categories { get; set; }
        public IList<Product> Products { get; set; }

        public async Task OnGetAsync()
        {
            Categories = await categoryRepository.GetAll();

            Products = await productRepository.GetAll(); 
        }
    }
}

