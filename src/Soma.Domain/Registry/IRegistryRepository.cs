namespace Soma.Domain.Registry;

public interface IRegistryRepository
{
    Task<IAppVersion> Add(long channelId, string name, string version, string fileName, byte[] content);

    Task<IAppVersion?> Get(long id);

    Task<IAppVersionFile?> GetFile(long id);
}