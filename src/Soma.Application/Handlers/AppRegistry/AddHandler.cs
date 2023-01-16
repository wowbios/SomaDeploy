using MediatR;
using Soma.Domain.Modules.AppRegistry;
using Soma.Domain.Modules.AppRegistry.Add;

namespace Soma.Application.Handlers.AppRegistry;

public sealed record AddHandler(IAppRegistryRepository Repository)
    : IRequestHandler<AddRequest, AddResponse>
{
    public async Task<AddResponse> Handle(AddRequest request, CancellationToken cancellationToken)
    {
        IAppVersion result = await Repository.Add(request.Name, request.Version, request.File);
        return new AddResponse(result);
    }
}