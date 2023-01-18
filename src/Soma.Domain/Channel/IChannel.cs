namespace Soma.Domain.Channel;

public interface IChannel
{
    long Id { get; }
    
    long ProjectId { get; }
    
    string Name { get; }
}