using InventarioAPI.Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InventarioAPI.Repository.IRepository
{
    public interface IEmpresaRepositoy
    {
        ICollection<Empresa> GetEmpresas();
        Empresa GetEmpresa(int empresaId);
        bool ExisteEmpresa(int empresaId);
        bool ExisteEmpresa(string nombre);
        bool CrearEmpresa(Empresa empresa);
        bool Actualizar(Empresa empresa);
        bool Eliminar(Empresa empresa); 
        bool Guardar();
    }
}
