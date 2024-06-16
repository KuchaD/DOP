using DOP.Abstaction;
using DOP.Abstaction.Persistence;
using Microsoft.Extensions.DependencyInjection;


namespace DOP.SQLStorage;

internal class SqlServerDopOptionsExtension(Action<ServerSqlOptions> configure) : IDopOptionsExtension
{
    public void AddServices(IServiceCollection services)
    {
        services.Configure(configure);
        services.AddOptions<SqlStorageOptions>();
        //todo: add key
        services.AddSingleton<IStorageOptions, SqlStorageOptions>();
        services.AddScoped<IPublishedStorage, SqlPublishedStorage>();
        services.AddTransient<IDbConnection, SqldbConnection>();
    }
}