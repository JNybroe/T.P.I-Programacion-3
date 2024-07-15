using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Entidades;
using Negocio;

namespace Vistas
{
    public partial class Login : System.Web.UI.Page
    {
        NegocioUsuario negUsuario = new NegocioUsuario();

        protected void Page_Load(object sender, EventArgs e)
        {
            ValidationSettings.UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            String user = txtUsuario.Text;
            String pass = txtPass.Text;
            String permiso = ddlTipoUsuario.SelectedItem.Text;

            Usuario aux = new Usuario(user, pass, permiso);

            Usuario existente = negUsuario.buscarUsuario(aux);

            if (existente == null)
            {
                mostrarErrorUsuario();
                return;
            }

            if (existente.ContraseniaUsuario != pass)
            {
                lblErrorUsuario.Text = "";
                mostrarErrorPass();
                return;
            }

            if (existente.NivelDePermisoUsuario != permiso)
            {
                lblErrorUsuario.Text = "";
                lblErrorPass.Text = "";
                mostrarErrorPermiso();
                return;
            }

            iniciarSesion(aux, permiso);
        }

        void mostrarErrorPass()
        {
            lblErrorPass.Text = "Contraseña incorrecta";
        }

        void mostrarErrorUsuario()
        {
            lblErrorUsuario.Text = "Usuario inexistente";
            txtUsuario.Text = "";
            lblErrorPass.Text = "";
        }

        void mostrarErrorPermiso()
        {
            lblErrorPermiso.Text = "Permiso incorrecto";
        }

        void iniciarSesion(Usuario aux, string permiso)
        {
            Session["usuario"] = aux;
            chequearPermiso(permiso);
        }

        void chequearPermiso(String permiso)
        {
            string legajo = negUsuario.traerDuenioUsuario(((Usuario)Session["usuario"]).NombreUsuario);   

            if (permiso == "Administrador")
            {
                Response.Redirect("~/Sesion/InicioAdministrador.aspx");
            }
            else
            {
                Session["legajo"] = legajo;
                Response.Redirect("~/ABML-Turnos/ListadoTurnos.aspx?legajo=" + legajo);
            }
        }
    }
}