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
    public class UsuarioController : Controller
    {
        private Usuario usuario = new Usuario();
        private TablaDato dato = new TablaDato();
        
        public ActionResult Index()
        {
            ViewBag.Paises = dato.Listar("pais");
            return View(usuario.Obtener(SessionHelper.GetUser()));
        }

        public JsonResult Guardar(Usuario model, HttpPostedFileBase foto)
        {
            var rm = new ResponseModel();
            ModelState.Remove("Password");
            if (ModelState.IsValid) 
            {
                rm = model.Guardar(foto);
            }

            return Json(rm);
        }
    }
}