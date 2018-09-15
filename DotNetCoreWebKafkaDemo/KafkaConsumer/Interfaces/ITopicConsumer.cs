using System;
using System.Collections.Generic;
using System.Text;

namespace KafkaConsumer.Interfaces
{
    interface ITopicConsumer
    {
        void Listen(Action<string> message);
    }
}
