using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Turno
    {
        private int id;
        private DateTime diaHora;
        private Medico medico;
        private Paciente paciente;
        private string estado;
        private string observacion;

        public Turno()
        {
        }

        public Turno(DateTime diaHora, Medico medico, Paciente paciente)
        {
            this.diaHora = diaHora;
            this.medico = medico;
            this.paciente = paciente;
        }

        public int Id { get => id; set => id = value; }
        public DateTime DiaHora { get => diaHora; set => diaHora = value; }
        public Medico medicoEncargado { get => medico; set => medico = value; }
        public Paciente pacienteTurno { get => paciente; set => paciente = value; }
        public string Estado { get => estado; set => estado = value; }
        public string Observacion { get => observacion; set => observacion = value; }
    }
}
