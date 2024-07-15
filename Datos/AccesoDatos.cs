using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace Datos
{
    class AccesoDatos
    {
        private SqlConnection conexion;
        private SqlCommand comando;
        private SqlDataReader lector;

        String ruta = "Data Source=localhost\\sqlexpress;Initial Catalog=Clinica_G21;Integrated Security=True";
        

        public AccesoDatos() { }

        private SqlConnection ObtenerConexion()
        {
            conexion = new SqlConnection(ruta);
            try
            {
                conexion.Open();
                return conexion;
            }
            catch (Exception ex)
            {
                return null;
                throw ex;
            }
        }

        private SqlDataAdapter ObtenerAdaptador(String consultaSql, SqlConnection cn)
        {
            SqlDataAdapter adaptador;
            try
            {
                adaptador = new SqlDataAdapter(consultaSql, cn);
                return adaptador;
            }
            catch (Exception ex)
            {
                return null;
                throw ex;
            }
        }

        public void cerrarConexion()
        {
            if (lector != null) { lector.Close(); }
            conexion.Close();
        }

        public DataTable ObtenerTabla(String NombreTabla, String Sql)
        {
            DataSet ds = new DataSet();
            SqlConnection Conexion = ObtenerConexion();
            SqlDataAdapter adp = ObtenerAdaptador(Sql, Conexion);
            adp.Fill(ds, NombreTabla);
            Conexion.Close();
            return ds.Tables[NombreTabla];
        }

        ///Sobrecarga del metodo
        public DataTable ObtenerTabla(String NombreTabla, SqlCommand comando)
        {
            DataSet ds = new DataSet();
            comando.Connection = ObtenerConexion();
            SqlDataAdapter adp = new SqlDataAdapter(comando);
            adp.Fill(ds, NombreTabla);
            cerrarConexion();
            return ds.Tables[NombreTabla];
        }

        public int ejecutarProcedimientoAlmacenado(ref SqlCommand command, String NombreSP)
        {
            conexion = ObtenerConexion();
            comando = command;
            comando.Connection = conexion;
            comando.CommandType = CommandType.StoredProcedure;
            comando.CommandText = NombreSP;
            int ultimaFila = comando.ExecuteNonQuery();
            cerrarConexion();
            return ultimaFila;
        }

        public int obtenerMaximo(String consulta)
        {
            int max = 0;
            conexion = ObtenerConexion();
            comando = new SqlCommand(consulta, conexion);
            SqlDataReader datos = comando.ExecuteReader();
            if (datos.Read())
            {
                max = Convert.ToInt32(datos[0].ToString());
            }
            datos.Close();
            cerrarConexion();
            return max;
        }

        public bool existeDato(String consulta)
        {
            bool existe = false;
            conexion = ObtenerConexion();
            comando = new SqlCommand(consulta, conexion);
            lector = comando.ExecuteReader();

            if (lector.Read())
                existe = true;

            cerrarConexion();
            return existe;
        }

        public void ejecutarConsulta(SqlCommand cmd)
        {
            conexion = ObtenerConexion();
            cmd.Connection = conexion;
            cmd.ExecuteNonQuery();
            cerrarConexion();
        }

    }
}
