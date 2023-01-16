namespace Soma.Domain.Modules.AppRegistry;

public interface IAppRegistryRepository
{
    Task<IAppVersion> Add(string name, string version, byte[] file);

    Task<IAppVersion> Get(long id);

    Task<byte[]> GetFile(long id);
}