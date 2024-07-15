using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Entidades;
using Negocio;

namespace Vistas.Sesion
{
    public partial class ModificarPass : System.Web.UI.Page
    {
        NegocioUsuario negUsuario = new NegocioUsuario();

        protected void Page_Load(object sender, EventArgs e)
        {
            ValidationSettings.UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;

            if (!IsPostBack)
            {
                asignarUsuario();
                rfvPassAux.Visible = false;
                rfvPassNuevo.Visible = false;
            }
        }

        protected void btnCambiarPass_Click(object sender, EventArgs e)
        {
            Usuario aux = (Usuario)Session["usuario"];

            if (aux != null && aux.ContraseniaUsuario == txtPassActual.Text)
            {
                ocultarPassActual();
                activarCamposPass();
            }
            else
            {
                lblErrorPass.Text = "Contraseña Incorrecta";
            }
        }


        protected void btnConfirmarCambio_Click(object sender, EventArgs e)
        {
            Usuario aux = (Usuario)Session["usuario"];

            if (aux != null)
            {
                if (txtPassNuevo.Text == txtPassAux.Text)
                {
                    lblCambiosRealizados.Text = "Cambios realizados exitosamente";
                    aux.ContraseniaUsuario = txtPassNuevo.Text;
                    negUsuario.modificarPassUsuario(aux);
                    ocultarCamposPass();
                }
                else
                {
                    lblCambiosRealizados.Visible = false;
                    lblErrorPass.Text = "Las contraseñas no coinciden";
                }
            }
        }


        void asignarUsuario()
        {
            if (Session["usuario"] != null)
            {
                Usuario aux = (Usuario)Session["usuario"];
                lblTipoUsuario.Text += " <b>" + aux.NivelDePermisoUsuario + "</b>";
                lblUsuario.Text += " <b>" + aux.NombreUsuario + "</b>";
            }
        }

        void activarCamposPass()
        {
            lblPassNuevo.Visible = true;
            txtPassNuevo.Visible = true;
            lblPassAux.Visible = true;
            txtPassAux.Visible = true;
            btnConfirmarCambio.Visible = true;
            lblErrorPass.Text = "";
            rfvPassNuevo.Visible = true;
            rfvPassAux.Visible = true;
        }

        void ocultarPassActual()
        {
            lblPassActual.Visible = false;
            txtPassActual.Visible = false;
            btnCambiarPass.Visible = false;
            rfvPassActual.Visible = false;
        }
        void ocultarCamposPass()
        {
            lblCambiosRealizados.Visible = true;
            lblErrorPass.Visible = false;
            lblPassNuevo.Visible = false;
            txtPassNuevo.Visible = false;
            lblPassAux.Visible = false;
            txtPassAux.Visible = false;
            btnConfirmarCambio.Visible = false;
            rfvPassNuevo.Visible = false;
            rfvPassAux.Visible = false;
        }

        protected void btnInicio_Click(object sender, EventArgs e)
        {
            Usuario aux = (Usuario)Session["usuario"];

            if(aux.NivelDePermisoUsuario == "Administrador")
            {
                Response.Redirect("~/Sesion/InicioAdministrador.aspx");
            }

            else Response.Redirect("~/ABML-Turnos/ListadoTurnos.aspx");
        }
    }
}
