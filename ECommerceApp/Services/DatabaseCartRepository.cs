using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using ECommerceApp.Data;
using ECommerceApp.Models;
using ECommerceApp.Services.Identity;

namespace ECommerceApp.Services
{
    public class DatabaseCartRepository : ICartRepository
    {
        private readonly ECommerceDbContext _context;
        private readonly IUserService userService;

        public DatabaseCartRepository(ECommerceDbContext context, IUserService userService)
        {
            _context = context;
            this.userService = userService;
        }


        public async Task AddToCart(int productId)
        {
            var cartItem = new CartItem
            {
                UserId = userService.GetUserId(),
                ProductId = productId,
            };

            _context.CartItems.Add(cartItem);
            await _context.SaveChangesAsync();
        }
    }
}
