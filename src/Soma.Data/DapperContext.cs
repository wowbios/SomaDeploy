using System.Data;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace Soma.Data;

public class DapperContext
{
    private static readonly HashSet<int> MappedEntitiesTypesCodes = new();
    private readonly string _connectionString;

    public DapperContext(IConfiguration configuration)
    {
        ArgumentNullException.ThrowIfNull(configuration);
        _connectionString = configuration.GetConnectionString("SqlConnection");
    }
    
    public async Task<T?> Get<T>(string sql)
    {
        EnsureMap<T>();
        using var _ = Connect();

        return await _.QuerySingleOrDefaultAsync<T>(sql);
    }

    public async Task<IEnumerable<T>> GetMany<T>(string sql)
    {
        EnsureMap<T>();
        using var _ = Connect();

        return (await _.QueryAsync<T>(sql)).ToArray();
    }

    public async Task<T?> Get<T>(string sql, object param)
    {
        EnsureMap<T>();
        using var _ = Connect();

        return await _.QuerySingleOrDefaultAsync<T>(sql, param);
    }

    public async Task<IEnumerable<T>> GetMany<T>(string sql, object param)
    {
        EnsureMap<T>();
        using var _ = Connect();

        return (await _.QueryAsync<T>(sql, param)).ToArray();
    }
    
    private IDbConnection Connect() => new SqlConnection(_connectionString);
    
    private static void EnsureMap<T>()
    {
        int code = typeof(T).GetHashCode();
        if (MappedEntitiesTypesCodes.Contains(code))
            return;

        Dapper.SqlMapper.SetTypeMap(
            typeof(T),
            new ColumnAttributeTypeMapper<T>());
        MappedEntitiesTypesCodes.Add(code);
    }
}