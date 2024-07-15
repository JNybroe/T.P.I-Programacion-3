using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Entidades;
using Negocio;

namespace Vistas.Informes
{
    public partial class Informes : System.Web.UI.Page
    {
        NegocioEspecialidad negocioEspecialidad = new NegocioEspecialidad();
        NegocioTurno negocioTurno = new NegocioTurno();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                cargarDDLEspecialidad();
                asignarUsuario();
            }
        }

        void cargarDDLEspecialidad()
        {
            ddlEspecialidades.DataSource = negocioEspecialidad.obtenerTablaEspecialidades();
            ddlEspecialidades.DataTextField = "NombreEspecialidad";
            ddlEspecialidades.DataValueField = "IdEspecialidad";
            ddlEspecialidades.DataBind();
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

        protected void ddlCriterioInforme_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (ddlCriterioInforme.SelectedValue)
            {
                case "Especialidad":
                    lblFechaInicio.Visible = false;
                    lblFechaFinal.Visible = false;
                    ddlEspecialidades.Visible = true;
                    txtFechaInicio.Visible = false;
                    txtFechaFin.Visible = false;
                    break;
                case "Fecha":
                    lblFechaInicio.Visible = true;
                    lblFechaFinal.Visible = true;
                    ddlEspecialidades.Visible = false;
                    txtFechaInicio.Visible = true;
                    txtFechaFin.Visible = true;
                    break;
                default:
                    break;
            }
        }

        protected void btnGenerarInforme_Click(object sender, EventArgs e)
        {
            switch (ddlCriterioInforme.SelectedValue)
            {
                case "Especialidad":
                    gvInforme.DataSource = negocioTurno.obtenerTablaTurnosFiltro(ddlEspecialidades.SelectedItem.Value);
                    gvInforme.DataBind();
                    break;
                case "Fecha":
                    lblFechaInicioVacia.Visible = false;
                    lblFechaFinalVacia.Visible = false;

                    if (txtFechaInicio.Text == string.Empty)
                    {
                        lblFechaInicioVacia.Visible = true;
                        return;
                    }

                    if (txtFechaFin.Text == string.Empty)
                    {
                        lblFechaFinalVacia.Visible = true;
                        return;
                    }

                    gvInforme.DataSource = negocioTurno.obtenerTablaTurnosFiltro(txtFechaInicio.Text, txtFechaFin.Text);
                    gvInforme.DataBind();
                    break;
                default:
                    break;
            }
        }

        protected void btnVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Sesion/InicioAdministrador.aspx");
        }
    }
}