namespace DOP.Abstaction;

public interface IDopPublisher
{
    Task Publish<T>(T contentObj, CancellationToken cancellationToken = default);
}