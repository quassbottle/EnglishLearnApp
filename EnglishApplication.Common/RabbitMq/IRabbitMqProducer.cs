namespace EnglishApplication.Common.RabbitMQ;

public interface IRabbitMqProducer
{
    void SendTextMessage(string msg, string exchange = "", string routingKey = "");
    Task<string> CallRpcAsync(string msg);
}