using ControlTecnicos.Models;

namespace ControlTecnicos.BLL.Servicios
{
    public interface ITecnicoService
    {
        Task<bool> Insertar(Tecnico modelo);
        Task<bool> Actualizar(Tecnico modelo);
        Task<bool> Eliminar(int id);
        Task<Tecnico> Obtener(int id);
        Task<IQueryable<Tecnico>> ObtenerTodos();
    }
}
