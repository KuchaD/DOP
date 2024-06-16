namespace DOP.Abstaction.Persistence;

public interface IStorageOptions
{
    public string GetLockTableName();
    public string GetPublishedTableName();
    public string GetReceivedTableName();
}