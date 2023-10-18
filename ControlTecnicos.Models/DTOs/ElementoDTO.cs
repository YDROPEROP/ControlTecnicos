using ControlTecnicos.Models.Entities;

namespace ControlTecnicos.Models.DTOs
{
    public class ElementoDTO
    {
        public int Id { get; set; }

        public string? Nombre { get; set; }

        public virtual ICollection<ElementosTecnicoDTO> ElementosTecnicos { get; set; } = new List<ElementosTecnicoDTO>();
    }
}
