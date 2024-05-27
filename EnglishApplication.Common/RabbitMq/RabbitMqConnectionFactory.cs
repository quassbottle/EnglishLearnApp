using EnglishApplication.Common.RabbitMQ.Interfaces;
using RabbitMQ.Client;

namespace EnglishApplication.Common.RabbitMQ;

public class RabbitMqConnectionFactory(IRabbitMqSettings settings): IRabbitMqConnectionFactory
{
    public ConnectionFactory CreateInstance()
    {
        return new ConnectionFactory()
        {
            UserName = settings.User,
            Port = settings.Port,
            Password = settings.Password,
            HostName = settings.Host
        };
    }
}