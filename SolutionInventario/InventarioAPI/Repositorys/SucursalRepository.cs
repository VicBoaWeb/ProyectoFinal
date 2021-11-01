using InventarioAPI.Datos;
using InventarioAPI.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InventarioAPI.Repository
{
    public class SucursalRepository : ISucursalRepository
    {
        private readonly InventarioContext db;

        public SucursalRepository(InventarioContext dbInventario)
        {
            db = dbInventario;
        }

        public bool ActualizaSucursal(Sucursal sucursal)
        {
            db.Update(sucursal);
            return Guardar(); 
        }

        public bool CrearSucursal(Sucursal sucursal)
        {
            db.Add(sucursal);
            return Guardar(); 
        }

        public bool EliminarSucursal(Sucursal sucursal)
        {
            sucursal.Estado = "0"; 
            db.Update(sucursal);
            return Guardar(); 
        }

        public bool ExisteSucursal(int sucursalId)
        {
            return db.Sucursals.Any(s => s.Idsucursal == sucursalId);   
        }

        public bool ExisteSucursal(string sucursalNombre)
        {
            return db.Sucursals.Any(s => s.Nombre.ToLower().Trim() == sucursalNombre);
        }

        public Sucursal GetSucursal(int sucursalId)
        {
            return db.Sucursals.FirstOrDefault(s => s.Idsucursal == sucursalId); 
        }

        public ICollection<Sucursal> GetSucursals()
        {
            return db.Sucursals.OrderBy(s => s.Estado == "1").ToList(); 
        }

        public bool Guardar()
        {
            return db.SaveChanges() > 0 ? true : false; 
        }
    }
}
