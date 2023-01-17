using Soma.Domain.AppChannel;

namespace Soma.Data.AppChannel;

public sealed record AppChannelRepository(DapperContext Db) : IAppChannelRepository
{
    public async Task<IAppChannel> Add(string name)
    {
        const string sql = @"
INSERT INTO AppChannel (NAME) VALUES (@name)

SELECT * FROM AppChannel WITH (NOLOCK) WHERE ID = SCOPE_IDENTITY()
";
        return (await Db.Get<AppChannel>(sql, new { name }))!;
    }

    public async Task<IAppChannel?> Get(string name)
    {
        const string sql = @"
SELECT * FROM AppChannel WITH (NOLOCK) WHERE NAME = @name
";
        return await Db.Get<AppChannel>(sql, new { name });
    }
}