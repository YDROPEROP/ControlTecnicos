using ControlTecnicos.DAL.Repository;
using ControlTecnicos.Models.DTOs;

namespace ControlTecnicos.BLL.Servicios
{
    public class SucursalService : ISucursalService
    {
        private readonly IGenericRepository<SucursalDTO> _sucursalRepository;

        public SucursalService(IGenericRepository<SucursalDTO> sucursalRepository) 
        { 
            this._sucursalRepository = sucursalRepository;
        }

        public async Task<bool> Actualizar(SucursalDTO sucursal)
        {
            return await this._sucursalRepository.Actualizar(sucursal);
        }

        public async Task<bool> Eliminar(int id)
        {
            return await this._sucursalRepository.Eliminar(id);
        }

        public async Task<bool> Insertar(SucursalDTO sucursal)
        {
            return await this._sucursalRepository.Insertar(sucursal);
        }

        public SucursalDTO Obtener(int id)
        {
            return this._sucursalRepository.Obtener(id);
        }

        public List<SucursalDTO> ObtenerTodos()
        {
            return this._sucursalRepository.ObtenerTodos();
        }
    }
}
