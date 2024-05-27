using System.Collections.Concurrent;
using System.Text;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace EnglishApplication.Common.RabbitMQ;

public class RpcClient : IDisposable
{
    private readonly ConcurrentDictionary<string, TaskCompletionSource<string>> _callbackMapper = new();

    private readonly IModel _channel;
    private readonly string _replyQueueName;
    private readonly string RABBIT_RPC_QUEUE;

    public RpcClient(string rpcCallQueue, IConnection connection)
    {
        RABBIT_RPC_QUEUE = rpcCallQueue;
        _channel = connection.CreateModel();
        // declare a server-named queue
        _replyQueueName = _channel.QueueDeclare().QueueName;
        var consumer = new EventingBasicConsumer(_channel);
        consumer.Received += (model, ea) =>
        {
            if (!_callbackMapper.TryRemove(ea.BasicProperties.CorrelationId, out var tcs))
                return;
            var body = ea.Body.ToArray();
            var response = Encoding.UTF8.GetString(body);
            tcs.TrySetResult(response);
        };

        _channel.BasicConsume(consumer: consumer,
            queue: _replyQueueName,
            autoAck: true);
    }

    public void Dispose()
    {
    }

    public Task<string> CallAsync(string message, CancellationToken cancellationToken = default)
    {
        var props = _channel.CreateBasicProperties();
        var correlationId = Guid.NewGuid().ToString();
        props.CorrelationId = correlationId;
        props.ReplyTo = _replyQueueName;
        var messageBytes = Encoding.UTF8.GetBytes(message);
        var tcs = new TaskCompletionSource<string>();
        _callbackMapper.TryAdd(correlationId, tcs);

        _channel.BasicPublish(string.Empty,
            RABBIT_RPC_QUEUE,
            props,
            messageBytes);

        cancellationToken.Register(() => _callbackMapper.TryRemove(correlationId, out _));
        return tcs.Task;
    }
}