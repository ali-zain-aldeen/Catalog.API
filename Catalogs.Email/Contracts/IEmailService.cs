using Catalog.Emails.Models;

namespace Catalog.Emails.Contracts
{
    public interface IEmailService
    {
        Task SendEmailAsync(EmailMessage emailMessage);
    }
}
