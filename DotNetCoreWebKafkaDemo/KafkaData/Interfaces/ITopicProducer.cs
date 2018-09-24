

namespace KafkaData.Interfaces
{
    public interface ITopicProducer
    {
        void Write(string message);
    }
}
