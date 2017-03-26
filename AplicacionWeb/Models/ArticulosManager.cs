using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace AplicacionWeb.Models
{
    public class ProductosManager
    {

        public void Agregar(Articulo producto)

        {   //se selecciona bd
            SqlConnection conexion = new SqlConnection(ConfigurationManager.AppSettings["BaseAppSQL"]);

            //SqlConnection conexion = new SqlConnection(ConfigurationManager.AppSettings["BaseAppSQL"]);

            //"server", se puede cargar la info desde xml en web.config. Otra forma de cargar el server sql
            //se abre
            conexion.Open();
            //se escribe la sentencia
            SqlCommand sentencia = conexion.CreateCommand();
            sentencia.CommandText = "insert into Productos (Titulo, Info, Imagen, Precio) VALUES (@Titulo, @Info, @Imagen, @Precio)";
            //se cargan los datos
            sentencia.Parameters.AddWithValue("@Titulo", producto.Titulo);
            sentencia.Parameters.AddWithValue("@Info", producto.Info);
            sentencia.Parameters.AddWithValue("@Imagen", producto.Imagen);
            sentencia.Parameters.AddWithValue("@Precio", producto.Precio);
            //se ejecuta
            sentencia.ExecuteNonQuery();
            //se cierra
            conexion.Close();
        }



        public List<Articulo> ConsultarTodos()
        {
            List<Articulo> productos = new List<Articulo>();

            //BBDD
            SqlConnection conexion = new SqlConnection("Server=CristianNet\\SQLEXPRESS;Database=BaseApp;Trusted_Connection=True;");
            //2-nos conectamos
            conexion.Open();
            //3-creamos el objeto que nos permite escribir la sentencia
            SqlCommand sentencia = conexion.CreateCommand();
            //4-escribrimos la sentencia
            sentencia.CommandText = "SELECT * FROM Articulo";
            //5-ejecutamos la consulta
            SqlDataReader reader = sentencia.ExecuteReader();
            while (reader.Read()) //mientras haya un registro para leer
            {
                //creo el artículo, le completo los datos 
                Articulo producto = new Articulo();
                producto.Titulo = reader["Titulo"].ToString();
                producto.Info = (string)reader["Info"];
                producto.Imagen = reader["Imagen"].ToString();
                //producto.Precio = (int)reader["Precio"];
                //producto.ID = (long)reader["ID"];
                

                productos.Add(producto);
            }

            reader.Close();
            conexion.Close();

            return productos;
        }



    }
}