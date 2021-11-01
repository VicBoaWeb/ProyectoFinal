using InventarioAPI.Datos;
using InventarioAPI.Repositorys.IRepositorys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InventarioAPI.Repositorys
{
    public class CompraRepository : ICompraRepository
    {
        private readonly InventarioContext db;

        public CompraRepository(InventarioContext inventarioContext)
        {
            db = inventarioContext; 
        }
        public bool Create(Compra compra)
        {
            db.Compras.Add(compra);
            return Save();
        }

        public bool Delete(Compra compra)
        {
            db.Compras.Remove(compra);
            return Save(); 
        }

        public bool ExisteCompra(int compraId)
        {
            return db.Compras.Any(c => c.Idcompra == compraId);
        }

        public Compra GetCompra(int compraId)
        {
            return db.Compras.FirstOrDefault(c => c.Idcompra == compraId);
        }

        public ICollection<Compra> GetCompras()
        {
            return (from c in db.Compras select c).ToList(); 
        }

        public bool Save()
        {
            return db.SaveChanges() > 0; 
        }

        public bool Update(Compra compra)
        {
            db.Compras.Update(compra);
            return Save(); 
        }
    }
}
