using ControlTecnicos.Models;

namespace ControlTecnicos.BLL.Servicios
{
    public interface ISucursalService
    {
        Task<bool> Insertar(Sucursal modelo);
        Task<bool> Actualizar(Sucursal modelo);
        Task<bool> Eliminar(int id);
        Task<Sucursal> Obtener(int id);
        Task<IQueryable<Sucursal>> ObtenerTodos();
    }
}
