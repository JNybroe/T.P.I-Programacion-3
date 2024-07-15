using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Entidades;

namespace Datos
{
    public class DatosProvincias
    {
        AccesoDatos datos = new AccesoDatos();
        
        public DataTable obtenerTablaProvincias()
        {
            DataTable tablaProvincias = datos.ObtenerTabla("Provincias", "SELECT * FROM Provincias");
            datos.cerrarConexion();
            return tablaProvincias;
        }

        public Provincia getProvincia(Provincia prov)
        {
            Provincia auxProv = new Provincia();

            DataTable tabla = datos.ObtenerTabla("Provincias", "Select * from Provincias where IdProvincia=" + prov.IdProvincia);

            auxProv.IdProvincia = (Convert.ToInt32(tabla.Rows[0][0].ToString()));
            auxProv.NombreProvincia = (tabla.Rows[0][1].ToString());

            return auxProv;
        }

        public Provincia getProvincia_Id(int id)
        {
            Provincia auxProv = new Provincia();

            DataTable tabla = datos.ObtenerTabla("Provincias", "Select * from Provincias where IdProvincia=" + id);

            auxProv.IdProvincia = (Convert.ToInt32(tabla.Rows[0][0].ToString()));
            auxProv.NombreProvincia = (tabla.Rows[0][1].ToString());

            return auxProv;
        }

    }
}
