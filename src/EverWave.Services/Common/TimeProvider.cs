using EverWave.Domain.Common;

namespace EverWave.Services.Common;

public class TimeProvider : ITimeProvider
{
    public DateTime UtcNow => DateTime.UtcNow;
    public DateTime Now => DateTime.Now;
}