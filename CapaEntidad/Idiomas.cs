using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class Idiomas
    {
        //IdIdiomas,Idioma,LoHabla,LoLee, LoEscribe, IdPersona
        public int IdIdiomas { get; set; }
        public string Idioma { get; set; }
        public string LoHabla { get; set; }
        public string LoLee { get; set; }
        public string LoEscribe { get; set; }
        public  Persona oIdPersona { get; set; }

    }
}
