namespace EverWave.Domain.Entities;

public class Unidade : BaseEntity
{
    public Guid Id { get; init; }
    public string Nome { get; set; }

    public List<Membro>? Membros { get; set; }
    public List<MinisterioLocal>? MinisteriosLocais { get; set; }
}