using Portafolio.Helper;
using Portafolio.Modelo;
using Portafolio.Web.Areas.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Portafolio.Web.Areas.Admin.Controllers
{
    [Autenticado]
    public class ExperienciaController : Controller
    {

        private Experiencia experiencia = new Experiencia();
        // GET: Admin/Experiencia
        public ActionResult Index(byte tipo=1)
        {
            ViewBag.Tipo = tipo;
            ViewBag.Title = tipo == 1 ? "Trabajos Realizados" : "Estudios Previos";
            ViewBag.Experiencias = experiencia.ObtenerLista(tipo, SessionHelper.GetUser());
            return View();

        }

        public ActionResult Crud(byte tipo, int id = 0)
        {
            if (id == 0)
            {
                experiencia.Tipo = tipo;
            }
            else
            {
                experiencia = experiencia.Obtener(id);
            }
            return View(experiencia);
        }

        public JsonResult Eliminar(byte tipo, int id)
        {
            var rm = new ResponseModel();
            try
            {
                if (ModelState.IsValid)
                {
                    rm = experiencia.Eliminar(id);
                    if (rm.response)
                    {
                        rm.href = "/admin/experiencia/?tipo=" + tipo;
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
            return Json(rm);
        }

        public JsonResult Guardar(Experiencia exper)
        {
            var rm = new ResponseModel();
            try
            {
                if (ModelState.IsValid)
                {
                    rm = exper.Guardar();
                    if (rm.response)
                    {
                        rm.href = "/admin/experiencia/?tipo=" + exper.Tipo;
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
            return Json(rm);
        }



    }
}