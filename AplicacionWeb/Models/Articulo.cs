using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AplicacionWeb.Models
{
    public class Articulo
    {
        public long ID { get; set; }
        public string Titulo { get; set; }
        public string Info { get; set; }
        public string Imagen { get; set; }
        public long Precio { get; set; }



    }
}