using MediatR;

namespace Soma.Domain.AppChannel;

public sealed record GetRequest(string Name) : IRequest<GetResponse>;

public sealed record GetResponse(IAppChannel Channel);