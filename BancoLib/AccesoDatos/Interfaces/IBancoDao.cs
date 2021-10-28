using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BancoLib.AccesoDatos.Interfaces
{
    interface IBancoDao
    {
        List<Cliente> GetClientes();
        Cliente GetCliente(string dni);
        Cliente CreateCliente();// agregar todos los datos del cliente 
        void  DeleteCliente();
        Cliente UpdateCliente();// agregar todos los datos de cliente
    }
}
