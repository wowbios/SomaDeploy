using MediatR;

namespace Soma.Domain.Channel;

public sealed record AddRequest(string Name, long ProjectId) : IRequest<AddResponse>;

public sealed record AddResponse(IChannel Channel);