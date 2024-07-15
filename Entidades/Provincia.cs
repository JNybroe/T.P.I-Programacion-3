using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Provincia
    {

        private int idProvincia;
        private string nombreProvincia;


        public Provincia()
        {

        }

        public Provincia(int idProvincia, string nombreProvincia)
        {
            this.IdProvincia = idProvincia;
            this.NombreProvincia = nombreProvincia;
        }

        public int IdProvincia { get => idProvincia; set => idProvincia = value; }
        public string NombreProvincia { get => nombreProvincia; set => nombreProvincia = value; }
    }
}
