using CapaEntidad;
using CapaNegocio;
using System;
using System.Collections;
using System.Collections.Generic;
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
            if (objeto.IdExperienciaLaboral == 0)
            {
                resultado = new CN_Ex_Laboral().RegistrarExpLaboral(objeto, out mensaje);
            }
            else
            {
                resultado = new CN_Ex_Laboral().ActualizarExpLaboral(objeto, out mensaje);
            }

            return Json(new { resultado = resultado, mensaje = mensaje }, JsonRequestBehavior.AllowGet);

        }



    }
}