namespace Soma.Domain.AppChannel;

public interface IAppChannel
{
    long Id { get; }
    
    string Name { get; }
}