using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;
using Entidades;

namespace Vistas
{
    public partial class ModificarMedico : System.Web.UI.Page
    {
        NegocioEspecialidad negocioEspecialidad = new NegocioEspecialidad();
        NegocioProvincia negocioProvincia = new NegocioProvincia();
        NegocioLocalidad negocioLocalidad = new NegocioLocalidad();
        NegocioMedico negocioMedico = new NegocioMedico();
        NegocioUsuario negocioUsuario = new NegocioUsuario();
        static String legajoActual;
        static String usuarioActual;
        static String DNIViejo;

        protected void Page_Load(object sender, EventArgs e)
        {
            ValidationSettings.UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;
            asignarUsuario();

            if (Request.QueryString["legajo"] != null)
            {
                Medico modificar = negocioMedico.buscarMedicoUnico(Request.QueryString["legajo"].ToString());
                cargarLegajo(modificar);
                txtLegajo.Enabled = false;
                btnBuscarLegajo.Visible = false;

                if (!IsPostBack)
                {
                    cargarDDLEspecialidad(modificar.Especialidad_Medico.IdEspecialidad.ToString());
                    cargarDDLProvincias(modificar.Provincia_Medico.IdProvincia.ToString(), modificar.Localidad_Medico.IdLocalidad.ToString());
                }
            }
            else
            {
                ingresos.Visible = false;
                btnModificarMedico.Visible = false;
            }

        }

        protected void btnBuscarLegajo_Click(object sender, EventArgs e)
        {
         
            Medico buscar = negocioMedico.buscarMedicoUnico(txtLegajo.Text);

            if (buscar != null)
            {
                habilitarValidadores(false);
                ingresos.Visible = true;
                cargarLegajo(buscar);
                cargarDDLEspecialidad(buscar.Especialidad_Medico.IdEspecialidad.ToString());
                cargarDDLProvincias(buscar.Provincia_Medico.IdProvincia.ToString(), buscar.Localidad_Medico.IdLocalidad.ToString());
                lblTextVacio.Text = "";
                btnBuscarLegajo.Visible = false;
                txtLegajo.Enabled = false;
                btnModificarMedico.Visible = true;
            }
            else
            {
                lblTextVacio.Text = "*Legajo inexistente.";
                habilitarValidadores(false);
            }
           
            habilitarValidadores(true);
        }

        protected void btnModificarMedico_Click(object sender, EventArgs e)
        {
            Medico actualizar = new Medico();

            if (Request.QueryString["legajo"] != null)
            {
                actualizar.LegajoMedico = Request.QueryString["legajo"].ToString();
            }
            else actualizar.LegajoMedico = txtLegajo.Text;

            actualizarMedico(actualizar);
            negocioUsuario.modificarUsuario(actualizar.Usuario_Medico);
            negocioMedico.modificarMedico(actualizar);

            mostrarMensajeModificacion();
        }
        protected void ddlProvincia_SelectedIndexChanged(object sender, EventArgs e)
        {
            ingresos.Visible = true;
            btnModificarMedico.Visible = true;
            cargarDDLLocalidades();
        }

        void mostrarMensajeModificacion()
        {
            btnModificarMedico.Visible = false;
            ingresos.Visible = false;
            btnCancelar.Text = "Volver al Inicio";
            btnCancelar.Visible = true;
            lblLegajo.Visible = false;
            txtLegajo.Visible = false;
            btnBuscarLegajo.Visible = false;
            lblOk.Text = "Medico modificado exitosamente";
        }

        void cargarDDLEspecialidad(string id = " ")
        {
            ddlEspecialidad.DataSource = negocioEspecialidad.obtenerTablaEspecialidades();
            ddlEspecialidad.DataTextField = "NombreEspecialidad";
            ddlEspecialidad.DataValueField = "IdEspecialidad";
            if (id != " ")
                ddlEspecialidad.SelectedValue = id;
            ddlEspecialidad.DataBind();
        }

        void cargarDDLProvincias(string id = " ", string localidad = " ")
        {
            ddlProvincia.DataSource = negocioProvincia.obtenerTablaProvincia();
            ddlProvincia.DataTextField = "NombreProvincia";
            ddlProvincia.DataValueField = "IdProvincia";
            if (id != " ")
                ddlProvincia.SelectedValue = id;
            ddlProvincia.DataBind();
            if (id != " ")
                cargarDDLLocalidades(localidad);
        }

        void cargarDDLLocalidades(string id = " ")
        {
            ddlLocalidad.DataSource = negocioLocalidad.obtenerTablaLocalidades(ddlProvincia.SelectedValue);
            ddlLocalidad.DataTextField = "NombreLocalidad";
            ddlLocalidad.DataValueField = "IdLocalidad";
            ddlLocalidad.DataBind();

            if (id != " ")
                ddlLocalidad.SelectedValue = id;
        }

        private void habilitarValidadores(bool aux)
        {
            rfvLegajo.Enabled = aux;
            rfvDireccion.Enabled = aux;
            rfvNombre.Enabled = aux;
            rfvApellido.Enabled = aux;
            rfvDNI.Enabled = aux;
            rfvNacionalidad.Enabled = aux;
            rfvFechaNacimiento.Enabled = aux;
            rfvTelefono.Enabled = aux;
            rfvEmail.Enabled = aux;
            rfvNombreUsuario.Enabled = aux;
            rfvContrasena.Enabled = aux;
        }

        public void cargarLegajo(Medico med)
        {
            txtLegajo.Text = med.LegajoMedico;
            txtDireccion.Text = med.DireccionMedico;
            txtNombre.Text = med.NombreMedico;
            txtApellido.Text = med.ApellidoMedico;
            txtDNI.Text = med.DniMedico;
            ddlSexo.SelectedValue = med.SexoMedico.ToString();
            txtNacionalidad.Text = med.NacionalidadMedico;
            txtFechaNacimiento.Text = med.FechaNacimiento_Medico.ToString("d");
            txtTelefono.Text = med.TelefonoMedico;
            txtEmail.Text = med.EmailMedico;
            txtNombreUsuario.Text = med.Usuario_Medico.NombreUsuario;
            txtContrasena.Text = med.Usuario_Medico.ContraseniaUsuario;

            DNIViejo = txtDNI.Text;
            legajoActual = txtLegajo.Text;
            usuarioActual = txtNombreUsuario.Text;
        }
        
        private void actualizarMedico(Medico actualizar)
        {
            actualizar.DireccionMedico = txtDireccion.Text;
            actualizar.NombreMedico = txtNombre.Text;
            actualizar.ApellidoMedico = txtApellido.Text;
            actualizar.DniMedico = txtDNI.Text;
            actualizar.SexoMedico = char.Parse(ddlSexo.SelectedItem.Value);
            actualizar.NacionalidadMedico = txtNacionalidad.Text;
            actualizar.FechaNacimiento_Medico = DateTime.Parse(txtFechaNacimiento.Text);
            actualizar.TelefonoMedico = txtTelefono.Text;
            actualizar.EmailMedico = txtEmail.Text;
            actualizar.Usuario_Medico = new Usuario();
            actualizar.Usuario_Medico.IdUsuario = negocioUsuario.getUsuarioID(usuarioActual);
            actualizar.Usuario_Medico.NombreUsuario = txtNombreUsuario.Text;
            actualizar.Usuario_Medico.ContraseniaUsuario = txtContrasena.Text;
            actualizar.Provincia_Medico = new Provincia();
            actualizar.Localidad_Medico = new Localidad();
            actualizar.Especialidad_Medico = new Especialidad();
            actualizar.Provincia_Medico.IdProvincia = int.Parse(ddlProvincia.SelectedValue);
            actualizar.Localidad_Medico.IdLocalidad = int.Parse(ddlLocalidad.SelectedValue);
            actualizar.Especialidad_Medico.IdEspecialidad = int.Parse(ddlEspecialidad.SelectedValue);
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
            Response.Redirect("/Sesion/InicioAdministrador.aspx");
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