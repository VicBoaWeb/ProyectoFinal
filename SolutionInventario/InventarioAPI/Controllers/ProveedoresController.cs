using AutoMapper;
using InventarioAPI.Datos;
using InventarioAPI.DtosModels;
using InventarioAPI.Repository.IRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InventarioAPI.Controllers
{
    [Route("api/Proveedores")]
    [ApiController]
    public class ProveedoresController : ControllerBase
    {
        private readonly IProveedorRepository proveedorRepository;
        private readonly IMapper mapper;

        public ProveedoresController(IProveedorRepository _proveedorRepository, IMapper _mapper)
        {
            proveedorRepository = _proveedorRepository;
            mapper = _mapper; 
        }

        [HttpGet("[action]")] //Metodo para mostrar los proveedores registrados  
        public IActionResult GetProveedores() 
        {
            var listProveedores = proveedorRepository.GetProveedors();

            var dtoProveedoresList = new List<DtoProveedor>();

            try
            {
                foreach (var lista in listProveedores)
                {
                    dtoProveedoresList.Add(mapper.Map<DtoProveedor>(lista));
                }

                return Ok(dtoProveedoresList);     

            }
            catch (Exception e)
            {
                ModelState.AddModelError("", $"Ha ocurrido un error al mostrar los datos {e.Message}");
                return StatusCode(500, ModelState);
            }
        }

        [HttpPost("[action]")] //Metodo para agregar proveedores  
        public IActionResult CreateProveedor([FromBody] DtoProveedor dtoProveedor) 
        {
            if (dtoProveedor == null)
            {
                return BadRequest(ModelState);
            }

            if (proveedorRepository.ExisteProveedor(dtoProveedor.Nombre))
            {
                ModelState.AddModelError("", $"El proveedor {dtoProveedor.Nombre} ya existe");
                return StatusCode(404, ModelState);
            }

            try
            {
                var proveedor = mapper.Map<Proveedor>(dtoProveedor);

                proveedorRepository.Create(proveedor); 

                return Ok("Se ha realizado con exito el registro");
            }
            catch (Exception e)
            {
                ModelState.AddModelError("", $"Ha ocurrido un error para guardar la empresa {dtoProveedor.Nombre}, {e.Message}");
                return StatusCode(500, ModelState);
            }
        }

        // Metodo para actualizar datos de los proveedores
        [HttpPut("[action]/{proveedorId:int}", Name = "UpdateProveedor")]
        public IActionResult UpdateProveedor(int proveedorId, [FromBody] DtoProveedor dtoProveedor)
        {
            if (dtoProveedor == null || proveedorId != dtoProveedor.Idproveedor)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var proveedor = mapper.Map<Proveedor>(dtoProveedor);
                proveedorRepository.Update(proveedor); 

                return Ok("Los datos del proveedor fueron actualizados con exito");

            }
            catch (Exception e)
            {
                ModelState.AddModelError("", $"Ha ocurrido un error al actualizar los datos, {e.Message}");
                return StatusCode(500, ModelState);
            }
        }

        // Metodo para dar de baja un proveedor
        [HttpPut("[action]/{proveedorId:int}", Name = "DeleteProveedor")]
        public IActionResult DeleteProveedor(int proveedorId)
        {

            if (!proveedorRepository.ExisteProveedor(proveedorId))
            {
                return NotFound();
            }
            try
            {
                var proveedor = proveedorRepository.GetProveedor(proveedorId);
                proveedorRepository.Delete(proveedor); 

                return Ok($"Se dio de baja al proveedor {proveedor.Nombre}"); 
            }
            catch (Exception e)
            {
                ModelState.AddModelError("", $"Ha ocurrido un error al dar de baja al proveedor");
                return StatusCode(500, ModelState);
            }

        }
    }
}
