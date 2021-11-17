using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ECommerceApp.Models;

namespace ECommerceApp.Services
{
    public interface ICartRepository
    {
        Task AddToCart(string userId, int productId);
    }
}
