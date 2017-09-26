using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using System.Windows.Forms;



public class Consulta
{
	//Valores para inicial la conexion
    private MySqlConnection conexion;
    String cadenaDeConexion;

    public Consulta() {
        
    } 

    //Crea la conexion
    private void iniciarConexion() {
        try
        {
            conexion = new MySqlConnection();
            cadenaDeConexion = ";server=localhost;user id=root;database=crm;password=root";
            conexion.ConnectionString = cadenaDeConexion;
            conexion.Open();
            
        }
        catch (MySqlException) {
            MessageBox.Show("Conexion sin exito");
        }
    }
    private void cerrarConexion() {
        conexion.Close();
    }

    //Primero tiene que iniciar una conexion y despues empieza a crear el query
    //Luego verifica si los datos son validos y se entra sesion
    //de lo contrario no entra y muestra mensaje de error.
    public Boolean validarUsuario(string usuario, string contrasena) {
        iniciarConexion();
        MySqlCommand instruccion = conexion.CreateCommand();
        string contrasenaDb = null;
        instruccion.CommandText = "call obtenerContrasena('" + usuario + "')";

        try {
            MySqlDataReader reader = instruccion.ExecuteReader();
            while (reader.Read())
            {
                contrasenaDb = reader["Contraseña"].ToString();
                if (contrasenaDb != null)
                {
                    if (contrasenaDb.Equals(contrasena))
                    {
                        reader.Dispose();
                        cerrarConexion();
                        return true;
                    }
                }
            }

            reader.Dispose();
            cerrarConexion();
        }
        catch (MySqlException ex) {
            MessageBox.Show("Falló la operación " + ex.Message);
        }
        return false;
    }

    //Esta funcion obtiene la informacion de los contactos
    public string  obtenerContactoPersonas() {
        string nick = "";
        string nombre = "";
        string direccion = "";
        string correo = "";
        string telefono = "";
        string empresa = "";
        string result = "";
        iniciarConexion();
        MySqlCommand instruccion = conexion.CreateCommand();
        instruccion.CommandText = "call obtenerContactosPersonas()";

        // La consulta podría generar errores
        try
        {
            MySqlDataReader reader = instruccion.ExecuteReader();
            while (reader.Read())
            {
                nick = reader["Nick"].ToString();
                nombre = reader["Nombre"].ToString() + reader["Primer_Apellido"].ToString()
                        + reader["Segundo_Apellido"].ToString();
                direccion = reader["Direccion"].ToString();
                correo = reader["correo"].ToString();
                telefono = reader["Telefono"].ToString();
                empresa = reader["Empresa"].ToString();
                result += codigoContactos(nick, nombre, empresa, correo, direccion,telefono);

            }

            reader.Dispose();
            cerrarConexion();
        }
        catch (MySqlException ex)
        {
            MessageBox.Show("Falló la operación " + ex.Message);
        }

        return result;
    }

    public string obtenerContactoEmpresas()
    {
        string nombre = "";
        string direccion = "";
        string correo = "";
        string telefono = "";
        string result = "";
        iniciarConexion();
        MySqlCommand instruccion = conexion.CreateCommand();
        instruccion.CommandText = "call obtenerContactosEmpresas()";

        // La consulta podría generar errores
        try
        {
            MySqlDataReader reader = instruccion.ExecuteReader();
            while (reader.Read())
            {
                nombre = reader["Nombre"].ToString();
                direccion = reader["Direccion"].ToString();
                correo = reader["Correo"].ToString();
                telefono = reader["Telefono"].ToString();

                result += codigoEmpresas(nombre, correo, direccion, telefono);

            }

            reader.Dispose();
            cerrarConexion();
        }
        catch (MySqlException ex)
        {
            MessageBox.Show("Falló la operación " + ex.Message);
        }

        return result;
    }

    //Esta funcion es para agregar los contactos a la pagina
    public string codigoContactos(string nick, string nombre, string empresa, string correo, string direccion, string telefono)
    {
        string codigoParaContacto = "<div class='col-md-6'>"
            + "<div class='box box-primary'>"
            + "<div class='box-body box-profile'>"
            + "<img class='profile-user-img img-responsive img-circle' src = '../../dist/img/user4-128x128.jpg' alt='User profile picture'>"
            + "<h3 class='profile-username text-center'>" + nick + "</h3>"

            + "<p class='text-muted text-center'>" + nombre + "</p>"

            + "<ul class='list-group list-group-unbordered'>"
            + "<li class='list-group-item'>"
            + "<b>Empresa</b> <a class='pull-right'>" + empresa + "</a>"
            + "</li>"
            + "<li class='list-group-item'>"
            + "<b>Correo</b> <a class='pull-right'>" + correo + "</a>"
            + "</li>"
            + "<b>Teléfono</b> <a class='pull-right'>" + telefono + "</a>"
            + "</li>"
            + "<li class='list-group-item'>"
            + "<b>Dirección</b> <a class='pull-right'>" + direccion + "</a>"
            + "</li>"
            + "</ul>"

            + "<a href = '#' class='btn btn-primary btn-block'><b>Follow</b></a>"
            + "</div>"
            + "</div>";

        return codigoParaContacto;
        
    }

    //Esta funcion es para agregar las empresas a la pagina
    public string codigoEmpresas(string nombre, string correo, string direccion, string telefono)
    {
        string codigoParaContacto = "<div class='col-md-6'>"
            + "<div class='box box-primary'>"
            + "<div class='box-body box-profile'>"
            + "<img class='profile-user-img img-responsive img-circle' src = '../../dist/img/user4-128x128.jpg' alt='User profile picture'>"
            + "<h3 class='profile-username text-center'>" + nombre + "</h3>"

            + "<p class='text-muted text-center'>" + direccion + "</p>"

            + "<ul class='list-group list-group-unbordered'>"
            + "<li class='list-group-item'>"
            + "<b>Correo</b> <a class='pull-right'>" + correo + "</a>"
            + "</li>"
            + "<li class='list-group-item'>"
            + "<b>Teléfono</b> <a class='pull-right'>" + telefono + "</a>"
            + "</li>"
            + "</ul>"

            + "<a href = '#' class='btn btn-primary btn-block'><b>Follow</b></a>"
            + "</div>"
            + "</div>";

        return codigoParaContacto;

    }
}
