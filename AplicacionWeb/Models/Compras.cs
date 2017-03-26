using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AplicacionWeb.Models
{
    public class Compras
    {
        public string TituloCompra { get; set; }
        public long IdCompra { get; set; }
        public long PrecioCompra { get; set; }
        public string EmailCompra { get; set; }

    }

    //public list<Compras> TodasCompras()
    //{
    //    List<Compras> compras = new List<Compras>();


    //}



}