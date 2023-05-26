using CapaEntidad;
using CapaNegocio;
using ClosedXML.Excel;
using DocumentFormat.OpenXml.Office2010.PowerPoint;
using Microsoft.Ajax.Utilities;
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
    [Authorize]
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

            if(string.IsNullOrWhiteSpace(numero))
            {
                numero = "0";
            }

            Session["Documento"] = Convert.ToInt32(numero);

            if(numero.Equals("0"))
            {
                string documento = ((string)Session["Consultarid"]);

                if(documento != null)
                {
                    S_Persona persona = new S_CN_Persona().Listar().Where((p) => p.NumeroDocumento == int.Parse(documento)).FirstOrDefault();


                    string idPersona = Convert.ToString(persona.IdPersona);


                    oLista = new S_CNF_Academica().Listar(idPersona);
                    return Json(new { data = oLista }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    oLista = new S_CNF_Academica().Listar("0");
                    return Json(new { data = oLista }, JsonRequestBehavior.AllowGet);
                }

                
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

            string numero;
            numero = Convert.ToString(Session["Documento"]);

            if (string.IsNullOrWhiteSpace(numero))
            {
                numero = "0";
            }
            if (numero.Equals("0"))
            {
                string documento = ((string)Session["Consultarid"]);

                if (documento != null)
                {
                    S_Persona persona = new S_CN_Persona().Listar().Where((p) => p.NumeroDocumento == int.Parse(documento)).FirstOrDefault();


                    string idPersona = Convert.ToString(persona.IdPersona);


                    oLista = new S_CN_Rlegales().Listar(idPersona);
                    return Json(new { data = oLista }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    oLista = new S_CN_Rlegales().Listar("0");
                    return Json(new { data = oLista }, JsonRequestBehavior.AllowGet);
                }


            }

            Session["Documento"] = Convert.ToInt32(numero); ;
            oLista = new S_CN_Rlegales().Listar(numero);

            return Json(new { data = oLista }, JsonRequestBehavior.AllowGet);

        }

        [HttpGet]
        public JsonResult ListarIdioma()

        {
            List<S_Idiomas> oLista = new List<S_Idiomas>();
            string numero;
            numero = Convert.ToString(Session["Documento"]);

            if (string.IsNullOrWhiteSpace(numero))
            {
                numero = "0";
            }
            if (numero.Equals("0"))
            {
                string documento = ((string)Session["Consultarid"]);

                if (documento != null)
                {
                    S_Persona persona = new S_CN_Persona().Listar().Where((p) => p.NumeroDocumento == int.Parse(documento)).FirstOrDefault();


                    string idPersona = Convert.ToString(persona.IdPersona);


                    oLista = new S_CN_Idiomas().Listar(idPersona);
                    return Json(new { data = oLista }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    oLista = new S_CN_Idiomas().Listar("0");
                    return Json(new { data = oLista }, JsonRequestBehavior.AllowGet);
                }

                
            }

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
            if (string.IsNullOrWhiteSpace(numero))
            {
                numero = "0";
            }
            if (numero.Equals("0"))
            {
                string documento = ((string)Session["Consultarid"]);

                if (documento != null)
                {
                    S_Persona persona = new S_CN_Persona().Listar().Where((p) => p.NumeroDocumento == int.Parse(documento)).FirstOrDefault();


                    string idPersona = Convert.ToString(persona.IdPersona);


                    oLista = new S_CN_Ex_Laboral().Listar(idPersona);
                    return Json(new { data = oLista }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    oLista = new S_CN_Ex_Laboral().Listar("0");
                    return Json(new { data = oLista }, JsonRequestBehavior.AllowGet);
                }

                
            }

            Session["Documento"] = Convert.ToInt32(numero); ;
            oLista = new S_CN_Ex_Laboral().Listar(numero);

            return Json(new { data = oLista }, JsonRequestBehavior.AllowGet);

            
        }
        [HttpGet]
        public JsonResult ListarDatosLaborales()
        {
            List<S_Datos_Laborales> oLista = new List<S_Datos_Laborales>();
            string numero;
            numero = Convert.ToString(Session["Documento"]);

            if (string.IsNullOrWhiteSpace(numero))
            {
                numero = "0";
            }
            Session["Documento"] = Convert.ToInt32(numero); ;

            if (numero.Equals("0"))
            {
                string documento = ((string)Session["Consultarid"]);

                if (documento != null)
                {
                    S_Persona persona = new S_CN_Persona().Listar().Where((p) => p.NumeroDocumento == int.Parse(documento)).FirstOrDefault();


                    string idPersona = Convert.ToString(persona.IdPersona);


                    oLista = new S_CN_Laborales().Listar(idPersona);
                    return Json(new { data = oLista }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    oLista = new S_CN_Laborales().Listar("0");
                    return Json(new { data = oLista }, JsonRequestBehavior.AllowGet);
                }

            }

            oLista = new S_CN_Laborales().Listar(numero);

            return Json(new { data = oLista }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult ListaCapacitacionesC()
        {
            List<S_CapacitacionesC> oLista = new List<S_CapacitacionesC>();
            string numero;
            numero = Convert.ToString(Session["Documento"]);

            if (string.IsNullOrWhiteSpace(numero))
            {
                numero = "0";
            }
            Session["Documento"] = Convert.ToInt32(numero); ;

            if (numero.Equals("0"))
            {
                string documento = ((string)Session["Consultarid"]);

                if (documento != null)
                {
                    S_Persona persona = new S_CN_Persona().Listar().Where((p) => p.NumeroDocumento == int.Parse(documento)).FirstOrDefault();


                    string idPersona = Convert.ToString(persona.IdPersona);


                    oLista = new S_CNCapacitacionesC().Listar(idPersona);
                    return Json(new { data = oLista }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    oLista = new S_CNCapacitacionesC().Listar("0");
                    return Json(new { data = oLista }, JsonRequestBehavior.AllowGet);
                }
                
            }

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
                Session["Documento"] = "0";
                if (id != 0)
                {
                    Session["Documento"] = id;
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
                objeto.IdPersona = Convert.ToString(Session["Documento"]);
                if (objeto.IdPersona == "")
                {
                    Session["Documento"] = "0";
                    objeto.IdPersona = "0";
                }

                if (objeto.IdPersona.Equals("0"))
                {
                    string documento = ((string)Session["Consultarid"]);

                    S_Persona persona = new S_CN_Persona().Listar().Where((p) => p.NumeroDocumento == int.Parse(documento)).FirstOrDefault();

                    objeto.IdPersona = Convert.ToString(persona.IdPersona);
                }
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

            // Obtiene los archivos adjuntos
            for (int i = 0; i < Request.Files.Count; i++)
            {
                HttpPostedFileBase archivo = Request.Files[i];
                string nombreArchivo = null;

                MemoryStream ms = new MemoryStream();

                archivo.InputStream.CopyTo(ms);
                byte[] data = ms.ToArray();

                if (archivo != null)
                {
                    nombreArchivo = Path.GetFileName(archivo.FileName);

                }

                if (Request.Files.GetKey(i) == "ActaColegioNombre")
                {
                    objeto.ActaColegio = data;
                    objeto.ActaColegioNombre = nombreArchivo;
                }
                else if (Request.Files.GetKey(i) == "DiplomaColegioNombre")
                {
                    objeto.DiplomaColegio = data;
                    objeto.DiplomaColegioNombre = nombreArchivo;
                }
                else if (Request.Files.GetKey(i) == "ActaUniversitariaNombre")
                {
                    objeto.ActaUniversitaria = data;
                    objeto.ActaUniversitariaNombre = nombreArchivo;
                }
                else if (Request.Files.GetKey(i) == "DiplomaUniversitarioNombre")
                {
                    objeto.DiplomaUniversitario = data;
                    objeto.DiplomaUniversitarioNombre = nombreArchivo;
                }
            }

            //
            if (objeto.IdFormacionAcademica == 0)
            {
                objeto.IdPersona = Convert.ToString(Session["Documento"]);
                if (objeto.IdPersona == "")
                {
                    Session["Documento"] = "0";
                    objeto.IdPersona = "0";
                }

                if (objeto.IdPersona.Equals("0"))
                {
                    string documento = ((string)Session["Consultarid"]);

                    S_Persona persona = new S_CN_Persona().Listar().Where((p) => p.NumeroDocumento == int.Parse(documento)).FirstOrDefault();

                    objeto.IdPersona = Convert.ToString(persona.IdPersona);
                }

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
                if (objeto.IdPersona == "")
                {
                    Session["Documento"] = "0";
                    objeto.IdPersona = "0";
                }

                if (objeto.IdPersona.Equals("0"))
                {
                    string documento = ((string)Session["Consultarid"]);

                    S_Persona persona = new S_CN_Persona().Listar().Where((p) => p.NumeroDocumento == int.Parse(documento)).FirstOrDefault();

                    objeto.IdPersona = Convert.ToString(persona.IdPersona);
                }
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


            HttpPostedFileBase archivo = Request.Files["AdjuntarSoporteNombre"];
            string nombreArchivo = null;

            MemoryStream ms = new MemoryStream();

            archivo.InputStream.CopyTo(ms);
            byte[] data = ms.ToArray();

            if (archivo != null)
            {
                nombreArchivo = Path.GetFileName(archivo.FileName);
            }

            objeto.AdjuntarSoporte = data;
            objeto.AdjuntarSoporteNombre = nombreArchivo;

            //
            if (objeto.IdExperienciaLaboral == 0)
            {
                //en caso de que alguien se haya olvidado de registrar en este modulo y le de depues por consultar y rellenarlo
                //para eso necesitamo que el Session["Documento"] sea igual a cero.
                objeto.IdPersona = Convert.ToString(Session["Documento"]);
                if(objeto.IdPersona == "")
                {
                    Session["Documento"] = "0";
                    objeto.IdPersona = "0";
                }
                if (objeto.IdPersona.Equals("0"))
                {
                    string documento = ((string)Session["Consultarid"]);

                    S_Persona persona = new S_CN_Persona().Listar().Where((p) => p.NumeroDocumento == int.Parse(documento)).FirstOrDefault();

                    objeto.IdPersona = Convert.ToString(persona.IdPersona);
                }
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


            HttpPostedFileBase archivo = Request.Files["ArchivoNombre"];
            MemoryStream ms = new MemoryStream();

            archivo.InputStream.CopyTo(ms);
            byte[] data = ms.ToArray();

            string nombreArchivo = null;
            if (archivo != null)
            {
                nombreArchivo = Path.GetFileName(archivo.FileName);
            }

            objeto.Archivo = data;
            objeto.ArchivoNombre = nombreArchivo;

            //
            if (objeto.idCapacitacionesCursos == 0)
            {
                objeto.IdPersona = Convert.ToString(Session["Documento"]);
                if (objeto.IdPersona == "")
                {
                    Session["Documento"] = "0";
                    objeto.IdPersona = "0";
                }

                if (objeto.IdPersona.Equals("0"))
                {
                    string documento = ((string)Session["Consultarid"]);

                    S_Persona persona = new S_CN_Persona().Listar().Where((p) => p.NumeroDocumento == int.Parse(documento)).FirstOrDefault();

                    objeto.IdPersona = Convert.ToString(persona.IdPersona);
                }
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
            //int resacr = 0;

            HttpPostedFileBase archivo = Request.Files["archivoNombre"];
            MemoryStream ms = new MemoryStream();
            
            archivo.InputStream.CopyTo(ms);
            byte[] data = ms.ToArray();

            string nombreArchivo = null;
            if (archivo != null)
            {
                nombreArchivo = Path.GetFileName(archivo.FileName);
                //resacr = CargaArchivo(archivo);
            }

            objeto.Archivo = data;
            objeto.archivoNombre = nombreArchivo;

            //
            if (objeto.IdRequisitosLegales == 0)
            {
                objeto.IdPersona = Convert.ToString(Session["Documento"]);
                if (objeto.IdPersona == "")
                {
                    Session["Documento"] = "0";
                    objeto.IdPersona = "0";
                }

                if (objeto.IdPersona.Equals("0"))
                {
                    string documento = ((string)Session["Consultarid"]);

                    S_Persona persona = new S_CN_Persona().Listar().Where((p) => p.NumeroDocumento == int.Parse(documento)).FirstOrDefault();

                    objeto.IdPersona = Convert.ToString(persona.IdPersona);
                }
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


        [HttpPost]
        public JsonResult Consultar(string documento)
        {
            bool estado;

            List<Buscar> oLista = new List<Buscar>();

            oLista = new CN_Buscar().Listar(documento);
            

            Session["Consultarid"] = "0";

            if (oLista.Count() > 0)
            {
                estado = true;
                Session["Consultarid"] = documento;
                return Json(new { message = "operacion exitosa", estado=estado }, JsonRequestBehavior.AllowGet);
            }

            estado = false;

            //retornamos esto de esta forma porque DataTable asi lo requiere
            return Json(new { message = "No se encontro a la persona ", estado=estado}, JsonRequestBehavior.AllowGet);
        }


        [HttpPost]
        public JsonResult ListarActividadSindicato(string tActividad)
        {
            List<Actividad> oLista = new List<Actividad>();

            oLista = new CN_Actividad().ListarActividad_Sindicato(tActividad);

            //retornamos esto de esta forma porque DataTable asi lo requiere
            return Json(new { data = oLista }, JsonRequestBehavior.AllowGet);
        }



        [HttpPost]
        public JsonResult ListarParaSindicato(int idActividad)
        {
            List<RequisitoPorActividad> oLista = new List<RequisitoPorActividad>();

            oLista = new CN_RequisitoPorActividad().ListarParaSindicato(idActividad);

            //retornamos esto de esta forma porque DataTable asi lo requiere
            return Json(new { data = oLista }, JsonRequestBehavior.AllowGet);
        }
    }
}




















