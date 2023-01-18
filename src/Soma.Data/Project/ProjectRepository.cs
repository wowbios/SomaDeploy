using Soma.Domain.Project;

namespace Soma.Data.Project;

public sealed record ProjectRepository(DapperContext Db) : IProjectRepository
{
    public async Task<IProject?> Get(long id)
    {
        const string sql = @"
SELECT * FROM Project WITH (NOLOCK) WHERE ID = @id
";

        return await Db.Get<Project>(sql, new { id });
    }

    public async Task<IProject> Create(string name)
    {
        const string sql = @"
INSERT INTO Project (NAME)
VALUES (@name)

SELECT * FROM Project WITH (NOLOCK) WHERE ID = SCOPE_IDENTITY()
";
        return (await Db.Get<Project>(sql, new { name }))!;
    }
}