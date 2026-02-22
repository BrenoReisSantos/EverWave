namespace EverWave.Domain.Entities;

public class CategoriaCargo : BaseEndableEntity
{
    public int Id { get; set; }
    public string Descricao { get; set; }

    public List<Cargo>? Cargos { get; set; }
}