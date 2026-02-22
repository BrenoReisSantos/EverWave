namespace EverWave.Domain.Entities;

public class Membro : BaseEntity
{
    public Guid Id { get; init; }
    public string Nome { get; set; }
    public string Email { get; set; }

    public List<Contato>? Contatos { get; set; }
    public Unidade? Unidade { get; set; }
    public List<Ministerio>? Ministerios { get; set; }
    public List<Cargo>? Cargos { get; set; }
}