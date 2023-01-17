using MediatR;
using Soma.Domain.AppRegistry;
using Soma.Domain.Exceptions;

namespace Soma.Application.Handlers.AppRegistry;

public sealed record GetHandler(IAppRegistryRepository Repository)
    : IRequestHandler<GetRequest, GetResponse>
{
    public async Task<GetResponse> Handle(GetRequest request, CancellationToken cancellationToken)
    {
        IAppVersion result = await Repository.Get(request.Id) ?? throw new NotFoundException($"AppVersion (id = {request.Id}) not found");
        return new GetResponse(result);
    }
}