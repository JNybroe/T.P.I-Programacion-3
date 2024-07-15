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
    public partial class ListadoPacientes : System.Web.UI.Page
    {
        NegocioPaciente negPaciente = new NegocioPaciente();
        static bool filtroActivado = false;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                asignarUsuario();
                cargarListaPacientes();
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


        public void cargarListaPacientes()
        {
            grdListaPacientes.DataSource = negPaciente.obtenerTablaPacientes();
            grdListaPacientes.DataBind();
        }

        protected void grdListaPacientes_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Page")
                return;

            switch (e.CommandName)
            {
                case "eventoEditar":
                    Response.Redirect("~/ABML-Pacientes/ModificarPaciente.aspx?ID=" + obtenerIDGD(e.CommandArgument));
                    break;
                case "eventoBaja":
                    Response.Redirect("~/ABML-Pacientes/BajaPaciente.aspx?DNI=" + obtenerDNIGD(e.CommandArgument));
                    break;
                default:
                    return;
            }
        }

        public string obtenerDNIGD(object obj)
        {
            int fila = Convert.ToInt32(obj);
            return ((Label)grdListaPacientes.Rows[fila].FindControl("lbl_it_DNI")).Text;
        }

        public string obtenerIDGD(object obj)
        {
            int fila = Convert.ToInt32(obj);
            return ((Label)grdListaPacientes.Rows[fila].FindControl("lbl_it_ID")).Text;
        }

        protected void btnBuscarPaciente_Click(object sender, EventArgs e)
        {
            grdListaPacientes.DataSource = negPaciente.obtenerTablaPacienteFiltro(ddlCriterioBusqueda.SelectedItem.Text, txtBuscarPaciente.Text);
            grdListaPacientes.DataBind();
            filtroActivado = true;
        }

        protected void grdListaPacientes_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdListaPacientes.PageIndex = e.NewPageIndex;
            if (filtroActivado)
                grdListaPacientes.DataSource = negPaciente.obtenerTablaPacienteFiltro(ddlCriterioBusqueda.SelectedItem.Text, txtBuscarPaciente.Text);
            else
                grdListaPacientes.DataSource = negPaciente.obtenerTablaPacientes();

            grdListaPacientes.DataBind();
        }

        protected void btnVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Sesion/InicioAdministrador.aspx");
        }


    }
}