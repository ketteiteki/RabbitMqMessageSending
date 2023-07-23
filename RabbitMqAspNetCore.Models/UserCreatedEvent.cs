namespace RabbitMqAspNetCore.Models;

public class UserCreatedEvent : IEvent
{
    public string UserMessage { get; set; }
}