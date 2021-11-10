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
    public class CuentaController : ControllerBase
    {
        private IService bancoService;

        public CuentaController()
        {
            bancoService = new BancoService();
        }
        // GET: api/<CuentaController>
        [HttpGet]
        public List<TipoCuenta> Get()
        {
            return bancoService.ConsultarCuenta();
        }

        // GET api/<CuentaController>/5
        [HttpGet("{nombre}")]
        public TipoCuenta Get(string nombre)
        {
            return bancoService.GetCuentaPorNombre(nombre);
        }

        // GET api/<CuentaController>/CuentaID
        [Route("CuentaID")]
        [HttpGet]
        public int GetNextCuentaID()
        {
            return bancoService.GetNextCuentaId();
        }
        
        // POST api/<CuentaController>
        [HttpPost]
        public IActionResult PostTipoCuenta(TipoCuenta oTipoCuenta)
        {
            if (oTipoCuenta == null)
            {
                return BadRequest();
            }
            if (bancoService.CreateTipoCuenta(oTipoCuenta))
            {
                return Ok("No se pudo cargar el cliente");
            }
            else
            {
                return Ok("Cliente cargado correctamente");
            }
        }

        // PUT api/<CuentaController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<CuentaController>/5
        [HttpDelete("{nombre}")]
        public IActionResult Delete(string nombre)
        {
            if (nombre == null)
                return BadRequest();
            if (bancoService.DeleteTipoCuenta(nombre))
            {
                return Ok("Se elimino correctamente");
            }
            else
                return Ok("Nombre requerido");
        }
    }
}
