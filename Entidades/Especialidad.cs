using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Especialidad
    {
        private int idEspecialidad;
        private string nombreEspecialidad;

        public Especialidad()
        {

        }

        public Especialidad(int idEspecialidad, string nombreEspecialidad)
        {
            this.IdEspecialidad = idEspecialidad;
            this.NombreEspecialidad = nombreEspecialidad;
        }

        public int IdEspecialidad { get => idEspecialidad; set => idEspecialidad = value; }
        public string NombreEspecialidad { get => nombreEspecialidad; set => nombreEspecialidad = value; }
    }
}
