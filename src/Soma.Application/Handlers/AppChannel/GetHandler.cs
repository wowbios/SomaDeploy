using MediatR;
using Soma.Domain.AppChannel;
using Soma.Domain.Exceptions;

namespace Soma.Application.Handlers.AppChannel;

public sealed record GetHandler(IAppChannelRepository Repository) : IRequestHandler<GetRequest, GetResponse>
{
    public async Task<GetResponse> Handle(GetRequest request, CancellationToken cancellationToken)
    {
        IAppChannel result = await Repository.Get(request.Name)
                             ?? throw new NotFoundException($"AppChannel (name = {request.Name}) not found");
        return new GetResponse(result);
    }
}