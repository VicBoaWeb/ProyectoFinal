using InventarioAPI.Datos;
using InventarioAPI.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InventarioAPI.Repository
{
    public class BodegaRepository : IBodegaRepository
    {
        private readonly InventarioContext db;

        public BodegaRepository(InventarioContext dbInventario)
        {
            db = dbInventario;
        }
        public bool Create(Bodega bodega)
        {
            db.Bodegas.Add(bodega);
            return Save();
        }

        public bool Delete(Bodega bodega)
        {
            bodega.Estado = "0";
            db.Bodegas.Update(bodega);
            return Save(); 
        }

        public bool ExisteBodega(int bodegaId)
        {
            return db.Bodegas.Any(b => b.Idbodega == bodegaId);
        }

        public bool ExisteBodega(string descripcion)
        {
            return db.Bodegas.Any(b => b.Descripcion.ToLower().Trim() == descripcion); 
        }

        public Bodega GetBodega(int bodegaId)
        {
            return db.Bodegas.FirstOrDefault(b => b.Idbodega == bodegaId); 
        }

        public ICollection<Bodega> GetBodegas()
        {
            return (from b in db.Bodegas where b.Estado == "1" select b).ToList(); 
        }

        public bool Save()
        {
            return db.SaveChanges() > 0; 
        }

        public bool Update(Bodega bodega)
        {
            db.Bodegas.Update(bodega);
            return Save(); 
        }
    }
}
