using Microsoft.AspNetCore.Identity.UI.Services;

namespace MVC_Project.Services
{
    public class ConsoleEmailSender : IEmailSender
    {
        public Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            // Log the email to the console (for testing purposes)
            System.Console.WriteLine("---Email---");
            System.Console.WriteLine($"To: {email}");
            System.Console.WriteLine($"Subject: {subject}");
            System.Console.WriteLine($"Message: {htmlMessage}");
            System.Console.WriteLine("---");

            return Task.CompletedTask;
        }
    }
}
