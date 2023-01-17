using MediatR;
using Microsoft.AspNetCore.Mvc;
using Soma.Api.Filters;
using Soma.Domain.AppChannel;

namespace Soma.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class AppChannelController : ControllerBase
{
    private readonly IMediator _mediator;

    public AppChannelController(IMediator mediator)
    {
        _mediator = mediator;
    }
    
    [HttpPost("/name={name}")]
    public async Task<IAppChannel?> Create(string name)
    {
        AddResponse result = await _mediator.Send(new AddRequest(name));
        return result.Channel;
    }

    [NotFoundExceptionFilter]
    [HttpGet("/name={name}")]
    public async Task<IAppChannel> Get(string name)
    {
        GetResponse result = await _mediator.Send(new GetRequest(name));
        return result.Channel;
    }
}