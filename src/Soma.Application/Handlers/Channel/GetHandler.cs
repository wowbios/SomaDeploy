using MediatR;
using Soma.Domain.Channel;
using Soma.Domain.Exceptions;

namespace Soma.Application.Handlers.Channel;

public sealed record GetHandler(IChannelRepository Repository) : IRequestHandler<GetRequest, GetResponse>
{
    public async Task<GetResponse> Handle(GetRequest request, CancellationToken cancellationToken)
    {
        IChannel result = await Repository.Get(request.Name)
                             ?? throw new NotFoundException($"AppChannel (name = {request.Name}) not found");
        return new GetResponse(result);
    }
}