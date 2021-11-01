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
    [Route("api/Articulos")]
    [ApiController]
    public class ArticulosController : ControllerBase
    {
        private readonly IArticuloRepository _articuloRepository;
        private readonly IMapper _mapper; 

        public ArticulosController(IArticuloRepository articuloRepository, IMapper mapper)
        {
            _articuloRepository = articuloRepository;
            _mapper = mapper; 
        }

        [HttpGet("[action]")] //Metodo para mostrar todos los articulos  
        public IActionResult GetArticulos() 
        {
            var listArticulos = _articuloRepository.GetArticulos();

            var dtoArtiuclos = new List<DtoArticulo>();  

            try
            {
                foreach (var lista in listArticulos)
                {
                    dtoArtiuclos.Add(_mapper.Map<DtoArticulo>(lista));
                }
                return Ok(listArticulos); 

            }
            catch (Exception e)
            {
                ModelState.AddModelError("", $"Ha ocurrido un error al mostrar los articulos, {e.Message}");
                return StatusCode(500, ModelState);
            }
        }

        [HttpPost("[action]")] //Metodo para registrar articulos 
        public IActionResult CreateArticulo([FromBody] DtoArticulo dtoArticulo) 
        {
            if (dtoArticulo == null)
            {
                return BadRequest(ModelState);
            }

            if (_articuloRepository.ExisteArticulo(dtoArticulo.Descripcion))
            {
                ModelState.AddModelError("", $"El articulo {dtoArticulo.Descripcion} ya existe");
                return StatusCode(404, ModelState);
            }

            try
            {
                var articulo = _mapper.Map<Articulo>(dtoArticulo); 

                _articuloRepository.Create(articulo); 

                return Ok("Se ha realizado el registro con exito ");

            }
            catch (Exception e)
            {
                ModelState.AddModelError("", $"Ha ocurrido un error al hacer el registro, {e.Message}");
                return StatusCode(500, ModelState);
            }
        }

        //Metodo para acualizar datos de los articulos
        [HttpPut("[action]/{articulolId:int}", Name = "UpdateArticulos")]
        public IActionResult UpdateArticulos(int articulolId, [FromBody] DtoArticulo dtoArticulo)
        {
            if (dtoArticulo == null || articulolId != dtoArticulo.Idarticulo) 
            {
                return BadRequest(ModelState);
            }

            try
            {
                var articulo = _mapper.Map<Articulo>(dtoArticulo);

                _articuloRepository.Update(articulo); 

                return Ok("Los datos del articulo fueron actualizados con exito");

            }
            catch (Exception e)
            {
                ModelState.AddModelError("", $"Ha ocurrido un error al actualizar los datos, {e.Message}");
                return StatusCode(500, ModelState);
            }
        }


        //Metodo para eliminar un articulo 
        [HttpDelete("[action]/{articulolId:int}", Name = "DeleteArticulo")] 
        public IActionResult DeleteArticulo(int articulolId) 
        {

            if (!_articuloRepository.ExisteArticulo(articulolId))
            {
                return NotFound();
            }
            try
            {
                var articulo = _articuloRepository.GetArticulo(articulolId);
                _articuloRepository.Delete(articulo); 

                return Ok("El articulo fue eliminado con exito ");
            }
            catch (Exception e)
            {
                ModelState.AddModelError("", $"Ha ocurrido un error al eliminar el articulo");
                return StatusCode(500, ModelState);
            }

        }
    }
}
