using InventarioAPI.Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InventarioAPI.Repository.IRepository
{
    public interface IClienteRepository
    {
        ICollection<Cliente> GetClientes();
        Cliente GetCliente(int clienteId);
        bool ExisteCliente(int clienteid);
        bool ExisteCliente(string nombre);
        bool Create(Cliente cliente);
        bool Update(Cliente cliente);
        bool Delete(Cliente cliente);
        bool Save(); 
    }
}
