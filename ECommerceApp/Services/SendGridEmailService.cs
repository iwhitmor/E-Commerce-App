using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace ECommerceApp.Services
{
    public class SendGridEmailService : IEmailService
    {
        private IConfiguration Configuration { get; }

        public SendGridEmailService(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public async Task SendEmail(string toEmail, string subject, string plainTextContent, string htmlContent)
        {
            var apiKey = Configuration["SendGrid:ApiKey"]
                ?? throw new InvalidOperationException("SendGrid:ApiKey not found");

            var client = new SendGridClient(apiKey);

            var from = new EmailAddress("ianwhitmor+golfland@gmail.com");
            //var subject = "Sending with SendGrid is Fun";

            var to = new EmailAddress(toEmail);
            //var plainTextContent = "and easy to do anywhere, even with C#";
            //var htmlContent = "<strong>and easy to do anywhere, even with C#</strong>";

            var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);

            var response = await client.SendEmailAsync(msg);
        }
    }
}
