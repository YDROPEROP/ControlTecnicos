using ControlTecnicos.Models.DTOs;

namespace ControlTecnicos.BLL.Servicios
{
    public interface ITecnicoService
    {
        Task<bool> Insertar(TecnicoCompletoDTO tecnicoCompleto);
        Task<bool> Actualizar(TecnicoCompletoDTO tecnicoCompleto);
        Task<bool> Eliminar(int id);
        TecnicoDTO Obtener(int id);
        List<TecnicoDTO> ObtenerTodos();
    }
}
