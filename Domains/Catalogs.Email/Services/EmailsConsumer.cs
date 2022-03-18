using Catalog.Common.Models;
using Catalog.Emails.Contracts;
using MassTransit;

namespace Catalog.Emails.Services
{
    public class EmailsConsumer : IConsumer<EmailMessage>
    {
        #region Properties

        private readonly IEmailService _emailService;

        #endregion Properties

        #region Constructor

        public EmailsConsumer(IEmailService emailService)
        {
            _emailService = emailService;
        }

        #endregion Constructor

        #region Methods

        public async Task Consume(ConsumeContext<EmailMessage> context)
        {
            var data = context.Message;

            await _emailService.SendEmailAsync(data);
        }

        #endregion Methods
    }
}