using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;
using Entidades;

namespace Vistas
{
    public partial class InicioAdministrador : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                asignarUsuario();
            }
        }

        // ABML MEDICOS 
        protected void btnMedicosAlta_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/ABML-Medicos/AltaMedico.aspx");
        }

        protected void btnMedicosBaja_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/ABML-Medicos/BajaMedico.aspx");
        }

        protected void btnMedicosModificacion_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/ABML-Medicos/ModificarMedico.aspx");
        }

        protected void btnMedicosListado_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/ABML-Medicos/ListadoMedicos.aspx");
        }

        //ABML PACIENTES
        protected void btnPacientesAlta_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/ABML-Pacientes/AltaPaciente.aspx");
        }

        protected void btnPacientesBaja_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/ABML-Pacientes/BajaPaciente.aspx");
        }

        protected void btnPacientesModificacion_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/ABML-Pacientes/ModificarPaciente.aspx");
        }

        protected void btnPacientesListado_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/ABML-Pacientes/ListadoPacientes.aspx");
        }

        //Barra de Navegacion

        void asignarUsuario()
        {
            if (Session["usuario"] != null)
            {
                Usuario aux = (Usuario)Session["usuario"];
                lblUsuario.Text = "@" + aux.NombreUsuario;
            }
        }

        protected void lnkCerrarSesion_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Response.Redirect("~/Sesion/Login.aspx"); 
        }

        protected void lnkPerfil_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Sesion/ModificarPass.aspx");
        }

        protected void btnTurnosAlta_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/ABML-Turnos/AltaTurno.aspx");
        }


        protected void btnTurnosListado_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/ABML-Turnos/ListadoTurnosAdmin.aspx");
        }

        protected void btnInformes_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Informes/Informes.aspx");
        }

        protected void btnTurnosModificar_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/ABML-Turnos/ModificarTurno.aspx");
        }
    }
}