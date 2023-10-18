using ControlTecnicos.Models.DTOs;

namespace ControlTecnicos.BLL.Servicios
{
    public interface IElementosTecnicoService
    {
        Task<bool> Insertar(List<ElementosTecnicoDTO> elementosTecnico);
        Task<bool> Actualizar(ElementosTecnicoDTO elementosTecnico);
        Task<bool> Eliminar(int id);
        ElementosTecnicoDTO Obtener(int id);
        List<ElementosTecnicoDTO> ObtenerTodos();
    }
}
