using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ECommerceApp.Data;
using ECommerceApp.Models;

namespace ECommerceApp.Services
{
    public class DatabaseCartRepository : ICartRepository
    {
        private readonly ECommerceDbContext _context;

        public DatabaseCartRepository(ECommerceDbContext context)
        {
            _context = context;
        }

        public async Task AddToCart(string userId, int productId)
        {
            var cartItem = new CartItem
            {
                UserId = userId,
                ProductId = productId,
            };

            _context.CartItems.Add(cartItem);
            await _context.SaveChangesAsync();
        }
    }
}
