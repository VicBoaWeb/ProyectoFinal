using InventarioAPI.Datos;
using InventarioAPI.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InventarioAPI.Repository
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly InventarioContext db;

        public ClienteRepository(InventarioContext dbInventario)
        {
            db = dbInventario; 
        }
        public bool Create(Cliente cliente)
        {
            db.Clientes.Add(cliente);
            return Save(); 
        }

        public bool Delete(Cliente cliente)
        {
            cliente.Estado = "0";
            db.Clientes.Update(cliente);
            return Save(); 
        }

        public bool ExisteCliente(int clienteid)
        {
            return db.Clientes.Any(c => c.Idcliente == clienteid); 
        }

        public bool ExisteCliente(string nombre)
        {
            return db.Clientes.Any(c => c.Nombre.ToLower().Trim() == nombre); 
        }

        public Cliente GetCliente(int clienteId)
        {
            return db.Clientes.FirstOrDefault(c => c.Idcliente == clienteId); 
        }

        public ICollection<Cliente> GetClientes()
        {
            return (from c in db.Clientes where c.Estado =="1" select c).ToList(); 
        }

        public bool Save()
        {
            return db.SaveChanges() > 0; 
        }

        public bool Update(Cliente cliente)
        {
            db.Clientes.Update(cliente);
            return Save(); 
        }
    }
}
