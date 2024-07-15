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
    public class NegocioLocalidad
    {
        DatosLocalidades datos = new DatosLocalidades();

        public DataTable obtenerTablaLocalidades(String id)
        {
            return datos.obtenerTablaLocalidades(id);
        }


        public Localidad obtenerLocalidad(int id)
        {
            Localidad auxLocalidad = new Localidad();
            auxLocalidad = datos.getLocalidad_Id(id);

            return auxLocalidad;
        }

    }
}
