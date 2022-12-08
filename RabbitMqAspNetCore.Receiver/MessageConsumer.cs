using MassTransit;
using RabbitMqAspNetCore.Models;

namespace RabbitMqAspNetCore.Receiver;

public class MessageConsumer : IConsumer<Message>
{
    public Task Consume(ConsumeContext<Message> context)
    {
        Console.WriteLine(context.Message.Text);
        
        return Task.CompletedTask;
    }
}