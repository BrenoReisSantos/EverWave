namespace EverWave.Domain.Entities;

public class ParticipacaoMinisterioLocal : BaseEndableEntity
{
    public Guid Id { get; init; }

    public Guid MinisterioLocalId { get; set; }
    public MinisterioLocal MinisterioLocal { get; set; }

    public Guid MembroId { get; set; }
    public Membro Membro { get; set; }

    public Guid CargoId { get; set; }
    public Cargo Cargo { get; set; }
}