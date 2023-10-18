namespace ControlTecnicos.DAL.Repository
{
    public interface IGenericRepository<T> where T : class
    {
        Task<bool> Insertar(T dto);
        Task<bool> Actualizar(T dto);
        Task<bool> Eliminar(int id);
        T Obtener(int id);
        List<T> ObtenerTodos();
    }
}
