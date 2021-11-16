using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ECommerceApp.Models;
using ECommerceApp.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ECommerceApp.Controllers
{
    [Authorize(Roles = "Administrator, Editor")]
    public class AdminController : Controller
    {
        private readonly ICategoryRepository categoryRepository;
        private readonly IProductRepository productRepository;

        public AdminController(ICategoryRepository categoryRepository, IProductRepository productRepository)
        {
            this.categoryRepository = categoryRepository;
            this.productRepository = productRepository;
        }

        public async Task<IActionResult> Index()
        {
            List<Category> categories = await categoryRepository.GetAll();
            List<Product> products = await productRepository.GetAll();

            var model = new AdminIndexViewModel
            {
                Categories = categories,
                Products = products,
            };

            return View(model);
        }
    }
}