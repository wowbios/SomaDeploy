namespace Soma.Domain.AppRegistry;

public interface IAppVersionFile
{
    long VersionId { get; }
    
    string Name { get; }
    
    byte[] Content { get; }
}