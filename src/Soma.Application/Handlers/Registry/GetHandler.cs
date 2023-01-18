using MediatR;
using Soma.Domain.Exceptions;
using Soma.Domain.Registry;

namespace Soma.Application.Handlers.Registry;

public sealed record GetHandler(IRegistryRepository Repository)
    : IRequestHandler<GetRequest, GetResponse>
{
    public async Task<GetResponse> Handle(GetRequest request, CancellationToken cancellationToken)
    {
        IAppVersion result = await Repository.Get(request.Id) ?? throw new NotFoundException($"AppVersion (id = {request.Id}) not found");
        return new GetResponse(result);
    }
}