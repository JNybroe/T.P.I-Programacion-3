using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Datos;
using Entidades;
using Negocio;

namespace Vistas
{
    public partial class AltaMedico : System.Web.UI.Page
    {
        NegocioProvincia negocioProvincias = new NegocioProvincia();
        NegocioLocalidad negocioLocalidades = new NegocioLocalidad();
        NegocioEspecialidad negocioEspecialidad = new NegocioEspecialidad();
        NegocioMedico negocioMedicos = new NegocioMedico();
        NegocioUsuario negocioUsuario = new NegocioUsuario();

        protected void Page_Load(object sender, EventArgs e)
        {
            ValidationSettings.UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;

            if (!IsPostBack)
            {
                int idUsuario = negocioUsuario.ultimoUsuarioID() + 1;
                txtIdentificadorUsuario.Text = idUsuario.ToString();
                asignarUsuario();
                cargarDDLProvincias();
                cargarDDLEspecialidades();
                cargarDDLLocalidades();
                limitantes();
            }
            
        }

        protected void btnAgregarMedico_Click(object sender, EventArgs e)
        {
            sinCadenasVacias();
            Medico medico = crearNuevoMedico();
            Usuario usuario = crearNuevoUsuario();
            chequearExistencias(medico, usuario);
            negocioUsuario.agregarUsuario(usuario);
            negocioMedicos.agregarMedico(medico);
            limpiarCampos();
            lblOk.Text = "Medico creado y guardado con exito!";
            int auxIdUsuario = negocioUsuario.ultimoUsuarioID() + 1;
            txtIdentificadorUsuario.Text = auxIdUsuario.ToString();
        }

        void chequearExistencias(Medico medico, Usuario usuario)
        {
            
            lblError.Text = "";

            if (negocioMedicos.existeLegajo(medico.LegajoMedico))
            {
                txtLegajoMedico.BorderColor = System.Drawing.Color.Red;
                lblError.Text = "*Legajo ya fue registrado";
                return;
            }
            else
            {
                txtLegajoMedico.BorderColor = System.Drawing.Color.Empty;
            }

            if (negocioMedicos.existeDNI(medico.DniMedico))
            {
                txtDNI.BorderColor = System.Drawing.Color.Red;
                lblError.Text = "*El DNI ya fue registrado";
                return;
            }
            else
            {
                txtDNI.BorderColor = System.Drawing.Color.Empty;
            }

            if (negocioMedicos.existeEmail(medico.EmailMedico))
            {
                txtEmail.BorderColor = System.Drawing.Color.Red;
                lblError.Text = "El email ya fue registrado";
                return;
            }
            else
            {
                txtEmail.BorderColor = System.Drawing.Color.Empty;
            }

            if (negocioUsuario.existeUsuario(usuario.NombreUsuario))
            {
                txtEmail.BorderColor = System.Drawing.Color.Red;
                lblError.Text = "El usuario ya existe.";
                return;
            }
            else
            {
                txtEmail.BorderColor = System.Drawing.Color.Empty;
            }
        }

        protected void ddlProvincia_SelectedIndexChanged(object sender, EventArgs e)
        {
            cargarDDLLocalidades();
        }

        void cargarDDLEspecialidades()
        {
            DataTable especialidad = negocioEspecialidad.obtenerTablaEspecialidades();
            ddlEspecialidad.DataSource = especialidad;
            ddlEspecialidad.DataTextField = "NombreEspecialidad";
            ddlEspecialidad.DataValueField = "IdEspecialidad";
            ddlEspecialidad.DataBind();
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

        private Medico crearNuevoMedico()
        {
            Especialidad especialidad = crearNuevaEspecialidad();
            Usuario usuario = crearNuevoUsuario();
            Localidad localidad = crearNuevaLocalidad();
            Provincia provincia = crearNuevaProvinca();

            return new Medico
            {
                LegajoMedico = txtLegajoMedico.Text,
                NombreMedico = txtNombre.Text,
                ApellidoMedico = txtApellido.Text,
                Especialidad_Medico = especialidad,
                Usuario_Medico = usuario,
                Localidad_Medico = localidad,
                Provincia_Medico = provincia,
                DniMedico = txtDNI.Text,
                SexoMedico = char.Parse(ddlSexo.SelectedItem.Value),
                NacionalidadMedico = txtNacionalidad.Text,
                DireccionMedico = txtDireccion.Text,
                EmailMedico = txtEmail.Text,
                TelefonoMedico = txtTelefono.Text,
                FechaNacimiento_Medico = DateTime.Parse(txtFechaNacimiento.Text)
            };
        }

        public Especialidad crearNuevaEspecialidad()
        {
            return new Especialidad
            {
                IdEspecialidad = int.Parse(ddlEspecialidad.SelectedValue),
                NombreEspecialidad = ddlProvincia.SelectedItem.Text
            };
        }

        public Usuario crearNuevoUsuario()
        {
            return new Usuario
            {
                IdUsuario = int.Parse(txtIdentificadorUsuario.Text),
                NombreUsuario = txtNombreUsuario.Text,
                ContraseniaUsuario = txtContrasena.Text,
                NivelDePermisoUsuario = txtPrivilegiosUsuario.Text,
            };
        }

        public Localidad crearNuevaLocalidad()
        {
            return new Localidad
            {
                IdLocalidad = int.Parse(ddlLocalidad.SelectedValue),
                Provincia_Localidad = crearNuevaProvinca(),
                NombreLocalidad = ddlLocalidad.SelectedItem.Text
            };
        }

        public Provincia crearNuevaProvinca()
        {
            return new Provincia
            {
                IdProvincia = int.Parse(ddlProvincia.SelectedValue),
                NombreProvincia = ddlProvincia.SelectedItem.Text
            };
        }
        protected void limpiarCampos()
        {
            txtLegajoMedico.Text = "";
            txtNombre.Text = "";
            txtApellido.Text = "";
            ddlEspecialidad.SelectedIndex = 0; 
            txtDNI.Text = "";
            ddlSexo.SelectedIndex = 0;  
            txtNacionalidad.Text = "";
            txtDireccion.Text = "";
            txtEmail.Text = "";
            txtTelefono.Text = "";
            txtFechaNacimiento.Text = "";
            txtIdentificadorUsuario.Text = "";
            txtNombreUsuario.Text = "";
            txtContrasena.Text = "";
            ddlProvincia.SelectedIndex = 0;
            cargarDDLLocalidades();
        }


        protected void sinCadenasVacias()
        {
            txtLegajoMedico.Text.Trim();
            txtNombre.Text.Trim();
            txtApellido.Text.Trim();
            txtDNI.Text.Trim();
            txtNacionalidad.Text.Trim();
            txtDireccion.Text.Trim();
            txtEmail.Text.Trim();
            txtTelefono.Text.Trim();
            txtFechaNacimiento.Text.Trim();
            txtIdentificadorUsuario.Text.Trim();
            txtNombreUsuario.Text.Trim();
            txtContrasena.Text.Trim();
            txtPrivilegiosUsuario.Text.Trim();
        }

        protected void limitantes()
        {
            txtDNI.MaxLength = 8;
            txtLegajoMedico.MaxLength = 5;
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
    }
}