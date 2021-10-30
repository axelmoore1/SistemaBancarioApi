using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BancoLib.Servicios.Interfaces
{
    public interface IService
    {
        List<Cliente> ConsultarClientes();

        Cliente ConsultarCliente(string dni);

        public bool CrearCliente(Cliente oCliente);

        public bool DeleteCliente(string dni);
    }

   
}
