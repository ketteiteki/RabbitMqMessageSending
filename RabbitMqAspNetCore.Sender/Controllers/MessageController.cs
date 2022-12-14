using MassTransit;
using Microsoft.AspNetCore.Mvc;
using RabbitMqAspNetCore.Models;

namespace RabbitMqAspNetCore.Sender.Controllers;

[Route("api/[controller]")]
[ApiController]
public class MessageController : ControllerBase
{
    IRequestClient<Message> _client;
    
    private readonly IPublishEndpoint _publishEndpoint;

    public MessageController(IPublishEndpoint publishEndpoint, IRequestClient<Message> client)
    {
        _publishEndpoint = publishEndpoint;
        _client = client;
    }

    [HttpPost]
    public async Task<IActionResult> SendMessage([FromBody] Message message)
    {
        var response = await _client.GetResponse<ResponseModel>(message);

        return Ok(response.Message);
    }
}