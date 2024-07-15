using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Entidades;
using Negocio;

namespace Vistas.ABML_Turnos
{
    public partial class Observaciones : System.Web.UI.Page
    {
        NegocioTurno negTurno = new NegocioTurno();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["IdTurno"] != null)
                {
                    Turno aux = negTurno.buscarTurnoUnico(Request.QueryString["IdTurno"].ToString());
                    cargarDatos(aux);
                    btnGuardarCambios.Enabled = true;
                }
                asignarUsuario();
            }
        }

        private void cargarDatos(Turno aux)
        {
            txtApellidoPaciente.Text = aux.pacienteTurno.ApellidoPaciente;
            txtNombrePaciente.Text = aux.pacienteTurno.NombrePaciente;
            txtTurno.Text = aux.Id.ToString();
            txtDNIPaciente.Text = aux.pacienteTurno.DniPaciente;
            txtObservacionesPaciente.Text = aux.Observacion;
            ddlEstadoPaciente.SelectedValue = aux.Estado;
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
            Response.Redirect("/Sesion/Login.aspx");
        }

        protected void lnkPerfil_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Sesion/ModificarPass.aspx");
        }

        protected void ddlEstadoPaciente_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (ddlEstadoPaciente.SelectedValue)
            {
                case "Ausente":
                    txtObservacionesPaciente.Enabled = false;
                    break;
                default:
                    txtObservacionesPaciente.Enabled = true;
                    break;
            }
        }

        protected void btnGuardarCambios_Click(object sender, EventArgs e)
        {
            Turno actualizar = new Turno();
            actualizar.Id = int.Parse(txtTurno.Text);
            actualizar.Estado = ddlEstadoPaciente.SelectedItem.Value;
            if (txtObservacionesPaciente.Enabled)
                actualizar.Observacion = txtObservacionesPaciente.Text;
            else
                actualizar.Observacion = " ";

            negTurno.actualizarEstadoTurno(actualizar);

            lblTurnoModificado.Text = "Se actualizo correctamente el turno.";
            btnCancelar.Text = "Salir";
            btnGuardarCambios.Enabled = false;
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("/ABML-Turnos/ListadoTurnos.aspx?legajo=" + Session["legajo"].ToString());
        }
    }
}