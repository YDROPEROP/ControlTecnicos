using ControlTecnicos.DAL.DataContext;
using ControlTecnicos.Models;

namespace ControlTecnicos.DAL.Repository
{
    public class TecnicoRepository : IGenericRepository<Tecnico>
    {
        private readonly DBTecnicosContext _dbContext;

        public TecnicoRepository(DBTecnicosContext context) 
        { 
            this._dbContext = context;
        }

        public async Task<bool> Actualizar(Tecnico modelo)
        {
            this._dbContext.Tecnicos.Update(modelo);
            await _dbContext.SaveChangesAsync();

            return true;
        }

        public async Task<bool> Eliminar(int id)
        {
            var modelo = this._dbContext.Tecnicos.First(tecnico => tecnico.Id == id);
            this._dbContext.Tecnicos.Remove(modelo);
            await _dbContext.SaveChangesAsync();

            return true;
        }

        public async Task<bool> Insertar(Tecnico modelo)
        {
            this._dbContext.Tecnicos.Add(modelo);
            await _dbContext.SaveChangesAsync();

            return true;
        }

        public async Task<Tecnico> Obtener(int id)
        {
            return await this._dbContext.Tecnicos.FindAsync(id);
        }

        public async Task<IQueryable<Tecnico>> ObtenerTodos()
        {
            return this._dbContext.Tecnicos;
        }
    }
}
