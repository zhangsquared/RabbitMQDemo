using System;
using System.Collections.Generic;
using System.Text;

namespace Receive
{
    class program
    {
        private static string url = "amqp://kyjsykok:TexnbeNcECKHq7gpRVWCRh3bfXD_j4rV@baboon.rmq.cloudamqp.com/kyjsykok";
        private static string queueName = "sender_receiver";

        static void Main(string[] args)
        {
            IReceive receive = new Worker();
            receive.Start(url, queueName);
        }
    }
}
