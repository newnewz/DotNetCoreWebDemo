using KafkaConsumer.Consumers;
using System;

namespace KafkaConsumer
{
    class Program
    {
        static void Main(string[] args)
        {
            var testTopicConsumer = new KafkaTopicConsumer("test");
            testTopicConsumer.Listen(Console.WriteLine);
        }
    }
}
