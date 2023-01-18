using MediatR;

namespace Soma.Domain.Project;

public sealed record AddRequest(string Name) : IRequest<AddResponse>;

public sealed record AddResponse(IProject Project);