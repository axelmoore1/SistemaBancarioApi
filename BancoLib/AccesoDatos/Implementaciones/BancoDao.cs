using BancoLib.AccesoDatos.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BancoLib.AccesoDatos.Implementaciones
{
    class BancoDao : IBancoDao
    {
        
        public List<Cliente> GetClientes()
        {

            SqlConnection conexion = new SqlConnection (@"Data Source=.\SQLEXPRESS;Initial Catalog=banco2;Integrated Security=True");
            SqlCommand comando = new SqlCommand();
            conexion.Open();
            comando.Connection = conexion;
            comando.CommandText = "SELECT * FROM Clientes";
            DataTable tabla = new DataTable();
            tabla.Load(comando.ExecuteReader());

            conexion.Close();

            List<Cliente> lista = new List<Cliente>();
            foreach (DataRow row in tabla.Rows)
            {
                Cliente oCliente = new Cliente();
                
                oCliente.nombre = row["nombre"].ToString();
                oCliente.apellido = row["apellido"].ToString();
                oCliente.dni = Convert.ToInt32(row["dni"].ToString());
                oCliente.FechaAlta = Convert.ToDateTime(row["fecha_alta"].ToString());
                    

                lista.Add(oCliente);
            }
            return lista;


        }
    }
}
