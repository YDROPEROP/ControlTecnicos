using ControlTecnicos.BLL.Servicios;
using ControlTecnicos.Models.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ControlTecnicos.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TecnicosController : ControllerBase
    {
        private readonly ISucursalService _sucursalService;
        private readonly IElementoService _elementoService;
        private readonly ITecnicoService _tecnicoService;
        private readonly IElementosTecnicoService _elementosTecnicoService;

        public TecnicosController(
            ISucursalService sucursalService,
            IElementoService elementoService,
            ITecnicoService tecnicoService,
            IElementosTecnicoService elementosTecnicoService)
        {
            this._sucursalService = sucursalService;
            this._elementoService = elementoService;
            this._tecnicoService = tecnicoService;
            this._elementosTecnicoService = elementosTecnicoService;
        }

        [HttpGet]
        public List<TecnicoDTO> ObtenerTecnicos()
        {
            return this._tecnicoService.ObtenerTodos();
        }

        [HttpGet("sucursales")]
        public List<SucursalDTO> ObtenerSucursales()
        {
            return this._sucursalService.ObtenerTodos();
        }

        [HttpGet("elementos")]
        public List<ElementoDTO> ObtenerElementos()
        {
            return this._elementoService.ObtenerTodos();
        }

        [HttpPost("elementos-tecnico")]
        public Task<bool> CrearElementosTecnico([FromBody] List<ElementosTecnicoDTO> elementosTecnico)
        {
            return this._elementosTecnicoService.Insertar(elementosTecnico);
        }

        [HttpPost]
        public Task<bool> CrearTecnico([FromBody] TecnicoDTO tecnico)
        {
            return this._tecnicoService.Insertar(tecnico);
        }

        [HttpPut]
        public Task<bool> ActualizarTecnico([FromBody] TecnicoDTO tecnico)
        {
            return this._tecnicoService.Actualizar(tecnico);
        }

        [HttpDelete]
        public Task<bool> EliminarTecnico(int id)
        {
            return this._tecnicoService.Eliminar(id);
        }
    }
}
