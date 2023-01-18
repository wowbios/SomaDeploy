using MediatR;

namespace Soma.Domain.Registry;

public sealed record GetFileRequest(long Id) : IRequest<GetFileResponse>;

public record GetFileResponse(IAppVersionFile File);