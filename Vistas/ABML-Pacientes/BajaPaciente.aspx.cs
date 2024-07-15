using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Entidades;
using Negocio;

namespace Vistas.ABML_Pacientes
{
    public partial class BajaPaciente : System.Web.UI.Page
    {
        NegocioPaciente paciente = new NegocioPaciente();

        protected void Page_Load(object sender, EventArgs e)
        {
            ValidationSettings.UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;

            if (Request.QueryString["DNI"] != null)
            {
                Paciente baja = paciente.obtenerPaciente_Dni(Request.QueryString["DNI"].ToString());
                cargarInicio(baja);
            }
            else
            {
                ingresos.Visible = false;
                btnEliminar.Visible = false;
            }

            if (!IsPostBack)
            {
                asignarUsuario();
            }
        }

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

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            int filas;
            Paciente bajaPaciente = new Paciente();
            bool control = paciente.buscarPaciente_Dni(txtDniPacienteBusqueda.Text);

            if (control)
            {
                bajaPaciente = paciente.obtenerPaciente_Dni(txtDniPacienteBusqueda.Text);
                filas = paciente.bajaDePaciente(bajaPaciente);
                lblError.Text = "";

                if (filas == 1)
                {
                    lblBajaCompleta.Text = "Paciente dado de baja exitosamente.";
                    ingresos.Visible = false;
                    btnEliminar.Visible = false;
                }
                else
                {
                    lblError.Text = "Error al dar de baja al Paciente.";
                }
            }
            else
            {
                lblErrorDNI.Text = "No se encontró el Paciente indicado.";
            }
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            bool control = paciente.buscarPaciente_Dni(txtDniPacienteBusqueda.Text);

            if (control)
            {
                ingresos.Visible = true;
                btnEliminar.Visible = true;
                txtDniPacienteBusqueda.Enabled = false;
                btnBuscar.Visible = false;
                Paciente auxPaciente = paciente.obtenerPaciente_Dni(txtDniPacienteBusqueda.Text);
                lblErrorDNI.Text = "";
                txtID.Text = auxPaciente.IdPaciente.ToString();
                txtNombrePaciente.Text = auxPaciente.NombrePaciente;
                txtApellidoPaciente.Text = auxPaciente.ApellidoPaciente;
                txtTelefonoPaciente.Text = auxPaciente.TelefonoPaciente;
                txtDireccionPaciente.Text = auxPaciente.DireccionPaciente;
                txtEmailPaciente.Text = auxPaciente.EmailPaciente;
            }
            else
            {
                lblErrorDNI.Text = "DNI de Paciente Inexistente.";
            }
        }

        public void cargarInicio(Paciente auxPaciente)
        {
            txtID.Text = auxPaciente.IdPaciente.ToString();
            txtNombrePaciente.Text = auxPaciente.NombrePaciente;
            txtApellidoPaciente.Text = auxPaciente.ApellidoPaciente;
            txtTelefonoPaciente.Text = auxPaciente.TelefonoPaciente;
            txtDireccionPaciente.Text = auxPaciente.DireccionPaciente;
            txtEmailPaciente.Text = auxPaciente.EmailPaciente;
        }

        protected void btnVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Sesion/InicioAdministrador.aspx");
        }

        protected void btnListado_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/ABML-Pacientes/ListadoPacientes.aspx");
        }
    }

}