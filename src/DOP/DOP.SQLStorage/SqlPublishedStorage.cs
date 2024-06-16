using Dapper;
using DOP.Abstaction;
using DOP.Abstaction.Message;
using DOP.Abstaction.Options;
using DOP.Abstaction.Persistence;
using Microsoft.Extensions.Options;

namespace DOP.SQLStorage;

public class SqlPublishedStorage(
    IDbConnection dbconnection, 
    IStorageOptions options,
    IOptions<DopOptions> dopOptions) : IPublishedStorage
{
    private string InsertQuery = $"INSERT INTO { options.GetPublishedTableName()} (Name, Attributes, Content, CreatedAt, ExpiresAt,  StatusName, Retries) VALUES (@Name, @Attributes, @Content, @CreatedAt, @ExpiresAt, @Status, @Retries) SELECT SCOPE_IDENTITY()";
    private string UpdateQuery = $"UPDATE { options.GetPublishedTableName()} SET StatusName = @Status WHERE Id = @Id";
    
    public Task ChangePublishState(StoreMessage message, StatusMessage state)
    {
        return dbconnection.Connection.ExecuteAsync(UpdateQuery, new { Id = message.Id, Status = state });
    }

    public async Task<StoreMessage> StoreMessage(string name, MessageAttributes messageAttributes, object message, CancellationToken cancellationToken)
    {
        var attributesJson = Serializer.JsonDefault.Serialize(messageAttributes);
        var messageJson = Serializer.JsonDefault.Serialize(message);
        
        var storeMessage = new StoreMessage
        {
            Name = name,
            Attributes = messageAttributes,
            Content = messageJson,
            CreatedAt = DateTimeOffset.UtcNow,
            ExpiresAt = DateTimeOffset.UtcNow.AddSeconds(dopOptions.Value.ExpirationTime),
            StatusMessage = StatusMessage.Pending,
            Retries = 0
        };
        
        var id = await dbconnection.Connection.QueryAsync<int>(InsertQuery, 
            new
            {
                storeMessage.Name,
                Attributes = attributesJson,
                storeMessage.Content,
                storeMessage.CreatedAt,
                storeMessage.ExpiresAt,
                Status = storeMessage.StatusMessage.ToString(),
                storeMessage.Retries
            });
        
        storeMessage.Id = (ulong) id.Single();
        
        dbconnection.Connection.Close();
        return storeMessage;
    }
}