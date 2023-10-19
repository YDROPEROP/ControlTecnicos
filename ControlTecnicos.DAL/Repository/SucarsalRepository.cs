using ControlTecnicos.DAL.DataContext;
using ControlTecnicos.Models.DTOs;
using ControlTecnicos.Models.Entities;

namespace ControlTecnicos.DAL.Repository
{
    public class SucarsalRepository : IGenericRepository<SucursalDTO>
    {
        private readonly DBTecnicosContext _dbContext;

        public SucarsalRepository(DBTecnicosContext context) 
        {
            this._dbContext = context;
        }

        public async Task<bool> Actualizar(SucursalDTO sucursal)
        {
            var modelo = new Sucursal()
            {
                Id = sucursal.Id,
                Nombre = sucursal.Nombre
            };

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

        public async Task<SucursalDTO> Insertar(SucursalDTO sucursal)
        {
            var modelo = new Sucursal()
            {
                Nombre = sucursal.Nombre
            };

            this._dbContext.Sucursales.Add(modelo);
            await _dbContext.SaveChangesAsync();

            sucursal.Id = modelo.Id;

            return sucursal;
        }

        public SucursalDTO Obtener(int id)
        {
            var sucursal = (from s in this._dbContext.Sucursales
                            where s.Id == id
                            select new SucursalDTO
                            {
                                Id = s.Id,
                                Nombre = s.Nombre
                            }).FirstOrDefault();

            return sucursal;
        }

        public List<SucursalDTO> ObtenerTodos()
        {
            var sucursales = (from s in this._dbContext.Sucursales
                            select new SucursalDTO
                            {
                                Id = s.Id,
                                Nombre = s.Nombre
                            }).ToList();

            return sucursales;
        }
    }
}
