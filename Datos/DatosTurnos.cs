using Entidades;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace Datos
{
    public class DatosTurnos
    {
        AccesoDatos datos = new AccesoDatos();

        public DataTable obtenerTablaTurnos()
        {
            return datos.ObtenerTabla("Turnos", "Select IdTurno as CodigoTurno, NombrePaciente + ' ' + ApellidoPaciente as Paciente, hora as Dia, nombreMedico + ' ' + apellidoMedico as MedicoEncargado, NombreEspecialidad as Especialidad, estado as Estado from Turnos INNER JOIN Pacientes ON Turnos.IdPaciente = Pacientes.IdPaciente INNER JOIN Medicos ON Turnos.legajoMedico = Medicos.legajoMedico INNER JOIN Especialidades ON Turnos.IdEspecialidad = Especialidades.IdEspecialidad");
        }

        public DataTable obtenerTablaTurnos(string legajo)
        {
            return datos.ObtenerTabla("Turnos", "Select IdTurno as CodigoTurno, NombrePaciente + ' ' + ApellidoPaciente as Paciente, hora as Dia, nombreMedico + ' ' + apellidoMedico as MedicoEncargado, NombreEspecialidad as Especialidad, estado as Estado from Turnos INNER JOIN Pacientes ON Turnos.IdPaciente = Pacientes.IdPaciente INNER JOIN Medicos ON Turnos.legajoMedico = Medicos.legajoMedico INNER JOIN Especialidades ON Turnos.IdEspecialidad = Especialidades.IdEspecialidad WHERE Turnos.legajoMedico = '" + legajo + "'");
        }

        public DataTable obtenerTablaTurnos(int especialidad)
        {
            //return datos.ObtenerTabla("Turnos", "SELECT NombreEspecialidad as Especialidad ,estado as Estado ,COUNT(estado) as Total FROM Turnos INNER JOIN Especialidades ON Turnos.IdEspecialidad = Especialidades.IdEspecialidad WHERE Turnos.IdEspecialidad = " + especialidad + " GROUP BY estado, NombreEspecialidad");
            return datos.ObtenerTabla("Turnos", "SELECT NombreEspecialidad as Especialidad ,estado as Estado ,COUNT(estado) as Total, CAST(COUNT(estado)* 100/(Select COUNT(*) FROM Turnos WHERE IdEspecialidad = " + especialidad + " ) as numeric(10,2)) as Porcentaje FROM Turnos INNER JOIN Especialidades ON Turnos.IdEspecialidad = Especialidades.IdEspecialidad WHERE Turnos.IdEspecialidad = " + especialidad + " GROUP BY estado, NombreEspecialidad");
        }

        public DataTable obtenerTablaTurnosFiltro(string fecha1, string fecha2)
        {
            return datos.ObtenerTabla("Turnos", "SET Language 'Spanish'" + "Select DATENAME(DAY, dia) as Dia, DATENAME(month, dia) as Mes, DATENAME(YEAR, dia) as Año, estado as Estado, COUNT(IdTurno) as TurnosTotales FROM Turnos WHERE dia BETWEEN '" + fecha1 + "' AND '" + fecha2 + "' GROUP BY DATENAME(month, dia), estado, DATENAME(YEAR, dia), DATENAME(DAY, dia)");
        }

        public void agregarTurno(Turno turno)
        {
            SqlCommand command = new SqlCommand();
            ParametrosAgregarTurno(ref command, turno);
            datos.ejecutarProcedimientoAlmacenado(ref command, "SpAgregarTurno");
        }

        public bool existeTurno(Turno turno)
        {
            bool existe = false;
            DataTable turnos = datos.ObtenerTabla("Turnos", "SELECT hora FROM Turnos WHERE legajoMedico = '" + turno.medicoEncargado.LegajoMedico + "' AND IdEspecialidad =" + turno.medicoEncargado.Especialidad_Medico.IdEspecialidad + " AND IdPaciente =" + turno.pacienteTurno.IdPaciente);
            foreach (DataRow item in turnos.Rows)
            {
                DateTime fechaAux = (DateTime)item["hora"];
                int sonIguales = DateTime.Compare(turno.DiaHora, fechaAux);

                if (sonIguales == 0)
                {
                    existe = true;
                    return existe;
                }
            }

            return existe;
        }

        public DataTable obtenerTablaTurnosFiltro(string criterio, string filtro, string legajo)
        {
            string consulta;
            if (legajo == string.Empty)
                consulta = "Select IdTurno as CodigoTurno, NombrePaciente + ' ' + ApellidoPaciente as Paciente, hora as Dia, nombreMedico + ' ' + apellidoMedico as MedicoEncargado, NombreEspecialidad as Especialidad, estado as Estado from Turnos INNER JOIN Pacientes ON Turnos.IdPaciente = Pacientes.IdPaciente INNER JOIN Medicos ON Turnos.legajoMedico = Medicos.legajoMedico INNER JOIN Especialidades ON Turnos.IdEspecialidad = Especialidades.IdEspecialidad WHERE ";
            else
                consulta = "Select IdTurno as CodigoTurno, NombrePaciente + ' ' + ApellidoPaciente as Paciente, NombreEspecialidad as Especialidad, hora as Dia, estado as Estado from Turnos INNER JOIN Pacientes ON Turnos.IdPaciente = Pacientes.IdPaciente INNER JOIN Medicos ON Turnos.legajoMedico = Medicos.legajoMedico INNER JOIN Especialidades ON Turnos.IdEspecialidad = Especialidades.IdEspecialidad WHERE Turnos.legajoMedico ='" + legajo + "' AND estado = 'PENDIENTE' AND ";

            switch (criterio)
            {
                case "Fecha":
                    consulta += " dia = '" + filtro + "'";
                    break;
                default:
                    consulta += " CONCAT(nombrePaciente,ApellidoPaciente) like '%" + filtro.Trim() + "%'";
                    break;
            }

            DataTable turnos = datos.ObtenerTabla("Turnos", consulta);
            datos.cerrarConexion();
            return turnos;
        }

        public DataTable obtenerTablaTurnosFiltro(string criterio, string filtro, int especialidad)
        {
            string consulta = "Select IdTurno as CodigoTurno, NombrePaciente + ' ' + ApellidoPaciente as Paciente, hora as Dia, nombreMedico + ' ' + apellidoMedico as MedicoEncargado, NombreEspecialidad as Especialidad, estado as Estado from Turnos INNER JOIN Pacientes ON Turnos.IdPaciente = Pacientes.IdPaciente INNER JOIN Medicos ON Turnos.legajoMedico = Medicos.legajoMedico INNER JOIN Especialidades ON Turnos.IdEspecialidad = Especialidades.IdEspecialidad WHERE Especialidades.IdEspecialidad = " + especialidad;

            switch (criterio)
            {
                case "Fecha":
                    consulta += " AND dia = '" + filtro + "'";
                    break;
                default:
                    consulta += " AND CONCAT(nombrePaciente,ApellidoPaciente) like '%" + filtro.Trim() + "%'";
                    break;
            }

            DataTable turnos = datos.ObtenerTabla("Turnos", consulta);
            datos.cerrarConexion();
            return turnos;
        }

        public void modificarTurno(Turno turno)
        {
            SqlCommand command = new SqlCommand();
            ParametrosModificarTurno(ref command, turno);
            datos.ejecutarProcedimientoAlmacenado(ref command, "SpActualizarTurno");
        }

        public void actualizarEstadoTurno(Turno turno)
        {
            SqlCommand command = new SqlCommand();
            ParametrosActualizarTurnoEstado(ref command, turno);
            datos.ejecutarProcedimientoAlmacenado(ref command, "SpActualizarEstadoTurno");
        }

        private void ParametrosActualizarTurnoEstado(ref SqlCommand command, Turno turno)
        {
            SqlParameter parametros = new SqlParameter();

            parametros = command.Parameters.Add("@IdTurno", SqlDbType.Int);
            parametros.Value = turno.Id;

            parametros = command.Parameters.Add("@estado", SqlDbType.VarChar);
            parametros.Value = turno.Estado;

            parametros = command.Parameters.Add("@observacion", SqlDbType.VarChar);
            parametros.Value = turno.Observacion;
        }

        private void ParametrosModificarTurno(ref SqlCommand command, Turno turno)
        {
            SqlParameter parametros = new SqlParameter();

            parametros = command.Parameters.Add("@IdTurno", SqlDbType.Int);
            parametros.Value = turno.Id;

            parametros = command.Parameters.Add("@legajoMedico", SqlDbType.VarChar);
            parametros.Value = turno.medicoEncargado.LegajoMedico;

            parametros = command.Parameters.Add("@IdEspecialidad", SqlDbType.Int);
            parametros.Value = turno.medicoEncargado.Especialidad_Medico.IdEspecialidad;

            parametros = command.Parameters.Add("@dia", SqlDbType.Date);
            parametros.Value = turno.DiaHora;

            parametros = command.Parameters.Add("@hora", SqlDbType.SmallDateTime);
            parametros.Value = turno.DiaHora;
        }

        public Turno traerTurno(string id)
        {
            Turno aux = new Turno();
            aux.Id = int.Parse(id);
            DataTable turnos = datos.ObtenerTabla("Turnos", "SELECT * FROM Turnos INNER JOIN Pacientes ON Turnos.IdPaciente = Pacientes.IdPaciente");
            foreach (DataRow item in turnos.Rows)
            {
                if (item["IdTurno"].ToString() == aux.Id.ToString())
                {
                    aux.DiaHora = (DateTime)item["hora"];
                    aux.medicoEncargado = new Medico();
                    aux.medicoEncargado.LegajoMedico = (string)item["legajoMedico"];
                    aux.medicoEncargado.Especialidad_Medico = new Especialidad();
                    aux.medicoEncargado.Especialidad_Medico.IdEspecialidad = (int)item["IdEspecialidad"];
                    aux.pacienteTurno = new Paciente();
                    aux.pacienteTurno.NombrePaciente = (string)item["NombrePaciente"];
                    aux.pacienteTurno.ApellidoPaciente = (string)item["ApellidoPaciente"];
                    aux.pacienteTurno.DniPaciente = (string)item["DNI"];
                    aux.Observacion = (string)item["observacion"];
                    aux.Estado = (string)item["estado"];
                    return aux;
                }
            }
            return null;

        }

        private void ParametrosAgregarTurno(ref SqlCommand command, Turno turno)
        {
            SqlParameter parametro = new SqlParameter();

            parametro = command.Parameters.Add("@IdEspecialidad", SqlDbType.Int);
            parametro.Value = turno.medicoEncargado.Especialidad_Medico.IdEspecialidad;

            parametro = command.Parameters.Add("@legajoMedico", SqlDbType.VarChar);
            parametro.Value = turno.medicoEncargado.LegajoMedico;

            parametro = command.Parameters.Add("@IdPaciente", SqlDbType.Int);
            parametro.Value = turno.pacienteTurno.IdPaciente;

            parametro = command.Parameters.Add("@dia", SqlDbType.Date);
            parametro.Value = turno.DiaHora.ToShortDateString();

            parametro = command.Parameters.Add("@hora", SqlDbType.SmallDateTime);
            parametro.Value = turno.DiaHora;
        }
    }
}
