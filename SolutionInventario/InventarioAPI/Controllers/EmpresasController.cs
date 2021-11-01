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
    [Route("api/Empresas")]
    [ApiController]
    public class EmpresasController : ControllerBase
    {
        private readonly IEmpresaRepositoy _empresaRepository;
        private readonly IMapper _mapper;

        public EmpresasController(IEmpresaRepositoy empresaRepositoy, IMapper mapper)
        {
            _empresaRepository = empresaRepositoy;
            _mapper = mapper;
        }


        [HttpGet("[action]")] //Metodo para mostrar empresas registradas 
        public IActionResult GetEmpresas()
        {
            var listEmpresas = _empresaRepository.GetEmpresas();

            var listDtoEmpresa = new List<DtoEmpresa>();

            try
            {
                foreach (var lista in listEmpresas)
                {
                    listDtoEmpresa.Add(_mapper.Map<DtoEmpresa>(lista));
                }

                return Ok(listDtoEmpresa);

            } catch (Exception e)
            {
                ModelState.AddModelError("", $"Ha ocurrido un error al mostrar los datos {e.Message}");
                return StatusCode(500, ModelState);
            }
        }


        [HttpPost("[action]")] //Metodo para agregar una empresa 
        public IActionResult CreateEmpresa([FromBody] DtoEmpresa dtoEmpresa)
        {
            if (dtoEmpresa == null)
            {
                return BadRequest(ModelState);
            }

            if (_empresaRepository.ExisteEmpresa(dtoEmpresa.Nombre))
            {
                ModelState.AddModelError("", $"La empresa {dtoEmpresa.Nombre} ya existe");
                return StatusCode(404, ModelState);
            }

            try
            {
                var empresa = _mapper.Map<Empresa>(dtoEmpresa);

                _empresaRepository.CrearEmpresa(empresa);

                return Ok("Se ha realizado con exito el registro");
            }
            catch (Exception e)
            {
                ModelState.AddModelError("", $"Ha ocurrido un error para guardar la empresa {dtoEmpresa.Nombre}, {e.Message}");
                return StatusCode(500, ModelState);
            }
        }


        // Metodo para actualizar datos de las empresas 
        [HttpPut("[action]/{empresaId}")] 
        public IActionResult UpdateEmpresa(int empresaId, [FromBody] DtoEmpresa dtoEmpresa)
        {
            if (dtoEmpresa == null || empresaId != dtoEmpresa.Idempresa)
            {
                return BadRequest(ModelState); 
            }
                
            try
            {
                var empresa = _mapper.Map<Empresa>(dtoEmpresa);
                _empresaRepository.Actualizar(empresa);

                return Ok("Los datos de la empresa fueron actualizados con exito");

            } catch (Exception e)
            {
                ModelState.AddModelError("", $"Ha ocurrido un error al actualizar los datos, {e.Message}");
                return StatusCode(500, ModelState); 
            }
        }


         // Metodo para dar de baja una empresa
        [HttpPut("[action]/{empresaId}")]
        public IActionResult DeleteEmpresas(int empresaId)
        {

            if (!_empresaRepository.ExisteEmpresa(empresaId))
            {
                return NotFound();
            }
            try
            {
                var empresa = _empresaRepository.GetEmpresa(empresaId);
                _empresaRepository.Eliminar(empresa);

                return Ok("se dio de baja la empresa"); 
            }
            catch(Exception e)
            {
                ModelState.AddModelError("", $"Ha ocurrido un error al eliminar la empresa");
                return StatusCode(500, ModelState);
            }

        }
    }
}
