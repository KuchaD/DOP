using DOP.Abstaction;
using DOP.Abstaction.Message;
using DOP.Abstaction.Persistence;

namespace DOP;

internal class DopPublisher(IPublishedStorage storage) : IDopPublisher
{
    public async Task Publish<T>(T contentObj, CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(contentObj, nameof(contentObj));
        
        var type = typeof(T).FullName ?? throw new InvalidOperationException("Type name is null");
        var message = new MessageAttributes
        {
            MessageName = type
        };
        
        await storage.StoreMessage(type, message, contentObj, cancellationToken);
    }
}