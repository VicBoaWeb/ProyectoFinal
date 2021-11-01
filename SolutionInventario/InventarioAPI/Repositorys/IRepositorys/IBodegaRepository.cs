using InventarioAPI.Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InventarioAPI.Repository.IRepository
{
    public interface IBodegaRepository
    {
        ICollection<Bodega> GetBodegas();
        Bodega GetBodega(int bodegaId);
        bool ExisteBodega(int bodegaId);
        bool ExisteBodega(string descripcion);
        bool Create(Bodega bodega);
        bool Update(Bodega bodega);
        bool Delete(Bodega bodega);
        bool Save(); 
    }
}
