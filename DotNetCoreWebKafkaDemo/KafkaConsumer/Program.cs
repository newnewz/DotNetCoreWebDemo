using KafkaConsumer.Consumers;
using System;

namespace KafkaConsumer
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(System.Runtime.InteropServices.RuntimeInformation.OSDescription);
            Console.WriteLine(System.Runtime.InteropServices.RuntimeInformation.FrameworkDescription);
            var testTopicConsumer = new KafkaTopicConsumer("test");
            testTopicConsumer.Listen(Console.WriteLine);
        }
    }
}
