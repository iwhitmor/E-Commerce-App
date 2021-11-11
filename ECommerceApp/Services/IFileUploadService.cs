using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace ECommerceApp.Services
{
    public interface IFileUploadService
    {
        Task<string> Upload(IFormFile productImage);
    }
}
