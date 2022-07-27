using System;
using System.Collections.Generic;
using System.Text;

namespace Receive
{
    public interface IReceive
    {
        void Start(string url, string queueName);
    }
}
