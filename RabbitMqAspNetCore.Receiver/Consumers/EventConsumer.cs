using MassTransit;
using RabbitMqAspNetCore.Models;

namespace RabbitMqAspNetCore.Receiver.Consumers;

public class EventConsumer : IConsumer<IEvent>
{
    public Task Consume(ConsumeContext<IEvent> context)
    {
        if (context.TryGetMessage<TransactionCreatedEvent>(out var transactionCreatedEventContext))
        {
            Console.WriteLine($"TransactionCreatedEvent: {transactionCreatedEventContext.Message.TransactionMessage}");
        }
        else if (context.TryGetMessage<UserCreatedEvent>(out var userCreatedEventContext))
        {
            Console.WriteLine($"UserCreatedEvent: {userCreatedEventContext.Message.UserMessage}");
        }

        return Task.CompletedTask;
    }
}