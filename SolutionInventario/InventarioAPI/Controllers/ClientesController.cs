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
    [Route("api/Clientes")]
    [ApiController]
    public class ClientesController : ControllerBase
    {
        private readonly IClienteRepository _clienteRepository;
        private readonly IMapper _mapper;

        public ClientesController(IClienteRepository clienteRepository, IMapper mapper)
        {
            _clienteRepository = clienteRepository;
            _mapper = mapper; 
        }


        [HttpGet("[action]")] //Metodo para mostrar los clientes registrados  
        public IActionResult GetClientes() 
        {
            var listClientes = _clienteRepository.GetClientes();

            var dtoCliente = new List<DtoCliente>(); 

            try
            {
                foreach (var lista in listClientes)
                {
                    dtoCliente.Add(_mapper.Map<DtoCliente>(lista));
                }

                return Ok(dtoCliente);

            }
            catch (Exception e)
            {
                ModelState.AddModelError("", $"Ha ocurrido un error al mostrar los datos {e.Message}");
                return StatusCode(500, ModelState);
            }
        }

        [HttpPost("[action]")] //Metodo para agregar clientes
        public IActionResult CreateClientes([FromBody] DtoCliente dtoCliente)
        {
            if (dtoCliente == null)
            {
                return BadRequest(ModelState);
            }

            if (_clienteRepository.ExisteCliente(dtoCliente.Nombre))
            {
                ModelState.AddModelError("", $"El cliente {dtoCliente.Nombre} ya existe");
                return StatusCode(404, ModelState);
            }

            try
            {
                var cliente = _mapper.Map<Cliente>(dtoCliente);

                _clienteRepository.Create(cliente); 

                return Ok("Se ha realizado con exito el registro");
            }
            catch (Exception e)
            {
                ModelState.AddModelError("", $"Ha ocurrido un error para registrar a {dtoCliente.Nombre}, {e.Message}");
                return StatusCode(500, ModelState);
            }
        }

        // Metodo para actualizar datos de los clientes
        [HttpPut("[action]/{clienteId:int}", Name = "UpdateCliente")] 
        public IActionResult UpdateCliente(int clienteId, [FromBody] DtoCliente dtoCliente)
        {
            if (dtoCliente == null || clienteId != dtoCliente.Idcliente)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var cliente = _mapper.Map<Cliente>(dtoCliente);
                _clienteRepository.Update(cliente);

                return Ok($"Los datos de {dtoCliente.Nombre} fueron actualizados con exito");

            }
            catch (Exception e)
            {
                ModelState.AddModelError("", $"Ha ocurrido un error al actualizar los datos, {e.Message}");
                return StatusCode(500, ModelState);
            }
        }

        // Metodo para dar de baja un cliente
        [HttpPut("[action]/{clienteId:int}", Name = "DeleteCliente")]
        public IActionResult DeleteCliente(int clienteId)
        {

            if (!_clienteRepository.ExisteCliente(clienteId))
            {
                return NotFound();
            }
            try
            {
                var cliente = _clienteRepository.GetCliente(clienteId);
                _clienteRepository.Delete(cliente);

                return Ok($"Se dio de baja a {cliente.Nombre}"); 
            }
            catch (Exception e)
            {
                ModelState.AddModelError("", $"Ha ocurrido un error al dar de baja al cliente");
                return StatusCode(500, ModelState);
            }

        }
    }
}
