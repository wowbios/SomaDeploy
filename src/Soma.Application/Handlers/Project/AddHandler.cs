using MediatR;
using Soma.Domain.Project;

namespace Soma.Application.Handlers.Project;

public sealed record AddHandler(IProjectRepository Repository) : IRequestHandler<AddRequest, AddResponse>
{
    public async Task<AddResponse> Handle(AddRequest request, CancellationToken cancellationToken)
    {
        IProject result = await Repository.Create(request.Name);
        return new AddResponse(result);
    }
}