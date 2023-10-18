namespace ControlTecnicos.Models.Entities;

public partial class Tecnico
{
    public int Id { get; set; }

    public string? Nombre { get; set; }

    public string? Codigo { get; set; }

    public decimal? SueldoBase { get; set; }

    public int? SucursalId { get; set; }

    public DateTime? FechaCreacion { get; set; }

    public DateTime? FechaModificacion { get; set; }

    public virtual ICollection<ElementosTecnico> ElementosTecnicos { get; set; } = new List<ElementosTecnico>();

    public virtual Sucursal? Sucursal { get; set; }
}
