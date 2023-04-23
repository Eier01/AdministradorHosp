using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using CapaEntidad;
using CapaNegocio;

namespace CapaPresentacionAdmin.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Procesos()
        {
            return View();
        }
        public ActionResult Actividades()
        {
            return View();
        }
        public ActionResult RequisitosLegales()
        {
            return View();
        }
        public ActionResult RequisitoActividad()
        {
            return View();
        }
        public ActionResult ReporteGeneral()
        {
            return View();
        }
        
       


        //PROCESOS JSONRESULT
        [HttpGet]
        public JsonResult ListarProcesos()
        {
            List<Procesos> oLista = new List<Procesos>();

            oLista = new CN_Procesos().Listar();

            //retornamos esto de esta forma porque DataTable asi lo requiere
            return Json(new {data = oLista}, JsonRequestBehavior.AllowGet);
        }

        
       
    }
}