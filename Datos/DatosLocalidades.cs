using Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class DatosLocalidades
    {
        AccesoDatos datos = new AccesoDatos();

        public DataTable obtenerTablaLocalidades(String id)
        {
            DataTable tablaLocalidades = datos.ObtenerTabla("Localidades", "SELECT * FROM Localidades WHERE IdProvincia =" + id);
            datos.cerrarConexion();
            return tablaLocalidades;
        }


        public Localidad getLocalidad(Localidad localidad)
        {
            Localidad auxLoc = new Localidad();

            DataTable tabla = datos.ObtenerTabla("Localidades", "Select * from Localidades where IdLocalidad=" + localidad.IdLocalidad);

            auxLoc.IdLocalidad = (Convert.ToInt32(tabla.Rows[0][0].ToString()));
            auxLoc.NombreLocalidad = (tabla.Rows[0][1].ToString());

            return auxLoc;
        }

        public Localidad getLocalidad_Id(int id)
        {
            Localidad auxLoc = new Localidad();

            DataTable tabla = datos.ObtenerTabla("Localidades", "Select * from Localidades where IdLocalidad=" + id);

            auxLoc.IdLocalidad = (Convert.ToInt32(tabla.Rows[0][0].ToString()));
            auxLoc.NombreLocalidad = (tabla.Rows[0][1].ToString());

            return auxLoc;
        }


    }
}
