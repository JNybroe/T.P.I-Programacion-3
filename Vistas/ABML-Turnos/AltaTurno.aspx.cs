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
    public partial class AltaTurno : System.Web.UI.Page
    {
        NegocioEspecialidad negocioEspecialidad = new NegocioEspecialidad();
        NegocioMedico negocioMedico = new NegocioMedico();
        NegocioPaciente negocioPaciente = new NegocioPaciente();
        NegocioTurno negocioTurno = new NegocioTurno();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                cargarDDLEspecialidad();
                cargarDDLMedicos("");
                cargarDDLPacientes();
                asignarUsuario();
            }
        }

        void cargarDDLEspecialidad()
        {
            ddlEspecialidad.DataSource = negocioEspecialidad.obtenerTablaEspecialidades();
            ddlEspecialidad.DataTextField = "NombreEspecialidad";
            ddlEspecialidad.DataValueField = "IdEspecialidad";
            ddlEspecialidad.DataBind();
            ddlEspecialidad.Items.Insert(0, new ListItem("- Seleccione una Especialidad -", ""));
        }

        void cargarDDLMedicos(string id)
        {
            if (!string.IsNullOrEmpty(id))
            {
                ddlMedicoDesignado.DataSource = negocioMedico.obtenerTablaMedicosEspecialidad(id);
                ddlMedicoDesignado.DataTextField = "Nombre";
                ddlMedicoDesignado.DataValueField = "legajoMedico";
                ddlMedicoDesignado.DataBind();
                ddlMedicoDesignado.Items.Insert(0, new ListItem("- Seleccione un Medico -", ""));
            }
            else
            {
                ddlMedicoDesignado.Items.Clear();
                ddlMedicoDesignado.Items.Insert(0, new ListItem("- Seleccione un Medico -", ""));
            }
        }

        void cargarDDLPacientes()
        {
            ddlPaciente.DataSource = negocioPaciente.obtenerTablaPacientes();
            ddlPaciente.DataTextField = "DNI";
            ddlPaciente.DataValueField = "ID";
            ddlPaciente.DataBind();
            ddlPaciente.Items.Insert(0, new ListItem("- Seleccione un Paciente -", ""));

        }

        protected void ddlEspecialidad_SelectedIndexChanged(object sender, EventArgs e)
        {
            cargarDDLMedicos(ddlEspecialidad.SelectedValue);
        }

        protected void btnAgregarTurno_Click(object sender, EventArgs e)
        {
            lblFechaError.Text = "";
            lblEspecialidadError.Text = "";
            lblMedicoError.Text = "";
            lblPacienteError.Text = "";

            if (ddlEspecialidad.SelectedIndex == 0)
            {
                lblEspecialidadError.Text = "*Especialidad no valida.";
                return;
            }

            if (ddlMedicoDesignado.SelectedIndex == 0)
            {
                lblMedicoError.Text = "*Medico no valido.";
                return;
            }

            if (txtFechaTurno.Text == string.Empty)
            {
                lblFechaError.Text = "*Fecha no valida, por favor cargue una nueva.";
                return;
            }

            if (ddlHorarioTurno.SelectedIndex == 0)
            {
                lblErrorHorario.Text = "Este campo es obligatorio";
                return;
            }

            if (ddlPaciente.SelectedIndex == 0)
            {
                lblPacienteError.Text = "*Paciente no valido.";
                return;
            }

            Medico auxMedico = new Medico();
            Paciente auxPaciente = new Paciente();
            Turno turno = new Turno();
            DateTime diaTurno = DateTime.Parse(txtFechaTurno.Text);

            auxMedico.Especialidad_Medico = new Especialidad();
            auxMedico.Especialidad_Medico.IdEspecialidad = int.Parse(ddlEspecialidad.SelectedValue);
            auxMedico.LegajoMedico = ddlMedicoDesignado.SelectedItem.Value;
            auxPaciente.IdPaciente = int.Parse(ddlPaciente.SelectedValue);

            turno.medicoEncargado = auxMedico;
            turno.pacienteTurno = auxPaciente;
            turno.DiaHora = diaTurno.AddHours(double.Parse(ddlHorarioTurno.SelectedItem.Value));

            if (!negocioTurno.existeTurno(turno))
            {
                lblErrorHorario.Text = "";
                negocioTurno.agregarTurno(turno);
                lblTurnoExistente.Text = "Turno agendado!";
                lblTurnoExistente.ForeColor = System.Drawing.Color.Green;
                btnCancelar.Text = "Salir";
                limpiarControles();
            }
            else
            {
                lblTurnoExistente.Text = "Existe el turno!";
                lblTurnoExistente.ForeColor = System.Drawing.Color.Red;
            }
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Sesion/InicioAdministrador.aspx");
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

        protected void ddlPaciente_SelectedIndexChanged(object sender, EventArgs e)
        {
            string aux = ddlPaciente.SelectedValue;

            if (!string.IsNullOrEmpty(aux))
            {
                cargarDatosPaciente(aux);
            }
        }

        void cargarDatosPaciente(string idPaciente)
        {
            Paciente aux = negocioPaciente.buscarPaciente_ID(idPaciente);
            txtApellidoPaciente.Text = aux.ApellidoPaciente;
            txtNombrePaciente.Text = aux.NombrePaciente;
            txtIdentificadorPaciente.Text = Convert.ToString(aux.IdPaciente);
        }

        void limpiarControles()
        {
            ddlEspecialidad.SelectedIndex = 0;
            ddlMedicoDesignado.SelectedIndex = 0;
            ddlHorarioTurno.SelectedIndex = 0;
            ddlPaciente.SelectedIndex = 0;
            txtFechaTurno.Text = "";
            txtApellidoPaciente.Text = "";
            txtNombrePaciente.Text = "";
            txtIdentificadorPaciente.Text = "";
        }
    }
}