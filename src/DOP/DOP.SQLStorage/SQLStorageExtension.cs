using DOP.Abstaction.Options;

namespace DOP.SQLStorage;

public static class SqlStorageExtension
{
    public static DopOptions UseServerSql(this DopOptions options, Action<ServerSqlOptions> configure)
    {
        ArgumentNullException.ThrowIfNull(configure);

        options.RegisterExtension(new SqlServerDopOptionsExtension(configure));

        return options;
    }
}

