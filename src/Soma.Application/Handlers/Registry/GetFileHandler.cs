using MediatR;
using Soma.Domain.Exceptions;
using Soma.Domain.Registry;

namespace Soma.Application.Handlers.Registry;

public sealed record GetFileHandler(IRegistryRepository Repository) : IRequestHandler<GetFileRequest, GetFileResponse>
{
    public async Task<GetFileResponse> Handle(GetFileRequest request, CancellationToken cancellationToken)
    {
        IAppVersionFile file = await Repository.GetFile(request.Id) ?? throw new NotFoundException($"App version file not found (id = {request.Id})");
        return new GetFileResponse(file);
    }
}