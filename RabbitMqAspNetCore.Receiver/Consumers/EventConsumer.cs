using MassTransit;
using RabbitMqAspNetCore.Models;

namespace RabbitMqAspNetCore.Receiver.Consumers;

public class EventConsumer : IConsumer<TransactionCreatedEvent>, IConsumer<UserCreatedEvent>
{
    public Task Consume(ConsumeContext<TransactionCreatedEvent> context)
    {
        Console.WriteLine($"TransactionCreatedEvent: {context.Message.TransactionMessage}");

        return Task.CompletedTask;
    }

    public Task Consume(ConsumeContext<UserCreatedEvent> context)
    {
        Console.WriteLine($"UserCreatedEvent: {context.Message.UserMessage}");

        return Task.CompletedTask;
    }
}