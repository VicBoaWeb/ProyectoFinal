using InventarioAPI.Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InventarioAPI.Repository.IRepository
{
    public interface ISucursalRepository
    {
        ICollection<Sucursal> GetSucursals();
        Sucursal GetSucursal(int sucursalId);
        bool ExisteSucursal(int sucursalId);
        bool ExisteSucursal(string sucursalNombre); 
        bool CrearSucursal(Sucursal sucursal);
        bool ActualizaSucursal(Sucursal sucursal);
        bool EliminarSucursal(Sucursal sucursal);
        bool Guardar(); 
    }
}
