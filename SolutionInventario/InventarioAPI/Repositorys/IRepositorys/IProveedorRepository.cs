using InventarioAPI.Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InventarioAPI.Repository.IRepository
{
    public interface IProveedorRepository
    {
        ICollection<Proveedor> GetProveedors(); 
        Proveedor GetProveedor(int proveedorId); 
        bool ExisteProveedor(int proveedorId);
        bool ExisteProveedor(string nombre);
        bool Create(Proveedor proveedor);
        bool Update(Proveedor proveedor);
        bool Delete(Proveedor proveedor);
        bool Save(); 
    }
}
