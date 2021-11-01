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
    [Route("api/Bodegas")] 
    [ApiController]
    public class BodegasController : ControllerBase
    {
        private readonly IBodegaRepository bodegaRepository;
        private readonly IMapper mapper;

        public BodegasController(IBodegaRepository _bodegaRepository, IMapper _mapper)
        {
            bodegaRepository = _bodegaRepository;
            mapper = _mapper;
        }


        [HttpGet("[action]")] //Metodo para mostrar las bodegas existentes  
        public IActionResult GetBodegas() 
        {
            var listBodegas = bodegaRepository.GetBodegas();

            var dtoBodega = new List<DtoBodega>();

            try
            {
                foreach (var lista in listBodegas)
                {
                    dtoBodega.Add(mapper.Map<DtoBodega>(lista));
                }

                return Ok(dtoBodega); 

            }
            catch (Exception e)
            {
                ModelState.AddModelError("", $"Ha ocurrido un error al mostrar los datos {e.Message}");
                return StatusCode(500, ModelState);
            }
        }


        [HttpPost("[action]")] //Metodo para agregar Bodegas
        public IActionResult CreateBodegas([FromBody] DtoBodega dtoBodega)
        {
            if (dtoBodega == null)
            {
                return BadRequest(ModelState);
            }

            if (bodegaRepository.ExisteBodega(dtoBodega.Descripcion))
            {
                ModelState.AddModelError("", $"La Bodega {dtoBodega.Descripcion} ya existe");
                return StatusCode(404, ModelState);
            }

            try
            {
                var bodega = mapper.Map<Bodega>(dtoBodega);

                bodegaRepository.Create(bodega);

                return Ok("Se ha realizado con exito el registro");
            }
            catch (Exception e)
            {
                ModelState.AddModelError("", $"Ha ocurrido un error para registrar a {dtoBodega.Descripcion}, {e.Message}");
                return StatusCode(500, ModelState);
            }
        }

        // Metodo para actualizar datos de las bodegas
        [HttpPut("[action]/{bodegaId:int}", Name = "UpdateBodega")]
        public IActionResult UpdateBodega(int bodegaId, [FromBody] DtoBodega dtoBodega)
        {
            if (dtoBodega == null || bodegaId != dtoBodega.Idbodega)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var bodega = mapper.Map<Bodega>(dtoBodega);
                bodegaRepository.Update(bodega); 

                return Ok($"Los datos de la bodega {dtoBodega.Descripcion} fueron actualizados con exito");

            }
            catch (Exception e)
            {
                ModelState.AddModelError("", $"Ha ocurrido un error al actualizar los datos, {e.Message}");
                return StatusCode(500, ModelState);
            }
        }

        // Metodo para dar de baja una bodega
        [HttpPut("[action]/{bodegaId:int}", Name = "DeleteBodega")]
        public IActionResult DeleteBodega(int bodegaId)
        {

            if (!bodegaRepository.ExisteBodega(bodegaId))
            {
                return NotFound();
            }
            try
            {
                var bodega = bodegaRepository.GetBodega(bodegaId);
                bodegaRepository.Delete(bodega);

                return Ok($"Se dio de baja la bodega {bodega.Descripcion}");
            }
            catch (Exception e)
            {
                ModelState.AddModelError("", $"Ha ocurrido un error al dar de baja la bodega");
                return StatusCode(500, ModelState);
            }

        }
    }
}
