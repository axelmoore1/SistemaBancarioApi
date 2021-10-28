using System;

namespace BancoLib
{
    public class Cuenta
    {
        private string Cbu { get; set; }
        private double Saldo { get; set; }

        private TipoCuenta cuenta { get; set; }

        private DateTime UltimoMovimiento { get; set; }
        

    }

    public enum TipoCuenta
    {
        CUENTA_SUELDO,
        CUENTA_CORRIENTE,
        CAJA_AHORRO_PESOS,
        CAJA_AHORRO_DOLARES, 

    }
}
