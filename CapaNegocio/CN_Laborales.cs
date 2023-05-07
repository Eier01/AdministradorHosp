using CapaDatos;
using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class CN_Laborales
    {
        private CD_Laborales objCapaDato = new CD_Laborales();

        public List<Datos_Laborales> Listar()
        {
            return objCapaDato.Listar();
        }
        public int RegistrarDatosLaborales(Datos_Laborales obj, out string Mensaje)
        {
            Mensaje = string.Empty;

            if (string.IsNullOrEmpty(obj.Area) || string.IsNullOrWhiteSpace(obj.Area))
            {
                Mensaje = "El proceso no puede ser vacio";
            }
            
            else if (string.IsNullOrEmpty(obj.NombreArea) || string.IsNullOrWhiteSpace(obj.NombreArea))
            {
                Mensaje = "Este campo numero documento es obligatorio";
            }
            else if (string.IsNullOrEmpty(obj.TipoActividad) || string.IsNullOrWhiteSpace(obj.TipoActividad))
            {
                Mensaje = "Este campo numero documento es obligatorio";
            }
            else if (string.IsNullOrEmpty(obj.FechaIngreso) || string.IsNullOrWhiteSpace(obj.FechaIngreso))
            {
                Mensaje = "Este campo numero documento es obligatorio";
            }
            else if (string.IsNullOrEmpty(obj.HorasContratadas) || string.IsNullOrWhiteSpace(obj.HorasContratadas))
            {
                Mensaje = "Este campo numero documento es obligatorio";
            }
            if (string.IsNullOrEmpty(Mensaje))
            {
                return objCapaDato.RegistrarDatosLaborales(obj, out Mensaje);
            }
            else
            {
                return 0;
            }
        }
        public bool EditarDatosLaborales(Datos_Laborales obj, out String Mensaje)
        {
            Mensaje = string.Empty;

            if (string.IsNullOrEmpty(obj.Area) || string.IsNullOrWhiteSpace(obj.Area))
            {
                Mensaje = "El proceso no puede ser vacio";
            }

            else if (string.IsNullOrEmpty(obj.NombreArea) || string.IsNullOrWhiteSpace(obj.NombreArea))
            {
                Mensaje = "Este campo numero documento es obligatorio";
            }
            else if (string.IsNullOrEmpty(obj.TipoActividad) || string.IsNullOrWhiteSpace(obj.TipoActividad))
            {
                Mensaje = "Este campo numero documento es obligatorio";
            }
            else if (string.IsNullOrEmpty(obj.FechaIngreso) || string.IsNullOrWhiteSpace(obj.FechaIngreso))
            {
                Mensaje = "Este campo numero documento es obligatorio";
            }
            else if (string.IsNullOrEmpty(obj.HorasContratadas) || string.IsNullOrWhiteSpace(obj.HorasContratadas))
            {
                Mensaje = "Este campo numero documento es obligatorio";
            }
            if (string.IsNullOrEmpty(Mensaje))
            {
                return objCapaDato.EditarDatosLaborales(obj, out Mensaje);
            }
            else
            {
                return false;
            }
        }
    }
}
