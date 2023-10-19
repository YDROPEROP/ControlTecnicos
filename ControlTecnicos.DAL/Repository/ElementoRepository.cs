using ControlTecnicos.DAL.DataContext;
using ControlTecnicos.Models.DTOs;
using ControlTecnicos.Models.Entities;

namespace ControlTecnicos.DAL.Repository
{
    public class ElementoRepository : IGenericRepository<ElementoDTO>
    {
        private readonly DBTecnicosContext _dbContext;

        public ElementoRepository(DBTecnicosContext context)
        {
            this._dbContext = context;
        }

        public async Task<bool> Actualizar(ElementoDTO elemento)
        {
            var modelo = new Elemento()
            {
                Id = elemento.Id,
                Nombre = elemento.Nombre
            };

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

        public async Task<ElementoDTO> Insertar(ElementoDTO elemento)
        {
            var modelo = new Elemento()
            {
                Nombre = elemento.Nombre
            };

            this._dbContext.Elementos.Add(modelo);
            await _dbContext.SaveChangesAsync();

            elemento.Id = modelo.Id;

            return elemento;
        }

        public ElementoDTO Obtener(int id)
        {
            var elemento = (from e in this._dbContext.Elementos
                            where e.Id == id
                            select new ElementoDTO
                            {
                                Id = e.Id,
                                Nombre = e.Nombre
                            }).FirstOrDefault();

            return elemento;
        }

        public List<ElementoDTO> ObtenerTodos()
        {
            var elementos = (from e in this._dbContext.Elementos
                            select new ElementoDTO
                            {
                                Id = e.Id,
                                Nombre = e.Nombre
                            }).ToList();

            return elementos;
        }
    }
}
