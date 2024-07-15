using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Entidades;

namespace Datos
{
    public class DatosMedicos
    {
        AccesoDatos datos = new AccesoDatos();

        public DataTable obtenerTablaMedicos()
        {
            DataTable tablaMedicos = datos.ObtenerTabla("Medicos", "SELECT legajoMedico as Legajo, nombreMedico as Nombre, apellidoMedico as Apellido, DNI, NombreEspecialidad as Especialidad, Email, Telefono, NombreProvincia as Provincia, NombreLocalidad as Localidad, Direccion, nombreUsuario as Usuario, nivelDePermiso as Permiso FROM Medicos INNER JOIN Especialidades ON Medicos.IdEspecialidad = Especialidades.IdEspecialidad INNER JOIN Provincias ON Medicos.IdProvincia = Provincias.IdProvincia INNER JOIN Localidades ON Medicos.IdLocalidad = Localidades.IdLocalidad INNER JOIN Usuarios ON Medicos.IdUsuario = Usuarios.IdUsuario WHERE Activo = 1");
            datos.cerrarConexion();
            return tablaMedicos;
        }

        public Medico traerMedico(string legajo)
        {
            Medico aux = new Medico();
            aux.LegajoMedico = legajo;
            DataTable tablaMedicos = datos.ObtenerTabla("Medicos", "SELECT * FROM Medicos INNER JOIN Usuarios ON Medicos.IdUsuario = Usuarios.IdUsuario WHERE Activo = 1 AND legajoMedico = '" + legajo + "'");
            foreach (DataRow item in tablaMedicos.Rows)
            {
                if (item["legajoMedico"].ToString() == aux.LegajoMedico)
                {
                    aux.Especialidad_Medico = new Especialidad();
                    aux.Especialidad_Medico.IdEspecialidad = (int)item["IdEspecialidad"];
                    aux.Provincia_Medico = new Provincia();
                    aux.Provincia_Medico.IdProvincia = (int)item["IdProvincia"];
                    aux.Localidad_Medico = new Localidad();
                    aux.Localidad_Medico.IdLocalidad = (int)item["IdLocalidad"];
                    aux.DireccionMedico = (String)item["Direccion"];
                    aux.NombreMedico = (String)item["nombreMedico"];
                    aux.ApellidoMedico = (String)item["apellidoMedico"];
                    aux.DniMedico = (String)item["DNI"];
                    aux.SexoMedico = char.Parse(item["Sexo"].ToString());
                    aux.NacionalidadMedico = (String)item["Nacionalidad"];
                    aux.FechaNacimiento_Medico = (DateTime)item["FechaNacimiento"];
                    aux.TelefonoMedico = (String)item["Telefono"];
                    aux.EmailMedico = (String)item["Email"];
                    aux.Usuario_Medico = new Usuario();
                    aux.Usuario_Medico.IdUsuario = (int)item["IdUsuario"];
                    aux.Usuario_Medico.NombreUsuario = (String)item["nombreUsuario"];
                    aux.Usuario_Medico.ContraseniaUsuario = (String)item["contrasenia"];
                    aux.Usuario_Medico.NivelDePermisoUsuario = (String)item["nivelDePermiso"];
                    return aux;
                }
            }

            return null;
        }

        public DataTable obtenerTablaMedicosFiltro(string criterio, string filtro)
        {
            string consulta = "SELECT legajoMedico as Legajo, nombreMedico as Nombre, apellidoMedico as Apellido, DNI, NombreEspecialidad as Especialidad, Email, Telefono, NombreProvincia as Provincia, NombreLocalidad as Localidad, Direccion, nombreUsuario as Usuario, nivelDePermiso as Permiso FROM Medicos INNER JOIN Especialidades ON Medicos.IdEspecialidad = Especialidades.IdEspecialidad INNER JOIN Provincias ON Medicos.IdProvincia = Provincias.IdProvincia INNER JOIN Localidades ON Medicos.IdLocalidad = Localidades.IdLocalidad INNER JOIN Usuarios ON Medicos.IdUsuario = Usuarios.IdUsuario WHERE Activo = 1";

            switch (criterio.ToLower())
            {
                case "legajo":
                    consulta += " AND legajoMedico LIKE '%" + filtro + "%'";
                    break;
                case "especialidad":
                    consulta += " AND NombreEspecialidad LIKE '%" + filtro + "%'";
                    break;
                default:
                    break;
            }

            DataTable tablaMedicos = datos.ObtenerTabla("Medicos", consulta);
            datos.cerrarConexion();
            return tablaMedicos;
        }

        //Sobrecarga metodo
        public DataTable obtenerTablaMedicosFiltro(string id)
        {
            String consulta = "SELECT nombreMedico + ' ' + apellidoMedico as Nombre, legajoMedico FROM Medicos WHERE Activo = 1 AND IdEspecialidad =" + id;
            DataTable tablaMedicos = datos.ObtenerTabla("Medicos", consulta);
            datos.cerrarConexion();
            return tablaMedicos;
        }


        public void modificarMedico(Medico actualizar)
        {
            SqlCommand command = new SqlCommand();
            ParametrosModificarMedico(ref command, actualizar);
            datos.ejecutarProcedimientoAlmacenado(ref command, "SpActualizarMedico");
        }

        private void ParametrosModificarMedico(ref SqlCommand command, Medico actualizar)
        {
            SqlParameter parametros = new SqlParameter();

            parametros = command.Parameters.Add("@legajoMedico", SqlDbType.VarChar);
            parametros.Value = actualizar.LegajoMedico;

            parametros = command.Parameters.Add("@nombreMedico", SqlDbType.VarChar);
            parametros.Value = actualizar.NombreMedico;

            parametros = command.Parameters.Add("@apellidoMedico", SqlDbType.VarChar);
            parametros.Value = actualizar.ApellidoMedico;

            parametros = command.Parameters.Add("@DNI", SqlDbType.VarChar);
            parametros.Value = actualizar.DniMedico;

            parametros = command.Parameters.Add("@IdEspecialidad", SqlDbType.Int);
            parametros.Value = actualizar.Especialidad_Medico.IdEspecialidad;

            parametros = command.Parameters.Add("@IdProvincia", SqlDbType.Int);
            parametros.Value = actualizar.Provincia_Medico.IdProvincia;

            parametros = command.Parameters.Add("@IdLocalidad", SqlDbType.Int);
            parametros.Value = actualizar.Localidad_Medico.IdLocalidad;

            parametros = command.Parameters.Add("@Sexo", SqlDbType.Char);
            parametros.Value = actualizar.SexoMedico;

            parametros = command.Parameters.Add("@Nacionalidad", SqlDbType.VarChar);
            parametros.Value = actualizar.NacionalidadMedico;

            parametros = command.Parameters.Add("@FechaNacimiento", SqlDbType.Date);
            parametros.Value = actualizar.FechaNacimiento_Medico;

            parametros = command.Parameters.Add("@Direccion", SqlDbType.VarChar);
            parametros.Value = actualizar.DireccionMedico;

            parametros = command.Parameters.Add("@Telefono", SqlDbType.VarChar);
            parametros.Value = actualizar.TelefonoMedico;

            parametros = command.Parameters.Add("@Email", SqlDbType.VarChar);
            parametros.Value = actualizar.EmailMedico;
        }

        public void bajaMedico(string legajo)
        {
            SqlCommand command = new SqlCommand();
            ParametrosBajaMedico(ref command, legajo);
            datos.ejecutarProcedimientoAlmacenado(ref command, "SpBajaLogicaMedico");
        }

        private void ParametrosBajaMedico(ref SqlCommand command, string legajo)
        {
            SqlParameter parametros = new SqlParameter();

            parametros = command.Parameters.Add("@legajoMedico", SqlDbType.VarChar);
            parametros.Value = legajo;
        }

        public bool existeDato(string consulta)
        {
            return datos.existeDato(consulta);
        }

        public bool existeLegajo(string legajo)
        {
            String consulta = "SELECT * FROM Medicos WHERE legajoMedico = '" + legajo + "'";
            return datos.existeDato(consulta);
        }

        public bool existeNombreApellido(string nombre, string apellido)
        {
            String consulta = "SELECT * FROM Medicos WHERE nombreMedico = '" + nombre + "' AND apellidoMedico = '" + apellido + "'";
            return datos.existeDato(consulta);
        }

        public bool existeDNI(String DNI)
        {
            String consulta = "SELECT * FROM Medicos WHERE DNI = '" + DNI + "'";
            return datos.existeDato(consulta);
        }

        public bool existeEmail(String email) 
        {
            String consulta = "SELECT * FROM Medicos WHERE Email = '" + email + "'";
            return datos.existeDato(consulta);
        }


        public void agregarMedico(Medico medico)
        {
            SqlCommand command = new SqlCommand();
            ParametrosAgregarMedico(ref command, medico);
            datos.ejecutarProcedimientoAlmacenado(ref command, "SpAgregarMedico");
        }

        private void ParametrosAgregarMedico(ref SqlCommand command, Medico medico)
        {
            SqlParameter parametros = new SqlParameter();

            parametros = command.Parameters.Add("@legajoMedico", SqlDbType.VarChar);
            parametros.Value = medico.LegajoMedico;

            parametros = command.Parameters.Add("@nombreMedico", SqlDbType.VarChar);
            parametros.Value = medico.NombreMedico;

            parametros = command.Parameters.Add("@apellidoMedico", SqlDbType.VarChar);
            parametros.Value = medico.ApellidoMedico;

            parametros = command.Parameters.Add("@DNI", SqlDbType.VarChar);
            parametros.Value = medico.DniMedico;

            parametros = command.Parameters.Add("@IdEspecialidad", SqlDbType.Int);
            parametros.Value = medico.Especialidad_Medico.IdEspecialidad;

            parametros = command.Parameters.Add("@IdProvincia", SqlDbType.Int);
            parametros.Value = medico.Provincia_Medico.IdProvincia;

            parametros = command.Parameters.Add("@IdLocalidad", SqlDbType.Int);
            parametros.Value = medico.Localidad_Medico.IdLocalidad;

            parametros = command.Parameters.Add("@IdUsuario", SqlDbType.Int);
            parametros.Value = medico.Usuario_Medico.IdUsuario;

            parametros = command.Parameters.Add("@Sexo", SqlDbType.Char);
            parametros.Value = medico.SexoMedico;

            parametros = command.Parameters.Add("@Nacionalidad", SqlDbType.VarChar);
            parametros.Value = medico.NacionalidadMedico;

            parametros = command.Parameters.Add("@FechaNacimiento", SqlDbType.Date);
            parametros.Value = medico.FechaNacimiento_Medico;

            parametros = command.Parameters.Add("@Direccion", SqlDbType.VarChar);
            parametros.Value = medico.DireccionMedico;

            parametros = command.Parameters.Add("@Telefono", SqlDbType.VarChar);
            parametros.Value = medico.TelefonoMedico;

            parametros = command.Parameters.Add("@Email", SqlDbType.VarChar);
            parametros.Value = medico.EmailMedico;
        }
    }
}
