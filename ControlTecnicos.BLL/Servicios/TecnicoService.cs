using ControlTecnicos.DAL.Repository;
using ControlTecnicos.Models.DTOs;

namespace ControlTecnicos.BLL.Servicios
{
    public class TecnicoService : ITecnicoService
    {
        private readonly IGenericRepository<TecnicoDTO> _tecnicoRepository;
        private readonly IElementosTecnicoService _elementosTecnicoService;

        public TecnicoService(
            IGenericRepository<TecnicoDTO> tecnicoRepository,
            IElementosTecnicoService elementosTecnicoService) 
        { 
            this._tecnicoRepository = tecnicoRepository;
            this._elementosTecnicoService = elementosTecnicoService;
        }

        public async Task<bool> Actualizar(TecnicoCompletoDTO tecnicoCompleto)
        {
            try
            {
                await this._tecnicoRepository.Actualizar(tecnicoCompleto.Tecnico);

                return await this._elementosTecnicoService.Insertar(tecnicoCompleto.ElementosTecnico);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public async Task<bool> Eliminar(int id)
        {
            try
            {
                await this._elementosTecnicoService.EliminarPorTecnico(id);
                return await this._tecnicoRepository.Eliminar(id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public async Task<bool> Insertar(TecnicoCompletoDTO tecnicoCompleto)
        {
            try
            {
                var tecnicoCreado = await this._tecnicoRepository.Insertar(tecnicoCompleto.Tecnico);

                foreach (var elementoTecnico in tecnicoCompleto.ElementosTecnico)
                {
                    elementoTecnico.TecnicoId = tecnicoCreado.Id;
                }

                return await this._elementosTecnicoService.Insertar(tecnicoCompleto.ElementosTecnico);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public TecnicoDTO Obtener(int id)
        {
            try
            {
                return this._tecnicoRepository.Obtener(id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public List<TecnicoDTO> ObtenerTodos()
        {
            try
            {
                return this._tecnicoRepository.ObtenerTodos();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
    }
}
