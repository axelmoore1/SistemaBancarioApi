using BancoLib.AccesoDatos.Implementaciones;
using BancoLib.AccesoDatos.Interfaces;
using BancoLib.Dominio;
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

        public List<ClienteCuenta> ConsultarClienteCuenta(long dni)
        {
            return bancoDao.GetClienteCuentas(dni);
        }

        public List<Cliente> ConsultarClientes()
        {
            return bancoDao.GetClientes();
        }

        public List<TipoCuenta> ConsultarCuenta()
        {
            return bancoDao.GetCuentas();
        }

        public bool CrearCliente(Cliente oCliente)
        {
            return bancoDao.CreateCliente(oCliente);
        }

        public bool CrearCuentaCliente(ClienteCuenta clienteCuentas)
        {
            return bancoDao.GetCreateClienteCuentas(clienteCuentas);
        }

        public bool DeleteCliente(string dni)
        {
            return bancoDao.Delete(dni);
        }
        public bool DeleteCuentaCliente(long cbu)
        {
            return bancoDao.DeleteCuentaCliente(cbu);
        }

        public bool CreateTipoCuenta(TipoCuenta oTipoCuenta)
        {
            return bancoDao.CreateTipoCuenta(oTipoCuenta);
        }

        public int GetNextCuentaId()
        {
            return bancoDao.GetNextCuentaId();
        }

        public TipoCuenta GetCuentaPorNombre(string nombre)
        {
            return bancoDao.GetCuentaPorNombre(nombre);
        }

        public bool DeleteTipoCuenta(string nombre)
        {
            return bancoDao.DeleteTipoCuenta(nombre);
        }
    }
}
