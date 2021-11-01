using AutoMapper;
using InventarioAPI.Datos;
using InventarioAPI.DtoModels;
using InventarioAPI.Repositorys.IRepositorys;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InventarioAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ComprasController : ControllerBase
    {
        private readonly ICompraRepository compraRepository;
        private readonly IMapper mapper;

        public ComprasController(ICompraRepository repository, IMapper _mapper)
        {
            compraRepository = repository;
            mapper = _mapper; 
        }

        [HttpGet("[action]")]
        public IActionResult GetCompras()
        {
            var compras = compraRepository.GetCompras();
            var dtoCompras = new List<DtoCompra>();

            try
            {
                foreach(var lista in compras)
                {
                    dtoCompras.Add(mapper.Map<DtoCompra>(lista));
                }
                return Ok(dtoCompras); 

            }catch(Exception e)
            {
                ModelState.AddModelError("", $"Ha ocurrido un error al mostrar las compras {e.Message}");
                return StatusCode(500, ModelState); 
            }
        }

        [HttpPost("[action]")]
        public IActionResult CreateCompra([FromBody] DtoCompra dtoCompra)
        {
            if (dtoCompra == null)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var compra = mapper.Map<Compra>(dtoCompra); 

                compraRepository.Create(compra); 

                return Ok("Se ha realizado con exito el registro");
            }
            catch (Exception e)
            {
                ModelState.AddModelError("", $"Ha ocurrido un error para guarda la compra, {e.Message}");
                return StatusCode(500, ModelState);
            }
        }
    }
}
