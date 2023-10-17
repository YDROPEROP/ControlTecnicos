using ControlTecnicos.DAL.Repository;
using ControlTecnicos.Models;

namespace ControlTecnicos.BLL.Servicios
{
    public class ElementosTecnicoService : IElementosTecnicoService
    {
        private readonly IGenericRepository<ElementosTecnico> _elementosTecnicoRepository;

        public ElementosTecnicoService(IGenericRepository<ElementosTecnico> elementosTecnicoRepository) 
        { 
            this._elementosTecnicoRepository = elementosTecnicoRepository;
        }

        public async Task<bool> Actualizar(ElementosTecnico modelo)
        {
            return await this._elementosTecnicoRepository.Actualizar(modelo);
        }

        public async Task<bool> Eliminar(int id)
        {
            return await this._elementosTecnicoRepository.Eliminar(id);
        }

        public async Task<bool> Insertar(ElementosTecnico modelo)
        {
            return await this._elementosTecnicoRepository.Insertar(modelo);
        }

        public async Task<ElementosTecnico> Obtener(int id)
        {
            return await this._elementosTecnicoRepository.Obtener(id);
        }

        public async Task<IQueryable<ElementosTecnico>> ObtenerTodos()
        {
            return await this._elementosTecnicoRepository.ObtenerTodos();
        }
    }
}
