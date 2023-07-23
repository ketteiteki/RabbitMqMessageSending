using MassTransit;
using Microsoft.AspNetCore.Mvc;
using RabbitMqAspNetCore.Models;

namespace RabbitMqAspNetCore.Sender.Controllers;

[Route("api")]
[ApiController]
public class RootController : ControllerBase
{
    private readonly IPublishEndpoint _client;

    public RootController(IPublishEndpoint client)
    {
        _client = client;
    }

    [HttpPost("transactionCreatedEvent")]
    public IActionResult SendTransactionCreatedEvent([FromBody] TransactionCreatedEvent transactionCreatedEvent)
    {
        _client.Publish(transactionCreatedEvent);

        return Ok();
    }
    
    [HttpPost("userCreatedEvent")]
    public IActionResult SendUserCreatedEvent([FromBody] UserCreatedEvent userCreatedEventModel)
    {
        _client.Publish(userCreatedEventModel);

        return Ok();
    }
}