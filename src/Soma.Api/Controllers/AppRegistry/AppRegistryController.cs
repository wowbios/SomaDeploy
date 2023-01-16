using System.Buffers;
using System.IO.Pipelines;
using System.Net;
using System.Net.Mime;
using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Soma.Domain.Modules.AppRegistry;
using Soma.Domain.Modules.AppRegistry.Add;
using Soma.Domain.Modules.AppRegistry.Get;
using Soma.Domain.Modules.AppRegistry.GetFile;

namespace Soma.Api.Controllers.AppRegistry;

[ApiController]
[Route("[controller]")]
public class AppRegistryController : ControllerBase
{
    private readonly IMediator _mediator;

    public AppRegistryController(IMediator mediator)
    {
        _mediator = mediator;
    }
    
    [HttpGet("/{id:long}")]
    public async Task<object> Get(long id)
    {
        GetResponse result = await _mediator.Send(new GetRequest(id));
        return new
        {
            result.Name,
            result.Version
        };
    }

    [HttpGet("/file/{id:long}")]
    public async Task<FileContentResult> GetFile(long id)
    {
        var info = await _mediator.Send(new GetRequest(id));
        var result = await _mediator.Send(new GetFileRequest(id));

        return File(result.Content, "application/octet-stream", info.Name);
    }

    [HttpPost("/name={name}&version={version}")]
    public async Task<IAppVersion> Create(string name, string version, IFormFile file)
    {
        await using Stream fileStream = file.OpenReadStream();
        using StreamContent reader = new (fileStream, 4096);
        byte[] content = await reader.ReadAsByteArrayAsync();

        AddResponse result = await _mediator.Send(new AddRequest(name, version, content));
        return result.AppVersion;
    }
}