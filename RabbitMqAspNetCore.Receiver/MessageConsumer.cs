using MassTransit;
using RabbitMqAspNetCore.Models;

namespace RabbitMqAspNetCore.Receiver;

public class MessageConsumer : IConsumer<Message>
{
    public async Task Consume(ConsumeContext<Message> context)
    {
        Console.WriteLine(context.Message.Text);
        
        await context.RespondAsync(new ResponseModel
        {
            Text = "Success2"
        });
    }
}