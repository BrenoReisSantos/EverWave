namespace EverWave.Domain.Entities;

public class BaseEntity
{
    public DateTime CreatedAt { get; init; } = DateTime.Now;
    public DateTime? UpdatedAt { get; set; } = DateTime.Now;
}