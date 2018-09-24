using KafkaData.Interfaces;
using Confluent.Kafka;
using System.Collections.Generic;
using Confluent.Kafka.Serialization;
using System.Text;

namespace KafkaData.Producers
{
    public class KafkaTopicProducer : ITopicProducer
    {
        string _topicName;

        public KafkaTopicProducer(string topicName)
        {
            _topicName = topicName;
        }

        public void Write(string message)
        {
            Dictionary<string, object> config = new Dictionary<string, object>();
            config.Add("bootstrap.servers", "kafkademodata.xzist.net:9092");

            using (var producer = new Producer<string, string>(config, new StringSerializer(Encoding.UTF8), new StringSerializer(Encoding.UTF8)))
            {
                producer.ProduceAsync(_topicName, null, message).GetAwaiter().GetResult();
                producer.Flush(1000);
            }

        }
    }
}
