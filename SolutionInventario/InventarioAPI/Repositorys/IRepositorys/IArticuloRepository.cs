using InventarioAPI.Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InventarioAPI.Repository.IRepository
{
    public interface IArticuloRepository
    {
        ICollection<Articulo> GetArticulos();
        Articulo GetArticulo(int articuloId); 
        bool ExisteArticulo(int articuloId);
        bool ExisteArticulo(string descricpion);
        bool Create(Articulo articulo);
        bool Update(Articulo articulo);
        bool Delete(Articulo articulo);
        bool Save(); 
    }
}
