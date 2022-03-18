using Catalog.Common.Models;
using Catalog.Emails.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace Catalog.Email.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmailsTestController : ControllerBase
    {
        private readonly IEmailService _emailService;

        public EmailsTestController(IEmailService emailService)
        {
            _emailService = emailService;
        }

        [HttpGet]
        public async Task<IActionResult> Test()
        {
            await _emailService.SendEmailAsync(new EmailMessage
            {
                MenuName = "test",
                ToName = "ali",
                ToEmail = "alizainaldeen17@gmail.com"
            });

            return Ok();
        }
    }
}