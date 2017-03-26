using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AplicacionWeb.Controllers
{
    public class ArticulosController : Controller
    {
        [HttpPost]
        public ActionResult GuardarProducto(int id, string titulo, string imagen, string info, long precio)
        {
            Models.Articulo nuevoProducto = new Models.Articulo();
            
            nuevoProducto.Titulo = titulo;
            nuevoProducto.Imagen = imagen;
            nuevoProducto.Info = info;
            nuevoProducto.ID = id;
            nuevoProducto.Precio = precio;

            Models.ProductosManager accion = new Models.ProductosManager();
            accion.Agregar(nuevoProducto);

            return RedirectToAction("Catalogo", "Home");

          
        }
    }
}
