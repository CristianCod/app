using AplicacionWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AplicacionWeb.Controllers
{
    public class UsuarioAccionesController : Controller
    {
        [HttpPost]

        public ActionResult LogueoUsuario(string email, string contraseña)
        {
            UsuarioManager manager = new UsuarioManager();
            Usuario usuario = manager.validar(email, contraseña);
            if (usuario!=null)
            {
                Session["UsuarioLogueado"] = usuario;

                TempData["Ingresaste Correctamente"] = "Espera un Segundo";
            }

            else
            {
                TempData["Error al Conectarse"] = "El usuario no existe o los datos no son correctos";
            }

            return RedirectToAction("Index", "Home");
        }

        public ActionResult CerrarSesion()
        {
            Session["UsuarioLogueado"] = null;
            return RedirectToAction("Index", "Home");
        }

    }
}