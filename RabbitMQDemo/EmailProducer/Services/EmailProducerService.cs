using RabbitMQ.Client;
using System.Text;

namespace EmailProducer.Services
{
    public class EmailProducerService
    {
        private readonly string _hostname = "localhost";
        private readonly string _queueName = "emailQueue";

        public void SendEmailMessage(string message)
        {
            var factory = new ConnectionFactory() { HostName = _hostname };
            using var connection = factory.CreateConnection();
            using var channel = connection.CreateModel();

            // Declare the queue
            channel.QueueDeclare(queue: _queueName,
                                 durable: false,
                                 exclusive: false,
                                 autoDelete: false,
                                 arguments: null);

            var body = Encoding.UTF8.GetBytes(message);

            // Publish the message
            channel.BasicPublish(exchange: "",
                                 routingKey: _queueName,
                                 basicProperties: null,
                                 body: body);

            Console.WriteLine($" [x] Sent {message}");
        }
    }
}
