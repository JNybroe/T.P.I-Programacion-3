using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Medico
    {
        private string legajoMedico;
        private Especialidad especialidad_Medico;
        private Usuario usuario_Medico;
        private Localidad localidad_Medico;
        private Provincia provincia_Medico;
        private string dniMedico;
        private string nombreMedico;
        private string apellidoMedico;
        private char sexoMedico;
        private string nacionalidadMedico;
        private DateTime fechaNacimiento_Medico;
        private string direccionMedico;
        private string telefonoMedico;
        private string emailMedico;


        public Medico()
        {

        }

        public Medico(string legajoMedico, Especialidad especialidad_Medico, Usuario usuario_Medico, Localidad localidad_Medico, Provincia provincia_Medico, string dniMedico, string nombreMedico, string apellidoMedico, char sexoMedico, string nacionalidadMedico, DateTime fechaNacimiento_Medico, string direccionMedico, string telefonoMedico, string emailMedico)
        {
            this.LegajoMedico = legajoMedico;
            this.Especialidad_Medico = especialidad_Medico;
            this.Usuario_Medico = usuario_Medico;
            this.Localidad_Medico = localidad_Medico;
            this.Provincia_Medico = provincia_Medico;
            this.DniMedico = dniMedico;
            this.NombreMedico = nombreMedico;
            this.ApellidoMedico = apellidoMedico;
            this.SexoMedico = sexoMedico;
            this.NacionalidadMedico = nacionalidadMedico;
            this.FechaNacimiento_Medico = fechaNacimiento_Medico;
            this.DireccionMedico = direccionMedico;
            this.TelefonoMedico = telefonoMedico;
            this.EmailMedico = emailMedico;
        }

        public string LegajoMedico { get => legajoMedico; set => legajoMedico = value; }
        public Especialidad Especialidad_Medico { get => especialidad_Medico; set => especialidad_Medico = value; }
        public Usuario Usuario_Medico { get => usuario_Medico; set => usuario_Medico = value; }
        public Localidad Localidad_Medico { get => localidad_Medico; set => localidad_Medico = value; }
        public Provincia Provincia_Medico { get => provincia_Medico; set => provincia_Medico = value; }
        public string DniMedico { get => dniMedico; set => dniMedico = value; }
        public string NombreMedico { get => nombreMedico; set => nombreMedico = value; }
        public string ApellidoMedico { get => apellidoMedico; set => apellidoMedico = value; }
        public char SexoMedico { get => sexoMedico; set => sexoMedico = value; }
        public string NacionalidadMedico { get => nacionalidadMedico; set => nacionalidadMedico = value; }
        public DateTime FechaNacimiento_Medico { get => fechaNacimiento_Medico; set => fechaNacimiento_Medico = value; }
        public string DireccionMedico { get => direccionMedico; set => direccionMedico = value; }
        public string TelefonoMedico { get => telefonoMedico; set => telefonoMedico = value; }
        public string EmailMedico { get => emailMedico; set => emailMedico = value; }
    }
}
