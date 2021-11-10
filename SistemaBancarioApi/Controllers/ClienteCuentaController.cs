using BancoLib.Dominio;
using BancoLib.Servicios.Implementaciones;
using BancoLib.Servicios.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SistemaBancarioApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteCuentaController : ControllerBase
    {
        private IService bancoService;

        public ClienteCuentaController()
        {
            bancoService = new BancoService();
        }
        // GET: api/<ClienteCuentaController>
        //[HttpGet]
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        // GET api/<ClienteCuentaController>/5
        [HttpGet("{dni}")]
        public List<ClienteCuenta> Get(long dni)
        {
            return bancoService.ConsultarClienteCuenta(dni);
        }

        // POST api/<ClienteCuentaController>
        [HttpPost]
        public IActionResult PostCuentaCliente(ClienteCuenta clienteCuenta)
        {
            if (clienteCuenta == null)
            {
                return BadRequest();
            }
            if (bancoService.CrearCuentaCliente(clienteCuenta))
            {
                return Ok("Cargado correctamente");
            }
            else
                return Ok("No se pudo cargar");
        }

        //// PUT api/<ClienteCuentaController>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        // DELETE api/<ClienteCuentaController>/5
        [HttpDelete("{cbu}")]
        public void Delete(long cbu)
        {
            bancoService.DeleteCuentaCliente(cbu);
        }
    }
}
