using CapaDatos;
using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class S_CN_Persona
    {
        private S_CD_Persona objCapaDato = new S_CD_Persona();
        public List<S_Persona> Listar()
        {
            return objCapaDato.Listar();
        }
        public int RegistrarPerson(S_Persona obj, out string Mensaje)
        {
            Mensaje = string.Empty;

            if (string.IsNullOrEmpty(obj.TipoIdentificacion) || string.IsNullOrWhiteSpace(obj.TipoIdentificacion))
            {
                Mensaje = "El campo identificacion es obligatorio";
            }
            else if (obj.NumeroDocumento == 0)
            {
                Mensaje = "El campo numero documento es obligatorio";
            }
            else if (string.IsNullOrEmpty(obj.FechaExpedicion) || string.IsNullOrWhiteSpace(obj.FechaExpedicion))
            {
                Mensaje = "El campo Fecha de Expedición es obligatorio";
            }
            else if (string.IsNullOrEmpty(obj.LugarExpedicion) || string.IsNullOrWhiteSpace(obj.LugarExpedicion))
            {
                Mensaje = "El campo lugar expedición es obligatorio";
            }
            else if (string.IsNullOrEmpty(obj.PrimerNombre) || string.IsNullOrWhiteSpace(obj.PrimerNombre))
            {
                Mensaje = "El campo primer nombre es obligatorio";
            }
            else if (string.IsNullOrEmpty(obj.SegundoNombre) || string.IsNullOrWhiteSpace(obj.SegundoNombre))
            {
                Mensaje = "El campo segundo nombre es obligatorio";
            }
            else if (string.IsNullOrEmpty(obj.PrimerApellido) || string.IsNullOrWhiteSpace(obj.PrimerApellido))
            {
                Mensaje = "El campo primer apellido es obligatorio";
            }
            else if (string.IsNullOrEmpty(obj.SegundoApellido) || string.IsNullOrWhiteSpace(obj.SegundoApellido))
            {
                Mensaje = "El campo segundo apellido es obligatorio";
            }

            else if (string.IsNullOrEmpty(obj.Genero) || string.IsNullOrWhiteSpace(obj.Genero))
            {
                Mensaje = "El campo sexo es obligatorio";
            }
            else if (string.IsNullOrEmpty(obj.Pais) || string.IsNullOrWhiteSpace(obj.Pais))
            {
                Mensaje = "El campo pais es obligatorio";
            }
                  
            else if (string.IsNullOrEmpty(obj.EstadoCivil) || string.IsNullOrWhiteSpace(obj.EstadoCivil))
            {
                Mensaje = "El campo estado civil es obligatorio";
            }
           


            else if (string.IsNullOrEmpty(obj.LibretaMilitar) || string.IsNullOrWhiteSpace(obj.LibretaMilitar))
            {
                Mensaje = "El campo libreta militar es obligatorio";
            }
          
            else if (string.IsNullOrEmpty(obj.FechaNacimiente) || string.IsNullOrWhiteSpace(obj.FechaNacimiente))
            {
                Mensaje = "El campo Fecha de nacimiento  es obligatorio";
            }

            else if (string.IsNullOrEmpty(obj.PaisNacimiento) || string.IsNullOrWhiteSpace(obj.PaisNacimiento))
            {
                Mensaje = "El campo pais nacimiento es obligatorio";
            }
            else if (string.IsNullOrEmpty(obj.DeapartamentoNacimiento) || string.IsNullOrWhiteSpace(obj.DeapartamentoNacimiento))
            {
                Mensaje = "El campo departamento nacimiento es obligatorio";
            }
            else if (string.IsNullOrEmpty(obj.CiudadNacimiento) || string.IsNullOrWhiteSpace(obj.CiudadNacimiento))
            {
                Mensaje = "El campo ciudad nacimiento es obligatorio";
            }
            else if (string.IsNullOrEmpty(obj.Direccion) || string.IsNullOrWhiteSpace(obj.Direccion))
            {
                Mensaje = "El campo direccion es obligatorio";
            }
            else if (string.IsNullOrEmpty(obj.PaisDireccion) || string.IsNullOrWhiteSpace(obj.PaisDireccion))
            {
                Mensaje = "El campo pais residencia es obligatorio";
            }

            else if (string.IsNullOrEmpty(obj.DepartamentoResidencia) || string.IsNullOrWhiteSpace(obj.DepartamentoResidencia))
            {
                Mensaje = "El campo departamento residencia es obligatorio";
            }

            else if (string.IsNullOrEmpty(obj.CiudadDireccion) || string.IsNullOrWhiteSpace(obj.CiudadDireccion))
            {
                Mensaje = "El campo ciudad residencia es obligatorio";
            }

            else if (string.IsNullOrEmpty(obj.Telefono) || string.IsNullOrWhiteSpace(obj.Telefono))
            {
                Mensaje = "El campo telefono es obligatorio";
            }

            else if (string.IsNullOrEmpty(obj.CorreoElectronico) || string.IsNullOrWhiteSpace(obj.CorreoElectronico))
            {
                Mensaje = "El campo correo electronico es obligatorio";
            }
            else if (string.IsNullOrEmpty(obj.GrupoSanguineo) || string.IsNullOrWhiteSpace(obj.GrupoSanguineo))
            {
                Mensaje = "El campo Grupo sanguineo es obligatorio";
            }
            else if (string.IsNullOrEmpty(obj.GrupoEtnico) || string.IsNullOrWhiteSpace(obj.GrupoEtnico))
            {
                Mensaje = "El campo Grupo etnico es obligatorio";
            }

            else if (string.IsNullOrEmpty(obj.Profesion) || string.IsNullOrWhiteSpace(obj.Profesion))
            {
                Mensaje = "El campo profesion es obligatorio";
            }
            else if (string.IsNullOrEmpty(obj.Eps) || string.IsNullOrWhiteSpace(obj.Eps))
            {
                Mensaje = "El campo eps es obligatorio";
            }
            else if (string.IsNullOrEmpty(obj.FondoPensiones) || string.IsNullOrWhiteSpace(obj.FondoPensiones))
            {
                Mensaje = "El campo fondo pensiones es obligatorio";
            }
            else if (string.IsNullOrEmpty(obj.Arl) || string.IsNullOrWhiteSpace(obj.Arl))
            {
                Mensaje = "Este campo arl es obligatorio";
            }



            if (string.IsNullOrEmpty(Mensaje))
            {

                return objCapaDato.RegistrarPerson(obj, out Mensaje);

            }
            else
            {
                return 0;
            }
        }

        public bool EditarPerson(S_Persona obj, out string Mensaje)
        {
            Mensaje = string.Empty;
            

            if (string.IsNullOrEmpty(obj.TipoIdentificacion) || string.IsNullOrWhiteSpace(obj.TipoIdentificacion))
            {
                Mensaje = "El campo identificacion es obligatorio";
            }
           
            else if (obj.NumeroDocumento == 0)
            {
                Mensaje = "El campo Identificación es obligatorio";
            }
            else if (string.IsNullOrEmpty(obj.FechaExpedicion) || string.IsNullOrWhiteSpace(obj.FechaExpedicion))
            {
                Mensaje = "El campo Fecha de Expedición es obligatorio";
            }
            else if (string.IsNullOrEmpty(obj.LugarExpedicion) || string.IsNullOrWhiteSpace(obj.LugarExpedicion))
            {
                Mensaje = "El campo lugar expedición es obligatorio";
            }
            else if (string.IsNullOrEmpty(obj.PrimerNombre) || string.IsNullOrWhiteSpace(obj.PrimerNombre))
            {
                Mensaje = "El campo primer nombre es obligatorio";
            }
            else if (string.IsNullOrEmpty(obj.SegundoNombre) || string.IsNullOrWhiteSpace(obj.SegundoNombre))
            {
                Mensaje = "El campo segundo nombre es obligatorio";
            }
            else if (string.IsNullOrEmpty(obj.PrimerApellido) || string.IsNullOrWhiteSpace(obj.PrimerApellido))
            {
                Mensaje = "El campo primer apellido es obligatorio";
            }
            else if (string.IsNullOrEmpty(obj.SegundoApellido) || string.IsNullOrWhiteSpace(obj.SegundoApellido))
            {
                Mensaje = "El campo segundo apellido es obligatorio";
            }

            else if (string.IsNullOrEmpty(obj.Genero) || string.IsNullOrWhiteSpace(obj.Genero))
            {
                Mensaje = "El campo sexo es obligatorio";
            }
            else if (string.IsNullOrEmpty(obj.Pais) || string.IsNullOrWhiteSpace(obj.Pais))
            {
                Mensaje = "El campo pais es obligatorio";
            }

            else if (string.IsNullOrEmpty(obj.EstadoCivil) || string.IsNullOrWhiteSpace(obj.EstadoCivil))
            {
                Mensaje = "El campo estado civil es obligatorio";
            }
           

            else if (string.IsNullOrEmpty(obj.LibretaMilitar) || string.IsNullOrWhiteSpace(obj.LibretaMilitar))
            {
                Mensaje = "El campo libreta militar es obligatorio";
            }
       
            else if (string.IsNullOrEmpty(obj.FechaNacimiente) || string.IsNullOrWhiteSpace(obj.FechaNacimiente))
            {
                Mensaje = "El campo Fecha de nacimiento  es obligatorio";
            }

            else if (string.IsNullOrEmpty(obj.PaisNacimiento) || string.IsNullOrWhiteSpace(obj.PaisNacimiento))
            {
                Mensaje = "El campo pais nacimiento es obligatorio";
            }
            else if (string.IsNullOrEmpty(obj.DeapartamentoNacimiento) || string.IsNullOrWhiteSpace(obj.DeapartamentoNacimiento))
            {
                Mensaje = "El campo departamento nacimiento es obligatorio";
            }
            else if (string.IsNullOrEmpty(obj.CiudadNacimiento) || string.IsNullOrWhiteSpace(obj.CiudadNacimiento))
            {
                Mensaje = "El campo ciudad nacimiento es obligatorio";
            }
            else if (string.IsNullOrEmpty(obj.Direccion) || string.IsNullOrWhiteSpace(obj.Direccion))
            {
                Mensaje = "El campo direccion es obligatorio";
            }
            else if (string.IsNullOrEmpty(obj.PaisDireccion) || string.IsNullOrWhiteSpace(obj.PaisDireccion))
            {
                Mensaje = "El campo pais residencia es obligatorio";
            }

            else if (string.IsNullOrEmpty(obj.DepartamentoResidencia) || string.IsNullOrWhiteSpace(obj.DepartamentoResidencia))
            {
                Mensaje = "El campo departamento residencia es obligatorio";
            }

            else if (string.IsNullOrEmpty(obj.CiudadDireccion) || string.IsNullOrWhiteSpace(obj.CiudadDireccion))
            {
                Mensaje = "El campo ciudad residencia es obligatorio";
            }

            else if (string.IsNullOrEmpty(obj.Telefono) || string.IsNullOrWhiteSpace(obj.Telefono))
            {
                Mensaje = "El campo telefono es obligatorio";
            }

            else if (string.IsNullOrEmpty(obj.CorreoElectronico) || string.IsNullOrWhiteSpace(obj.CorreoElectronico))
            {
                Mensaje = "El campo correo electronico es obligatorio";
            }
            else if (string.IsNullOrEmpty(obj.GrupoSanguineo) || string.IsNullOrWhiteSpace(obj.GrupoSanguineo))
            {
                Mensaje = "El campo Grupo sanguineo es obligatorio";
            }
            else if (string.IsNullOrEmpty(obj.GrupoEtnico) || string.IsNullOrWhiteSpace(obj.GrupoEtnico))
            {
                Mensaje = "El campo Grupo etnico es obligatorio";
            }

            else if (string.IsNullOrEmpty(obj.Profesion) || string.IsNullOrWhiteSpace(obj.Profesion))
            {
                Mensaje = "El campo profesion es obligatorio";
            }
            else if (string.IsNullOrEmpty(obj.Eps) || string.IsNullOrWhiteSpace(obj.Eps))
            {
                Mensaje = "El campo eps es obligatorio";
            }
            else if (string.IsNullOrEmpty(obj.FondoPensiones) || string.IsNullOrWhiteSpace(obj.FondoPensiones))
            {
                Mensaje = "El campo fondo pensiones es obligatorio";
            }
            else if (string.IsNullOrEmpty(obj.Arl) || string.IsNullOrWhiteSpace(obj.Arl))
            {
                Mensaje = "Este campo arl es obligatorio";
            }
            else if (string.IsNullOrEmpty(obj.Estadofecha) || string.IsNullOrWhiteSpace(obj.Estadofecha))
            {
                Mensaje = "Este campo fecha acticación es obligatorio";
            }
           

            if (string.IsNullOrEmpty(Mensaje))
            {
                return objCapaDato.EditarPerson(obj, out Mensaje);
            }
            else
            {
                return false;
            }


        }

        //public bool EliminarPersona(int id, out string Mensaje)
        //{

        //    return objCapaDato.EliminarPersona(id, out Mensaje);

        //}


    }
}
