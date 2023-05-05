using CapaEntidad;
using CapaNegocio;
using System;
using System.Collections;
using System.Collections.Generic;
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


        [HttpGet]
        public JsonResult ListarFacademica()
        {
            List<Formacion_academica> oLista = new List<Formacion_academica>();
            oLista = new CNF_Academica().Listar();

            return Json(new { data = oLista }, JsonRequestBehavior.AllowGet);
        }



        [HttpGet]
        public JsonResult ListarPersona()
        
        {
            List<Persona> oLista = new List<Persona>();
            oLista = new CN_Persona().Listar();

            return Json(new { data = oLista }, JsonRequestBehavior.AllowGet);
        }


        [HttpGet]
        public JsonResult ListarIdioma()

        {
            List<Idiomas> oLista = new List<Idiomas>();
            oLista = new CN_Idiomas().Listar();

            return Json(new { data = oLista }, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public JsonResult ListaExp_Laboral()
        {
            List<Ex_Laboral> oLista = new List<Ex_Laboral>();
            oLista = new CN_Ex_Laboral().Listar();

            return Json(new { data = oLista }, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult GuardarPersona(Persona objeto)
        {
            object resultado;
            string mensaje = string.Empty;

            if(objeto.IdPersona == 0)
            {
                resultado = new CN_Persona().RegistrarPerson(objeto, out mensaje);
            }
            else
            {
                resultado = new CN_Persona().EditarPerson(objeto, out mensaje);
            }

            return Json(new { resultado = resultado, mensaje = mensaje }, JsonRequestBehavior.AllowGet);
        }


        [HttpPost]
        public JsonResult GuardarFormacion(Formacion_academica objeto)
        {
            object resultado;
            string mensaje = string.Empty;

            if (objeto.IdFormacionAcademica == 0)
            {
                resultado = new CNF_Academica().RegistrarFormacion(objeto, out mensaje);
            }
            else
            {
                resultado = new CNF_Academica().EditarFormacion(objeto, out mensaje);
            }

            return Json(new { resultado = resultado, mensaje = mensaje }, JsonRequestBehavior.AllowGet);
        }


        [HttpPost]
        public JsonResult GuardarIdioma(Idiomas objeto)
        {
            object resultado;
            string mensaje = string.Empty;
            if (objeto.IdIdiomas == 0)
            {
                resultado = new CN_Idiomas().RegistrarIdioma(objeto, out mensaje);
            }
            else
            {
                resultado = new CN_Idiomas().EditarIdiomas(objeto, out mensaje);
            }

            return Json(new { resultado = resultado, mensaje = mensaje }, JsonRequestBehavior.AllowGet);

        }
        [HttpPost]
        public JsonResult GuardarExp(Ex_Laboral objeto)
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
                resultado = new CN_Ex_Laboral().RegistrarExpLaboral(objeto, out mensaje);
            }
            else
            {
                resultado = new CN_Ex_Laboral().ActualizarExpLaboral(objeto, out mensaje);
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



    }
}