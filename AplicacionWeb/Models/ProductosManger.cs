using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace AplicacionWeb.Models
{
    public class ProductosManger
    {
        public List<Productos> TodosProductos()
        {
            List<Productos> productos = new List<Productos>();
            //
            SqlConnection consulta = new SqlConnection(ConfigurationManager.AppSettings["BaseAppSQL"]);
            //
            consulta.Open();
            //
            SqlCommand operacion = consulta.CreateCommand();
            //
            operacion.CommandText = "select * from Productos";
            //
            SqlDataReader leer = operacion.ExecuteReader();
            //
            while (leer.Read())
            {
                Productos producto = new Productos();
                producto.Titulo = leer["Titulo"].ToString();
                producto.Info = leer["Info"].ToString();
                producto.Precio = (int)leer["Precio"];
                producto.ID = (long)leer["Id"];
                producto.Imagen = leer["Imagen"].ToString();

                productos.Add(producto);


            }

            //se cierra
            leer.Close();
            consulta.Close();
            return productos;
            //se devuelve los productos
        }



    }
}