using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MotoFinal.Models;
using System.IO;
using MotoFinal.Contenido.BD;

namespace MotoFinal.Controllers
{
    public class InicioController : Controller
    {
        // GET: Inicio
        /*public ActionResult Productos(string idEstablecimiento) {
            CrudSubcategorias crudSubcategorias = new CrudSubcategorias();
            CrudProducto crudProducto = new CrudProducto();
            ModeloProducto modeloProducto = new ModeloProducto();
            List<Producto> listaProductos = crudProducto.obtenerProductosPorEstablecimiento(idEstablecimiento);
            List<Subcategorias> listaSubcategorias = crudSubcategorias.obtenerPorEstablecimiento(idEstablecimiento);
            modeloProducto.listaProductos = listaProductos;
            modeloProducto.listaSubcategorias = listaSubcategorias;
            return View(modeloProducto);
        }*/
        public ActionResult Productos(string idEstablecimiento, string subcategoria)
        {
            CrudSubcategorias crudSubcategorias = new CrudSubcategorias();
            CrudProducto crudProducto = new CrudProducto();
            ModeloProducto modeloProducto = new ModeloProducto();
            List<Producto> listaProductos;
            if (subcategoria == "0")
            {
                 listaProductos= crudProducto.obtenerProductosPorEstablecimiento(idEstablecimiento);
            }
            else {
                 listaProductos = crudProducto.obtenerProductosPorSubCategorias(subcategoria);
            }
            List<Subcategorias> listaSubcategorias = crudSubcategorias.obtenerPorEstablecimiento(idEstablecimiento);
            modeloProducto.listaProductos = listaProductos;
            modeloProducto.listaSubcategorias = listaSubcategorias;
            return View(modeloProducto);
        }
        public ActionResult BrowserTienda(string idEstablecimiento) {
            var establecimiento = new Establecimiento();
            establecimiento.idEstablecimiento = int.Parse(idEstablecimiento);
            return View(establecimiento);
        }
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult RegistrarNegocio() {
            ModeloEstablecimiento modeloEstablecimiento = new ModeloEstablecimiento();
            modeloEstablecimiento.establecimiento = new Establecimiento();
            modeloEstablecimiento.usuario = new Usuario();
            modeloEstablecimiento.domicilio = new Domicilio();
            return View(modeloEstablecimiento);
        }

        [HttpPost]
        public ActionResult RegistrarNegocio(ModeloEstablecimiento modeloEstablecimiento,HttpPostedFileBase txtFotoPerfil, HttpPostedFileBase txtFotoPortada) {
            if(txtFotoPerfil!=null)
            modeloEstablecimiento.establecimiento.fotoPerfil = convertirABytes(txtFotoPerfil);
            if(txtFotoPortada!=null)
            modeloEstablecimiento.establecimiento.fotoPortada = convertirABytes(txtFotoPortada);
            
            if (ModelState.IsValid)
            {
                string id=Request.Form["cbCategoria"];
                CrudEstablecimiento crudEstablecimiento = new CrudEstablecimiento();
                crudEstablecimiento.insertar(modeloEstablecimiento.usuario, modeloEstablecimiento.establecimiento, modeloEstablecimiento.domicilio, id);
                return Redirect("~/Inicio/Index");
            }
            else {
                return View(modeloEstablecimiento);
            }
        }
        public ActionResult NegocioGuardado() {
            return View();
        }

        public ActionResult IniciarSesion() {
            return View();
        }
        public ActionResult Tiendas(string categoria) {
            CrudEstablecimiento crudEstablecimiento = new CrudEstablecimiento();
            List<Establecimiento> lista;
            if (categoria == "0")
                lista = crudEstablecimiento.obtenerTodos();
            else
                lista = crudEstablecimiento.obtenerEstablecimientosPorCategoria(categoria);

            return View(lista);
        }
        public ActionResult Registrar() {
            Usuario usuario = new Usuario();
            return View(usuario);
        }
        [HttpPost]
        public ActionResult Registrar(string seleccion, Usuario usuario, Cliente cliente, Repartidor repartidor){
            if (seleccion == "cliente"){
                ViewBag.selec = "C";
            }
            else if (seleccion == "repartidor") {
                ViewBag.selec = "R";
            }
            if (ModelState.IsValid)
            {
                return Redirect("~/Inicio/Index");
            }
            else {
                return View(usuario);
            }
        }
        public byte[] convertirABytes(HttpPostedFileBase postedFileBase) {
            var lenght = postedFileBase.ContentLength;
            byte[] data = null;
            using (var binaryReader = new BinaryReader(postedFileBase.InputStream))
            {
                data = binaryReader.ReadBytes(postedFileBase.ContentLength);
            }
            return data;
        }
    }
}
