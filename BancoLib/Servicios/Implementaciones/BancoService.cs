using BancoLib.AccesoDatos.Implementaciones;
using BancoLib.AccesoDatos.Interfaces;
using BancoLib.Servicios.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BancoLib.Servicios.Implementaciones
{
    public class BancoService : IService
    {
        private IBancoDao bancoDao = new BancoDao();
        public List<Cliente> ConsultarClientes()
        {
            return bancoDao.GetClientes();
        }
    }
}
