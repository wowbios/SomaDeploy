using Soma.Domain.Registry;

namespace Soma.Data.Registry;

public sealed record RegistryRepository(DapperContext Db) : IRegistryRepository
{
    public async Task<IAppVersion> Add(long channelId, string name, string version, string fileName, byte[] content)
    {
        const string sql = @"
INSERT INTO Registry (NAME, VERSION, [FILE], FILE_NAME, CHANNEL_ID)
VALUES (@name, @version, @content, @fileName, @channelId)

SELECT * FROM Registry WITH (NOLOCK)
WHERE ID = SCOPE_IDENTITY()";

        return (await Db.Get<AppVersion>(
            sql,
            new { name, version, content, fileName, channelId }))!;
    }

    public async Task<IAppVersion?> Get(long id)
    {
        const string sql = @"SELECT * FROM Registry WITH (NOLOCK) WHERE ID = @id";
        return await Db.Get<AppVersion>(sql, new { id });
    }
    
    public async Task<IAppVersionFile?> GetFile(long id)
    {
        const string sql = @"SELECT ID, [FILE], FILE_NAME FROM Registry WITH (NOLOCK) WHERE ID = @id";
        return await Db.Get<AppVersionFile>(sql, new { id });
    }
}