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
    public class NegocioPaciente
    {
        DatosPacientes datosPacientes = new DatosPacientes();


        public DataTable obtenerTablaPacientes()
        {

            return datosPacientes.obtenerTablaPacientes();
        }

        public void agregarPaciente(Paciente paciente)
        {

            datosPacientes.agregarPaciente(paciente);

        }

        public Paciente buscarPaciente_ID(string id)
        {
            return datosPacientes.getPaciente_Id(id);
        }

        public bool buscarPaciente_Dni(string dni)
        {
            bool existe = false;


            existe = datosPacientes.existenciaPaciente_Dni(dni);

            return existe;
        }


        public Paciente obtenerPaciente_Dni(string dni)
        {
            Paciente auxPaciente = new Paciente();

            auxPaciente = datosPacientes.getPaciente_Dni(dni);

            return auxPaciente;
        }


        public int bajaDePaciente(Paciente paciente)
        {
            int baja;
            baja = datosPacientes.darDeBajaPaciente(paciente);
            return baja;
        }

        public void modificarPaciente(Paciente actualizar)
        {
            datosPacientes.modificarPaciente(actualizar);
        }

        public DataTable obtenerTablaPacienteFiltro(string criterio, string filtro)
        {    
            return datosPacientes.obtenerTablaPacientesFiltro(criterio, filtro);
        }


        public Paciente traerPaciente(String DNI)
        {
            return datosPacientes.getPaciente_Dni(DNI);
        }
    }
}
