using System;
using System.Collections.Generic;
using System.Text;

namespace KafkaData.Interfaces
{
    interface ITopicConsumer
    {
        void Listen(Action<string> message);
    }
}
