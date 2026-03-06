namespace EverWave.Web.Values.Table;

public record UnidadeVisualizacaoTable
{
    public Guid Id { get; init; }
    public string Nome { get; init; }
    public DateTime Fundacao { get; init; }
    public DateTime? UltimaAlteracao { get; init; }
    public bool Ativo { get; init; }
}