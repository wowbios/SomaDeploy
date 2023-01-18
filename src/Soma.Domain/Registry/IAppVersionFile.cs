namespace Soma.Domain.Registry;

public interface IAppVersionFile
{
    long VersionId { get; }
    
    string Name { get; }
    
    byte[] Content { get; }
}