using ControlTecnicos.DAL.DataContext;
using ControlTecnicos.Models.Entities;
using ControlTecnicos.Models.DTOs;

namespace ControlTecnicos.DAL.Repository
{
    public class ElementosTecnicoRepository : IElementosTecnicoRepository
    {
        private readonly DBTecnicosContext _dbContext;

        public ElementosTecnicoRepository(DBTecnicosContext dbContext) 
        { 
            this._dbContext = dbContext;
        }

        public async Task<bool> Actualizar(ElementosTecnicoDTO elementosTecnico)
        {
            var modelo = new ElementosTecnico()
            {
                Id = elementosTecnico.Id,
                TecnicoId = elementosTecnico.TecnicoId,
                ElementoId = elementosTecnico.ElementoId,
                Cantidad = elementosTecnico.Cantidad,
                FechaModificacion = DateTime.Now
            };

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

        public async Task<bool> EliminarPorTecnico(int tecnicoId)
        {
            var modelos = this._dbContext.ElementosTecnicos.Where(elemento => elemento.TecnicoId == tecnicoId);
            this._dbContext.ElementosTecnicos.RemoveRange(modelos);
            await _dbContext.SaveChangesAsync();

            return true;
        }

        public async Task<ElementosTecnicoDTO> Insertar(ElementosTecnicoDTO elementosTecnico)
        {
            var modelo = new ElementosTecnico()
            {
                TecnicoId = elementosTecnico.TecnicoId,
                ElementoId = elementosTecnico.ElementoId,
                Cantidad = elementosTecnico.Cantidad
            };

            this._dbContext.ElementosTecnicos.Add(modelo);
            await _dbContext.SaveChangesAsync();

            elementosTecnico.Id = modelo.Id;

            return elementosTecnico;
        }

        public ElementosTecnicoDTO Obtener(int id)
        {
            var elementosTecnico = (from et in this._dbContext.ElementosTecnicos
                                    where et.Id == id
                                    select new ElementosTecnicoDTO
                                    {
                                        Id = et.Id,
                                        TecnicoId = et.TecnicoId,
                                        ElementoId = et.ElementoId,
                                        FechaCreacion = et.FechaCreacion,
                                        Cantidad = et.Cantidad
                                    }).FirstOrDefault();
            
            return elementosTecnico;
        }

        public List<ElementosTecnicoDTO> ObtenerTodos()
        {
            var elementosTecnicos = (from et in this._dbContext.ElementosTecnicos
                                    select new ElementosTecnicoDTO
                                    {
                                        Id = et.Id,
                                        TecnicoId = et.TecnicoId,
                                        ElementoId = et.ElementoId,
                                        FechaCreacion = et.FechaCreacion,
                                        Cantidad = et.Cantidad
                                    }).ToList();

            return elementosTecnicos;
        }
    }
}
