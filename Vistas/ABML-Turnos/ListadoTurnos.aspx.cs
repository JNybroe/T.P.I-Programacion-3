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
    public partial class ListadoTurnos : System.Web.UI.Page
    {
        NegocioTurno negocioTurno = new NegocioTurno();
        static bool filtroActivado = false;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["legajo"] != null)
            {
                txtLegajoMedico.Text = Request.QueryString["legajo"].ToString();
            }

            if (!IsPostBack)
            {
                asignarUsuario();
                cargarGridView(txtLegajoMedico.Text);
            }
        }

        void cargarGridView(string legajo)
        {
            gvTurnos.DataSource = negocioTurno.obtenerTablaTurnos(legajo);
            gvTurnos.DataBind();
        }

        protected void ddlCriterioBusqueda_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (ddlCriterioBusqueda.SelectedValue)
            {
                case "Fecha":
                    txtBuscarTurno.TextMode = TextBoxMode.Date;
                    txtBuscarTurno.Text = "";
                    break;
                case "Nombre":
                    txtBuscarTurno.TextMode = TextBoxMode.Search;
                    txtBuscarTurno.Text = "";
                    break;
                default:
                    break;
            }
        }


        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            if (txtLegajoMedico.Text == string.Empty)
                return;

            gvTurnos.DataSource = negocioTurno.obtenerTablaTurnosFiltro(ddlCriterioBusqueda.SelectedItem.Text, txtBuscarTurno.Text, txtLegajoMedico.Text);
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

            if (e.CommandName == "observaciones")
            {
                Response.Redirect("observaciones.aspx?IdTurno=" + idTurno);
            }

        }

        protected void gvTurnos_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvTurnos.PageIndex = e.NewPageIndex;

            if (filtroActivado)
            {
                gvTurnos.DataSource = negocioTurno.obtenerTablaTurnosFiltro(ddlCriterioBusqueda.SelectedItem.Text, txtBuscarTurno.Text, txtLegajoMedico.Text);
            }
            else
            {
                gvTurnos.DataSource = negocioTurno.obtenerTablaTurnos(txtLegajoMedico.Text);
            }

            gvTurnos.DataBind();
        }

    }
}