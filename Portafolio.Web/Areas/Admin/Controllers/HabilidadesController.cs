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
    public class HabilidadesController : Controller
    {
        private Habilidad habilidad = new Habilidad();

        public ActionResult Index()
        {
            ViewBag.Habilidades= habilidad.ObtenerLista(SessionHelper.GetUser());
            return View(habilidad);
        }

        public ActionResult Crud(int id = 0)
        {
            if (id>0)
            {
                habilidad = habilidad.Obtener(id);
            }            
            return View(habilidad);
        }

        public JsonResult Eliminar(int id)
        {
            var rm = new ResponseModel();
            try
            {
                if (ModelState.IsValid)
                {
                    rm = habilidad.Eliminar(id);
                    if (rm.response)
                    {
                        rm.href = "/admin/habilidades/";
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
            return Json(rm);
        }

        public JsonResult Guardar(Habilidad habilid)
        {
            var rm = new ResponseModel();
            try
            {
                if (ModelState.IsValid)
                {
                    rm = habilid.Guardar();
                    if (rm.response)
                    {
                        rm.href = "/admin/habilidades/";
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