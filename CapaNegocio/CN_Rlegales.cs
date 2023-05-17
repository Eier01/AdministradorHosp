using CapaDatos;
using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class CN_Rlegales
    {
        private CD_Rlegales objCapaDato = new CD_Rlegales();

        public List<Rlegales> Listar()
        {
            return objCapaDato.Listar();
        }

        public int RegistrarRlegales(Rlegales obj, out string Mensaje)
        {
            Mensaje = string.Empty;

            if (string.IsNullOrEmpty(obj.FechaExpedicion) || string.IsNullOrWhiteSpace(obj.FechaExpedicion))
            {
                Mensaje = "El campo fecha de expedición no puede ser vacio";
            }

            else if (string.IsNullOrEmpty(obj.Archivo) || string.IsNullOrWhiteSpace(obj.Archivo))
            {
                Mensaje = "Este campo numero documento es obligatorio";
            }

            if (string.IsNullOrEmpty(Mensaje))
            {
                return objCapaDato.RegistrarRlegales(obj, out Mensaje);
            }
            else
            {
                return 0;
            }
        }
        public bool EditarRlegales(Rlegales obj, out String Mensaje)
        {
            Mensaje = string.Empty;

            if (string.IsNullOrEmpty(obj.FechaExpedicion) || string.IsNullOrWhiteSpace(obj.FechaExpedicion))
            {
                Mensaje = "El campo fecha de expedición no puede quedar vacio";
            }

            else if (string.IsNullOrEmpty(obj.Archivo) || string.IsNullOrWhiteSpace(obj.Archivo))
            {
                Mensaje = "El campo numero documento no puede quedar  vacio";
            }

            if (string.IsNullOrEmpty(Mensaje))
            {
                return objCapaDato.EditarRlegales(obj, out Mensaje);
            }
            else
            {
                return false;
            }
        }

    }
}
