using System.ComponentModel.DataAnnotations.Schema;
using Soma.Domain.AppChannel;

#pragma warning disable CS8618

namespace Soma.Data.AppChannel;

public class AppChannel : IAppChannel
{
    [Column("ID")]
    public long Id { get; set; }
    
    [Column("NAME")]
    public string Name { get; set; }
}