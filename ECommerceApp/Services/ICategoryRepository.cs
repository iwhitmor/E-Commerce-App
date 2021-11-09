using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ECommerceApp.Models;

namespace ECommerceApp.Services
{
    public class ICategoryRepository
    {
        Task<List<Category>> GetAll();

        Task<List<Category>> GetNew(int count);
    }
}
