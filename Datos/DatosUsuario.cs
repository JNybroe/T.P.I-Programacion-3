using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;

namespace Datos
{
    public class DatosUsuario
    {
        AccesoDatos datos = new AccesoDatos();

        public void agregarUsuario(Usuario usu)
        {
            SqlCommand command = new SqlCommand();
            ParametrosAgregarUsuario(ref command, usu);
            datos.ejecutarProcedimientoAlmacenado(ref command, "SpAgregarUsuario");
        }

        public int getUsuarioID(String nombre)
        {
            DataTable usuario = datos.ObtenerTabla("Usuarios", "SELECT IdUsuario, NombreUsuario  FROM Usuarios WHERE NombreUsuario = '" + nombre + "'");
            foreach (DataRow item in usuario.Rows)
            {
                if (item["nombreUsuario"].ToString() == nombre)
                    return (int)item["IdUsuario"];
            }
            return 0;
        }

        public void modificarUsuario(Usuario usuario)
        {
            SqlCommand command = new SqlCommand();
            ParametrosActualizarUsuario(ref command, usuario);
            datos.ejecutarProcedimientoAlmacenado(ref command, "SpActualizarUsuario");
        }

        private void ParametrosActualizarUsuario(ref SqlCommand command, Usuario usuario)
        {
            SqlParameter parametro = new SqlParameter();

            parametro = command.Parameters.Add("@IdUsuario", SqlDbType.VarChar);
            parametro.Value = usuario.IdUsuario;

            parametro = command.Parameters.Add("@nombreUsuario", SqlDbType.VarChar);
            parametro.Value = usuario.NombreUsuario;

            parametro = command.Parameters.Add("@contrasenia", SqlDbType.VarChar);
            parametro.Value = usuario.ContraseniaUsuario;
        }

        public string traerDuenioUsuario(string nombreUsuario)
        {
            string consulta = "SELECT legajoMedico FROM Usuarios INNER JOIN Medicos ON Usuarios.IdUsuario = Medicos.IdUsuario WHERE nombreUsuario = '" + nombreUsuario + "'";

            DataTable tablaUsuarios = datos.ObtenerTabla("Usuarios", consulta);
            foreach (DataRow item in tablaUsuarios.Rows)
            {
                return (string)item["legajoMedico"];
            }
            return null;
        }

        public void ParametrosAgregarUsuario(ref SqlCommand command, Usuario usu)
        {
            SqlParameter parametro = new SqlParameter();

            parametro = command.Parameters.Add("@nombreUsuario", SqlDbType.VarChar);
            parametro.Value = usu.NombreUsuario;

            parametro = command.Parameters.Add("@contrasenia", SqlDbType.VarChar);
            parametro.Value = usu.ContraseniaUsuario;

            parametro = command.Parameters.Add("@nivelDePermiso", SqlDbType.VarChar);
            parametro.Value = usu.NivelDePermisoUsuario;
        }

        public int ultimoUsuarioID()
        {
            return datos.obtenerMaximo("SELECT max(IdUsuario) FROM Usuarios");
        }

        public Usuario getUsuario(Usuario aux)
        {
            string consulta = "SELECT IdUsuario AS id, NombreUsuario AS nombre, Contrasenia AS pass, NivelDePermiso AS permiso FROM Usuarios WHERE NombreUsuario = @nombreUsuario";

            SqlCommand comando = new SqlCommand(consulta);
            comando.Parameters.AddWithValue("@nombreUsuario", aux.NombreUsuario);
            DataTable tabla = datos.ObtenerTabla("Usuarios", comando);

            if (tabla.Rows.Count == 0)
            {
                return null;
            }

            aux.IdUsuario = Convert.ToInt32(tabla.Rows[0]["id"]);
            aux.NombreUsuario = tabla.Rows[0]["nombre"].ToString();
            aux.ContraseniaUsuario = tabla.Rows[0]["pass"].ToString();
            aux.NivelDePermisoUsuario = tabla.Rows[0]["permiso"].ToString();

            return aux;
        }
        public void modificarAtributoPass(Usuario aux)
        {
            string consulta = "UPDATE Usuarios SET Contrasenia = @contrasenia WHERE NombreUsuario = @nombreUsuario";
            SqlCommand comando = new SqlCommand(consulta);
            comando.Parameters.AddWithValue("@nombreUsuario", aux.NombreUsuario);
            comando.Parameters.AddWithValue("@contrasenia", aux.ContraseniaUsuario);
            datos.ejecutarConsulta(comando);
        }




        public bool existeUsuario(string nomUsuario)
        {
            String consulta = "SELECT * FROM Usuarios WHERE nombreUsuario = '" + nomUsuario + "'";
            return datos.existeDato(consulta);

        }




    }
}
