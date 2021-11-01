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
    [Route("api/TiposArticulos")]
    [ApiController]
    public class TiposArticulosController : ControllerBase
    {
        private readonly ITipoArticuloRepository _tipoArticuloRepository;
        private readonly IMapper _mapper; 

        public TiposArticulosController(ITipoArticuloRepository tipoArticuloRepository, IMapper mapper)
        {
            _tipoArticuloRepository = tipoArticuloRepository;
            _mapper = mapper; 
        }

        [HttpGet("[action]")] //Metodo para mostrar todos los tipos de productos existentes 
        public IActionResult GetTipos()  
        {
            var listTiposArt = _tipoArticuloRepository.GetTipoArticulos();

            var dtoTiposArt = new List<DtoTipoArticulo>();

            try
            {
                foreach (var lista in listTiposArt)
                {
                    dtoTiposArt.Add(_mapper.Map<DtoTipoArticulo>(lista));
                }
                return Ok(dtoTiposArt); 

            }
            catch (Exception e)
            {
                ModelState.AddModelError("", $"Ha ocurrido un error al mostrar los tipos , {e.Message}");
                return StatusCode(500, ModelState);
            }
        }


        [HttpPost("[action]")] //Metodo para registra tipos de articulos 
        public IActionResult CreateTipo([FromBody] DtoTipoArticulo dtoTipoArticulo)
        {
            if (dtoTipoArticulo == null)
            {
                return BadRequest(ModelState);
            }

            if (_tipoArticuloRepository.ExisteTipoArticulo(dtoTipoArticulo.Descripcion))
            {
                ModelState.AddModelError("", $"El tipo {dtoTipoArticulo.Descripcion} ya existe");
                return StatusCode(404, ModelState);
            }

            try
            {
                var tipo = _mapper.Map<TipoArticulo>(dtoTipoArticulo);

                _tipoArticuloRepository.Create(tipo); 

                return Ok("Se ha realizado con exito el registro");

            }
            catch (Exception e)
            {
                ModelState.AddModelError("", $"Ha ocurrido un error al hacer el registro, {e.Message}");
                return StatusCode(500, ModelState);
            }
        }

        //Metodo para acualizar datos  
        [HttpPut("[action]/{tipoArtId:int}", Name = "UpdateTipo")] 
        public IActionResult UpdateTipo(int tipoArtId, [FromBody] DtoTipoArticulo dtoTipoArticulo)
        {
            if (dtoTipoArticulo == null || tipoArtId != dtoTipoArticulo.IdtipoArticulo)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var tipoArt = _mapper.Map<TipoArticulo>(dtoTipoArticulo);

                _tipoArticuloRepository.Update(tipoArt); 

                return Ok("Los datos fueron actualizados con exito");

            }
            catch (Exception e)
            {
                ModelState.AddModelError("", $"Ha ocurrido un error al actualizar los datos, {e.Message}");
                return StatusCode(500, ModelState);
            }
        }

        //Metodo para dar de baja los tipos de articulos 
        [HttpPut("[action]/{tipoArtId:int}", Name = "DeleteTipo")]
        public IActionResult DeleteTipo(int tipoArtId)
        {
            if (!_tipoArticuloRepository.ExisteTipoArticulo(tipoArtId))
            {
                return NotFound();
            }
            try
            {
                var tipoArt = _tipoArticuloRepository.GetTipoArticulo(tipoArtId); 
                _tipoArticuloRepository.Delete(tipoArt); 

                return Ok("se dio de baja el tipo");
            }
            catch (Exception e)
            {
                ModelState.AddModelError("", $"Ha ocurrido un error al eliminar el tipo de articulo ");
                return StatusCode(500, ModelState);
            }

        }
    }
}
