using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceApp.Controllers
{
    public class AdministratorController : Controller
    {
       public IActionResult Index()
        {
            return View();
        }
    }
}