using ControlTecnicos.DAL.DataContext;
using ControlTecnicos.Models;

namespace ControlTecnicos.DAL.Repository
{
    public class SucarsalRepository : IGenericRepository<Sucursal>
    {
        private readonly DBTecnicosContext _dbContext;

        public SucarsalRepository(DBTecnicosContext context) 
        {
            this._dbContext = context;
        }

        public async Task<bool> Actualizar(Sucursal modelo)
        {
            this._dbContext.Sucursales.Update(modelo);
            await _dbContext.SaveChangesAsync();

            return true;
        }

        public async Task<bool> Eliminar(int id)
        {
            var modelo = this._dbContext.Sucursales.First(sucursal => sucursal.Id == id);
            this._dbContext.Sucursales.Remove(modelo);
            await _dbContext.SaveChangesAsync();

            return true;
        }

        public async Task<bool> Insertar(Sucursal modelo)
        {
            this._dbContext.Sucursales.Add(modelo);
            await _dbContext.SaveChangesAsync();

            return true;
        }

        public async Task<Sucursal> Obtener(int id)
        {
            return await this._dbContext.Sucursales.FindAsync(id);
        }

        public async Task<IQueryable<Sucursal>> ObtenerTodos()
        {
            return this._dbContext.Sucursales;
        }
    }
}
