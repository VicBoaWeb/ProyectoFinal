using InventarioAPI.Datos;
using InventarioAPI.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InventarioAPI.Repository
{
    public class ProveedorRepository : IProveedorRepository
    {
        private readonly InventarioContext db;

        public ProveedorRepository(InventarioContext dbInventario)
        {
            db = dbInventario; 
        }

        public bool Create(Proveedor proveedor)
        {
            db.Proveedors.Add(proveedor);
            return Save(); 
        }

        public bool Delete(Proveedor proveedor)
        {
            proveedor.Estado = "0";
            db.Proveedors.Update(proveedor);
            return Save(); 
        }

        public bool ExisteProveedor(int proveedorId)
        {
            return db.Proveedors.Any(p => p.Idproveedor == proveedorId); 
        }

        public bool ExisteProveedor(string nombre)
        {
            return db.Proveedors.Any(p => p.Nombre.ToLower().Trim() == nombre); 
        }

        public Proveedor GetProveedor(int proveedorId)
        {
            return db.Proveedors.FirstOrDefault(p => p.Idproveedor == proveedorId);  
        }

        public ICollection<Proveedor> GetProveedors()
        {
            return db.Proveedors.OrderBy(p => p.Estado == "1").ToList(); 
        }

        public bool Save()
        {
            return db.SaveChanges() > 0 ? true : false;  
        }

        public bool Update(Proveedor proveedor)
        {
            db.Proveedors.Update(proveedor);
            return Save(); 
        }
    }
}
