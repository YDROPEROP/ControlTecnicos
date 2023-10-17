using ControlTecnicos.DAL.DataContext;
using ControlTecnicos.Models;

namespace ControlTecnicos.DAL.Repository
{
    public class ElementosTecnicoRepository : IGenericRepository<ElementosTecnico>
    {
        private readonly DBTecnicosContext _dbContext;

        public ElementosTecnicoRepository(DBTecnicosContext dbContext) 
        { 
        this._dbContext = dbContext;
        }

        public async Task<bool> Actualizar(ElementosTecnico modelo)
        {
            this._dbContext.ElementosTecnicos.Update(modelo);
            await _dbContext.SaveChangesAsync();

            return true;
        }

        public async Task<bool> Eliminar(int id)
        {
            var modelo = this._dbContext.ElementosTecnicos.First(elemento => elemento.Id == id);
            this._dbContext.ElementosTecnicos.Remove(modelo);
            await _dbContext.SaveChangesAsync();

            return true;
        }

        public async Task<bool> Insertar(ElementosTecnico modelo)
        {
            this._dbContext.ElementosTecnicos.Add(modelo);
            await _dbContext.SaveChangesAsync();

            return true;
        }

        public async Task<ElementosTecnico> Obtener(int id)
        {
            return await this._dbContext.ElementosTecnicos.FindAsync(id);
        }

        public async Task<IQueryable<ElementosTecnico>> ObtenerTodos()
        {
            return this._dbContext.ElementosTecnicos;
        }
    }
}
