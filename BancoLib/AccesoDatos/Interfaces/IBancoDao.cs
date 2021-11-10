﻿using BancoLib.Dominio;
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
        List<TipoCuenta> GetCuentas();

        List<ClienteCuenta> GetClienteCuentas(long dni);

        bool GetCreateClienteCuentas(ClienteCuenta clienteCuentas);
        bool DeleteCuentaCliente(long cbu);
        public bool CreateTipoCuenta(TipoCuenta oTipoCuenta);
        int GetNextCuentaId();

        TipoCuenta GetCuentaPorNombre(string nombre);

        public bool DeleteTipoCuenta(string nombre);


    }
}
