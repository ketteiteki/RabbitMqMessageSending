using MassTransit;
using Microsoft.AspNetCore.Mvc;
using RabbitMqAspNetCore.Models;

namespace RabbitMqAspNetCore.Sender.Controllers;

[Route("api/[controller]")]
[ApiController]
public class MessageController : ControllerBase
{
    private readonly IPublishEndpoint _publishEndpoint;

    public MessageController(IPublishEndpoint publishEndpoint)
    {
        _publishEndpoint = publishEndpoint;
    }

    [HttpPost]
    public async Task<IActionResult> SendMessage([FromBody] Message message)
    {
        await _publishEndpoint.Publish(message);

        return Ok();
    }
}