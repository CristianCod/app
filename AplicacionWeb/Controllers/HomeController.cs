using AplicacionWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;

namespace AplicacionWeb.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        public ActionResult MiPerfil()
        {
            return View();
        }

        public ActionResult MailContacto()
        {

            return View();
        }

        public ActionResult Catalogo()
        {
            //QUE DISLEXIA, "manger", 10min de ver escrito manager
            ProductosManger manager = new ProductosManger();
            List<Productos> productos = manager.TodosProductos();
            ViewBag.Productos = productos;
            //se llama consultar todos para la lista

            return View();
        }


        //Almacenamiento de catalogo

        [HttpPost]
        public ActionResult Guardar(string nombre, string apellido, string email, string contraseña)
        {
            //Se guardan datos para lista de registrados y confirmacion por email.
            Models.Usuario usuarioNuevo = new Models.Usuario();

            usuarioNuevo.Nombre = nombre;
            usuarioNuevo.Apellido = apellido;
            usuarioNuevo.Email = email;
            usuarioNuevo.Contraseña = contraseña;

            List<Models.Usuario> lista = (List<Models.Usuario>)Session["usuarios"];

            if (lista == null)
            {
                lista = new List<Models.Usuario>();
            }


            lista.Add(usuarioNuevo);
            Session["usuarios"] = lista;

            //Envio de correo

            //Configuracion smtp
            SmtpClient smtp = new SmtpClient();
            smtp.Host = "smtp.gmail.com";
            smtp.Port = 25;
            smtp.EnableSsl = true;
            smtp.UseDefaultCredentials = true;
            //Correo electronico de la pagina


            string correoPag = "cristian.alarcon.tec@gmail.com";
            string contraseñaPag = "2210cristian22";
            smtp.Credentials = new NetworkCredential(correoPag, contraseñaPag);
            //Cuerpo de correo

            MailMessage EmailRegistro = new MailMessage();
            EmailRegistro.From = new MailAddress(correoPag);
            EmailRegistro.To.Add(email);
            EmailRegistro.IsBodyHtml = true;//VERIFICO COMANDO LUEGO
            EmailRegistro.Subject = "Confirmación de Cuenta ";
            EmailRegistro.Body = "Buen Día " + nombre + " " + apellido + " nos comunicamos para confirmar tu Email, recorda que al mismo llegaran las notificaciones de compra y otra información.";
            smtp.Send(EmailRegistro);





            return View();
        }

        //public ActionResult Modal(string Emailusuario, string Contraseñausuario)
        //{


        //}

        public ActionResult Logueo()
        {
            return View();

        }
 
       



    }

}
