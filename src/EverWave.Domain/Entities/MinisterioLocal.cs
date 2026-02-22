namespace EverWave.Domain.Entities;

public class MinisterioLocal : BaseEndableEntity
{
    public Guid Id { get; init; }

    public Guid MinisterioId { get; set; }
    public Ministerio? Ministerio { get; set; }
    public Guid UnidadeId { get; set; }
    public Unidade? Unidade { get; set; }

    public List<MinisterioLocalParticipacao> ParticipacoesMinisterios { get; set; }
}