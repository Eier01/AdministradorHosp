﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CapaDatos;
using CapaEntidad;

namespace CapaNegocio
{
    public  class CN_CRequisitoLegal
    {
        private CD_CRequisitoLegal objCapaDato = new CD_CRequisitoLegal();

        public List<CrearRequisitoLegal> Listar()
        {
            return objCapaDato.Listar();
        }


        public int Registrar(CrearRequisitoLegal obj, out string Mensaje)
        {
            Mensaje = string.Empty;

            if (string.IsNullOrEmpty(obj.NombreRequisito) || string.IsNullOrWhiteSpace(obj.NombreRequisito))
            {
                Mensaje = "El Requisito Legal no puede ser vacio";
            }

            if (string.IsNullOrEmpty(Mensaje))
            {
                return objCapaDato.Registrar(obj, out Mensaje);
            }
            else
            {
                return 0;
            }
        }

        public bool Editar(CrearRequisitoLegal obj, out string Mensaje)
        {
            Mensaje = string.Empty;

            if (string.IsNullOrEmpty(obj.NombreRequisito) || string.IsNullOrWhiteSpace(obj.NombreRequisito))
            {
                Mensaje = "El Requisito Legal no puede ser vacio";
            }

            if (string.IsNullOrEmpty(Mensaje))
            {
                return objCapaDato.Editar(obj, out Mensaje);
            }
            else
            {
                return false;
            }
        }

        public bool Eliminar(int id, out string Mensaje)
        {
            return objCapaDato.Eliminar(id, out Mensaje);
        }
    }
}
