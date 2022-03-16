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
            await _emailService.SendEmailAsync(new Emails.Models.EmailMessage
            {
                Content = "<p> test </p>",
                Subject = "this is a test",
                ToAddress = "alizainaldeen17@gmail.com",
                ToName = "test"
            });

            return Ok();
        }
    }
}