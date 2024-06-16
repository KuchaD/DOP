namespace DOP.Abstaction.Message;

public record StoreMessage
{
    public ulong Id { get; set; }
    
    public DateTimeOffset CreatedAt { get; init; }
    
    public DateTimeOffset ExpiresAt { get; init; }
    
    public MessageAttributes Attributes { get; init; }
    
    public string Content { get; init; }
    
    public string Name { get; init; }
    
    public StatusMessage StatusMessage { get; init; }
    
    public int Retries { get; init; }
}