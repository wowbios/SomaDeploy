using MediatR;
using Soma.Domain.AppRegistry;
using Soma.Domain.Exceptions;

namespace Soma.Application.Handlers.AppRegistry;

public sealed record GetFileHandler(IAppRegistryRepository Repository) : IRequestHandler<GetFileRequest, GetFileResponse>
{
    public async Task<GetFileResponse> Handle(GetFileRequest request, CancellationToken cancellationToken)
    {
        IAppVersionFile file = await Repository.GetFile(request.Id) ?? throw new NotFoundException($"App version file not found (id = {request.Id})");
        return new GetFileResponse(file);
    }
}