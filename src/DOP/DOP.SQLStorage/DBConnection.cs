using System.Data;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Options;

namespace DOP.SQLStorage;

public interface IDbConnection
{ 
    public System.Data.IDbConnection Connection { get; }
}

public class SqldbConnection : IDbConnection
{
    public System.Data.IDbConnection Connection { get; }

    public SqldbConnection(IOptions<ServerSqlOptions> options)
    {
        Connection = new SqlConnection(options.Value.ConnectionString) ;
    }
}
