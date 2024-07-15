using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Entidades;
using Negocio;

namespace Vistas.ABML_Pacientes
{
    public partial class ModificarPaciente : System.Web.UI.Page
    {
        NegocioPaciente negocioPaciente = new NegocioPaciente();
        NegocioProvincia negocioProvincia = new NegocioProvincia();
        NegocioLocalidad negocioLocalidad = new NegocioLocalidad();

        protected void Page_Load(object sender, EventArgs e)
        {
            ValidationSettings.UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;
            asignarUsuario();

            if (Request.QueryString["ID"] != null)
            {
                Paciente modificar = negocioPaciente.buscarPaciente_ID(Request.QueryString["ID"].ToString());
                cargarDatos(modificar);
                txtIdPaciente.Enabled = false;
                btnBuscarIdPaciente.Visible = false;

                if (!IsPostBack)
                {
                    cargarDDLProvincias(modificar.Provincia_Paciente.IdProvincia.ToString(), modificar.Localidad_Paciente.IdLocalidad.ToString());
                }
            }
            else
            {
                ingresos.Visible = false;
                btnModificarPaciente.Visible = false;
            }
        }

        protected void btnBuscarIdPaciente_Click(object sender, EventArgs e)
        {
            Paciente buscar = negocioPaciente.buscarPaciente_ID(txtIdPaciente.Text);
            btnModificarPaciente.Visible = true;

            if (buscar != null)
            {
                habilitarValidadores(false);
                ingresos.Visible = true;
                cargarDatos(buscar);
                cargarDDLProvincias(buscar.Provincia_Paciente.IdProvincia.ToString(), buscar.Localidad_Paciente.IdLocalidad.ToString());
                lblTextVacio.Text = "";
                btnBuscarIdPaciente.Visible = false;
                txtIdPaciente.Enabled = false;
            }
            else
            {
                lblTextVacio.Text = "ID inexistente.";
                btnModificarPaciente.Visible = false;
                habilitarValidadores(false);
            }

            habilitarValidadores(true);
        }

        protected void btnModificarPaciente_Click(object sender, EventArgs e)
        {
            Paciente actualizar = new Paciente();

            if (Request.QueryString["ID"] != null)
            {
                actualizar.IdPaciente = int.Parse(Request.QueryString["ID"].ToString());
            }

            else actualizar.IdPaciente = int.Parse(txtIdPaciente.Text);

            actualizarPaciente(actualizar);
            negocioPaciente.modificarPaciente(actualizar);
            mostrarMensajeModificacion();
        }

        protected void ddlProvincia_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnModificarPaciente.Visible = true;
            ingresos.Visible = true;
            cargarDDLLocalidades();
        }

        void mostrarMensajeModificacion()
        {
            btnModificarPaciente.Visible = false;
            ingresos.Visible = false;
            btnCancelar.Text = "Volver al Inicio";
            btnCancelar.Visible = true;
            lblIdPaciente.Visible = false;
            txtIdPaciente.Visible = false;
            btnBuscarIdPaciente.Visible = false;
            lblMensaje.Text = "Paciente modificado exitosamente";
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
            rfvApellido.Enabled = aux;
            rfvDireccion.Enabled = aux;
            rfvDNI.Enabled = aux;
            rfvEmail.Enabled = aux;
            rfvFechaNacimiento.Enabled = aux;
            rfvIdPaciente.Enabled = aux;
            rfvNacionalidad.Enabled = aux;
            rfvNombre.Enabled = aux;
            rfvTelefono.Enabled = aux;
        }

        private void cargarDatos(Paciente modificar)
        {
            txtIdPaciente.Text = modificar.IdPaciente.ToString();
            txtNombre.Text = modificar.NombrePaciente;
            txtApellido.Text = modificar.ApellidoPaciente;
            txtFechaNacimiento.Text = modificar.FechaNacimiento_Paciente.ToString("d");
            txtDNI.Text = modificar.DniPaciente;
            ddlSexo.SelectedValue = modificar.SexoPaciente.ToString();
            txtDireccion.Text = modificar.DireccionPaciente;
            txtEmail.Text = modificar.EmailPaciente;
            txtTelefono.Text = modificar.TelefonoPaciente;
            txtNacionalidad.Text = modificar.NacionalidadPaciente;
        }

        private void actualizarPaciente(Paciente actualizar)
        {
            actualizar.NombrePaciente = txtNombre.Text;
            actualizar.ApellidoPaciente = txtApellido.Text;
            actualizar.DniPaciente = txtDNI.Text;
            actualizar.SexoPaciente = char.Parse(ddlSexo.SelectedItem.Value);
            actualizar.NacionalidadPaciente = txtNacionalidad.Text;
            actualizar.FechaNacimiento_Paciente = DateTime.Parse(txtFechaNacimiento.Text);
            actualizar.DireccionPaciente = txtDireccion.Text;
            actualizar.TelefonoPaciente = txtTelefono.Text;
            actualizar.EmailPaciente = txtEmail.Text;
            actualizar.Provincia_Paciente = new Provincia { IdProvincia = int.Parse(ddlProvincia.SelectedValue) };
            actualizar.Localidad_Paciente = new Localidad { IdLocalidad = int.Parse(ddlLocalidad.SelectedValue) };
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
            Response.Redirect("~/ABML-Pacientes/ListadoPacientes.aspx");
        }
    }
}
