using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MySql.Data.MySqlClient;
using MotoFinal.Models;
using MotoFinal.Contenido.BD;

namespace MotoFinal.Controllers
{
    public class EstablecimientoController : Controller
    {
        public JsonResult obtenerTodos() {
            CrudEstablecimiento crudEstablecimiento = new CrudEstablecimiento();
            List<Establecimiento> lista = crudEstablecimiento.obtenerTodos();
            return Json(lista, JsonRequestBehavior.AllowGet);
        }

        public ActionResult guardar(Establecimiento establecimiento) {
            establecimiento.nombre = Request.Form["txtNombreNegocio"];
            establecimiento.paginaWeb = Request.Form["txtPaginaWeb"];
            if (ModelState.IsValid)
            {
                return View();
            }
            else
            {
                return View("~/Views/Inicio/RegistrarNegocio.cshtml");
            }
        }
    }
}
