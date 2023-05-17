using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;

using CapaEntidad;
using CapaNegocio;
using ClosedXML.Excel;
using System.Globalization;
using System.Data;
using static ClosedXML.Excel.XLPredefinedFormat;
using DateTime = System.DateTime;
using System.Web.Services.Description;

namespace CapaPresentacionAdmin.Controllers
{
    public class VerificarController : Controller
    {
        // GET: Verificar
        public ActionResult Buscar()
        {
            return View();
        }
        public ActionResult DatosPersonales()
        {
            return View();
        }
        public ActionResult FormacionAcademica()
        {
            return View();
        }
        public ActionResult Capacitaciones()
        {
            return View();
        }
        public ActionResult Idiomas()
        {
            return View();
        }
        public ActionResult ExperienciaLaboral()
        {
            return View();
        }
        public ActionResult DatosLaborales()
        {
            return View();
        }
        public ActionResult Requisitos()
        {
            return View();
        }
        public ActionResult Reporte()
        {
            return View();
        }

        //--------------------------------BUSCAR JSONRESULT

        [HttpGet]
        public JsonResult ListarBuscar()
        {
            string numero = "";

            List<Buscar> oLista = new List<Buscar>();

            oLista = new CN_Buscar().Listar(numero);


            //retornamos esto de esta forma porque DataTable asi lo requiere
            return Json(new { data = oLista }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult Consultar(string documento)
        {
            List<Buscar> oLista = new List<Buscar>();

            oLista = new CN_Buscar().Listar(documento);

            Session["numDocumento"] = '0';

            if (oLista.Count() > 0)
            {
                Session["numDocumento"] = documento;
            }


            //retornamos esto de esta forma porque DataTable asi lo requiere
            return Json(new { data = oLista }, JsonRequestBehavior.AllowGet);
        }




        [HttpPost]
        public ActionResult exportarReporte(string numero)
        {
            List<Buscar> oLista = new List<Buscar>();

            oLista = new CN_Buscar().Listar(numero);

            //dt es de tipo tabla
            DataTable dt = new DataTable();

            dt.Locale = new System.Globalization.CultureInfo("es-CO");

            dt.Columns.Add("IdPersona", typeof(int));
            dt.Columns.Add("Cedula", typeof(int));
            dt.Columns.Add("Nombre", typeof(string));
            dt.Columns.Add("Genero", typeof(string));
            dt.Columns.Add("FechaNacimiento", typeof(string));
            dt.Columns.Add("CorreoElectronico", typeof(string));
            dt.Columns.Add("Telefono", typeof(string));
            dt.Columns.Add("Sindicato", typeof(string));
            dt.Columns.Add("Profesion", typeof(string));
            dt.Columns.Add("Actividad", typeof(string));
            dt.Columns.Add("FechaIngreso", typeof(string));
            dt.Columns.Add("FechaRetiro", typeof(string));
            dt.Columns.Add("Estado", typeof(int));
            dt.Columns.Add("Verificado", typeof(string));

            foreach (Buscar rp in oLista)
            {
                dt.Rows.Add(new object[]
                {
                    rp.IdPersona,
                    rp.Cedula,
                    rp.Nombre,
                    rp.Genero,
                    rp.FechaNacimiento,
                    rp.CorreoElectronico,
                    rp.Telefono,
                    rp.Sindicato,
                    rp.Profesion,
                    rp.Actividad,
                    rp.FechaIngreso,
                    rp.FechaRetiro,
                    rp.Estado,
                    rp.Verificado,
                });
            }

            dt.TableName = "datos";

            //creamos el doumento excel
            using (XLWorkbook wb = new XLWorkbook())
            {
                var hoja = wb.Worksheets.Add(dt);

                //vamos a guardar el documento en el memorystream
                using (MemoryStream stream = new MemoryStream())
                {
                    wb.SaveAs(stream);
                    return File(stream.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Reporte" + DateTime.Now.ToString() + ".xlsx");
                }
            }
        }

        //--------------------------------LISTAR DATOS PERSONALES Y DEMAS

        [HttpGet]
        public JsonResult ListarInfoCpersona()
        {

            List<InfoCPersona> oLista = new List<InfoCPersona>();

            string numero = ((string)Session["numDocumento"]);

            Session["numDocumento"] = numero;

            oLista = new CN_InfoCPersona().Listar(numero);

            //Session["InfoCPersona"] = oLista;
            //List<InfoCPersona> hola = ((List<InfoCPersona>)Session["InfoCPersona"]);

            //retornamos esto de esta forma porque DataTable asi lo requiere
            return Json(new { data = oLista }, JsonRequestBehavior.AllowGet);
        }



        //--------------------------------FORMACION ACADEMICA
        [HttpGet]
        public JsonResult ListarFAcademica()
        {

            InfoCPersona oLista;

            string numero = ((string)Session["numDocumento"]);

            Session["numDocumento"] = numero;


            //oLista = new CN_InfoCPersona().Listar(numero);
            oLista = new CN_InfoCPersona().Listar(numero).Where((Ra) => Ra.NumeroDocumento == int.Parse(numero)).FirstOrDefault();

            if (oLista == null)
            {
                oLista = new InfoCPersona();
                if (string.IsNullOrEmpty(oLista.ObservacionBasica) && string.IsNullOrEmpty(oLista.ObservacionSuperior))
                {
                    oLista.ObservacionBasica = "Debes Hacer una consulta";
                    oLista.ObservacionSuperior = "Debes Hacer una consulta";
                }
            }

            if (string.IsNullOrEmpty(oLista.ObservacionBasica) && string.IsNullOrEmpty(oLista.ObservacionSuperior))
            {
                oLista.ObservacionBasica = "Agrega un Comentario";
                oLista.ObservacionSuperior = "Agrega un Comentario";
            }

            if (string.IsNullOrEmpty(oLista.CumpleBasica) && string.IsNullOrEmpty(oLista.CumpleSuperior))
            {
                oLista.CumpleBasica = "Sin Seleccionar";
                oLista.CumpleSuperior = "Sin Seleccionar";
            }


            //retornamos esto de esta forma porque DataTable asi lo requiere
            return Json(new { data = oLista }, JsonRequestBehavior.AllowGet);
        }


        [HttpPost]
        public JsonResult EditarFormacioAcademica(int IdFAcademica, string Numero, string Cumple, string Observacion)
        {
            //nos permite guarda cualquier tipo de datos
            bool resultado;
            InfoCPersona oLista;
            string mensaje = string.Empty;

            string numero = ((string)Session["numDocumento"]);

            Session["numDocumento"] = numero;

            oLista = new CN_InfoCPersona().Listar(numero).Where((Ra) => Ra.NumeroDocumento == int.Parse(numero)).FirstOrDefault();

            if (oLista == null)
            {
                resultado = false;
                mensaje = "Debes consultar una persona primero";
                return Json(new { resultado = resultado, mensaje = mensaje }, JsonRequestBehavior.AllowGet);
            }

            int IdPersona = oLista.IdPersonaFAcademica;

            resultado = new CN_InfoCPersona().Editar(IdPersona, IdFAcademica, Numero, Cumple, Observacion, out mensaje);


            return Json(new { resultado = resultado, mensaje = mensaje }, JsonRequestBehavior.AllowGet);
        }


        //--------------------------------CURSOS
        [HttpPost]
        public JsonResult EditarCurso(int IdPersona, int IdCurso, string Cumple, string Observacion)
        {
            bool resultado;
            string mensaje = string.Empty;

            resultado = new CN_InfoCPersona().EditarCurso(IdPersona, IdCurso, Cumple, Observacion, out mensaje);

            return Json(new { resultado = resultado, mensaje = mensaje }, JsonRequestBehavior.AllowGet);
        }



        //--------------------------------IDIOMAS

        [HttpGet]
        public JsonResult ListarIdiomas()
        {

            List<Idiomas> oLista = new List<Idiomas>();

            string numero = ((string)Session["numDocumento"]);

            Session["numDocumento"] = numero;

            oLista = new CN_Idiomas().Listar(numero);

            //retornamos esto de esta forma porque DataTable asi lo requiere
            return Json(new { data = oLista }, JsonRequestBehavior.AllowGet);
        }


        //--------------------------------EXPERIENCIA LABORAL

        [HttpGet]
        public JsonResult ListarExpLaboral()
        {

            List<ExperienciaLaboral> oLista = new List<ExperienciaLaboral>();

            string numero = ((string)Session["numDocumento"]);

            Session["numDocumento"] = numero;

            oLista = new CN_ExperienciaLaboral().Listar(numero);

            //retornamos esto de esta forma porque DataTable asi lo requiere
            return Json(new { data = oLista }, JsonRequestBehavior.AllowGet);
        }


        [HttpPost]
        public JsonResult EditarExpLaboral(int IdPersona, int IdExperienciaL, string Cumple, string Observacion)
        {
            bool resultado;

            string mensaje = string.Empty;

            resultado = new CN_ExperienciaLaboral().EditarExpLaboral(IdPersona, IdExperienciaL, Cumple, Observacion, out mensaje);

            return Json(new { resultado = resultado, mensaje = mensaje }, JsonRequestBehavior.AllowGet);
        }



        //--------------------------------DATOS LABORALES
        [HttpGet]
        public JsonResult ListarDatosLaborales()
        {

            List<DatosLaborales> oLista = new List<DatosLaborales>();

            string numero = ((string)Session["numDocumento"]);

            Session["numDocumento"] = numero;

            oLista = new CN_DatosLaborales().Listar(numero);

            //retornamos esto de esta forma porque DataTable asi lo requiere
            return Json(new { data = oLista }, JsonRequestBehavior.AllowGet);
        }


        [HttpPost]
        public JsonResult EditarDatoLaboral(int IdPersona, int IdDlaboral, string Cumple, string Observacion)
        {
            bool resultado;

            string mensaje = string.Empty;

            resultado = new CN_DatosLaborales().EditarDatoLaboral(IdPersona, IdDlaboral, Cumple, Observacion, out mensaje);

            return Json(new { resultado = resultado, mensaje = mensaje }, JsonRequestBehavior.AllowGet);
        }


        //--------------------------------REQUISITOS
        [HttpGet]
        public JsonResult ListarRequisitos()
        {

            List<Requisitos> oLista = new List<Requisitos>();

            string numero = ((string)Session["numDocumento"]);

            Session["numDocumento"] = numero;

            oLista = new CN_Requisitos().Listar(numero);

            //retornamos esto de esta forma porque DataTable asi lo requiere
            return Json(new { data = oLista }, JsonRequestBehavior.AllowGet);
        }


        [HttpPost]
        public JsonResult EditarRequisito(int IdPersona, int IdRequisito, string Cumple, string Observacion)
        {
            bool resultado;

            string mensaje = string.Empty;

            resultado = new CN_Requisitos().EditarRequisito(IdPersona, IdRequisito, Cumple, Observacion, out mensaje);

            return Json(new { resultado = resultado, mensaje = mensaje }, JsonRequestBehavior.AllowGet);
        }
    }
}