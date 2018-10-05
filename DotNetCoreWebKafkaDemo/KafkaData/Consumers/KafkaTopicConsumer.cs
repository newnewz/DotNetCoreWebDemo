

using Confluent.Kafka;
using Confluent.Kafka.Serialization;
using KafkaData.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace KafkaData.Consumers
{
    public class KafkaTopicConsumer : ITopicConsumer
    {
        string _topicName = "";

        public KafkaTopicConsumer(string topicName)
        {
            _topicName = topicName;
        }

        public void Listen(Action<string> message)
        {
            Dictionary<string, object> config = new Dictionary<string, object>();
            config.Add("bootstrap.servers", "kafkademodata.xzist.net:9092");
            config.Add("group.id", "dotnetconsoleconsumer1");
            config.Add("enable.auto.commit", "false");


            using (var consumer = new Consumer<string, string>(config, new StringDeserializer(Encoding.UTF8), new StringDeserializer(Encoding.UTF8)))
            {
                consumer.Subscribe(_topicName);
                consumer.OnMessage += (key, msg) =>
                {
                    message(msg.Value);
                    consumer.CommitAsync();
                };

                while (true)
                {
                    consumer.Poll(1000);
                }
            }
        }

        public string GetMessage()
        {
            Dictionary<string, object> config = new Dictionary<string, object>();
            config.Add("bootstrap.servers", "kafkademodata.xzist.net:9092");
            config.Add("group.id", "dotnetconsoleconsumer1");
            config.Add("enable.auto.commit", "false");

            using (var consumer = new Consumer<string, string>(config, new StringDeserializer(Encoding.UTF8), new StringDeserializer(Encoding.UTF8)))
            {
                consumer.Subscribe(_topicName);
                Message<string, string> kafkaMessage;
                var msg = consumer.Consume(out kafkaMessage, 100);
                return kafkaMessage.Value;
            }
        }
    }
}
