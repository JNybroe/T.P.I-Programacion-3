using Datos;
using Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class NegocioMedico
    {
        DatosMedicos datos = new DatosMedicos();

        public DataTable obtenerTablaMedicos()
        {

            return datos.obtenerTablaMedicos();

        }

        public void agregarMedico(Medico medico)
        {
            datos.agregarMedico(medico);
        }

        public void bajaLogicaMedico(String legajo)
        {
            datos.bajaMedico(legajo);
        }

        public bool existeLegajo(String legajo)
        {
            return datos.existeLegajo(legajo);
        }

        public bool existeNombreApellido(String nombre, String apellido)
        {
            return datos.existeNombreApellido(nombre, apellido);
        }

        public DataTable obtenerTablaMedicosEspecialidad(string id)
        {
            return datos.obtenerTablaMedicosFiltro(id);
        }

        public bool existeDNI(String DNI)
        {
            return datos.existeDNI(DNI);
        }

        public bool existeEmail(string email)
        {
            return datos.existeEmail(email);
        }

        public Medico buscarMedicoUnico(String legajo)
        {
            return datos.traerMedico(legajo);
        }

        public void modificarMedico(Medico actualizar)
        {
            datos.modificarMedico(actualizar);
        }

        public DataTable obtenerTablaMedicosFiltro(string criterio, string filtro)
        {
            return datos.obtenerTablaMedicosFiltro(criterio, filtro);
        }

    }
}
