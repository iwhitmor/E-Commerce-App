using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ECommerceApp.Data;
using ECommerceApp.Models;
using Microsoft.EntityFrameworkCore;

namespace ECommerceApp.Services
{
    public class DatabaseCategoryRepository : ICategoryRepository
    {
        private readonly ECommerceDbContext _context;

        public DatabaseCategoryRepository(ECommerceDbContext context)
        {
            _context = context;
        }

        public async Task<List<Category>> GetAll()
        {
            return await _context.Categories.ToListAsync();
        }

        public async Task<Category> GetById(int? id)
        {
            return await _context.Categories
                .FirstOrDefaultAsync(m => m.Id == id);
        }
    }
}