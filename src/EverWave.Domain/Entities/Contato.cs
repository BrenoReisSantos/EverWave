namespace EverWave.Domain.Entities;

public class Contato : BaseEntity
{
    public Guid Id { get; init; }
    public string Ddd { get; set; }
    public string Telefone { get; set; }
    public string Ddi { get; set; }

    public Membro? Membro { get; init; }
}