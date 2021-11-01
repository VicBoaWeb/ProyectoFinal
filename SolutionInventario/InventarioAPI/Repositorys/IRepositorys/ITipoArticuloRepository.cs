using InventarioAPI.Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InventarioAPI.Repository.IRepository
{
    public interface ITipoArticuloRepository 
    {
        ICollection<TipoArticulo> GetTipoArticulos();
        TipoArticulo GetTipoArticulo(int tipoId);
        bool ExisteTipoArticulo(int tipoId);
        bool ExisteTipoArticulo(string descripcion);
        bool Create(TipoArticulo tipoArticulo);
        bool Update(TipoArticulo tipoArticulo);
        bool Delete(TipoArticulo tipoArticulo);
        bool Save(); 
    }
}
