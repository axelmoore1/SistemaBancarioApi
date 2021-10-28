using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BancoLib
{
    class Persona
    {
        public string nombre { get; set; }
        public string apellido { get; set; }
        public long dni { get; set; }
        public string password { get; set; }

        public Persona()
        {
        }
        public Persona(string nombre, string apellido, long dni, string password)
        {
            this.nombre = nombre;
            this.apellido = apellido;
            this.dni = dni;
            this.password = password;
        }

        override public string ToString() 
        {
            return "Apellido: " + apellido + ". Nombre: " + nombre + ". DNI: " + dni.ToString() + ". Password: " + password;
        }

    }
}
