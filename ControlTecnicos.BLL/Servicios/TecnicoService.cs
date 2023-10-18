using ControlTecnicos.DAL.Repository;
using ControlTecnicos.Models.DTOs;

namespace ControlTecnicos.BLL.Servicios
{
    public class TecnicoService : ITecnicoService
    {
        private readonly IGenericRepository<TecnicoDTO> _tecnicoRepository;

        public TecnicoService(IGenericRepository<TecnicoDTO> tecnicoRepository) 
        { 
            this._tecnicoRepository = tecnicoRepository;
        }

        public async Task<bool> Actualizar(TecnicoDTO tecnico)
        {
            return await this._tecnicoRepository.Actualizar(tecnico);
        }

        public async Task<bool> Eliminar(int id)
        {
            return await this._tecnicoRepository.Eliminar(id);
        }

        public async Task<bool> Insertar(TecnicoDTO tecnico)
        {
            return await this._tecnicoRepository.Insertar(tecnico);
        }

        public TecnicoDTO Obtener(int id)
        {
            return this._tecnicoRepository.Obtener(id);
        }

        public List<TecnicoDTO> ObtenerTodos()
        {
            return this._tecnicoRepository.ObtenerTodos();
        }
    }
}
