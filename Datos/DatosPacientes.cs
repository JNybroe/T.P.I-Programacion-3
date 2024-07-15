using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;

namespace Datos
{
    public class DatosPacientes
    {
        AccesoDatos datos = new AccesoDatos();

        public void agregarPaciente(Paciente paciente)
        {
            SqlCommand command = new SqlCommand();
            ParametrosAgregarPaciente(ref command, paciente);
            datos.ejecutarProcedimientoAlmacenado(ref command, "SpAgregarPaciente");
        }

        public DataTable obtenerTablaPacientes()
        {
            DataTable tablaPacientes = datos.ObtenerTabla("Pacientes", "SELECT IdPaciente as ID, NombrePaciente as Nombre, ApellidoPaciente as Apellido, DNI, FechaNacimiento, Sexo, Email, Telefono, Nacionalidad, " +
            "NombreProvincia as Provincia, NombreLocalidad as Localidad, Direccion FROM Pacientes " +
            "INNER JOIN Provincias ON Pacientes.IdProvincia = Provincias.IdProvincia " +
            "INNER JOIN Localidades ON Pacientes.IdLocalidad = Localidades.IdLocalidad WHERE Activo = 1");
            datos.cerrarConexion();
            return tablaPacientes;
        }

        public Paciente getPaciente_Id(string id)
        {
            Paciente aux = new Paciente();
            aux.IdPaciente = int.Parse(id);
            DataTable tablaPaciente = datos.ObtenerTabla("Pacientes", "SELECT * FROM Pacientes WHERE Activo = 1 AND IdPaciente =" + id);

            foreach(DataRow item in tablaPaciente.Rows)
            {
                if (item["IdPaciente"].ToString() == aux.IdPaciente.ToString())
                {
                    aux.NombrePaciente= (String)item["NombrePaciente"];
                    aux.ApellidoPaciente = (String)item["ApellidoPaciente"];
                    aux.DniPaciente = (String)item["DNI"];
                    aux.SexoPaciente = char.Parse(item["Sexo"].ToString());
                    aux.DireccionPaciente = (String)item["Direccion"];
                    aux.EmailPaciente = (String)item["Email"];
                    aux.TelefonoPaciente = (String)item["Telefono"];
                    aux.NacionalidadPaciente = (String)item["Nacionalidad"];
                    aux.FechaNacimiento_Paciente = (DateTime)item["FechaNacimiento"];
                    aux.Provincia_Paciente = new Provincia();
                    aux.Provincia_Paciente.IdProvincia = (int)item["IdProvincia"];
                    aux.Localidad_Paciente = new Localidad();
                    aux.Localidad_Paciente.IdLocalidad = (int)item["IdLocalidad"];
                    return aux;
                }
            }

            return null;

        }

        public DataTable obtenerTablaPacientesFiltro(string criterio, string filtro)
        {
            string consulta = "SELECT IdPaciente as ID, NombrePaciente as Nombre, ApellidoPaciente as Apellido, DNI, FechaNacimiento, Sexo, Email, Telefono, Nacionalidad, NombreProvincia as Provincia, NombreLocalidad as Localidad, Direccion FROM Pacientes INNER JOIN Provincias ON Pacientes.IdProvincia = Provincias.IdProvincia INNER JOIN Localidades ON Pacientes.IdLocalidad = Localidades.IdLocalidad WHERE Activo = 1";

            switch (criterio.ToUpper())
            {
                case "ID":
                    if (!string.IsNullOrEmpty(filtro))
                        consulta += " AND IdPaciente = " + filtro;
                    break;
                case "DNI":
                    consulta += " AND DNI LIKE '%" + filtro + "%'";
                    break;
                case "APELLIDO":
                    consulta += " AND ApellidoPaciente LIKE '%" + filtro + "%'";
                    break;
                default:
                    break;
            }

            DataTable tablaPacientes = datos.ObtenerTabla("Pacientes", consulta);
            datos.cerrarConexion();
            return tablaPacientes;
        }

        private void ParametrosAgregarPaciente(ref SqlCommand command, Paciente paciente)
        {
            SqlParameter parametros = new SqlParameter();

            parametros = command.Parameters.Add("@NombrePaciente", SqlDbType.VarChar);
            parametros.Value = paciente.NombrePaciente;

            parametros = command.Parameters.Add("@ApellidoPaciente", SqlDbType.VarChar);
            parametros.Value = paciente.ApellidoPaciente;

            parametros = command.Parameters.Add("@DNI", SqlDbType.VarChar);
            parametros.Value = paciente.DniPaciente;

            parametros = command.Parameters.Add("@Sexo", SqlDbType.Char);
            parametros.Value = paciente.SexoPaciente;

            parametros = command.Parameters.Add("@Nacionalidad", SqlDbType.VarChar);
            parametros.Value = paciente.NacionalidadPaciente;

            parametros = command.Parameters.Add("@FechaNacimiento", SqlDbType.Date);
            parametros.Value = paciente.FechaNacimiento_Paciente;

            parametros = command.Parameters.Add("@Direccion", SqlDbType.VarChar);
            parametros.Value = paciente.DireccionPaciente;

            parametros = command.Parameters.Add("@Telefono", SqlDbType.VarChar);
            parametros.Value = paciente.TelefonoPaciente;

            parametros = command.Parameters.Add("@Email", SqlDbType.VarChar);
            parametros.Value = paciente.EmailPaciente;

            parametros = command.Parameters.Add("@IdProvincia", SqlDbType.Int);
            parametros.Value = paciente.Provincia_Paciente.IdProvincia;

            parametros = command.Parameters.Add("@IdLocalidad", SqlDbType.Int);
            parametros.Value = paciente.Localidad_Paciente.IdLocalidad;

           
            
        }

        public Boolean existenciaPaciente_Dni(string dni)
        {
            String consulta = "Select * from Pacientes where DNI='" + dni + "' AND Activo = 1";
            return datos.existeDato(consulta);
        }


        public Paciente getPaciente_Dni(string dni)
        {
            Paciente paciente = new Paciente();
            DatosProvincias dsProvincia = new DatosProvincias();
            DatosLocalidades dsLocalidades = new DatosLocalidades();
            int idProv;
            int idLoc;

            Localidad loc = new Localidad();

            DataTable tabla = datos.ObtenerTabla("Pacientes", "Select * from Pacientes where DNI='" + dni + "' AND Activo = 1");

            paciente.IdPaciente = (Convert.ToInt32(tabla.Rows[0][0].ToString()));
            paciente.NombrePaciente = (tabla.Rows[0][1].ToString());
            paciente.ApellidoPaciente = (tabla.Rows[0][2].ToString());
            paciente.DniPaciente = (tabla.Rows[0][3].ToString());
            paciente.SexoPaciente = (Convert.ToChar(tabla.Rows[0][4]));
            paciente.NacionalidadPaciente = (tabla.Rows[0][5].ToString());
            paciente.FechaNacimiento_Paciente = (Convert.ToDateTime(tabla.Rows[0][6]));
            paciente.DireccionPaciente = (tabla.Rows[0][7].ToString());
            paciente.TelefonoPaciente = (tabla.Rows[0][8].ToString());
            paciente.EmailPaciente = (tabla.Rows[0][9].ToString());

            idProv = (Convert.ToInt32(tabla.Rows[0][10].ToString()));
            idLoc = (Convert.ToInt32(tabla.Rows[0][11].ToString()));

            paciente.Provincia_Paciente = dsProvincia.getProvincia_Id(idProv);


            paciente.Localidad_Paciente = dsLocalidades.getLocalidad_Id(idLoc);


            paciente.ActivoPaciente = (Convert.ToBoolean(tabla.Rows[0][12]));

            return paciente;

        }

        public int darDeBajaPaciente(Paciente paciente)
        {
            SqlCommand comando = new SqlCommand();
            parametrosBajaPaciente(ref comando, paciente);
            return datos.ejecutarProcedimientoAlmacenado(ref comando, "spBajaLogicaPaciente");

        }


        public void parametrosBajaPaciente(ref SqlCommand comando, Paciente paciente)
        {
            SqlParameter SqlParametros = new SqlParameter();
            SqlParametros = comando.Parameters.Add("@IDPACIENTE", SqlDbType.Int);
            SqlParametros.Value = paciente.IdPaciente;
        }

        public void modificarPaciente(Paciente actualizar)
        {
            string consulta = @"
            UPDATE Pacientes
            SET NombrePaciente = @NombrePaciente, ApellidoPaciente = @ApellidoPaciente, DNI = @DNI,
            IdProvincia = @IdProvincia, IdLocalidad = @IdLocalidad, Sexo = @Sexo,
            Nacionalidad = @Nacionalidad, FechaNacimiento = @FechaNacimiento,
            Direccion = @Direccion, Telefono = @Telefono, Email = @Email
            WHERE IdPaciente = @IdPaciente";

            SqlCommand command = new SqlCommand(consulta);

            command.Parameters.AddWithValue("@IdPaciente", actualizar.IdPaciente);
            command.Parameters.AddWithValue("@NombrePaciente", actualizar.NombrePaciente);
            command.Parameters.AddWithValue("@ApellidoPaciente", actualizar.ApellidoPaciente);
            command.Parameters.AddWithValue("@DNI", actualizar.DniPaciente);
            command.Parameters.AddWithValue("@IdProvincia", actualizar.Provincia_Paciente.IdProvincia);
            command.Parameters.AddWithValue("@IdLocalidad", actualizar.Localidad_Paciente.IdLocalidad);
            command.Parameters.AddWithValue("@Sexo", actualizar.SexoPaciente);
            command.Parameters.AddWithValue("@Nacionalidad", actualizar.NacionalidadPaciente);
            command.Parameters.AddWithValue("@FechaNacimiento", actualizar.FechaNacimiento_Paciente);
            command.Parameters.AddWithValue("@Direccion", actualizar.DireccionPaciente);
            command.Parameters.AddWithValue("@Telefono", actualizar.TelefonoPaciente);
            command.Parameters.AddWithValue("@Email", actualizar.EmailPaciente);

            datos.ejecutarConsulta(command);
        }

    }
}
