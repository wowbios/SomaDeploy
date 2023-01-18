using System.ComponentModel.DataAnnotations.Schema;
using Soma.Domain.Channel;

#pragma warning disable CS8618

namespace Soma.Data.Channel;

public class Channel : IChannel
{
    [Column("ID")]
    public long Id { get; set; }

    [Column("PROJECT_ID")]
    public long ProjectId { get; set; }

    [Column("NAME")]
    public string Name { get; set; }
}