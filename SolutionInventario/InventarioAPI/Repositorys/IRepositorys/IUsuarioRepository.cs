using InventarioAPI.Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InventarioAPI.Repository.IRepository
{
    public interface IUsuarioRepository
    {
        ICollection<Usuario> GetUsuarios();
        Usuario GetUsuario(string user);
        Usuario Login(string user, string password);  
        bool ExisteUsuario(string user);
        bool ExistePassword(string password); 
        bool Create(Usuario usuario);
        bool Update(Usuario usuario);
        bool Delete(Usuario usuario);
        bool Save(); 
    }
}
