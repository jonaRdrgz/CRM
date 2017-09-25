using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using System.Windows.Forms;


public class Consulta
{

    private MySqlConnection conexion;
    String cadenaDeConexion;

    public Consulta() {
        

    } 

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

    public Boolean validarUsuario(string usuario, string contrasena) {
        iniciarConexion();
        MySqlCommand instruccion = conexion.CreateCommand();
        string usuarioDB = null;
        string contrasenaDb = null;
        instruccion.CommandText = "call obtenerDatosUsuario()";

        try
        {
            MySqlDataReader reader = instruccion.ExecuteReader();
            while (reader.Read())
            {
                usuarioDB = reader["Nombre"].ToString();
                contrasenaDb = reader["Contraseña"].ToString();
            }
            if (usuarioDB != null && contrasenaDb != null)
            {
                if (usuarioDB.Equals(usuario) && contrasenaDb.Equals(contrasena))
                {
                    reader.Dispose();
                    return true;
                }
            }
            reader.Dispose();
            cerrarConexion();
        }
        catch (MySqlException) {

        }

        cerrarConexion();
        return false;

    }
}