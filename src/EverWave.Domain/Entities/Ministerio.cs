namespace EverWave.Domain.Entities;

public class Ministerio : BaseEntity
{
    public Guid Id { get; init; }
    public string Nome { get; init; }

    public List<MinisterioLocal>? MinisteriosLocais { get; set; }
}