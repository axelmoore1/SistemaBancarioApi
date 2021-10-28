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
    }
}
