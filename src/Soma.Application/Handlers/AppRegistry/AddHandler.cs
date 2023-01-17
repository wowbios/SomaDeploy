using MediatR;
using Soma.Domain.AppRegistry;

namespace Soma.Application.Handlers.AppRegistry;

public sealed record AddHandler(IAppRegistryRepository Repository)
    : IRequestHandler<AddRequest, AddResponse>
{
    public async Task<AddResponse> Handle(AddRequest request, CancellationToken cancellationToken)
    {
        IAppVersion result = await Repository.Add(request.ChannelId, request.Name, request.Version, request.FileName, request.Content);
        return new AddResponse(result);
    }
}