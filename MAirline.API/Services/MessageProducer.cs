using RabbitMQ.Client;
using System.Text;
using System.Text.Json;

namespace MAirline.API.Services
{
    public class MessageProducer : IMessageProducer
    {
        public async Task SendingMessage<T>(T message)
        {
            var factory = new ConnectionFactory()
            {
                Uri = new Uri("amqps://ibfnxmgi:505o89xyJclBwAjh7--cEwAy17AU6OMk@shrimp.rmq.cloudamqp.com/ibfnxmgi")
            };
            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                channel.QueueDeclare("bookings-queue", durable: true, false, false, null);

                var jsonString = JsonSerializer.Serialize(message);
                var body = Encoding.UTF8.GetBytes(jsonString);
                var properties = channel.CreateBasicProperties();
                properties.Persistent = true;

                channel.BasicPublish(exchange: "", routingKey: "bookings-queue", basicProperties: properties, body: body);
            }
        }
    }
}