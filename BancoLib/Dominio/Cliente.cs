using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BancoLib
{
    public class Cliente : Persona
    {
        //public List< Cuenta> cuentas;
        public DateTime FechaAlta { get; set;  }
        public Cliente(string nombre, string apellido, long dni, string password)
                    : base(nombre, apellido, dni, password) { }

        public Cliente()
        {
        }

        public override string ToString()
        {
            return base.ToString() + FechaAlta.ToString();
        }
    }
}
