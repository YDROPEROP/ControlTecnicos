using ControlTecnicos.Models.Entities;

namespace ControlTecnicos.Models.DTOs
{
    public class SucursalDTO
    {
        public int Id { get; set; }

        public string? Nombre { get; set; }

        public virtual ICollection<TecnicoDTO> Tecnicos { get; set; } = new List<TecnicoDTO>();
    }
}
