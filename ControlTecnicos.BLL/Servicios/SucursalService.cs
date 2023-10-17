using ControlTecnicos.DAL.Repository;
using ControlTecnicos.Models;

namespace ControlTecnicos.BLL.Servicios
{
    public class SucursalService : ISucursalService
    {
        private readonly IGenericRepository<Sucursal> _sucursalRepository;

        public SucursalService(IGenericRepository<Sucursal> sucursalRepository) 
        { 
            this._sucursalRepository = sucursalRepository;
        }

        public async Task<bool> Actualizar(Sucursal modelo)
        {
            return await this._sucursalRepository.Actualizar(modelo);
        }

        public async Task<bool> Eliminar(int id)
        {
            return await this._sucursalRepository.Eliminar(id);
        }

        public async Task<bool> Insertar(Sucursal modelo)
        {
            return await this._sucursalRepository.Insertar(modelo);
        }

        public async Task<Sucursal> Obtener(int id)
        {
            return await this._sucursalRepository.Obtener(id);
        }

        public async Task<IQueryable<Sucursal>> ObtenerTodos()
        {
            return await this._sucursalRepository.ObtenerTodos();
        }
    }
}
