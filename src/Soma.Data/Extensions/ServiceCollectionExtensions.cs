using Microsoft.Extensions.DependencyInjection;
using Soma.Data.Channel;
using Soma.Data.Project;
using Soma.Data.Registry;
using Soma.Domain.Channel;
using Soma.Domain.Project;
using Soma.Domain.Registry;

namespace Soma.Data.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddDataServices(this IServiceCollection services) =>
        services
            .AddSingleton<DapperContext>()
            .AddScoped<IRegistryRepository, RegistryRepository>()
            .AddScoped<IChannelRepository, ChannelRepository>()
            .AddScoped<IProjectRepository, ProjectRepository>();
}