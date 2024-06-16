namespace DOP.Abstaction.Options;

public class DopOptions
{
    /// <summary>
    /// Default is 24*3600 seconds.
    /// </summary>
    public int ExpirationTime { get; init; } = 24 * 3600;

    public IList<IDopOptionsExtension> Extensions { get; } = new List<IDopOptionsExtension>();
    
    public void RegisterExtension(IDopOptionsExtension extension)
    {
        ArgumentNullException.ThrowIfNull(extension);

        Extensions.Add(extension);
    }
}