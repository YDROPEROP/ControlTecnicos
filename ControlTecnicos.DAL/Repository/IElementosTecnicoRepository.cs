using ControlTecnicos.Models.DTOs;

namespace ControlTecnicos.DAL.Repository
{
    public interface IElementosTecnicoRepository: IGenericRepository<ElementosTecnicoDTO>
    {
        Task<bool> EliminarPorTecnico(int tecnicoId);
    }
}
