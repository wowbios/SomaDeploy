using MediatR;

namespace Soma.Domain.Project;

public sealed record GetRequest(long Id) : IRequest<GetResponse>;

public sealed record GetResponse(IProject Project);