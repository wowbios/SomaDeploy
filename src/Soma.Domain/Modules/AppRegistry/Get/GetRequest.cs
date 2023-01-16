using MediatR;

namespace Soma.Domain.Modules.AppRegistry.Get;

public record GetRequest(long Id) : IRequest<GetResponse>;