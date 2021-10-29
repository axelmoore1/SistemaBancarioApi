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
        public Cliente GetCliente(string dni)
        {
            SqlConnection conexion = new SqlConnection(@"Data Source=.\SQLEXPRESS02;Initial Catalog=banco2;Integrated Security=True");
            SqlCommand comando = new SqlCommand();
            conexion.Open();
            comando.Connection = conexion;
            comando.CommandType = CommandType.StoredProcedure;
            comando.CommandText = "SP_CONSULTAR_CLIENTE_POR_DNI";

            //Set SqlParameter - el id del cliente 
            SqlParameter param1 = new SqlParameter();
            param1.ParameterName = "@dni";
            param1.SqlDbType = SqlDbType.VarChar;
            param1.Value = dni;

            //add the parameter to the SqlCommand object
            comando.Parameters.Add(param1);

            //set the SqlCommand type to stored procedure and execute
            SqlDataReader dr = comando.ExecuteReader();

            //si encuentra algun cliente
            if (dr.HasRows)
            {
                Cliente oCliente = new Cliente();
                while (dr.Read())
                {
                    oCliente.nombre = dr.GetString(1);
                    oCliente.apellido = dr.GetString(2);
                    oCliente.dni = long.Parse(dr.GetString(3));
                    oCliente.FechaAlta = dr.GetDateTime(4);
    
                }
                return oCliente;
            }
            // en el caso de no encontrar cliente con ese id
            else
            {
                return null;
            }

        }

        public List<Cliente> GetClientes()
        {

            SqlConnection conexion = new SqlConnection (@"Data Source=.\SQLEXPRESS02;Initial Catalog=banco2;Integrated Security=True");
            SqlCommand comando = new SqlCommand();
            conexion.Open();
            comando.Connection = conexion;
            comando.CommandType = CommandType.StoredProcedure;
            comando.CommandText = "SP_CONSULTAR_CLIENTES";
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
                oCliente.FechaAlta = Convert.ToDateTime(row["Fecha"].ToString());
                    

                lista.Add(oCliente);
            }
            return lista;


        }
    }
}
