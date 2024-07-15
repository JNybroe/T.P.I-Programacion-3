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
    public class NegocioProvincia
    {
        DatosProvincias datos = new DatosProvincias();

        public DataTable obtenerTablaProvincia()
        {
            return datos.obtenerTablaProvincias();
        }

        public Provincia obtenerProvincia(int id)
        {
            Provincia auxProv = new Provincia();
            auxProv = datos.getProvincia_Id(id);

            return auxProv;
        }
    }
}
