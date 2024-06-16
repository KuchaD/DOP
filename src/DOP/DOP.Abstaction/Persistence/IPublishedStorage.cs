using DOP.Abstaction.Message;

namespace DOP.Abstaction.Persistence;

public interface IPublishedStorage
{
    Task ChangePublishState(StoreMessage message, StatusMessage state);
 
    Task<StoreMessage> StoreMessage(string name, MessageAttributes attributes, object message, CancellationToken cancellationToken);
}