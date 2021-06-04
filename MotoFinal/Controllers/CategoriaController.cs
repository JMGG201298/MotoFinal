using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MotoFinal.Contenido.BD;
using MotoFinal.Models;

namespace MotoFinal.Controllers
{
    public class CategoriaController : Controller
    {
        // GET: Categoria
        //Este metodo nos permite obtener una lista de cateogorias con la ayuda de un crud, para despues convertirlo en JSON
        //Y lo retornamos
        public JsonResult ObtenerTodos()
        {
            CrudCategorias crudCategorias = new CrudCategorias();
            List<Categoria> lista = crudCategorias.obtenerTodos();
            return Json(lista, JsonRequestBehavior.AllowGet);
        }

        
    }
}
