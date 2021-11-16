using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ECommerceApp.Models;

namespace ECommerceApp.Services
{
    public interface IProductRepository
    {
        Task<List<Product>> GetAll();

        Task<Product> GetById(int id);
    }
}
