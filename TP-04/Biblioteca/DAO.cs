using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Biblioteca
{
    public static class DAO
    {
        private static SqlConnection Conexion(string cadena)
        {
            SqlConnection conexion = null;
            try
            {
                conexion = new SqlConnection(cadena);
            }
            catch (Exception)
            {
                throw;
            }

            return conexion;
        }

        public static DataTable Leer(string select)
        {
            DataTable table = new DataTable();
            SqlConnection conexion = null;
            SqlCommand comando = null;
            SqlDataAdapter adapter = null;
            try
            {
                conexion = Conexion(Archivos.LeerArchivoCadenaConexion());
                conexion.Open();

                comando = new SqlCommand(select, conexion);
                adapter = new SqlDataAdapter(comando);
                adapter.Fill(table);
                
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                conexion.Close();
                comando.Dispose();
            }
            return table;
        }

        public static int Grabar(string script)
        {
            SqlConnection conexion = null;
            SqlCommand comando = null;
            int filasAfectadas = 0;
            try
            {
                conexion = Conexion(Archivos.LeerArchivoCadenaConexion());
                conexion.Open();               
                comando = new SqlCommand(script, conexion);
                filasAfectadas = comando.ExecuteNonQuery();
                
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                conexion.Close();
            }
            return filasAfectadas;

        }
    }
}
