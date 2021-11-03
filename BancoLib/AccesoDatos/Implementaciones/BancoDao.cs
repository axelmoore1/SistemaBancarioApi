using BancoLib.AccesoDatos.Interfaces;
using BancoLib.Dominio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace BancoLib.AccesoDatos.Implementaciones
{
    class BancoDao : IBancoDao
    {
        private string cadena = Properties.Resources.conexion;
        public bool CreateCliente(Cliente oCliente)
        {
            bool ok = true;
            int id_cliente = 0;

            SqlConnection conexion = new SqlConnection(cadena);
            SqlCommand comando = new SqlCommand();
            SqlTransaction transaction = null;
            conexion.Open();
            comando.Connection = conexion;
            comando.CommandType = CommandType.StoredProcedure;
            comando.CommandText = "SP_INSERTAR_CLIENTE";
            try
            {
                transaction = conexion.BeginTransaction();

                comando.CommandType = CommandType.StoredProcedure;
                comando.Transaction = transaction;
                comando.Parameters.AddWithValue("@nombre", oCliente.nombre);
                comando.Parameters.AddWithValue("@apellido", oCliente.apellido);
                comando.Parameters.AddWithValue("@dni", oCliente.dni.ToString());
                comando.Parameters.AddWithValue("@fecha_alta", oCliente.FechaAlta);
                comando.Parameters.AddWithValue("@passw", oCliente.password);
                SqlParameter param = new SqlParameter();
                param.ParameterName = "@id_cliente";
                param.SqlDbType = SqlDbType.Int;
                param.Direction = ParameterDirection.Output;
                comando.Parameters.Add(param);
                comando.ExecuteNonQuery();
                id_cliente = (int)param.Value;
                

                transaction.Commit();
            }
            catch (Exception)
            {
                transaction.Rollback();
                ok = false;

            }
            finally
            {
                if (conexion.State == ConnectionState.Open)
                {
                    conexion.Close();
                }
            }
            return ok;

        }

        public bool Delete(string dni)
        {
            SqlConnection conexion = new SqlConnection(cadena);
            SqlTransaction transaction = null;
            int affected = 0;
            try
            {
                
                conexion.Open();
                transaction = conexion.BeginTransaction(); //crea una conexion con la transaccion 
                SqlCommand comando = new SqlCommand();
                comando.Connection = conexion;
                comando.Transaction = transaction; //utiliza el comando transaccion para poder utilizarla 
                comando.CommandType = CommandType.StoredProcedure;
                comando.CommandText = "SP_BORRAR_CLIENTE";


                comando.Parameters.AddWithValue("@dni", dni);
                affected = comando.ExecuteNonQuery();
                transaction.Commit();
            }
            catch (Exception)
            {
                transaction.Rollback();
            }
            finally
            {
                if (conexion != null && conexion.State == ConnectionState.Open)
                    conexion.Close();
            }

            return affected == 1;

        } 
    

        public Cliente GetCliente(string dni)
        {
            SqlConnection conexion = new SqlConnection(cadena);
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
                    oCliente.Id = dr.GetInt32(0);
                    oCliente.nombre = dr.GetString(1);
                    oCliente.apellido = dr.GetString(2);
                    oCliente.dni = long.Parse(dr.GetString(3));
                    oCliente.FechaAlta = dr.GetDateTime(4);
                    oCliente.password = dr.GetString(5);
                }
                return oCliente;
            }
            // en el caso de no encontrar cliente con ese id
            else
            {
                return null;
            }

        }

        public List<ClienteCuenta> GetClienteCuentas(long dni)
        {
            SqlConnection conexion = new SqlConnection(cadena);
            SqlCommand comando = new SqlCommand();
            conexion.Open();
            comando.Connection = conexion;
            comando.CommandType = CommandType.StoredProcedure;
            comando.CommandText = "SP_CONSULTAR_Cliente_Cuenta";
            SqlParameter param1 = new SqlParameter();
            param1.ParameterName = "@dni";
            param1.SqlDbType = SqlDbType.VarChar;
            param1.Value = dni.ToString();

            comando.Parameters.Add(param1);

            DataTable tabla = new DataTable();
            tabla.Load(comando.ExecuteReader());
            conexion.Close();
            List<ClienteCuenta> lista = new List<ClienteCuenta>();
            foreach (DataRow row in tabla.Rows)
            {
                ClienteCuenta oCliente = new ClienteCuenta();
                oCliente.Id = Convert.ToInt32(row["ID"].ToString());
                oCliente.Cbu = long.Parse(row["CBU"].ToString());
                oCliente.Saldo = float.Parse(row["Saldo"].ToString());
                oCliente.tipoCuenta = Convert.ToInt32(row["Tipo_Cuenta"].ToString());
                lista.Add(oCliente);
            }
            return lista;
        }

        public List<Cliente> GetClientes()
        {

            SqlConnection conexion = new SqlConnection (cadena);
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
                oCliente.Id = Convert.ToInt32(row["id_cliente"].ToString());
                oCliente.nombre = row["nombre"].ToString();
                oCliente.apellido = row["apellido"].ToString();
                oCliente.dni = Convert.ToInt32(row["dni"].ToString());
                oCliente.FechaAlta = Convert.ToDateTime(row["Fecha"].ToString());
                oCliente.password = row["passw"].ToString();


                lista.Add(oCliente);
            }
            return lista;


        }

        public bool GetCreateClienteCuentas(ClienteCuenta clienteCuentas) 
        {
            bool affect = true;
            SqlConnection conexion = new SqlConnection(cadena);
            SqlCommand comando = new SqlCommand();
            SqlTransaction transaction = null;
            conexion.Open();
            comando.Connection = conexion;
            comando.CommandType = CommandType.StoredProcedure;
            comando.CommandText = "SP_INSERTAR_CUENTA_CLIENTE";
            try
            {
                transaction = conexion.BeginTransaction();

              
                comando.Transaction = transaction;
                comando.Parameters.AddWithValue("@id_cliente",clienteCuentas.Id_cliente);
                comando.Parameters.AddWithValue("@tipoCuenta", clienteCuentas.tipoCuenta);
                comando.Parameters.AddWithValue("@cbu", clienteCuentas.Cbu);
                comando.Parameters.AddWithValue("@saldo",clienteCuentas.Saldo);
                var result = comando.ExecuteNonQuery();
                
                transaction.Commit();
            }
            catch (Exception)
            {
                transaction.Rollback();
                affect = false;

            }
            finally
            {
                if (conexion.State == ConnectionState.Open)
                {
                    conexion.Close();
                }
            }
            return affect;
        }

        public List<TipoCuenta> GetCuentas()
        {
            SqlConnection conexion = new SqlConnection(cadena);
            SqlCommand comando = new SqlCommand();
            conexion.Open();
            comando.Connection = conexion;
            comando.CommandType = CommandType.StoredProcedure;
            comando.CommandText = "SP_CONSULTAR_CUENTAS";
            DataTable tabla = new DataTable();
            tabla.Load(comando.ExecuteReader());

            conexion.Close();

            List<TipoCuenta> lista = new List<TipoCuenta>();
            foreach (DataRow row in tabla.Rows)
            {
                TipoCuenta oCuenta = new TipoCuenta();

                oCuenta.Id =Convert.ToInt32 (row["id_tipo_cuenta"]);
                oCuenta.Nombre = row["nombre_tipo_cuenta"].ToString();
                


                lista.Add(oCuenta);
            }
            return lista;
        }
    }
}
