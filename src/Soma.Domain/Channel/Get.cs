using MediatR;

namespace Soma.Domain.Channel;

public sealed record GetRequest(string Name) : IRequest<GetResponse>;

public sealed record GetResponse(IChannel Channel);