﻿using KafkaData.Consumers;
using System;
using System.Collections.Generic;
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
            var testTopicConsumer = new KafkaTopicConsumer("test");
            testTopicConsumer.Listen(PostToApi);
        }

        static void PostToApi(string message)
        {

            Console.WriteLine(message);
            var response = client.PostAsync("https://localhost:5001/comments/newMessage", new StringContent("\"" +message + "\"", Encoding.UTF8, "application/json"));
            
        }
    }
}
