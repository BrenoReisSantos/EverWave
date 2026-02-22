namespace EverWave.Domain.Entities;

public class Cargo : BaseEntity
{
    public int Id { get; init; }
    public string Descricao { get; set; }

    public List<Membro>? Membros { get; set; }

    public int CategoriaCargoId { get; set; }
    public CategoriaCargo? Categoria { get; set; }
}