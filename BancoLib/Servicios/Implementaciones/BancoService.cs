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

        public Cliente ConsultarCliente(string dni)
        {
            return bancoDao.GetCliente(dni);
        }

        public List<Cliente> ConsultarClientes()
        {
            return bancoDao.GetClientes();
        }

        public bool CrearCliente(Cliente oCliente)
        {
            return bancoDao.CreateCliente(oCliente);
        }

        public bool DeleteCliente(string dni)
        {
            return bancoDao.Delete(dni);
        }
    }
}
