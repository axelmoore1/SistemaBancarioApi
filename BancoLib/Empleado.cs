using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BancoLib
{
    class Empleado : Persona
    {
        public Empleado(string nombre, string apellido, long dni, string password)
                    : base(nombre, apellido, dni, password) { }

    }
}
