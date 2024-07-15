using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Datos;
using Entidades;

namespace Negocio
{
    public class NegocioTurno
    {
        DatosTurnos datos = new DatosTurnos();

        public void agregarTurno(Turno turno)
        {
            datos.agregarTurno(turno);
        }
        public DataTable obtenerTablaTurnos()
        {
            return datos.obtenerTablaTurnos();
        }

        public DataTable obtenerTablaTurnos(string legajo)
        {
            return datos.obtenerTablaTurnos(legajo);
        }


        public bool existeTurno(Turno turno)
        {
            return datos.existeTurno(turno);
        }

        public Turno buscarTurnoUnico(string id)
        {
            return datos.traerTurno(id);
        }

        public void modificarTurno(Turno actualizar)
        {
            datos.modificarTurno(actualizar);
        }

        public DataTable obtenerTablaTurnosFiltro(string criterio, string filtro, string legajo = " ")
        {
            return datos.obtenerTablaTurnosFiltro(criterio, filtro, legajo);
        }

        public DataTable obtenerTablaTurnosFiltro(string criterio, string filtro, int especialidad)
        {
            return datos.obtenerTablaTurnosFiltro(criterio, filtro, especialidad);
        }

        public DataTable obtenerTablaTurnosFiltro(string fecha1, string fecha2)
        {
            return datos.obtenerTablaTurnosFiltro(fecha1, fecha2);
        }

        public void actualizarEstadoTurno(Turno actualizar)
        {
            datos.actualizarEstadoTurno(actualizar);
        }

        public DataTable obtenerTablaTurnosFiltro(string especialidad)
        {
            return datos.obtenerTablaTurnos(int.Parse(especialidad));
        }
    }
}
