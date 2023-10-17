namespace ControlTecnicos.Models;

public partial class Elemento
{
    public int Id { get; set; }

    public string? Nombre { get; set; }

    public virtual ICollection<ElementosTecnico> ElementosTecnicos { get; set; } = new List<ElementosTecnico>();
}
