using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Paciente
    {

        private int idPaciente;
        private string nombrePaciente;
        private string apellidoPaciente;
        private string dniPaciente;
        private char sexoPaciente;
        private string nacionalidadPaciente;
        private DateTime fechaNacimiento_Paciente;
        private string direccionPaciente;
        private string telefonoPaciente;
        private string emailPaciente;
        private Provincia provincia_Paciente;
        private Localidad localidad_Paciente;
        private bool activoPaciente;


        public Paciente()
        {

        }

        public Paciente(int idPaciente, string nombrePaciente, string apellidoPaciente, string dniPaciente, char sexoPaciente, string nacionalidadPaciente, DateTime fechaNacimiento_Paciente, string direccionPaciente, string telefonoPaciente, string emailPaciente, Provincia provincia_Paciente, Localidad localidad_Paciente, bool activoPaciente)
        {
            this.IdPaciente = idPaciente;
            this.NombrePaciente = nombrePaciente;
            this.ApellidoPaciente = apellidoPaciente;
            this.DniPaciente = dniPaciente;
            this.SexoPaciente = sexoPaciente;
            this.NacionalidadPaciente = nacionalidadPaciente;
            this.FechaNacimiento_Paciente = fechaNacimiento_Paciente;
            this.DireccionPaciente = direccionPaciente;
            this.TelefonoPaciente = telefonoPaciente;
            this.EmailPaciente = emailPaciente;
            this.Provincia_Paciente = provincia_Paciente;
            this.Localidad_Paciente = localidad_Paciente;
            this.ActivoPaciente = activoPaciente;
        }

        public int IdPaciente { get => idPaciente; set => idPaciente = value; }
        public string NombrePaciente { get => nombrePaciente; set => nombrePaciente = value; }
        public string ApellidoPaciente { get => apellidoPaciente; set => apellidoPaciente = value; }
        public string DniPaciente { get => dniPaciente; set => dniPaciente = value; }
        public char SexoPaciente { get => sexoPaciente; set => sexoPaciente = value; }
        public string NacionalidadPaciente { get => nacionalidadPaciente; set => nacionalidadPaciente = value; }
        public DateTime FechaNacimiento_Paciente { get => fechaNacimiento_Paciente; set => fechaNacimiento_Paciente = value; }
        public string DireccionPaciente { get => direccionPaciente; set => direccionPaciente = value; }
        public string TelefonoPaciente { get => telefonoPaciente; set => telefonoPaciente = value; }
        public string EmailPaciente { get => emailPaciente; set => emailPaciente = value; }
        public Provincia Provincia_Paciente { get => provincia_Paciente; set => provincia_Paciente = value; }
        public Localidad Localidad_Paciente { get => localidad_Paciente; set => localidad_Paciente = value; }
        public bool ActivoPaciente { get => activoPaciente; set => activoPaciente = value; }
    }
}
