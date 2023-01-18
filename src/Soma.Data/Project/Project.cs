using System.ComponentModel.DataAnnotations.Schema;
using Soma.Domain.Project;

#pragma warning disable CS8618

namespace Soma.Data.Project;

public class Project : IProject
{
    [Column("ID")]
    public long Id { get; set; }
    
    [Column("NAME")]
    public string Name { get; set; }
}