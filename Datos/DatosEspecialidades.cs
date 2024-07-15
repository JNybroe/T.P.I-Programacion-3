using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class DatosEspecialidades
    {
        AccesoDatos datos = new AccesoDatos();

        public DataTable obtenerTablaEspecialidades()
        {
            DataTable especialidades = datos.ObtenerTabla("Especialidades", "SELECT * FROM Especialidades");
            datos.cerrarConexion();
            return especialidades;
        }
    }
}
