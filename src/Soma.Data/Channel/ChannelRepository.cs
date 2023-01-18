using Soma.Domain.Channel;

namespace Soma.Data.Channel;

public sealed record ChannelRepository(DapperContext Db) : IChannelRepository
{
    public async Task<IChannel> Add(string name, long projectId)
    {
        const string sql = @"
INSERT INTO Channel (NAME, PROJECT_ID) VALUES (@name, @projectId)

SELECT * FROM Channel WITH (NOLOCK) WHERE ID = SCOPE_IDENTITY()
";
        return (await Db.Get<Channel>(sql, new { name, projectId }))!;
    }

    public async Task<IChannel?> Get(string name)
    {
        const string sql = @"
SELECT * FROM Channel WITH (NOLOCK) WHERE NAME = @name
";
        return await Db.Get<Channel>(sql, new { name });
    }
}