namespace Soma.Domain.Modules.AppRegistry;

public interface IAppVersion
{
    long Id { get; }
    
    string Version { get; }
    
    string Name { get; }
}