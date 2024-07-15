using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos;
using Entidades;

namespace Negocio
{
    public class NegocioEspecialidad
    {
        DatosEspecialidades datos = new DatosEspecialidades();

        public DataTable obtenerTablaEspecialidades()
        {
            return datos.obtenerTablaEspecialidades();
        }
    }
}
