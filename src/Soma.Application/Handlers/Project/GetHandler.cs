using MediatR;
using Soma.Domain.Exceptions;
using Soma.Domain.Project;

namespace Soma.Application.Handlers.Project;

public sealed record GetHandler(IProjectRepository Repository) : IRequestHandler<GetRequest, GetResponse>
{
    public async Task<GetResponse> Handle(GetRequest request, CancellationToken cancellationToken)
    {
        IProject project = await Repository.Get(request.Id)
                          ?? throw new NotFoundException($"Repository not found (id = {request.Id}");

        return new GetResponse(project);
    }
}