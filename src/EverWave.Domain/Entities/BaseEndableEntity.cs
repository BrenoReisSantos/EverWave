namespace EverWave.Domain.Entities;

public class BaseEndableEntity : BaseEntity
{
    public DateTime? InactivatedAt { get; set; }
}