using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Text;

namespace Receive
{
    class Program
    {
        private static string url = "amqp://kyjsykok:TexnbeNcECKHq7gpRVWCRh3bfXD_j4rV@baboon.rmq.cloudamqp.com/kyjsykok";
        private static string queueName = "task_queue";

        static void Main(string[] args)
        {
            ConnectionFactory factory = new ConnectionFactory();
            factory.Uri = new Uri(url);

            using(var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                channel.QueueDeclare(queue: queueName, durable: true, exclusive: false, autoDelete: false, arguments: null);

                var prop = channel.CreateBasicProperties();
                prop.Persistent = true;

                string message = GetMessage(args);
                var body = Encoding.UTF8.GetBytes(message);

                channel.BasicPublish(exchange: "", routingKey: queueName, basicProperties: prop, body: body);
                Console.WriteLine(" [x] Sent {0}", message);
            }
            

            // Console.WriteLine(" Press [enter] to exit.");
            // Console.ReadLine();
            
        }

        private static string GetMessage(string[] args)
        {
            return ((args.Length > 0) ? string.Join(" ", args) : "Hello World!");
        }
    }
}
