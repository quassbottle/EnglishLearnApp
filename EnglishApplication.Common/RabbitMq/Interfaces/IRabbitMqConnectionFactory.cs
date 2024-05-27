using RabbitMQ.Client;

namespace EnglishApplication.Common.RabbitMQ.Interfaces;

public interface IRabbitMqConnectionFactory
{
    ConnectionFactory CreateInstance();
}