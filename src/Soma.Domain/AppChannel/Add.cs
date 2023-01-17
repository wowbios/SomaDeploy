using MediatR;

namespace Soma.Domain.AppChannel;

public sealed record AddRequest(string Name) : IRequest<AddResponse>;

public sealed record AddResponse(IAppChannel Channel);