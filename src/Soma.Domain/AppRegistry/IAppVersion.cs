namespace Soma.Domain.AppRegistry;

public interface IAppVersion
{
    long Id { get; }
    
    string Version { get; }
    
    string Name { get; }
    
    string FileName { get; }
    
    long ChannelId { get; }
}