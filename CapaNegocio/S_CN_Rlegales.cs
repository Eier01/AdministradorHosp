using CapaDatos;
using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class S_CN_Rlegales
    {
        private S_CD_Rlegales objCapaDato = new S_CD_Rlegales();

        public List<S_Rlegales> Listar(string numero)
        {
            return objCapaDato.Listar(numero);
        }

        public int RegistrarRlegales(S_Rlegales obj, out string Mensaje)
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
        public bool EditarRlegales(S_Rlegales obj, out String Mensaje)
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
