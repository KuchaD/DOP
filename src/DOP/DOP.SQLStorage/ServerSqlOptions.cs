namespace DOP.SQLStorage;

public class ServerSqlOptions
{
    public required string ConnectionString { get; set; }
    
    public string? Schema { get; set; }
}