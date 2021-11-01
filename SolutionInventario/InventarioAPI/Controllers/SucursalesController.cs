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
    [Route("api/Sucursales")]
    [ApiController]
    public class SucursalesController : ControllerBase
    {
        private readonly ISucursalRepository _sucursalRepository;
        private readonly IMapper _mapper;

        public SucursalesController(ISucursalRepository sucursalRepository, IMapper mapper)
        {
            _sucursalRepository = sucursalRepository;
            _mapper = mapper; 
        }

        [HttpGet("[action]")] //Metodo para mostrar todas las sucursales 
        public IActionResult GetSucursales() 
        {
            var listSucusales = _sucursalRepository.GetSucursals();

            var dtosucursales = new List<DtoSucursal>();

            try
            {
                foreach(var lista in listSucusales)
                {
                    dtosucursales.Add(_mapper.Map<DtoSucursal>(lista)); 
                }
                return Ok(dtosucursales);  

            }catch(Exception e)
            {
                ModelState.AddModelError("", $"Ha ocurrido un error al mostrar las sucursales, {e.Message}");
                return StatusCode(500, ModelState); 
            }
        }

        [HttpPost("[action]")] //Metodo para registrar una sucursal 
        public IActionResult CreateSucuesal([FromBody] DtoSucursal dtoSucursal)
        {
            if(dtoSucursal == null)
            {
                return BadRequest(ModelState);
            }

            if(_sucursalRepository.ExisteSucursal(dtoSucursal.Nombre))
            {
                ModelState.AddModelError("", $"La sucursal {dtoSucursal.Nombre} ya existe");
                return StatusCode(404, ModelState); 
            }

            try
            {
                var sucursal = _mapper.Map<Sucursal>(dtoSucursal);

                _sucursalRepository.CrearSucursal(sucursal);

                return Ok("Se ha realizado con exito el registro"); 

            }catch(Exception e)
            {
                ModelState.AddModelError("", $"Ha ocurrido un error al hacer el registro, {e.Message}");
                return StatusCode(500, ModelState); 
            }
        }

        //Metodo para acualizar datos de las sucursales 
        [HttpPut("[action]/{sucursalId:int}", Name = "UpdateSucursal")]
        public IActionResult UpdateSucursal(int sucursalId, [FromBody] DtoSucursal dtoSucursal) 
        {
            if (dtoSucursal == null || sucursalId != dtoSucursal.Idsucursal)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var sucursal= _mapper.Map<Sucursal>(dtoSucursal);

                _sucursalRepository.ActualizaSucursal(sucursal);

                return Ok("Los datos de la sucursal fueron actualizados con exito");

            }
            catch (Exception e)
            {
                ModelState.AddModelError("", $"Ha ocurrido un error al actualizar los datos, {e.Message}");
                return StatusCode(500, ModelState);
            }
        }

        //Metodo para dar de baja una sucursal 
        [HttpPut("[action]/{sucursalId:int}", Name = "DeleteSucursal")]
        public IActionResult DeleteSucursal(int sucursalId) 
        {

            if (!_sucursalRepository.ExisteSucursal(sucursalId))
            {
                return NotFound();
            }
            try
            {
                var sucursal = _sucursalRepository.GetSucursal(sucursalId);
                _sucursalRepository.EliminarSucursal(sucursal); 

                return Ok("se dio de baja la empresa");
            }
            catch (Exception e)
            {
                ModelState.AddModelError("", $"Ha ocurrido un error al eliminar la empresa");
                return StatusCode(500, ModelState);
            }

        }
    }
}
