using ControlTecnicos.Models.DTOs;

namespace ControlTecnicos.BLL.Servicios
{
    public interface IElementoService
    {
        Task<ElementoDTO> Insertar(ElementoDTO elemento);
        Task<bool> Actualizar(ElementoDTO elemento);
        Task<bool> Eliminar(int id);
        ElementoDTO Obtener(int id);
        List<ElementoDTO> ObtenerTodos();
    }
}
