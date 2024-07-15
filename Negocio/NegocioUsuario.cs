using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos;
using Entidades;

namespace Negocio
{
    public class NegocioUsuario
    {
        DatosUsuario datos = new DatosUsuario();

        public void agregarUsuario(Usuario usu)
        {
            datos.agregarUsuario(usu);
        }

        public int getUsuarioID(string nombre)
        {
            return datos.getUsuarioID(nombre);
        }

        public int ultimoUsuarioID()
        {
            return datos.ultimoUsuarioID();
        }

        public Usuario buscarUsuario(Usuario usu)
        {
            Usuario aux = datos.getUsuario(usu);

            if (aux == null)
            {
                return null;
            }

            else return aux;
        }

        public void modificarUsuario(Usuario usuario)
        {
            datos.modificarUsuario(usuario);
        }

        public void modificarPassUsuario(Usuario usu)
        {
            datos.modificarAtributoPass(usu);
        }

        public string traerDuenioUsuario(string nombreUsuario)
        {
            return datos.traerDuenioUsuario(nombreUsuario);
        }


        public bool existeUsuario(String nomUsuario)
        {
            return datos.existeUsuario(nomUsuario);
        }

    }
}
