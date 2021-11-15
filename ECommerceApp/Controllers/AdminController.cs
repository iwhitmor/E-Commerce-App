using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ECommerceApp.Models;
using ECommerceApp.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ECommerceApp.Controllers
{
    public class AdminController : Controller
    {
        private readonly ICategoryRepository categoryRepository;
       
        public AdminController(ICategoryRepository categoryRepository)
        {
            this.categoryRepository = categoryRepository;
        }

        public async Task<IActionResult> Index()
        {
            List<Category> categories = await categoryRepository.GetAll();
            return View(categories);

            List<Product> products = await p
        }
    }
}