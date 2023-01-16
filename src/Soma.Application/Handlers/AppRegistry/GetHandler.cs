using MediatR;
using Soma.Domain.Modules.AppRegistry;
using Soma.Domain.Modules.AppRegistry.Get;

namespace Soma.Application.Handlers.AppRegistry;

public sealed record GetHandler(IAppRegistryRepository Repository)
    : IRequestHandler<GetRequest, GetResponse>
{
    public async Task<GetResponse> Handle(GetRequest request, CancellationToken cancellationToken)
    {
        IAppVersion result = await Repository.Get(request.Id);
        return new GetResponse(result.Name, result.Version);
    }
}