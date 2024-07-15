using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Localidad
    {
        private int idLocalidad;
        private Provincia provincia_Localidad;
        private string nombreLocalidad;

        public Localidad() { }

        public Localidad(int idLocalidad, Provincia provincia_Localidad, string nombreLocalidad)
        {
            this.IdLocalidad = idLocalidad;
            this.Provincia_Localidad = provincia_Localidad;
            this.NombreLocalidad = nombreLocalidad;
        }

        public int IdLocalidad { get => idLocalidad; set => idLocalidad = value; }
        public Provincia Provincia_Localidad { get => provincia_Localidad; set => provincia_Localidad = value; }
        public string NombreLocalidad { get => nombreLocalidad; set => nombreLocalidad = value; }
    }
}
