using CapaDatos;
using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class CN_Usuarios
    {
        private CD_Usuarios objCapaDato = new CD_Usuarios();

        public List<Usuario> Listar()
        {
            return objCapaDato.Listar();
        }
        //Nombres, Apelldios, Correo, Clave, Reestablecer, Activo, Fecharegistro

        public int RegistrarUsuarios(Usuario obj, out string Mensaje)
        {
            Mensaje = string.Empty;

            if (string.IsNullOrEmpty(obj.Nombres) || string.IsNullOrWhiteSpace(obj.Nombres))
            {
                Mensaje = "El proceso no puede ser vacio";
            }
            else if (string.IsNullOrEmpty(obj.Apelldios) || string.IsNullOrWhiteSpace(obj.Apelldios))
            {
                Mensaje = "Este campo numero documento es obligatorio";
            }
            else if (string.IsNullOrEmpty(obj.Correo) || string.IsNullOrWhiteSpace(obj.Correo))
            {
                Mensaje = "Este campo numero documento es obligatorio";
            }
            else if (string.IsNullOrEmpty(obj.Clave) || string.IsNullOrWhiteSpace(obj.Clave))
            {
                Mensaje = "Este campo numero documento es obligatorio";
            }
            //else if (bool.IsNullOrEmpty(obj.Reestablecer) || bool.IsNullOrWhiteSpace(obj.Reestablecer))
            //{
            //    Mensaje = "Este campo numero documento es obligatorio";
            //}
            //else if (bool.IsNullOrEmpty(obj.Activo) || bool.IsNullOrWhiteSpace(obj.Activo))
            //{
            //    Mensaje = "Este campo numero documento es obligatorio";
            //}
            else if (string.IsNullOrEmpty(obj.Fecharegistro) || string.IsNullOrWhiteSpace(obj.Fecharegistro))
            {
                Mensaje = "Este campo numero documento es obligatorio";
            }

            if (string.IsNullOrEmpty(Mensaje))
            {
                return objCapaDato.RegistrarUsuarios(obj, out Mensaje);
            }
            else
            {
                return 0;
            }
        }
        //Nombres, Apelldios, Correo, Clave, Reestablecer, Activo, Fecharegistro

        public bool EditarUsuarios(Usuario obj, out String Mensaje)
        {
            Mensaje = string.Empty;


            if (string.IsNullOrEmpty(obj.Nombres) || string.IsNullOrWhiteSpace(obj.Nombres))
            {
                Mensaje = "El proceso no puede ser vacio";
            }
            else if (string.IsNullOrEmpty(obj.Apelldios) || string.IsNullOrWhiteSpace(obj.Apelldios))
            {
                Mensaje = "Este campo numero documento es obligatorio";
            }
            else if (string.IsNullOrEmpty(obj.Correo) || string.IsNullOrWhiteSpace(obj.Correo))
            {
                Mensaje = "Este campo numero documento es obligatorio";
            }
            else if (string.IsNullOrEmpty(obj.Clave) || string.IsNullOrWhiteSpace(obj.Clave))
            {
                Mensaje = "Este campo numero documento es obligatorio";
            }
            //else if (bool.IsNullOrEmpty(obj.Reestablecer.HasValue) || bool.IsNullOrWhiteSpace(obj.Reestablecer))
            //{
            //    Mensaje = "Este campo numero documento es obligatorio";
            //}
            //else if (bool.IsNullOrEmpty(obj.Activo) || bool.IsNullOrWhiteSpace(obj.Activo))
            //{
            //    Mensaje = "Este campo numero documento es obligatorio";
            //}
            else if (string.IsNullOrEmpty(obj.Fecharegistro) || string.IsNullOrWhiteSpace(obj.Fecharegistro))
            {
                Mensaje = "Este campo numero documento es obligatorio";
            }

            if (string.IsNullOrEmpty(Mensaje))
            {
                return objCapaDato.EditarUsuarios(obj, out Mensaje);
            }
            else
            {
                return false;
            }

        }

        public bool EliminarUsuario(int id, out string Mensaje)
        {
            return objCapaDato.EliminarUsuario(id, out Mensaje);
        }
    }
}
