﻿using CapaEntidad;
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
        public JsonResult ListarRlegales()

        {
            List<Rlegales> oLista = new List<Rlegales>();
            oLista = new CN_Rlegales().Listar();

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
        [HttpGet]
        public JsonResult ListarDatosLaborales()
        {
            List<Datos_Laborales> oLista = new List<Datos_Laborales>();
            oLista = new CN_Laborales().Listar();

            return Json(new { data = oLista }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult ListaCapacitacionesC()
        {
            List<CapacitacionesC> oLista = new List<CapacitacionesC>();
            oLista = new CNCapacitacionesC().Listar();

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
        public JsonResult GuardarDatosLaborales(Datos_Laborales objeto)
        {
            object resultado;
            string mensaje = string.Empty;

            if (objeto.IdDatosLaborales == 0)
            {
                resultado = new CN_Laborales().RegistrarDatosLaborales(objeto, out mensaje);
            }
            else
            {
                resultado = new CN_Laborales().EditarDatosLaborales(objeto, out mensaje);
            }

            return Json(new { resultado = resultado, mensaje = mensaje }, JsonRequestBehavior.AllowGet);
        }


        [HttpPost]
    
        public JsonResult GuardarFormacion(Formacion_academica objeto)
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
                resultado = new CNF_Academica().RegistrarFormacion(objeto, out mensaje);
            }
            else
            {
                resultado = new CNF_Academica().EditarFormacion(objeto, out mensaje);
            }

            //mensaje = nombreArchivo+"_"+resacr;
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

        [HttpPost]
        public JsonResult GuardarCapatacitaciones(CapacitacionesC objeto)
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
                resultado = new CNCapacitacionesC().RegistrarCursos(objeto, out mensaje);
            }
            else
            {
                resultado = new CNCapacitacionesC().EditarCursos(objeto, out mensaje);
            }

            //mensaje = nombreArchivo+"_"+resacr;
            return Json(new { resultado = resultado, mensaje = mensaje }, JsonRequestBehavior.AllowGet);

        }

        public JsonResult GuardarRlegales(Rlegales objeto)
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
                resultado = new CN_Rlegales().RegistrarRlegales(objeto, out mensaje);
            }
            else
            {
                resultado = new CN_Rlegales().EditarRlegales(objeto, out mensaje);
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