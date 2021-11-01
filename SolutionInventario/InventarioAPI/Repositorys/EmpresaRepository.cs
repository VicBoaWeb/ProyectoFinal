using InventarioAPI.Datos;
using InventarioAPI.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InventarioAPI.Repository
{
    public class EmpresaRepository : IEmpresaRepositoy 
    {
        private readonly InventarioContext db; 

        public EmpresaRepository(InventarioContext dbInventario)
        {
            db = dbInventario; 
        }

        public bool Actualizar(Empresa empresa)
        {
            db.Empresas.Update(empresa);
            return Guardar(); 
        }

        public bool CrearEmpresa(Empresa empresa)
        {
            db.Empresas.Add(empresa);
            return Guardar(); 
        }

        public bool Eliminar(Empresa empresa)
        {
            empresa.Estado = "0";
            db.Empresas.Update(empresa);  
            return Guardar(); 
        }

        public bool ExisteEmpresa(int empresaId)
        {
            return db.Empresas.Any(e => e.Idempresa == empresaId); 
        }

        public bool ExisteEmpresa(string nombre)
        {
            bool valor = db.Empresas.Any(e => e.Nombre.ToLower().Trim() == nombre);
            return valor; 
        }

        public Empresa GetEmpresa(int empresaId)
        {
            return db.Empresas.FirstOrDefault(e => e.Idempresa == empresaId); 
        }

        public ICollection<Empresa> GetEmpresas()
        {
            return db.Empresas.OrderBy(e => e.Estado == "1").ToList();  
        }

        public bool Guardar()
        {
            return db.SaveChanges() >=0 ? true : false; 
        }
    }
}
