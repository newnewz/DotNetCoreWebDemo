using KafkaData.Consumers;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;

namespace KafkaConsumer
{
    class Program
    {
        private static readonly HttpClient client = new HttpClient();

        static void Main(string[] args)
        {
            Console.WriteLine(System.Runtime.InteropServices.RuntimeInformation.OSDescription);
            Console.WriteLine(System.Runtime.InteropServices.RuntimeInformation.FrameworkDescription);
            Console.WriteLine($"Listening on topic : {args[1]}");
            var testTopicConsumer = new KafkaTopicConsumer(args[1]);
            testTopicConsumer.Listen(PostToApi);
        }

        static async void PostToApi(string message)
        {

            Console.WriteLine(message);
            
            var response = await client.PostAsync("http://localhost:28123/comments/newMessage", new StringContent("\"" +message + "\"", Encoding.UTF8, "application/json"));

            Console.WriteLine(await response.Content.ReadAsStringAsync());
        }
    }
}
