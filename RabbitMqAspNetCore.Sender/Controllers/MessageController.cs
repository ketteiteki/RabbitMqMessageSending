using MassTransit;
using Microsoft.AspNetCore.Mvc;
using RabbitMqAspNetCore.Models;

namespace RabbitMqAspNetCore.Sender.Controllers;

[Route("api/[controller]")]
[ApiController]
public class MessageController : ControllerBase
{
    private readonly IRequestClient<Message> _client;

    public MessageController(IRequestClient<Message> client)
    {
        _client = client;
    }

    [HttpPost]
    public async Task<IActionResult> SendMessage([FromBody] Message message)
    {
        var response = await _client.GetResponse<ResponseModel>(message);

        return Ok(response.Message);
    }
}