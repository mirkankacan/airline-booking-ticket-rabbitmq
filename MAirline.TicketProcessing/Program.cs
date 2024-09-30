// See https://aka.ms/new-console-template for more information
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;

Console.WriteLine("Welcome to MAirline Ticket Service");

var factory = new ConnectionFactory()
{
    Uri = new Uri("amqps://ibfnxmgi:505o89xyJclBwAjh7--cEwAy17AU6OMk@shrimp.rmq.cloudamqp.com/ibfnxmgi")
};

using (var connection = factory.CreateConnection())
using (var channel = connection.CreateModel())
{
    channel.QueueDeclare("bookings-queue", durable: true, false, false, null);
    channel.BasicQos(prefetchSize: 0, prefetchCount: 1, global: false);

    var consumer = new EventingBasicConsumer(channel);
    channel.BasicConsume("bookings-queue", false, consumer);

    consumer.Received += (sender, e) =>
    {
        var body = e.Body.ToArray();
        var message = Encoding.UTF8.GetString(body);
        Console.WriteLine($"New ticket has been created {message}");
        channel.BasicAck(e.DeliveryTag, false);
    };
    Console.ReadKey();
}