using ControlTecnicos.DAL.Repository;
using ControlTecnicos.Models.DTOs;

namespace ControlTecnicos.BLL.Servicios
{
    public class ElementoService : IElementoService
    {
        private readonly IGenericRepository<ElementoDTO> _elementoRepository;

        public ElementoService(IGenericRepository<ElementoDTO> elementoRepository) 
        { 
            this._elementoRepository = elementoRepository;
        }

        public async Task<bool> Actualizar(ElementoDTO elemento)
        {
            return await this._elementoRepository.Actualizar(elemento);
        }

        public async Task<bool> Eliminar(int id)
        {
            return await this._elementoRepository.Eliminar(id);
        }

        public async Task<ElementoDTO> Insertar(ElementoDTO elemento)
        {
            return await this._elementoRepository.Insertar(elemento);
        }

        public ElementoDTO Obtener(int id)
        {
            return this._elementoRepository.Obtener(id);
        }

        public List<ElementoDTO> ObtenerTodos()
        {
            return this._elementoRepository.ObtenerTodos();
        }
    }
}
