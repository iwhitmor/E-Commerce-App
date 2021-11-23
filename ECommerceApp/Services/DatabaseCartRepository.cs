using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using ECommerceApp.Data;
using ECommerceApp.Models;
using ECommerceApp.Services.Identity;
using Microsoft.EntityFrameworkCore;

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

        public async Task AddToCart(int productId, int qty)
        {

            var userId = userService.GetUserId();

            var cartItem = await _context.CartItems
                .FirstOrDefaultAsync(ci =>
                    ci.UserId == userId &&
                    ci.ProductId == productId);


            if (cartItem == null)
            {
                cartItem = new CartItem
                {
                    UserId = userService.GetUserId(),
                    ProductId = productId,
                    Quantity = qty,
                };

                _context.CartItems.Add(cartItem);
            }
            else
            {
                cartItem.Quantity += qty;
                _context.Entry(cartItem).State = EntityState.Modified;
            }

            await _context.SaveChangesAsync();

        }

        public async Task<int> GetCartQuantity()
        {
            var userId = userService.GetUserId();

            var cartQuantity = await
                _context.CartItems
                    .Where(cq =>
                       cq.UserId == userId)
                    .SumAsync(cq =>
                       cq.Quantity);

            return cartQuantity;
        }

        public async Task<List<CartItem>> ShoppingCart()
        {
            var userId = userService.GetUserId();

            var shoppingCart = await _context.CartItems
                .Where(sc =>
                    sc.UserId == userId)
                .Include(sc =>
                    sc.Product)
                .ThenInclude(sc =>
                    sc.Category)
                .ToListAsync();

            return shoppingCart;
        }

        public async Task UpdatedCartProduct(int productId, int qty)
        {
            var userId = userService.GetUserId();

           // var cartItem = await _context.CartItems
           //.FirstOrDefaultAsync(ci =>
           //    ci.UserId == userId &&
           //    ci.ProductId == productId);

            var updatedCartProduct = await _context.CartItems
                .Where(cp =>
                    cp.UserId == userId)
                .Include(cp =>
                    cp.Product)
                .FirstOrDefaultAsync();

            updatedCartProduct.Quantity += qty;
            _context.Entry(updatedCartProduct).State = EntityState.Modified;

            await _context.SaveChangesAsync();
        }
    }
}
