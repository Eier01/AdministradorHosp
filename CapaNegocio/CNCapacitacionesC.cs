using CapaDatos;
using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class CNCapacitacionesC
    {
        private CD_CapacitacionesC objCapaDato = new CD_CapacitacionesC();

        public List<CapacitacionesC> Listar()
        {
            return objCapaDato.Listar();
        }

        public int RegistrarCursos(CapacitacionesC obj, out string Mensaje)
        {
            Mensaje = string.Empty;

            if (string.IsNullOrEmpty(obj.TipoFormacion) || string.IsNullOrWhiteSpace(obj.TipoFormacion))
            {
                Mensaje = "El Tipo de formacion  no puede ser vacio";
            }
            else if (string.IsNullOrEmpty(obj.Nombre) || string.IsNullOrWhiteSpace(obj.Nombre))
            {
                Mensaje = "El campo Nombre  es obligatorio";
            }
            else if (string.IsNullOrEmpty(obj.EstadoFormacion) || string.IsNullOrWhiteSpace(obj.EstadoFormacion))
            {
                Mensaje = "El campo Estado de formacion es obligatorio";
            }
            else if (string.IsNullOrEmpty(obj.FechaInicio) || string.IsNullOrWhiteSpace(obj.FechaInicio))
            {
                Mensaje = "El campo Fecha inicio es obligatorio";
            }
            else if (string.IsNullOrEmpty(obj.FechaFinalizacion) || string.IsNullOrWhiteSpace(obj.FechaFinalizacion))
            {
                Mensaje = "El campo fecha de finalizacion  es obligatorio";
            }
            else if (string.IsNullOrEmpty(obj.Archivo) || string.IsNullOrWhiteSpace(obj.Archivo))
            {
                Mensaje = "El campo adjuntar  es obligatorio";
            }

            if (string.IsNullOrEmpty(Mensaje))
            {
                return objCapaDato.RegistrarCursos(obj, out Mensaje);
            }
            else
            {
                return 0;
            }
        }
        public bool EditarCursos(CapacitacionesC obj, out String Mensaje)
        {
            Mensaje = string.Empty;

            if (string.IsNullOrEmpty(obj.TipoFormacion) || string.IsNullOrWhiteSpace(obj.TipoFormacion))
            {
                Mensaje = "El Tipo de formacion  no puede ser vacio";
            }
            else if (string.IsNullOrEmpty(obj.Nombre) || string.IsNullOrWhiteSpace(obj.Nombre))
            {
                Mensaje = "El campo Nombre  es obligatorio";
            }
            else if (string.IsNullOrEmpty(obj.EstadoFormacion) || string.IsNullOrWhiteSpace(obj.EstadoFormacion))
            {
                Mensaje = "El campo Estado de formacion es obligatorio";
            }
            else if (string.IsNullOrEmpty(obj.FechaInicio) || string.IsNullOrWhiteSpace(obj.FechaInicio))
            {
                Mensaje = "El campo Fecha inicio es obligatorio";
            }
            else if (string.IsNullOrEmpty(obj.FechaFinalizacion) || string.IsNullOrWhiteSpace(obj.FechaFinalizacion))
            {
                Mensaje = "El campo fecha de finalizacion  es obligatorio";
            }
            else if (string.IsNullOrEmpty(obj.Archivo) || string.IsNullOrWhiteSpace(obj.Archivo))
            {
                Mensaje = "El campo adjuntar  es obligatorio";
            }

            if (string.IsNullOrEmpty(Mensaje))
            {
                return objCapaDato.EditarCursos(obj, out Mensaje);
            }
            else
            {
                return false;
            }
        }
    }
}
