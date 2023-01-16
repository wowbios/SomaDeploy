using MediatR;

namespace Soma.Domain.Modules.AppRegistry.GetFile;

public sealed record GetFileRequest(long Id) : IRequest<GetFileResponse>;