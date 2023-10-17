using ControlTecnicos.Models;

namespace ControlTecnicos.BLL.Servicios
{
    public interface IElementosTecnicoService
    {
        Task<bool> Insertar(ElementosTecnico modelo);
        Task<bool> Actualizar(ElementosTecnico modelo);
        Task<bool> Eliminar(int id);
        Task<ElementosTecnico> Obtener(int id);
        Task<IQueryable<ElementosTecnico>> ObtenerTodos();
    }
}
