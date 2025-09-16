using EmailProducer.Services;
using Microsoft.AspNetCore.Mvc;

namespace EmailProducer.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ConsumerController : ControllerBase
    {
        private readonly EmailConsumerService _consumer;

        public ConsumerController()
        {
            _consumer = new EmailConsumerService();
        }

        [HttpGet("start")]
        public IActionResult Start()
        {
            _consumer.StartConsumer();
            return Ok("Consumer started. Check console for received messages.");
        }
    }
}
