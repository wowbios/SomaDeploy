namespace Soma.Domain.Channel;

public interface IChannelRepository
{
    Task<IChannel> Add(string name, long projectId);

    Task<IChannel?> Get(string name);
}