using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceApp.Components
{
    public class CartCount : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View();
        }
    }
}
