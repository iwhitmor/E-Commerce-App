using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using ECommerceApp.Models;

namespace ECommerceApp.Services
{
    public interface ICartRepository
    {
        Task AddToCart(int productId, int qty);

        Task<int> GetCartQuantity();
    }
}
