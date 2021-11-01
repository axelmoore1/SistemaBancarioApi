using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BancoLib
{
    public class Cliente : Persona
    {
        public DateTime FechaAlta { get; set;  }
        public List<Cuenta> Cuentas { get; set; }
        public Cliente(string nombre, string apellido, long dni, string password)
                    : base(nombre, apellido, dni, password) { }
        
        public Cliente()
        {
            Cuentas = new List<Cuenta>();
        }

        public void Agregar(Cuenta Ocuenta)
        {
            Cuentas.Add(Ocuenta);
        }


        public void QuitarCuenta(int nro)
        {
            Cuentas.RemoveAt(nro);
        }
        public override string ToString()
        {
            return base.ToString() + FechaAlta.ToString();
        }
    }
}
