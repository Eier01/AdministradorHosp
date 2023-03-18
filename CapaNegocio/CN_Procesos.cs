using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CapaDatos;
using CapaEntidad;

namespace CapaNegocio
{
    public class CN_Procesos
    {
        private CD_Procesos objCapaDato = new CD_Procesos();

        public List<Procesos> Listar()
        {
            return objCapaDato.Listar();
        }
    }
}
