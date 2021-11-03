using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BancoLib.Dominio
{
    public class ClienteCuenta
    {
        public ClienteCuenta()
        {
        }
        public ClienteCuenta(int id,long cbu, float saldo, int tipoCuenta, int Id_cliente)
        {
            Id = id;
            Cbu = cbu;
            Saldo = saldo;
            this.tipoCuenta = tipoCuenta;
            this.Id_cliente = Id_cliente;
        }
        public int Id { get; set; }
        public long Cbu { get; set; }
        public float Saldo { get; set; }
        public int tipoCuenta{ get; set; }
        public int Id_cliente { get; set; }

        public static long GenerarCbu()
        {
            var seed = Environment.TickCount;
            Random random = new Random(seed);
            string cbu = "";
            for (int i = 0; i < 5; i++)
            {
                var value = random.Next(0, 10);
                cbu += value.ToString();
            }

            return long.Parse(cbu);
        }

    }
}
