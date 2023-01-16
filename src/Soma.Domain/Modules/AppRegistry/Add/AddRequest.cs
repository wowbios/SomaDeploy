using MediatR;

namespace Soma.Domain.Modules.AppRegistry.Add;

public record AddRequest(string Name, string Version, byte[] File) : IRequest<AddResponse>;