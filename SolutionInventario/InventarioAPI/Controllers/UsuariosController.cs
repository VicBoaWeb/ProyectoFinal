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
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private readonly IUsuarioRepository usuarioRepository;
        private readonly IMapper mapper;

        public UsuariosController(IUsuarioRepository repository, IMapper _mapper)
        {
            usuarioRepository = repository;
            mapper = _mapper; 
        }

        [HttpGet("[action]")]
        public IActionResult GetUsuarios()
        {
            var usuarios = usuarioRepository.GetUsuarios();
            var dtoUsuarios = new List<DtoUsuario>();

            try
            {
                foreach(var lista in usuarios)
                {
                    dtoUsuarios.Add(mapper.Map<DtoUsuario>(lista));
                }
                return Ok(dtoUsuarios); 

            }catch(Exception e)
            {
                ModelState.AddModelError("", $"Ha ocurrido un error al mostrar los datos, {e.Message}");
                return StatusCode(500, ModelState); 
            }
        }

        [HttpPost("[action]")]
        public IActionResult CreateUsuarios([FromBody] DtoUsuario dtoUsuario)
        {
            if(dtoUsuario == null)
            {
                return BadRequest(ModelState);
            }

            if(usuarioRepository.ExisteUsuario(dtoUsuario.User)) 
            {
                ModelState.AddModelError("", $"El usuario {dtoUsuario.User} ya existe");
                return StatusCode(500, ModelState); 
            }

            try
            {
                var usuario = mapper.Map<Usuario>(dtoUsuario);
                usuarioRepository.Create(usuario);

                return Ok("El usuario se registro con exito"); 

            }catch(Exception e)
            {
                ModelState.AddModelError("", $"Ha ocurrido un error al agregar el usuario {dtoUsuario.User}, {e.Message}");
                return StatusCode(500, ModelState); 
            }
        }

        [HttpPut("[action]/{user}")] 
        public IActionResult UpdateUsuarios(string user, [FromBody] DtoUsuario dtoUsuario)
        {
            if (dtoUsuario == null || user != dtoUsuario.User)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var usuario = mapper.Map<Usuario>(dtoUsuario);
                usuarioRepository.Update(usuario); 

                return Ok("Los datos del usuario fueron actualizados con exito");

            }
            catch (Exception e)
            {
                ModelState.AddModelError("", $"Ha ocurrido un error al actualizar los datos, {e.Message}");
                return StatusCode(500, ModelState);
            }
        }

        [HttpDelete("[action]/{user}")]
        public IActionResult DeleteUsuarios(string user)
        {
            if (!usuarioRepository.ExisteUsuario(user))
            {
                return NotFound();
            }
            try
            {
                var usuario = usuarioRepository.GetUsuario(user);
                usuarioRepository.Delete(usuario); 

                return Ok("se dio de baja el usuario");
            }
            catch (Exception e)
            {
                ModelState.AddModelError("", $"Ha ocurrido un error al eliminar el usuario");
                return StatusCode(500, ModelState);
            }
        }
    }
}
