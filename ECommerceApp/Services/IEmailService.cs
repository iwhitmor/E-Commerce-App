using System;
namespace ECommerceApp.Services
{
    public interface IEmailService
    {
        Task SendEmail(string to, string subject, string bodyHtml);
    }
}
