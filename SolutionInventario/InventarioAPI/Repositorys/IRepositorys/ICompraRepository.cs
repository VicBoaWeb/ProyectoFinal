using InventarioAPI.Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InventarioAPI.Repositorys.IRepositorys
{
    public interface ICompraRepository
    {
        ICollection<Compra> GetCompras();
        Compra GetCompra(int compraId);
        bool ExisteCompra(int compraId);
        bool Create(Compra compra);
        bool Update(Compra compra); 
        bool Delete(Compra compra);
        bool Save(); 
    }
}
