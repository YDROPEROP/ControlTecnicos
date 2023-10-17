using ControlTecnicos.DAL.Repository;
using ControlTecnicos.Models;

namespace ControlTecnicos.BLL.Servicios
{
    public class ElementoService : IElementoService
    {
        private readonly IGenericRepository<Elemento> _elementoRepository;

        public ElementoService(IGenericRepository<Elemento> elementoRepository) 
        { 
            this._elementoRepository = elementoRepository;
        }

        public async Task<bool> Actualizar(Elemento modelo)
        {
            return await this._elementoRepository.Actualizar(modelo);
        }

        public async Task<bool> Eliminar(int id)
        {
            return await this._elementoRepository.Eliminar(id);
        }

        public async Task<bool> Insertar(Elemento modelo)
        {
            return await this._elementoRepository.Insertar(modelo);
        }

        public async Task<Elemento> Obtener(int id)
        {
            return await this._elementoRepository.Obtener(id);
        }

        public async Task<IQueryable<Elemento>> ObtenerTodos()
        {
            return await this._elementoRepository.ObtenerTodos();
        }
    }
}
