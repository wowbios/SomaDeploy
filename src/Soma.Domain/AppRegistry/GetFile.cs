using MediatR;

namespace Soma.Domain.AppRegistry;

public sealed record GetFileRequest(long Id) : IRequest<GetFileResponse>;

public record GetFileResponse(IAppVersionFile File);