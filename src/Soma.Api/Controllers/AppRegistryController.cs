using MediatR;
using Microsoft.AspNetCore.Mvc;
using Soma.Api.Extensions;
using Soma.Api.Filters;
using Soma.Domain.AppRegistry;

namespace Soma.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class AppRegistryController : ControllerBase
{
    private readonly IMediator _mediator;

    public AppRegistryController(IMediator mediator)
    {
        _mediator = mediator;
    }
    
    [NotFoundExceptionFilter]
    [HttpGet("/{id:long}")]
    public async Task<IAppVersion> Get(long id)
    {
        GetResponse result = await _mediator.Send(new GetRequest(id));
        return result.AppVersion;
    }

    [NotFoundExceptionFilter]
    [HttpGet("/file/{id:long}")]
    public async Task<FileContentResult> GetFile(long id)
    {
        GetFileResponse result = await _mediator.Send(new GetFileRequest(id));
        return File(result.File.Content, "application/octet-stream", result.File.Name);
    }

    [HttpPost("/channel-id={channelId:long}&name={name}&version={version}")]
    public async Task<IAppVersion> Create(long channelId, string name, string version, IFormFile file)
    {
        (string fileName, byte[] fileContent) = await file.GetFile();

        AddResponse result = await _mediator.Send(new AddRequest(channelId, name, version, fileName, fileContent));
        return result.AppVersion;
    }
}