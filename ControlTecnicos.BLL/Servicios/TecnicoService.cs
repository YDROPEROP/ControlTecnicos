using ControlTecnicos.DAL.Repository;
using ControlTecnicos.Models;

namespace ControlTecnicos.BLL.Servicios
{
    public class TecnicoService : ITecnicoService
    {
        private readonly IGenericRepository<Tecnico> _tecnicoRepository;

        public TecnicoService(IGenericRepository<Tecnico> tecnicoRepository) 
        { 
            this._tecnicoRepository = tecnicoRepository;
        }

        public async Task<bool> Actualizar(Tecnico modelo)
        {
            return await this._tecnicoRepository.Actualizar(modelo);
        }

        public async Task<bool> Eliminar(int id)
        {
            return await this._tecnicoRepository.Eliminar(id);
        }

        public async Task<bool> Insertar(Tecnico modelo)
        {
            return await this._tecnicoRepository.Insertar(modelo);
        }

        public async Task<Tecnico> Obtener(int id)
        {
            return await this._tecnicoRepository.Obtener(id);
        }

        public async Task<IQueryable<Tecnico>> ObtenerTodos()
        {
            return await this._tecnicoRepository.ObtenerTodos();
        }
    }
}
