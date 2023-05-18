using CapaEntidad;
using CapaNegocio;
using ClosedXML.Excel;
using DocumentFormat.OpenXml.Office2010.PowerPoint;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CapaPresentacionAdmin.Controllers
{
    public class SindicatoController : Controller
    {
        // GET: Sindicato
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Personaview()
        {
            return View();
        }
        public ActionResult Idiomasview()
        {
            return View();
        }
        public ActionResult F_AcademicaView()
        {
            return View();
        }
        public ActionResult Exp_Laboralview()
        {
            return View();
        }
        public ActionResult Datos_Laboralesview()
        {
            return View();
        }
        public ActionResult CapacitacionesCView()
        {

            return View();
        }
        public ActionResult RlegalesView()
        {
            return View();
        }


        [HttpGet]
        public JsonResult ListarFacademica()
        {
            List<S_Formacion_academica> oLista = new List<S_Formacion_academica>();

            string numero;

            numero = Convert.ToString(Session["Documento"]);
           
            Session["Documento"] = Convert.ToInt32(numero);

            if(numero.Equals('0'))
            {
                string documento = ((string)Session["Documento"]);

                oLista = new S_CNF_Academica().Listar(numero);
                return Json(new { data = oLista }, JsonRequestBehavior.AllowGet);
            }

            oLista = new S_CNF_Academica().Listar(numero);


            return Json(new { data = oLista }, JsonRequestBehavior.AllowGet);
        }



        [HttpGet]
        public JsonResult ListarPersona()         
        {
            
            List<S_Persona> oLista = new List<S_Persona>();
            oLista = new S_CN_Persona().Listar();

            return Json(new { data = oLista }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public FileResult ExportPersona()
        {
            List<S_Persona> oLista = new List<S_Persona>();
            oLista = new S_CN_Persona().Listar();

            DataTable dt = new DataTable();
            dt.Locale= new System.Globalization.CultureInfo("es-CO");

            //Identificación	Primer nombre	Dirección	Telefono	Correo	Profesión	Eps	
            dt.Columns.Add("Identificación", typeof(String));
            dt.Columns.Add("Primer nombre", typeof(String));
            dt.Columns.Add("Dirección", typeof(String));
            dt.Columns.Add("Telefono", typeof(String));
            dt.Columns.Add("Correo", typeof(String));
            dt.Columns.Add("Profesión", typeof(String));
            dt.Columns.Add("Eps", typeof(String));

            foreach (S_Persona persona in oLista)
            {
                dt.Rows.Add(new object[]
                {
                    persona.NumeroDocumento,
                    persona.PrimerNombre,
                    persona.Direccion,
                    persona.Telefono,
                    persona.CorreoElectronico,
                    persona.Profesion,
                    persona.Eps


                });
            }
            dt.TableName = "ReportePersonas";

            using (XLWorkbook wb = new XLWorkbook())
            {
                wb.Worksheets.Add(dt);
                using(MemoryStream stream = new MemoryStream())
                {
                    wb.SaveAs(stream);
                    return File(stream.ToArray(),"application/vnd.openxmlformats-officedocument.spreadsheetml.sheet","Reporte Usuarios "+ DateTime.Now.ToString("dd/MM/yyyy_HH:mm:ss") + ".xlsx");
                }
            }

        }


        [HttpGet]
        public JsonResult ListarRlegales()

        {
            List<S_Rlegales> oLista = new List<S_Rlegales>();
            oLista = new S_CN_Rlegales().Listar();

            return Json(new { data = oLista }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult ListarIdioma()

        {
            List<S_Idiomas> oLista = new List<S_Idiomas>();
            string numero;
            numero = Convert.ToString(Session["Documento"]);
            Session["Documento"] = Convert.ToInt32(numero); ;
            oLista = new S_CN_Idiomas().Listar(numero);

            return Json(new { data = oLista }, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public JsonResult ListaExp_Laboral()
        {
            
            List<S_Ex_Laboral> oLista = new List<S_Ex_Laboral>();
            string numero;
            numero = Convert.ToString(Session["Documento"]);
            Session["Documento"] = Convert.ToInt32(numero); ;
            oLista = new S_CN_Ex_Laboral().Listar(numero);

            return Json(new { data = oLista }, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public JsonResult ListarDatosLaborales()
        {
            List<S_Datos_Laborales> oLista = new List<S_Datos_Laborales>();
            oLista = new S_CN_Laborales().Listar();

            return Json(new { data = oLista }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult ListaCapacitacionesC()
        {
            List<S_CapacitacionesC> oLista = new List<S_CapacitacionesC>();
            string numero;
            numero = Convert.ToString(Session["Documento"]);
            Session["Documento"] = Convert.ToInt32(numero); ;
            oLista = new S_CNCapacitacionesC().Listar(numero);

            return Json(new { data = oLista }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult GuardarPersona(S_Persona objeto)
        {
            object resultado;
            string mensaje = string.Empty;

            if(objeto.IdPersona == 0)
            {

                resultado = new S_CN_Persona().RegistrarPerson(objeto, out mensaje);
                int id = Convert.ToInt32(resultado);
                if (id != 0)
                {
                    Session["Documento"] = id;
                }
                else
                {
                    Session["Documento"] = '0';
                }
            }
            else
            {
                resultado = new S_CN_Persona().EditarPerson(objeto, out mensaje);
            }

            return Json(new { resultado = resultado, mensaje = mensaje }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult GuardarDatosLaborales(S_Datos_Laborales objeto)
        {
            object resultado;
            string mensaje = string.Empty;

            if (objeto.IdDatosLaborales == 0)
            {
                resultado = new S_CN_Laborales().RegistrarDatosLaborales(objeto, out mensaje);
            }
            else
            {
                resultado = new S_CN_Laborales().EditarDatosLaborales(objeto, out mensaje);
            }

            return Json(new { resultado = resultado, mensaje = mensaje }, JsonRequestBehavior.AllowGet);
        }


        [HttpPost]
    
        public JsonResult GuardarFormacion(S_Formacion_academica objeto)
        {
            object resultado;
            string mensaje = string.Empty;
            List<string> nombresArchivosActaUniversitaria = new List<string>();
            List<string> nombresArchivosDiplomaUniversitario = new List<string>();
            List<string> nombresArchivosActaColegio = new List<string>();
            List<string> nombresArchivosDiplomaColegio = new List<string>();
            List<int> resacrsActaUniversitaria = new List<int>();
            List<int> resacrsDiplomaUniversitario = new List<int>();
            List<int> resacrsActaColegio = new List<int>();
            List<int> resacrsDiplomaColegio = new List<int>();

            // Obtiene los archivos adjuntos
            for (int i = 0; i < Request.Files.Count; i++)
            {
                HttpPostedFileBase archivo = Request.Files[i];
                string nombreArchivo = null;
                int resacr = 0;

                if (archivo != null)
                {
                    nombreArchivo = Path.GetFileName(archivo.FileName);
                    resacr = CargaArchivo(archivo);
                }

                if (Request.Files.GetKey(i) == "ActaUniversitaria")
                {
                    nombresArchivosActaUniversitaria.Add(nombreArchivo);
                    resacrsActaUniversitaria.Add(resacr);
                }
                else if (Request.Files.GetKey(i) == "DiplomaUniversitario")
                {
                    nombresArchivosDiplomaUniversitario.Add(nombreArchivo);
                    resacrsDiplomaUniversitario.Add(resacr);
                }
                else if (Request.Files.GetKey(i) == "ActaColegio")
                {
                    nombresArchivosActaColegio.Add(nombreArchivo);
                    resacrsActaColegio.Add(resacr);
                }
                else if (Request.Files.GetKey(i) == "DiplomaColegio")
                {
                    nombresArchivosDiplomaColegio.Add(nombreArchivo);
                    resacrsDiplomaColegio.Add(resacr);
                }
            }

            objeto.ActaUniversitaria = string.Join(",", nombresArchivosActaUniversitaria);
            objeto.DiplomaUniversitario = string.Join(",", nombresArchivosDiplomaUniversitario);
            objeto.ActaColegio = string.Join(",", nombresArchivosActaColegio);
            objeto.DiplomaColegio = string.Join(",", nombresArchivosDiplomaColegio);

            //
            if (objeto.IdFormacionAcademica == 0)
            {
                objeto.IdPersona = Convert.ToString(Session["Documento"]);

                resultado = new S_CNF_Academica().RegistrarFormacion(objeto, out mensaje);
            }
            else
            {
                resultado = new S_CNF_Academica().EditarFormacion(objeto, out mensaje);
            }

            //mensaje = nombreArchivo+"_"+resacr;
            return Json(new { resultado = resultado, mensaje = mensaje }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult GuardarIdioma(S_Idiomas objeto)
        {
            object resultado;
            string mensaje = string.Empty;
            if (objeto.IdIdiomas == 0)
            {
                objeto.IdPersona = Convert.ToString(Session["Documento"]);
                resultado = new S_CN_Idiomas().RegistrarIdioma(objeto, out mensaje);
            }
            else
            {
                resultado = new S_CN_Idiomas().EditarIdiomas(objeto, out mensaje);
            }

            return Json(new { resultado = resultado, mensaje = mensaje }, JsonRequestBehavior.AllowGet);

        }
        [HttpPost]
        public JsonResult GuardarExp(S_Ex_Laboral objeto)
        {
            object resultado;
            string mensaje = string.Empty;
            int resacr = 0;

            HttpPostedFileBase archivo = Request.Files["AdjuntarSoporte"];
            string nombreArchivo = null;
            if (archivo != null)
            {
                nombreArchivo = Path.GetFileName(archivo.FileName);
                resacr = CargaArchivo(archivo);
            }

            objeto.AdjuntarSoporte = nombreArchivo;

            //
            if (objeto.IdExperienciaLaboral == 0)
            {
                objeto.IdPersona = Convert.ToString(Session["Documento"]);
                resultado = new S_CN_Ex_Laboral().RegistrarExpLaboral(objeto, out mensaje);
            }
            else
            {
                resultado = new S_CN_Ex_Laboral().ActualizarExpLaboral(objeto, out mensaje);
            }

            //mensaje = nombreArchivo+"_"+resacr;
            return Json(new { resultado = resultado, mensaje = mensaje }, JsonRequestBehavior.AllowGet);

        }

        [HttpPost]
        public JsonResult GuardarCapatacitaciones(S_CapacitacionesC objeto)
        {
            object resultado;
            string mensaje = string.Empty;
            int resacr = 0;

            HttpPostedFileBase archivo = Request.Files["Archivo"];
            string nombreArchivo = null;
            if (archivo != null)
            {
                nombreArchivo = Path.GetFileName(archivo.FileName);
                resacr = CargaArchivo(archivo);
            }

            objeto.Archivo = nombreArchivo;

            //
            if (objeto.idCapacitacionesCursos == 0)
            {
                objeto.IdPersona = Convert.ToString(Session["Documento"]);
                resultado = new S_CNCapacitacionesC().RegistrarCursos(objeto, out mensaje);
            }
            else
            {
                resultado = new S_CNCapacitacionesC().EditarCursos(objeto, out mensaje);
            }

            //mensaje = nombreArchivo+"_"+resacr;
            return Json(new { resultado = resultado, mensaje = mensaje }, JsonRequestBehavior.AllowGet);

        }

        public JsonResult GuardarRlegales(S_Rlegales objeto)
        {
            object resultado;
            string mensaje = string.Empty;
            int resacr = 0;

            HttpPostedFileBase archivo = Request.Files["Archivo"];
            string nombreArchivo = null;
            if (archivo != null)
            {
                nombreArchivo = Path.GetFileName(archivo.FileName);
                resacr = CargaArchivo(archivo);
            }

            objeto.Archivo = nombreArchivo;

            //
            if (objeto.IdRequisitosLegales == 0)
            {
                resultado = new S_CN_Rlegales().RegistrarRlegales(objeto, out mensaje);
            }
            else
            {
                resultado = new S_CN_Rlegales().EditarRlegales(objeto, out mensaje);
            }

            //mensaje = nombreArchivo+"_"+resacr;
            return Json(new { resultado = resultado, mensaje = mensaje }, JsonRequestBehavior.AllowGet);

        }

        public int CargaArchivo(HttpPostedFileBase archivo)
        {
            try
            {
                // Verifica que se haya seleccionado un archivo
                if (archivo != null && archivo.ContentLength > 0)
                {
                    // Crea la ruta de destino del archivo
                    string rutaDestino = Server.MapPath("~/Views/Subidos/") + archivo.FileName;

                    // Guarda el archivo en la carpeta "subidos"
                    archivo.SaveAs(rutaDestino);

                    // Devuelve 1 si el archivo se subió correctamente
                    return 1;
                }

                // Devuelve 0 si no se seleccionó ningún archivo
                return 0;
            }
            catch (Exception ex)
            {
                // Loguea la excepción
                // ...

                // Devuelve -1 si se produjo un error al subir el archivo
                return -1;
            }
        }


        [HttpGet]
        public JsonResult Consultar(string documento)
        {
            List<Buscar> oLista = new List<Buscar>();

            oLista = new CN_Buscar().Listar(documento);
            

            Session["Consultarid"] = '0';

            if (oLista.Count() > 0)
            {
                Session["Consultarid"] = documento;
                return Json(new { data = "operacion exitosa" }, JsonRequestBehavior.AllowGet);
            }



            //retornamos esto de esta forma porque DataTable asi lo requiere
            return Json(new { data = "No se encontro a la persona " }, JsonRequestBehavior.AllowGet);
        }
    }
}