using ControlTecnicos.DAL.DataContext;
using ControlTecnicos.Models.DTOs;
using ControlTecnicos.Models.Entities;

namespace ControlTecnicos.DAL.Repository
{
    public class TecnicoRepository : IGenericRepository<TecnicoDTO>
    {
        private readonly DBTecnicosContext _dbContext;

        public TecnicoRepository(DBTecnicosContext context) 
        { 
            this._dbContext = context;
        }

        public async Task<bool> Actualizar(TecnicoDTO tecnico)
        {
            var modelo = new Tecnico()
            {
                Id = tecnico.Id,
                Nombre = tecnico.Nombre,
                Codigo = tecnico.Codigo,
                SueldoBase = tecnico.SueldoBase,
                SucursalId = tecnico.Sucursal.Id,
                FechaModificacion = new DateTime()
            };

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

        public async Task<bool> Insertar(TecnicoDTO tecnico)
        {
            var modelo = new Tecnico()
            {
                Nombre = tecnico.Nombre,
                Codigo = tecnico.Codigo,
                SueldoBase = tecnico.SueldoBase,
                SucursalId = tecnico.Sucursal.Id
            };

            this._dbContext.Tecnicos.Add(modelo);
            await _dbContext.SaveChangesAsync();

            return true;
        }

        public TecnicoDTO Obtener(int id)
        {
            var tecnico = (from t in this._dbContext.Tecnicos
                          join s in this._dbContext.Sucursales on t.SucursalId equals s.Id
                          where t.Id == id
                          select new TecnicoDTO
                          {
                              Id = t.Id,
                              Nombre = t.Nombre,
                              Codigo = t.Codigo,
                              SueldoBase = t.SueldoBase,
                              Sucursal = s
                          }).FirstOrDefault();

            return tecnico;
        }

        public List<TecnicoDTO> ObtenerTodos()
        {
            var tecnicos = (from t in this._dbContext.Tecnicos
                            join s in this._dbContext.Sucursales on t.SucursalId equals s.Id
                            select new TecnicoDTO
                            {
                                Id = t.Id,
                                Nombre = t.Nombre,
                                Codigo = t.Codigo,
                                SueldoBase = t.SueldoBase,
                                Sucursal = s
                            }).ToList();

            var elementosTecnicos = (from et in this._dbContext.ElementosTecnicos
                                     join e in this._dbContext.Elementos on et.ElementoId equals e.Id
                                     select new ElementosTecnicoDTO
                                     {
                                         Id = et.Id,
                                         TecnicoId = et.TecnicoId,
                                         Cantidad = et.Cantidad,
                                         Elemento = e
                                     });

            foreach (var t in tecnicos)
            {
                t.ElementosTecnicos = elementosTecnicos.Where(et => et.TecnicoId == t.Id).ToList();
            }

            return tecnicos;
        }
    }
}
