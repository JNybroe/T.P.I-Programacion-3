using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Usuario
    {
        private int idUsuario;
        private string nombreUsuario;
        private string contraseniaUsuario;
        private string nivelDePermisoUsuario;

        public Usuario()
        {

        }
        public Usuario(string nombre, string pass, string permiso)
        {
            nombreUsuario = nombre;
            contraseniaUsuario = pass;
            nivelDePermisoUsuario = permiso;
        }


        public Usuario(int idUsuario, string nombreUsuario, string contraseniaUsuario, string nivelDePermisoUsuario)
        {
            this.IdUsuario = idUsuario;
            this.NombreUsuario = nombreUsuario;
            this.ContraseniaUsuario = contraseniaUsuario;
            this.NivelDePermisoUsuario = nivelDePermisoUsuario;
        }

        public int IdUsuario { get => idUsuario; set => idUsuario = value; }
        public string NombreUsuario { get => nombreUsuario; set => nombreUsuario = value; }
        public string ContraseniaUsuario { get => contraseniaUsuario; set => contraseniaUsuario = value; }
        public string NivelDePermisoUsuario { get => nivelDePermisoUsuario; set => nivelDePermisoUsuario = value; }
    }
}
