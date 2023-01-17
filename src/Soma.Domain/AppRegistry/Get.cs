using MediatR;

namespace Soma.Domain.AppRegistry;

public record GetRequest(long Id) : IRequest<GetResponse>;

public record GetResponse(IAppVersion AppVersion);