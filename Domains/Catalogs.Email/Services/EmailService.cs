using Catalog.Common.Models;
using Catalog.Emails.Configuration;
using Catalog.Emails.Contracts;
using MailKit.Net.Smtp;
using MimeKit;
using MimeKit.Text;

namespace Catalog.Emails.Services
{
    public class EmailService : IEmailService
    {
        #region Properties

        private readonly MailSettings _mailSettings;

        #endregion Properties

        #region Costructor

        public EmailService(MailSettings mailSettings)
        {
            _mailSettings = mailSettings;
        }

        #endregion Costructor

        #region Properties

        public async Task SendEmailAsync(EmailMessage emailMessage)
        {
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress(_mailSettings.DisplayName, _mailSettings.Mail));
            message.To.Add(new MailboxAddress(emailMessage.ToName, emailMessage.ToEmail));
            message.Subject = "New Menu Item!!!";
            message.Body = new TextPart(TextFormat.Html)
            {
                Text = $"<p> New menue item with name {emailMessage.MenuName} has been added"
            };

            using (var emailClient = new SmtpClient())
            {
                //The last parameter here is to use SSL (Which you should!)
                emailClient.Connect(_mailSettings.Host, _mailSettings.Port, true);
                emailClient.AuthenticationMechanisms.Remove("XOAUTH2");
                emailClient.Authenticate(_mailSettings.Mail, _mailSettings.Password);
                emailClient.Send(message);
                emailClient.Disconnect(true);
            }
        }

        #endregion Properties
    }
}