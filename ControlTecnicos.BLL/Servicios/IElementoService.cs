using ControlTecnicos.Models;

namespace ControlTecnicos.BLL.Servicios
{
    public interface IElementoService
    {
        Task<bool> Insertar(Elemento modelo);
        Task<bool> Actualizar(Elemento modelo);
        Task<bool> Eliminar(int id);
        Task<Elemento> Obtener(int id);
        Task<IQueryable<Elemento>> ObtenerTodos();
    }
}
