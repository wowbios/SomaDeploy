using MediatR;
using Microsoft.AspNetCore.Mvc;
using Soma.Domain.Project;

namespace Soma.Api.Controllers;

[ApiController]
[Route("api/project")]
public class ProjectController : ControllerBase
{
    private readonly IMediator _mediator;

    public ProjectController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("id={id:long}")]
    public async Task<IProject> Get(long id)
    {
        GetResponse result = await _mediator.Send(new GetRequest(id));
        return result.Project;
    }

    [HttpPost("name={name}")]
    public async Task<IProject> Create(string name)
    {
        AddResponse result = await _mediator.Send(new AddRequest(name));
        return result.Project;
    }
}