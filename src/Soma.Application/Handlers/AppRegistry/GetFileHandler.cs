using MediatR;
using Soma.Domain.Modules.AppRegistry;
using Soma.Domain.Modules.AppRegistry.GetFile;

namespace Soma.Application.Handlers.AppRegistry;

public sealed record GetFileHandler(IAppRegistryRepository Repository) : IRequestHandler<GetFileRequest, GetFileResponse>
{
    public async Task<GetFileResponse> Handle(GetFileRequest request, CancellationToken cancellationToken)
    {
        byte[] file = await Repository.GetFile(request.Id);
        return new GetFileResponse(file);
    }
}