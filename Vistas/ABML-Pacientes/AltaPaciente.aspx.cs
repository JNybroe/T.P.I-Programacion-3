using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Entidades;
using Negocio;

namespace Vistas.ABML_Pacientes
{
    public partial class AltaPaciente : System.Web.UI.Page
    {
        Paciente paciente = new Paciente();
        NegocioProvincia negocioProvincias = new NegocioProvincia();
        NegocioLocalidad negocioLocalidades = new NegocioLocalidad();


        NegocioPaciente negPaciente = new NegocioPaciente();

        protected void Page_Load(object sender, EventArgs e)
        {
            ValidationSettings.UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;

            if (!IsPostBack)
            {
                cargarDDLProvincias();
                cargarDDLLocalidades();
                asignarUsuario();
            }
           
        }

        void cargarDDLProvincias()
        {
            DataTable provincia = negocioProvincias.obtenerTablaProvincia();
            ddlProvincia.DataSource = provincia;
            ddlProvincia.DataTextField = "NombreProvincia";
            ddlProvincia.DataValueField = "IdProvincia";
            ddlProvincia.DataBind();
        }

        void cargarDDLLocalidades()
        {
            DataTable localidad = negocioLocalidades.obtenerTablaLocalidades(ddlProvincia.SelectedValue);
            ddlLocalidad.DataSource = localidad;
            ddlLocalidad.DataTextField = "NombreLocalidad";
            ddlLocalidad.DataValueField = "IdLocalidad";
            ddlLocalidad.DataBind();
        }

        protected void ddlProvincia_SelectedIndexChanged(object sender, EventArgs e)
        {
            cargarDDLLocalidades();
        }

        protected void btnAgregarPaciente_Click(object sender, EventArgs e)
        {
            paciente = cargarPaciente();

            if (negPaciente.buscarPaciente_Dni(paciente.DniPaciente))
            {
                lblError.Text = "El DNI ingresado ya existe";
                return;
            }

            lblError.Visible = false;
            negPaciente.agregarPaciente(paciente);
            lblPacienteAgregado.Text = "Paciente agregado correctamente";
            limpiarContenido();

            
        }

        public Paciente cargarPaciente()
        {
            
            Localidad locPaciente = crearNuevaLocalidad();
            Provincia provPaciente = crearNuevaProvincia();

            paciente.NombrePaciente = txtNombre.Text;
            paciente.ApellidoPaciente = txtApellido.Text;
            paciente.DniPaciente = txtDNI.Text;
            paciente.SexoPaciente = char.Parse(ddlSexo.SelectedItem.Value);
            paciente.NacionalidadPaciente = txtNacionalidad.Text;
            paciente.FechaNacimiento_Paciente = txtFechaNacimiento.Text == string.Empty ? DateTime.Now : DateTime.Parse(txtFechaNacimiento.Text);

            paciente.DireccionPaciente = txtDireccion.Text;
            paciente.TelefonoPaciente = txtTelefono.Text;
            paciente.EmailPaciente = txtEmail.Text;
            paciente.Provincia_Paciente = provPaciente;
            paciente.Localidad_Paciente = locPaciente;

            return paciente;
        }

        public Localidad crearNuevaLocalidad()
        {
            return new Localidad
            {
                IdLocalidad = int.Parse(ddlLocalidad.SelectedValue),
                Provincia_Localidad = crearNuevaProvincia(),
                NombreLocalidad = ddlLocalidad.SelectedItem.Text
            };
        }

        public Provincia crearNuevaProvincia()
        {
            return new Provincia
            {
                IdProvincia = int.Parse(ddlProvincia.SelectedValue),
                NombreProvincia = ddlProvincia.SelectedItem.Text
            };
        }

        public void limpiarContenido()
        {
            txtNombre.Text = "";
            txtApellido.Text = "";
            txtDNI.Text = "";
            ddlSexo.SelectedIndex = 0;
            txtNacionalidad.Text = "";
            txtDireccion.Text = "";
            txtTelefono.Text = "";
            txtEmail.Text = "";
            ddlProvincia.SelectedIndex = 0;
            cargarDDLLocalidades();
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

        protected void btnInicio_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Sesion/InicioAdministrador.aspx");
        }
    }
}