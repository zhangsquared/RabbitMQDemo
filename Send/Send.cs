using System;
using RabbitMQ.Client;
using System.Text;

namespace Send
{
    class Program
    {
        private static string url = "amqp://kyjsykok:TexnbeNcECKHq7gpRVWCRh3bfXD_j4rV@baboon.rmq.cloudamqp.com/kyjsykok";
        private static string queueName = "sender_receiver";
 
        static void Main(string[] args)
        {


            Console.WriteLine(" Press [enter] to exit.");
            Console.ReadLine();

        }


    }

    public class Send
    {
        public void Start(string url, string queueName)
        {
            ConnectionFactory factory = new ConnectionFactory();
            factory.Uri = new Uri(url);

            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                channel.QueueDeclare(queue: queueName, durable: false, exclusive: false, autoDelete: false, arguments: null);

                string message = GetMessage(args);
                var body = Encoding.UTF8.GetBytes(message);

                channel.BasicPublish(exchange: "", routingKey: queueName, basicProperties: null, body: body);
                Console.WriteLine(" [x] Sent {0}", message);
            }
        }

        private string GetMessage(string[] args)
        {
            return ((args.Length > 0) ? string.Join(" ", args) : "Hello World!");
        }
    }
}
