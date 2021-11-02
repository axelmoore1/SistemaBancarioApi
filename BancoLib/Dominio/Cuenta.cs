using System;

namespace BancoLib
{
    public class Cuenta
    {
        public Cuenta()
        {
            Cbu = string.Empty;
            Saldo = 0;
            UltimoMovimiento = DateTime.Now;
        }

        public Cuenta(string cbu, double saldo, TipoCuenta cuenta, DateTime ultimoMovimiento)
        {
            Cbu = cbu;
            Saldo = saldo;
            this.cuenta = cuenta;
            UltimoMovimiento = ultimoMovimiento;
        }

        private string Cbu { get; set; }
        private double Saldo { get; set; }

        private TipoCuenta cuenta { get; set; }

        private DateTime UltimoMovimiento { get; set; }
        

    }

    
}
