using ControlTecnicos.DAL.DataContext;
using ControlTecnicos.Models;

namespace ControlTecnicos.DAL.Repository
{
    public class ElementoRepository : IGenericRepository<Elemento>
    {
        private readonly DBTecnicosContext _dbContext;

        public ElementoRepository(DBTecnicosContext context)
        {
            this._dbContext = context;
        }
        public async Task<bool> Actualizar(Elemento modelo)
        {
            this._dbContext.Elementos.Update(modelo);
            await _dbContext.SaveChangesAsync();

            return true;
        }

        public async Task<bool> Eliminar(int id)
        {
            var modelo = this._dbContext.Elementos.First(elemento => elemento.Id == id);
            this._dbContext.Elementos.Remove(modelo);
            await _dbContext.SaveChangesAsync();

            return true;
        }

        public async Task<bool> Insertar(Elemento modelo)
        {
            this._dbContext.Elementos.Add(modelo);
            await _dbContext.SaveChangesAsync();

            return true;
        }

        public async Task<Elemento> Obtener(int id)
        {
            return await this._dbContext.Elementos.FindAsync(id);
        }

        public async Task<IQueryable<Elemento>> ObtenerTodos()
        {
            return this._dbContext.Elementos;
        }
    }
}
