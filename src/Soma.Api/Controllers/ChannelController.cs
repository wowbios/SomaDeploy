using MediatR;
using Microsoft.AspNetCore.Mvc;
using Soma.Api.Filters;
using Soma.Domain.Channel;

namespace Soma.Api.Controllers;

[ApiController]
[Route("api/channel")]
public class ChannelController : ControllerBase
{
    private readonly IMediator _mediator;

    public ChannelController(IMediator mediator)
    {
        _mediator = mediator;
    }
    
    [HttpPost("name={name}&project-id={projectId:long}")]
    public async Task<IChannel?> Create(string name, long projectId)
    {
        AddResponse result = await _mediator.Send(new AddRequest(name, projectId));
        return result.Channel;
    }

    [NotFoundExceptionFilter]
    [HttpGet("name={name}")]
    public async Task<IChannel> Get(string name)
    {
        GetResponse result = await _mediator.Send(new GetRequest(name));
        return result.Channel;
    }
}