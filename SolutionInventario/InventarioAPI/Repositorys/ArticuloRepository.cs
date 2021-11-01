using InventarioAPI.Datos;
using InventarioAPI.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InventarioAPI.Repository
{
    public class ArticuloRepository : IArticuloRepository
    {
        private readonly InventarioContext db;

        public ArticuloRepository(InventarioContext dbInventario)
        {
            db = dbInventario; 
        }
        public bool Create(Articulo articulo)
        {
            db.Articulos.Add(articulo);
            return Save();
        }

        public bool Delete(Articulo articulo)
        {
            db.Articulos.Remove(articulo);
            return Save(); 
        }

        public bool ExisteArticulo(int articuloId)
        {
            return db.Articulos.Any(a => a.Idarticulo == articuloId); 
        }

        public bool ExisteArticulo(string descricpion)
        {
            return db.Articulos.Any(a => a.Descripcion.ToLower().Trim() == descricpion); 
        }

        public Articulo GetArticulo(int articuloId)
        {
            return db.Articulos.FirstOrDefault(a => a.Idarticulo == articuloId); 
        }

        public ICollection<Articulo> GetArticulos()
        {
            return (from a in db.Articulos
                    select a).ToList(); 
        }

        public bool Save()
        {
            return db.SaveChanges() > 0;    
        }

        public bool Update(Articulo articulo)
        {
            db.Articulos.Update(articulo);
            return Save(); 
        }
    }
}
