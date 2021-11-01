using InventarioAPI.Datos;
using InventarioAPI.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InventarioAPI.Repository
{
    public class TipoArticuloRepository : ITipoArticuloRepository
    {
        private readonly InventarioContext db;

        public TipoArticuloRepository(InventarioContext dbInventario)
        {
            db = dbInventario; 
        }
        public bool Create(TipoArticulo tipoArticulo)
        {
            db.TipoArticulos.Add(tipoArticulo);
            return Save(); 
        }

        public bool Delete(TipoArticulo tipoArticulo)
        {
            tipoArticulo.Estado = "0";
            db.TipoArticulos.Update(tipoArticulo);
            return Save(); 
        }

        public bool ExisteTipoArticulo(int tipoId)
        {
            return db.TipoArticulos.Any(t => t.IdtipoArticulo == tipoId); 
        }

        public bool ExisteTipoArticulo(string descripcion)
        {
            return db.TipoArticulos.Any(t => t.Descripcion.ToLower().Trim() == descripcion); 
        }

        public TipoArticulo GetTipoArticulo(int tipoId)
        {
            return db.TipoArticulos.FirstOrDefault(t => t.IdtipoArticulo == tipoId); 
        }

        public ICollection<TipoArticulo> GetTipoArticulos()
        {
            return db.TipoArticulos.OrderBy(t => t.Estado == "1").ToList(); 
        }

        public bool Save()
        {
            return db.SaveChanges() > 0 ? true : false; 
        }

        public bool Update(TipoArticulo tipoArticulo)
        {
            db.TipoArticulos.Update(tipoArticulo);
            return Save(); 
        }
    }
}
