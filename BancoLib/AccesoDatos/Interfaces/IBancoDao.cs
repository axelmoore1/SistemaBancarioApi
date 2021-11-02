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
        bool CreateCliente(Cliente oCliente); // agregar todos los datos del cliente 

        bool Delete(string dni);
        //Cliente UpdateCliente();// agregar todos los datos de cliente
        List<TipoCuenta2> GetCuentas();
    }
}
