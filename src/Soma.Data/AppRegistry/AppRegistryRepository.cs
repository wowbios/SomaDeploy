using Dapper;
using Soma.Domain.Modules.AppRegistry;

namespace Soma.Data.AppRegistry;

public sealed class AppRegistryRepository : IAppRegistryRepository
{
    private readonly DapperContext _context;

    public AppRegistryRepository(DapperContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }
    
    public async Task<IAppVersion> Add(string name, string version, byte[] file)
    {
        const string sql = @"
INSERT INTO AppRegistry (NAME, VERSION, [FILE])
VALUES (@name, @version, @file)

SELECT * FROM AppRegistry WITH (NOLOCK)
WHERE ID = SCOPE_IDENTITY()";

        using var _ = _context.Connect();

        return await _.QuerySingleAsync<AppVersion>(
            sql,
            new { name, version, file });
    }

    public async Task<IAppVersion> Get(long id)
    {
        const string sql = @"
SELECT * FROM AppRegistry WITH (NOLOCK)
WHERE ID = @id";

        using var _ = _context.Connect();

        return await _.QuerySingleAsync<AppVersion>(sql, new { id });
    }
    
    public async Task<byte[]> GetFile(long id)
    {
        const string sql = @"SELECT [FILE] FROM AppRegistry WITH (NOLOCK) WHERE ID = @id";
        using var _ = _context.Connect();
        return await _.QuerySingleAsync<byte[]>(sql, new { id });
    }
}