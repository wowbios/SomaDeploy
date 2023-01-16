using System.ComponentModel.DataAnnotations.Schema;
using Soma.Domain.Modules.AppRegistry;

namespace Soma.Data.AppRegistry;

internal sealed record AppVersion : IAppVersion
{
    [Column("ID")]
    public long Id { get; }
    
    [Column("VERSION")]
    public string Version { get; }
    
    [Column("NAME")]
    public string Name { get; }
} 