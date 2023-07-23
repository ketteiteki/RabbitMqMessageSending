namespace RabbitMqAspNetCore.Models;

public class TransactionCreatedEvent : IEvent
{
    public string TransactionMessage { get; set; }
}