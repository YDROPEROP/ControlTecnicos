using ControlTecnicos.BLL.Servicios;
using ControlTecnicos.Models.DTOs;
using ControlTecnicos.UI.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace ControlTecnicos.UI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ISucursalService _sucursalService;
        private readonly IElementoService _elementoService;
        private readonly ITecnicoService _tecnicoService;
        private readonly IElementosTecnicoService _elementosTecnicoService;

        public HomeController(
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

        public IActionResult Index()
        {
            var sucursales = this._sucursalService.ObtenerTodos();
            var elementos = this._elementoService.ObtenerTodos();
            var tecnicos = this._tecnicoService.ObtenerTodos();

            return View("Index", new TecnicosViewModel()
            {
                Sucursales = sucursales,
                Elementos = elementos,
                Tecnicos = tecnicos,
                Tecnico = new TecnicoDTO(),
                EstaEditando = false
            });
        }

        [HttpPost]
        public async void OnSubmit([FromBody] TecnicosViewModel tecnicosViewModel)
        {
            if (tecnicosViewModel.EstaEditando)
            {
                await this._tecnicoService.Actualizar(tecnicosViewModel.Tecnico);
            } 
            else
            {
                await this._tecnicoService.Insertar(tecnicosViewModel.Tecnico);
            }
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}