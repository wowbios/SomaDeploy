using System.ComponentModel.DataAnnotations.Schema;
using Soma.Domain.AppRegistry;

#pragma warning disable CS8618

namespace Soma.Data.AppRegistry;

internal sealed record AppVersion : IAppVersion
{
    [Column("ID")]
    public long Id { get; set; }
    
    [Column("VERSION")]
    public string Version { get; set; }
    
    [Column("NAME")]
    public string Name { get; set;}
    
    [Column("CHANNEL_ID")]
    public long ChannelId { get; set;}
    
    [Column("FILE_NAME")]
    public string FileName { get; set; }
} 