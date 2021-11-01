using InventarioAPI.Datos;
using InventarioAPI.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InventarioAPI.Repository
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly InventarioContext db;

        public UsuarioRepository(InventarioContext dbInventario)
        {
            db = dbInventario; 
        }
        public bool Create(Usuario usuario)
        {
            db.Usuarios.Add(usuario);
            return Save();
        }

        public bool Delete(Usuario usuario)
        {
            db.Usuarios.Remove(usuario);
            return Save(); 
        }

        public bool ExistePassword(string password)
        {
            return db.Usuarios.Any(u => u.Password == password); 
        }

        public bool ExisteUsuario(string user)
        {
            return db.Usuarios.Any(u => u.User.ToLower().Trim() == user); 
        }

        public Usuario GetUsuario(string user)
        {
            return db.Usuarios.FirstOrDefault(u => u.User == user); 
        }

        public ICollection<Usuario> GetUsuarios()
        {
            return (from u in db.Usuarios select u).ToList(); 
        }

        //public Usuario Login(string usuario, string pasword)
        ////{
        ////    if(!ExisteUsuario(usuario) && ExistePassword(pasword))
        ////    {
        ////        return null; 
        ////    }

        ////    return 
        //}

        public bool Save()
        {
            return db.SaveChanges() > 0;
        }

        public bool Update(Usuario usuario)
        {
            db.Usuarios.Update(usuario);
            return Save(); 
        }
    }
}
