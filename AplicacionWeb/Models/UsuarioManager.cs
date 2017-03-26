using System.Configuration;
using AplicacionWeb.Models;
using System.Data.SqlClient;

namespace AplicacionWeb.Models
{
    public class UsuarioManager
    {

        internal Usuario validar(string email, string contraseña)
        {
            
            Usuario usuario = new Models.Usuario();//se crea el objeto en la clase
            //conexion a base de datos 
            SqlConnection conexion = new SqlConnection(ConfigurationManager.AppSettings["BaseAppSQL"]);
            //se abre la conexion
            conexion.Open();
            //creo comando
            SqlCommand sentencia = conexion.CreateCommand();
            //selecciono tabla de sql
            sentencia.CommandText = "SELECT * FROM Usuarios WHERE Email = @email AND Contraseña = @contraseña";
            //agrego parametros
            sentencia.Parameters.AddWithValue("@Email", email);
            sentencia.Parameters.AddWithValue("@Contraseña", contraseña);
            //se lee el comando
            SqlDataReader leer = sentencia.ExecuteReader();
            //se verifica
            if (leer.Read())
            {
                usuario.Nombre = leer["Nombre"].ToString();
                usuario.Email = leer["Email"].ToString();
                usuario.Contraseña = leer["Contraseña"].ToString();

            }

            else
            {
                usuario = null;
            }
            //se cierra
            leer.Close();
            conexion.Close();

            return usuario;
        }



    }
}