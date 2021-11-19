using System.Threading.Tasks;

namespace ECommerceApp.Services
{
    public interface IEmailService
    {
        Task SendEmail(string to, string subject, string bodyPlain, string bodyHtml);
    }
}
