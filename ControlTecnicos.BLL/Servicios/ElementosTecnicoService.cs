using ControlTecnicos.DAL.Repository;
using ControlTecnicos.Models.DTOs;
using ControlTecnicos.Models.Entities;

namespace ControlTecnicos.BLL.Servicios
{
    public class ElementosTecnicoService : IElementosTecnicoService
    {
        private readonly IElementosTecnicoRepository _elementosTecnicoRepository;

        public ElementosTecnicoService(IElementosTecnicoRepository elementosTecnicoRepository) 
        { 
            this._elementosTecnicoRepository = elementosTecnicoRepository;
        }

        public async Task<bool> Actualizar(ElementosTecnicoDTO elementosTecnico)
        {
            return await this._elementosTecnicoRepository.Actualizar(elementosTecnico);
        }

        public async Task<bool> Eliminar(int id)
        {
            return await this._elementosTecnicoRepository.Eliminar(id);
        }

        public async Task<bool> EliminarPorTecnico(int tecnicoId)
        {
            return await this._elementosTecnicoRepository.EliminarPorTecnico(tecnicoId);
        }

        public async Task<bool> Insertar(List<ElementosTecnicoDTO> elementosTecnico)
        {
            foreach (var elementoTecnico in elementosTecnico)
            {
                var elementoTecnicoEncontrado = this.ObtenerTodos().Find(et => et.TecnicoId == elementoTecnico.TecnicoId && et.ElementoId == elementoTecnico.ElementoId);
                if (elementoTecnicoEncontrado is not null)
                {
                    elementoTecnicoEncontrado.Cantidad = elementoTecnico.Cantidad;
                    await this._elementosTecnicoRepository.Actualizar(elementoTecnicoEncontrado);
                } else
                {
                    await this._elementosTecnicoRepository.Insertar(elementoTecnico);
                }
            }

            return true;
        }

        public ElementosTecnicoDTO Obtener(int id)
        {
            return this._elementosTecnicoRepository.Obtener(id);
        }

        public List<ElementosTecnicoDTO> ObtenerTodos()
        {
            return this._elementosTecnicoRepository.ObtenerTodos();
        }
    }
}
