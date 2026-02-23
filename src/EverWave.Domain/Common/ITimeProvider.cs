namespace EverWave.Domain.Common;

public interface ITimeProvider
{
    DateTime UtcNow { get; }
    DateTime Now { get; }
}