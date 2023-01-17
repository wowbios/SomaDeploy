using MediatR;
using Soma.Domain.AppChannel;

namespace Soma.Application.Handlers.AppChannel;

public sealed record AddHandler(IAppChannelRepository ChannelRepository) : IRequestHandler<AddRequest, AddResponse>
{
    public async Task<AddResponse> Handle(AddRequest request, CancellationToken cancellationToken)
    {
        IAppChannel result = await ChannelRepository.Add(request.Name);
        return new AddResponse(result);
    }
}