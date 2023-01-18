using MediatR;
using Soma.Domain.Channel;

namespace Soma.Application.Handlers.Channel;

public sealed record AddHandler(IChannelRepository ChannelRepository) : IRequestHandler<AddRequest, AddResponse>
{
    public async Task<AddResponse> Handle(AddRequest request, CancellationToken cancellationToken)
    {
        IChannel result = await ChannelRepository.Add(request.Name, request.ProjectId);
        return new AddResponse(result);
    }
}