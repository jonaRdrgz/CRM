/**
 *	Clase InsertarUsuario
 *	
 *	Version 1.0
 *	
 *	26/09/2017
 *
 *	Jonathan Rodríguez
 *	Melissa Molina Corrales
 *	Edwin Cen Xu
 */

using System;
using MySql.Data.MySqlClient;
using System.Windows.Forms;
using CRM_Proyect.Modelo;
using CRM_Proyect.Modelo.ClassTest;


/**
*	Clase para hacer la solicitud a la base de datos de los usuarios y empresas .
*/
public class InsertarUsuario : IInsertarUsuario
    {
    	// Constantes de retorno de las consultas
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

        /*	
        	Inserta los datos de un nuevo usuario en la base.

        */
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

        /*
			Valida que el usuario no este regisstrado en la base de datos
        */
        public Boolean validarUsuario(string usuario) {
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

        /*
        	Valida que el correo del usuario no este registrado en la base de datos.
        */
        public Boolean validarCorreo(string correo)
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

        /*
        	Inserta una empresa en la base de datos
        */
        public int insertarEmpresa(string nombre,  string correo, string direccion, string telefono, 
        	string usuario, string contrasena)
        {
            if (validarUsuario(usuario))
            {
                return USUARIO_INVALIDO;
            }

        if (validarCorreo(correo))
            {
                return CORREO_INVALIDO;
            }

            iniciarConexion();
            MySqlCommand instruccion = conexion.CreateCommand();
            contrasena = Seguridad.encriptar(contrasena);   
        	instruccion.CommandText = "call insertarEmpresa('" + nombre + "', '" + direccion + "', '" + correo + "', '"  +
                telefono + "', '" + usuario + "', '" + contrasena + "')";

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
