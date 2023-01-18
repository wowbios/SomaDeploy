using System.ComponentModel.DataAnnotations.Schema;
using Soma.Domain.Registry;

#pragma warning disable CS8618

namespace Soma.Data.Registry;

internal sealed record AppVersionFile : IAppVersionFile
{
    [Column("ID")]
    public long VersionId { get; set; }
    
    [Column("FILE_NAME")]
    public string Name { get; set; }
     
    [Column("FILE")]
    public byte[] Content { get; set; }
}