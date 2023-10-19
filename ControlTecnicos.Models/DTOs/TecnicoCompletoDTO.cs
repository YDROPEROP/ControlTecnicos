namespace ControlTecnicos.Models.DTOs
{
    public class TecnicoCompletoDTO
    {
        public TecnicoDTO Tecnico { get; set; }
        public List<ElementosTecnicoDTO> ElementosTecnico { get; set; }
    }
}
