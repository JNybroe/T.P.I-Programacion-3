using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;
using Entidades;

namespace Vistas.ABML_Turnos
{
    public partial class ModificarTurno : System.Web.UI.Page
    {
        NegocioEspecialidad negocioEspecialidad = new NegocioEspecialidad();
        NegocioMedico negocioMedico = new NegocioMedico();
        NegocioTurno negocioTurno = new NegocioTurno();
        static int idActual;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["IdTurno"] != null)
            {
                Turno modificar = negocioTurno.buscarTurnoUnico(Request.QueryString["IdTurno"].ToString());

                if (modificar == null)
                    return;

                cargarTurno(modificar);
                idActual = modificar.Id;
                txtIdentificadorTurno.ReadOnly = true;
                btnBuscarTurno.Visible = false;

                if (!IsPostBack)
                {
                    cargarDDLEspecialidad();
                    asignarUsuario();
                }
            }
        }

        void cargarDDLEspecialidad(string id = " ", string legajo = "")
        {
            ddlEspecialidades.DataSource = negocioEspecialidad.obtenerTablaEspecialidades();
            ddlEspecialidades.DataTextField = "NombreEspecialidad";
            ddlEspecialidades.DataValueField = "IdEspecialidad";
            if (id != " ")
                ddlEspecialidades.SelectedValue = id;
            ddlEspecialidades.DataBind();
            if (legajo != " ")
                cargarDDLMedico(legajo);
        }

        void cargarDDLMedico(string legajo = " ")
        {
            ddlMedico.DataSource = negocioMedico.obtenerTablaMedicosEspecialidad(ddlEspecialidades.SelectedItem.Value);
            ddlMedico.DataTextField = "Nombre";
            ddlMedico.DataValueField = "legajoMedico";
            ddlMedico.DataBind();

            if (legajo != " ")
                ddlMedico.SelectedValue = legajo;
        }

        void cargarTurno(Turno turno)
        {
            txtIdentificadorTurno.Text = turno.Id.ToString();
            txtNombrePaciente.Text = turno.pacienteTurno.NombrePaciente;
            txtApellidoPaciente.Text = turno.pacienteTurno.ApellidoPaciente;
            txtDNIPaciente.Text = turno.pacienteTurno.DniPaciente;
            txtFechaTurno.Text = turno.DiaHora.ToString("d");
            ddlHorario.SelectedValue = turno.DiaHora.Hour.ToString() + ".00";
        }

        protected void ddlEspecialidades_SelectedIndexChanged(object sender, EventArgs e)
        {
            cargarDDLMedico();
        }

        protected void btnBuscarTurno_Click(object sender, EventArgs e)
        {
            if (txtIdentificadorTurno.Text == string.Empty)
            {
                lblIDVacio.Text = "*Error al buscar el turno.";
                return;
            }

            Turno buscar = negocioTurno.buscarTurnoUnico(txtIdentificadorTurno.Text);

            if (buscar != null)
            {
                cargarTurno(buscar);
                idActual = buscar.Id;
                cargarDDLEspecialidad(buscar.medicoEncargado.Especialidad_Medico.IdEspecialidad.ToString(), buscar.medicoEncargado.LegajoMedico);
                lblIDVacio.Text = "";
            }
            else
                lblIDVacio.Text = "*Turno inexistente.";
        }

        protected void btnModificarTurno_Click(object sender, EventArgs e)
        {
            Turno actualizar = new Turno();

            if (Request.QueryString["IdTurno"] != null)
                actualizar.Id = int.Parse(Request.QueryString["IdTurno"].ToString());
            else
                actualizar.Id = idActual;

            DateTime diaNuevo = DateTime.Parse(txtFechaTurno.Text);

            actualizar.medicoEncargado = new Medico();
            actualizar.medicoEncargado.LegajoMedico = ddlMedico.SelectedItem.Value;
            actualizar.medicoEncargado.Especialidad_Medico = new Especialidad();
            actualizar.medicoEncargado.Especialidad_Medico.IdEspecialidad = int.Parse(ddlEspecialidades.SelectedItem.Value);
            actualizar.DiaHora = diaNuevo.AddHours(double.Parse(ddlHorario.SelectedItem.Value));

            negocioTurno.modificarTurno(actualizar);
            lblTurnoModificado.Text = "Turno modificado.";
            btnModificarTurno.Enabled = false;
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

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("/ABML-Turnos/ListadoTurnosAdmin.aspx");
        }

        protected void btnVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Sesion/InicioAdministrador.aspx");
        }
    }
}