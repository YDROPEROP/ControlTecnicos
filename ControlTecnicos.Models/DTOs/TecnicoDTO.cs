using ControlTecnicos.Models.Entities;

namespace ControlTecnicos.Models.DTOs
{
    public class TecnicoDTO
    {
        public int Id { get; set; }

        public string? Nombre { get; set; }

        public string? Codigo { get; set; }

        public decimal? SueldoBase { get; set; }
        public int? SucursalId { get; set; }
        public DateTime? FechaCreacion { get; set; }

        public virtual List<ElementosTecnicoDTO> ElementosTecnicos { get; set; } = new List<ElementosTecnicoDTO>();

        public virtual Sucursal? Sucursal { get; set; }
    }
}
