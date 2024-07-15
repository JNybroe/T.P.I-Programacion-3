using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Datos;
using Negocio;
using Entidades;

namespace Vistas
{
    public partial class ListadoMedicos : System.Web.UI.Page
    {
        NegocioMedico negMedico = new NegocioMedico();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                cargarGridView();
                asignarUsuario();
            }
        }

        public void cargarGridView()
        {
            gvListadoMedicos.DataSource = negMedico.obtenerTablaMedicos();
            gvListadoMedicos.DataBind();
        }

        protected void gvListadoMedicos_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvListadoMedicos.PageIndex = e.NewPageIndex;
            gvListadoMedicos.DataSource = negMedico.obtenerTablaMedicos();
            gvListadoMedicos.DataBind();
        }

        protected void gvListadoMedicos_SelectedIndexChanged(object sender, EventArgs e)
        {
            String legajo = gvListadoMedicos.SelectedDataKey.Value.ToString();
            Response.Redirect("~/ABML-Medicos/ModificarMedico.aspx?legajo=" + legajo);
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

        protected void gvListadoMedicos_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            switch (e.CommandName)
            {
                case "eventoEditar":
                    Response.Redirect("~/ABML-Medicos/ModificarMedico.aspx?legajo=" + obtenerLegajoGD(e.CommandArgument));
                    break;
                case "eventoBaja":
                    Response.Redirect("~/ABML-Medicos/BajaMedico.aspx?legajo=" + obtenerLegajoGD(e.CommandArgument));
                    break;
                default:
                    break;
            }
        }

        public string obtenerLegajoGD(object obj)
        {
            int fila = Convert.ToInt32(obj);
            return ((Label)gvListadoMedicos.Rows[fila].FindControl("lbl_it_legajo")).Text;
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            gvListadoMedicos.DataSource = negMedico.obtenerTablaMedicosFiltro(ddlCriterioBusqueda.SelectedItem.Text, txtBuscarMedico.Text);
            gvListadoMedicos.DataBind();
        }

        protected void btnVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Sesion/InicioAdministrador.aspx");
        }
    }
}