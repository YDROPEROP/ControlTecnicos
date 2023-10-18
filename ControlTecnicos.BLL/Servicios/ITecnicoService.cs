using ControlTecnicos.Models.DTOs;

namespace ControlTecnicos.BLL.Servicios
{
    public interface ITecnicoService
    {
        Task<bool> Insertar(TecnicoDTO tecnico);
        Task<bool> Actualizar(TecnicoDTO tecnico);
        Task<bool> Eliminar(int id);
        TecnicoDTO Obtener(int id);
        List<TecnicoDTO> ObtenerTodos();
    }
}
