namespace ControlTecnicos.Models.DTOs
{
    public class TecnicosViewModel
    {
        public List<SucursalDTO> Sucursales { get; set; }
        public List<ElementoDTO> Elementos { get; set; }
        public List<TecnicoDTO> Tecnicos { get; set; }
        public TecnicoDTO Tecnico { get; set; }
        public bool EstaEditando { get; set; }
    }
}
