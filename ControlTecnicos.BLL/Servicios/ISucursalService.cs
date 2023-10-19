using ControlTecnicos.Models.DTOs;

namespace ControlTecnicos.BLL.Servicios
{
    public interface ISucursalService
    {
        Task<SucursalDTO> Insertar(SucursalDTO sucursal);
        Task<bool> Actualizar(SucursalDTO sucursal);
        Task<bool> Eliminar(int id);
        SucursalDTO Obtener(int id);
        List<SucursalDTO> ObtenerTodos();
    }
}
