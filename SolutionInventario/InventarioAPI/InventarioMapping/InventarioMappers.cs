using AutoMapper;
using InventarioAPI.Datos;
using InventarioAPI.DtoModels;
using InventarioAPI.DtosModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InventarioAPI.InventarioMapper
{
    public class InventarioMappers : Profile
    {
        public InventarioMappers()
        {
            CreateMap<Empresa, DtoEmpresa>().ReverseMap();
            CreateMap<Sucursal, DtoSucursal>().ReverseMap();
            CreateMap<TipoArticulo, DtoTipoArticulo>().ReverseMap();
            CreateMap<Proveedor, DtoProveedor>().ReverseMap();
            CreateMap<Articulo, DtoArticulo>().ReverseMap();
            CreateMap<Cliente, DtoCliente>().ReverseMap();
            CreateMap<Bodega, DtoBodega>().ReverseMap();
            CreateMap<Usuario, DtoUsuario>().ReverseMap();
            CreateMap<Compra, DtoCompra>().ReverseMap(); 
        }
    }
}
