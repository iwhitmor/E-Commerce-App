using System;
using Microsoft.EntityFrameworkCore;

namespace ECommerceApp.Data
{
    public class ECommerceDbContext : DbContext
    {
        public ECommerceDbContext(DbContextOptions options) : base(options)
        {
        }
    }
}
