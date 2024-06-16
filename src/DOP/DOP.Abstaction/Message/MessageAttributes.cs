namespace DOP.Abstaction.Message;

public class MessageAttributes
{
    IDictionary<string, string> Properties { get; init; }
    
    public required string MessageName {get; init; }
    
    
    public MessageAttributes(IDictionary<string, string> properties)
    {
        Properties = properties;
    }
    
    public MessageAttributes()
    {
        Properties = new Dictionary<string, string>();
    }
}