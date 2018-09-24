using KafkaData.Producers;
using System;

namespace KafkaProducerConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter a queue name: ");
            string queueName = Console.ReadLine();
            var topicProducer = new KafkaTopicProducer(queueName);

            Console.WriteLine("Type a message or :q!");
            string message;
            while(!(message = Console.ReadLine()).Equals(":q!"))
            {
                topicProducer.Write(message);
            }
        }
    }
}
