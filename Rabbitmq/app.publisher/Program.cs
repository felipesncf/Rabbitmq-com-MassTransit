// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");

using RabbitMQ.Client;
using System.Text;

var factory = new ConnectionFactory()
{
    HostName = "localhost"
};

using (var connection = factory.CreateConnection()) 

using (var channel = connection.CreateModel())
{
    channel.QueueDeclare(queue: "msg_1", durable: false, exclusive: false, autoDelete: true, arguments: null);

    string message = "Testando RabbitMQ";

    var body = Encoding.UTF8.GetBytes(message);

    channel.BasicPublish(exchange: "", routingKey: "msg_1", basicProperties: null, body: body);

    Console.WriteLine($" [x] Enviada: {message}");

    Console.ReadLine();
}
