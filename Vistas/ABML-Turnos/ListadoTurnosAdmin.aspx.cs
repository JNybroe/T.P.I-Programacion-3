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
    public partial class ListadoTurnosAdmin : System.Web.UI.Page
    {
        NegocioTurno negocioTurno = new NegocioTurno();
        NegocioEspecialidad negocioEspecialidad = new NegocioEspecialidad();
        static bool filtroActivado = false;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                asignarUsuario();
                cargarGridView();
                cargarDDLEspecialidades();
            }
        }

        void cargarGridView()
        {
            gvTurnos.DataSource = negocioTurno.obtenerTablaTurnos();
            gvTurnos.DataBind();
        }

        void cargarDDLEspecialidades()
        {
            ddlEspecialidades.DataSource = negocioEspecialidad.obtenerTablaEspecialidades();
            ddlEspecialidades.DataTextField = "NombreEspecialidad";
            ddlEspecialidades.DataValueField = "IdEspecialidad";
            ddlEspecialidades.DataBind();
        }

        protected void ddlCriterioBusqueda_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (ddlCriterioBusqueda.SelectedValue)
            {
                case "Fecha":
                    txtBuscarTurno.TextMode = TextBoxMode.Date;
                    txtBuscarTurno.Text = "";
                    break;
                default:
                    txtBuscarTurno.TextMode = TextBoxMode.Search;
                    txtBuscarTurno.Text = "";
                    break;
            }
        }


        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            if (txtBuscarTurno.Text == string.Empty)
            {
                lblTxtboxVacio.Text = "*Por favor ingrese información valida.";
                return;
            }

            lblTxtboxVacio.Text = "";
            gvTurnos.DataSource = negocioTurno.obtenerTablaTurnosFiltro(ddlCriterioBusqueda.SelectedItem.Text, txtBuscarTurno.Text, int.Parse(ddlEspecialidades.SelectedItem.Value));
            filtroActivado = true;
            gvTurnos.DataBind();
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

        protected void btnTurnosAsignados_Click(object sender, EventArgs e)
        {
            Response.Redirect("/ABML-Turnos/ListadoTurnosMedicos.aspx");
        }

        protected void gvTurnos_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Page")
                return;

            int index = Convert.ToInt32(e.CommandArgument);

            GridViewRow selectedRow = gvTurnos.Rows[index];

            string idTurno = (selectedRow.FindControl("lbl_it_CodigoTurno") as Label).Text;

            if (e.CommandName == "modificar")
            {
                Response.Redirect("ModificarTurno.aspx?IdTurno=" + idTurno);
            }

        }

        protected void gvTurnos_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvTurnos.PageIndex = e.NewPageIndex;
            if (filtroActivado)
                gvTurnos.DataSource = negocioTurno.obtenerTablaTurnosFiltro(ddlCriterioBusqueda.SelectedItem.Text, txtBuscarTurno.Text, int.Parse(ddlEspecialidades.SelectedItem.Value));
            else
                gvTurnos.DataSource = negocioTurno.obtenerTablaTurnos();

            gvTurnos.DataBind();
        }

        protected void btnVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Sesion/InicioAdministrador.aspx");
        }
    }
}