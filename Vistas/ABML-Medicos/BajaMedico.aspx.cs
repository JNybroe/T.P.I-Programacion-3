using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;
using Entidades;
using System.Data;

namespace Vistas
{
    public partial class BajaMedico : System.Web.UI.Page
    {
        NegocioMedico negocioMedico = new NegocioMedico();
        NegocioEspecialidad negocioEspecialidad = new NegocioEspecialidad();
        protected void Page_Load(object sender, EventArgs e)
        {
            ValidationSettings.UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;

            if (Request.QueryString["legajo"] != null)
            {
                Medico aux = negocioMedico.buscarMedicoUnico(Request.QueryString["legajo"].ToString());
                txtLegajoMedico.Text = Request.QueryString["legajo"].ToString();
                cargarDatos(aux);
                btnBuscar.Visible = false;
                txtLegajoMedico.Enabled = false;
            }
            else
            {
                ingresos.Visible = false;
                btnEliminarMedico.Visible = false;
            }

            cargarDDLEspecialidades();

            if (!IsPostBack)
            {
                asignarUsuario();
            }
        }

        void cargarDatos(Medico medico)
        {
            if (medico != null)
            {
                lblLegajoIncorrecto.Visible = false;
                txtNombre.Text = medico.NombreMedico;
                txtApellido.Text = medico.ApellidoMedico;
                txtIdentificadorUsuario.Text = medico.Usuario_Medico.IdUsuario.ToString();
                txtPrivilegiosUsuario.Text = medico.Usuario_Medico.NivelDePermisoUsuario;
                txtDNI.Text = medico.DniMedico;
                txtNombreUsuario.Text = medico.Usuario_Medico.NombreUsuario;
                ddlEspecialidad.SelectedValue = medico.Especialidad_Medico.IdEspecialidad.ToString();
            }
        }
        void cargarDDLEspecialidades()
        {
            DataTable especialidad = negocioEspecialidad.obtenerTablaEspecialidades();
            ddlEspecialidad.DataSource = especialidad;
            ddlEspecialidad.DataTextField = "NombreEspecialidad";
            ddlEspecialidad.DataValueField = "IdEspecialidad";
            ddlEspecialidad.DataBind();
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            limpiarControles();
            Medico aux = negocioMedico.buscarMedicoUnico(txtLegajoMedico.Text);
            if (aux != null)
            {
                cargarDatos(aux);
                ingresos.Visible = true;
                btnEliminarMedico.Visible = true;
                btnBuscar.Visible = false;
                txtLegajoMedico.Enabled = false;

            }
            else
            {
                lblLegajoIncorrecto.Visible = true;
                lblLegajoIncorrecto.Text = "*Legajo inexistente.";
            }
        }

        protected void btnEliminarMedico_Click(object sender, EventArgs e)
        {
            ingresos.Visible = false;
            btnCancelar.Visible = true;
            chkConfirmarBaja.Visible = true;
            btnConfirmarbaja.Visible = true;
            btnEliminarMedico.Visible = false;
        }

        protected void btnConfirmarbaja_Click(object sender, EventArgs e)
        {
            btnCancelar.Visible = true;

            if (chkConfirmarBaja.Checked)
            {
                negocioMedico.bajaLogicaMedico(txtLegajoMedico.Text);
                chkConfirmarBaja.Visible = false;
                btnConfirmarbaja.Visible = false;
                lblBajaCompleta.Visible = true;
                lblBajaCompleta.Text = "Se dio de baja al medico solicitado!";
                btnCancelar.Text = "Salir";
                btnCancelar.Visible = true;

            }
        }

        void limpiarControles()
        {
            btnCancelar.Text = "Cancelar";
            chkConfirmarBaja.Visible = false;
            btnConfirmarbaja.Visible = false;
            lblBajaCompleta.Visible = false;
            txtNombre.Text = "";
            txtApellido.Text = "";
            txtIdentificadorUsuario.Text = "";
            txtDNI.Text = "";
            txtNombreUsuario.Text = "";
            ddlEspecialidad.SelectedValue = "1";
        } 

        void asignarUsuario()
        {
            if (Session["usuario"] != null)
            {
                Usuario aux = (Usuario)Session["usuario"];
                lblUsuario.Text = "@" + aux.NombreUsuario;
            }
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Sesion/InicioAdministrador.aspx");
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

        protected void btnListado_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/ABML-Medicos/ListadoMedicos.aspx");
        }
    }
}