namespace Soma.Domain.Registry;

public interface IAppVersion
{
    long Id { get; }
    
    string Version { get; }
    
    string Name { get; }
    
    string FileName { get; }
    
    long ChannelId { get; }
}