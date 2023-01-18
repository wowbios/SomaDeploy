using MediatR;

namespace Soma.Domain.Registry;

public record GetRequest(long Id) : IRequest<GetResponse>;

public record GetResponse(IAppVersion AppVersion);