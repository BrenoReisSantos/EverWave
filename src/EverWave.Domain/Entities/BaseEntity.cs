namespace EverWave.Domain.Entities;

public class BaseEntity
{
    public DateTime CreatedAt { get; init; }
    public DateTime? UpdatedAt { get; set; }
}