using EmailProducer.Services;
using Microsoft.AspNetCore.Mvc;

namespace EmailProducer.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmailController : ControllerBase
    {
        private readonly EmailProducerService _producer;

        public EmailController()
        {
            _producer = new EmailProducerService();
        }

        [HttpPost("send")]
        public IActionResult SendEmail()
        {
            _producer.SendEmailMessage("Test email message via RabbitMQ");
            return Ok("Message sent to RabbitMQ");
        }
    }
}
