using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using System.Windows.Forms;


namespace CRM_Proyect.Modelo
{
    public class InsertarUsuario
    {
        private int EXITO_DE_INSERCION = 0;
        private int FALLO_DE_INSERCION = -1;
        private int USUARIO_INVALIDO = 1;
        private int CORREO_INVALIDO = 2;

        private MySqlConnection conexion;
        String cadenaDeConexion;


        private void iniciarConexion()
        {
            try
            {
                conexion = new MySqlConnection();
                cadenaDeConexion = ";server=localhost;user id=root;database=crm;password=root";
                conexion.ConnectionString = cadenaDeConexion;
                conexion.Open();

            }
            catch (MySqlException)
            {
                MessageBox.Show("Conexion sin exito");
            }
        }

        private void cerrarConexion()
        {
            conexion.Close();
        }

        public int InsertarUsuarioBD(string nombre, string primerApellido, string segundoApellido, string correo,
                        string direccion, string usuario, string contrasena, string telefono)
        {
            if (validarUsuario(usuario)) {
                return USUARIO_INVALIDO;
            }

            if (validarCorreo(correo))
            {
                return CORREO_INVALIDO;
            }

            iniciarConexion();
            contrasena = Seguridad.encriptar(contrasena);
            MySqlCommand instruccion = conexion.CreateCommand();
            instruccion.CommandText = "call insertarUsuario('" + nombre + "', '" + primerApellido + "', '"+  segundoApellido +
                "', '" + direccion + "', '" +  correo + "', '" +  usuario + "', '" + contrasena + "', '" + telefono +"')";

            // La consulta podría generar errores
            try
            {
                if (instruccion.ExecuteNonQuery() == 1)
                {
                    cerrarConexion();
                    return EXITO_DE_INSERCION;
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Falló la operación " + ex.Message);
            }
            cerrarConexion();
            return FALLO_DE_INSERCION;
        }

        private Boolean validarUsuario(string usuario) {
            iniciarConexion();
            MySqlCommand instruccionVerificarUsuario = conexion.CreateCommand();
            instruccionVerificarUsuario.CommandText = "call validarUsuario('" + usuario + "')";
            // La consulta podría generar errores
            try
            {
                MySqlDataReader reader = instruccionVerificarUsuario.ExecuteReader();
                while (reader.Read())
                {
                    if (reader["nombre"] != null) {
                        return true;
                    }
                    
                }

                reader.Dispose();
                cerrarConexion();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Falló la operación " + ex.Message);
            }
            cerrarConexion();
            return false;
        }

        private Boolean validarCorreo(string correo)
        {
            iniciarConexion();
            MySqlCommand instruccionVerificarUsuario = conexion.CreateCommand();
            instruccionVerificarUsuario.CommandText = "call verificarCorreo('" + correo + "')";
            // La consulta podría generar errores
            try
            {
                MySqlDataReader reader = instruccionVerificarUsuario.ExecuteReader();
                while (reader.Read())
                {
                    if (!reader["Correo"].ToString().Equals(""))
                    {
                        return true;
                    }

                }

                reader.Dispose();
                cerrarConexion();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Falló la operación " + ex.Message);
            }
            cerrarConexion();
            return false;
        }

        public int insertarEmpresa(string nombre,  string correo, string direccion, string telefono)
        {

            if (validarCorreo(correo))
            {
                return CORREO_INVALIDO;
            }

            iniciarConexion();
            MySqlCommand instruccion = conexion.CreateCommand();
            instruccion.CommandText = "call insertarEmpresa('" + nombre + "', '" + direccion + "', '" + correo + "', '"  + telefono + "')";

            // La consulta podría generar errores
            try
            {
                if (instruccion.ExecuteNonQuery() == 1)
                {
                    cerrarConexion();
                    return EXITO_DE_INSERCION;
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Falló la operación " + ex.Message);
            }
            cerrarConexion();
            return FALLO_DE_INSERCION;
        }

    }
}