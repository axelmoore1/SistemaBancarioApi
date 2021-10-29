using BancoLib;
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
    public class ClienteController : ControllerBase
    {
        private IService bancoService;

        public ClienteController()
        {
            bancoService = new BancoService();
        }

        // GET: api/<ClienteController>
        [HttpGet]
        public List<Cliente> Get()
        {
            return bancoService.ConsultarClientes();
        }

        // GET api/<ClienteController>/5
        [HttpGet("{dni}")]
        public Cliente Get(string dni)
        {
            return bancoService.ConsultarCliente(dni);
        }

        // POST api/<ClienteController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<ClienteController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ClienteController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
