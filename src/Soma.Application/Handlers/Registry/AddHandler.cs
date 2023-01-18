using MediatR;
using Soma.Domain.Registry;

namespace Soma.Application.Handlers.Registry;

public sealed record AddHandler(IRegistryRepository Repository)
    : IRequestHandler<AddRequest, AddResponse>
{
    public async Task<AddResponse> Handle(AddRequest request, CancellationToken cancellationToken)
    {
        IAppVersion result = await Repository.Add(request.ChannelId, request.Name, request.Version, request.FileName, request.Content);
        return new AddResponse(result);
    }
}