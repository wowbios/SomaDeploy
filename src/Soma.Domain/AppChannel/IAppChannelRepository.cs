namespace Soma.Domain.AppChannel;

public interface IAppChannelRepository
{
    Task<IAppChannel> Add(string name);

    Task<IAppChannel?> Get(string name);
}