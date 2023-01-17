using Dapper;
using Soma.Domain.AppRegistry;

namespace Soma.Data.AppRegistry;

public sealed record AppRegistryRepository(DapperContext Db) : IAppRegistryRepository
{
    public async Task<IAppVersion> Add(long channelId, string name, string version, string fileName, byte[] content)
    {
        const string sql = @"
INSERT INTO AppRegistry (NAME, VERSION, [FILE], FILE_NAME, CHANNEL_ID)
VALUES (@name, @version, @content, @fileName, @channelId)

SELECT * FROM AppRegistry WITH (NOLOCK)
WHERE ID = SCOPE_IDENTITY()";

        return (await Db.Get<AppVersion>(
            sql,
            new { name, version, content, fileName, channelId }))!;
    }

    public async Task<IAppVersion?> Get(long id)
    {
        const string sql = @"SELECT * FROM AppRegistry WITH (NOLOCK) WHERE ID = @id";
        return await Db.Get<AppVersion>(sql, new { id });
    }
    
    public async Task<IAppVersionFile?> GetFile(long id)
    {
        const string sql = @"SELECT ID, [FILE], FILE_NAME FROM AppRegistry WITH (NOLOCK) WHERE ID = @id";
        return await Db.Get<AppVersionFile>(sql, new { id });
    }
}