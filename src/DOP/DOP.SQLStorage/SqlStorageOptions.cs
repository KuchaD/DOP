using DOP.Abstaction.Persistence;
using Microsoft.Extensions.Options;

namespace DOP.SQLStorage;

public class SqlStorageOptions(IOptions<ServerSqlOptions> options) : IStorageOptions
{
    private const string LockName = "Lock";
    
    private const string ReceivedName = "Received";
    
    private const string PublishedName = "Published";
    
    public required string SchemaName = options.Value.Schema is null ? string.Empty : $"[{options.Value.Schema}].";

    public string GetLockTableName() => $"{SchemaName}{LockName}";
    
    public string GetPublishedTableName() => $"{SchemaName}{PublishedName}";

    public string GetReceivedTableName() => $"{SchemaName}{ReceivedName}";
}