namespace ControlTecnicos.Models;

public partial class Sucursal
{
    public int Id { get; set; }

    public string? Nombre { get; set; }

    public virtual ICollection<Tecnico> Tecnicos { get; set; } = new List<Tecnico>();
}
