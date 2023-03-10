using MediatR;

namespace Soma.Domain.Registry;

public record AddRequest(long ChannelId, string Name, string Version, string FileName, byte[] Content) : IRequest<AddResponse>;

public record AddResponse(IAppVersion AppVersion);