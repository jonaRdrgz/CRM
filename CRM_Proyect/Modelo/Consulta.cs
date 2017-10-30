/**
 *	Clase Consulta
 *	
 *	Version 1.0
 *	
 *	24/09/2017
 *
 *	Jonathan Rodríguez
 *	Melissa Molina Corrales
 *	Edwin Cen Xu
 */

using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using System.Windows.Forms;
using CRM_Proyect.Modelo;

   /**
   *	Clase que contiene los métodos necesarios para el manejo de usuarios y empresas cuando se realiza alguna consulta en la base de datos.
   *
   */
public class Consulta: IConsulta

{
    private MySqlConnection conexion;
    String cadenaDeConexion; 
    public static int idUsuarioActual ;
    public  int tipoCuenta;
    private Boolean session = false;
    public Consulta() {
        
    }
    public int getIdUsuarioActual()
    {
        return idUsuarioActual;
    }

    public void setIdUsuarioActual(int nuevoId) {
        idUsuarioActual = nuevoId;
    }

    public int getTipoCuenta() {
        return tipoCuenta;
    }

    public Boolean getSession()
    {
        return session;
    }
    public void setSessionFalse()
    {
        session = false;
    }

    private void iniciarConexion() {
        try
        {
            conexion = new MySqlConnection();
            cadenaDeConexion = ";server=localhost;user id=root;database=crm;password=root";
            conexion.ConnectionString = cadenaDeConexion;
            conexion.Open();
            
        }
        catch (MySqlException ex) {
            MessageBox.Show("Conexion sin exito" + ex.Message);
        }
    }
    private void cerrarConexion() {
        conexion.Close();
    }

    public Boolean validarUsuario(string usuario, string contrasena) {
        iniciarConexion();
        MySqlCommand instruccion = conexion.CreateCommand();
        string contrasenaDb = null;
        instruccion.CommandText = "call obtenerContrasena('" + usuario + "')";
   
        try {
            MySqlDataReader reader = instruccion.ExecuteReader();
            while (reader.Read())
            {
                contrasenaDb = reader["contraseña"].ToString();
                if (contrasenaDb != null)
                {
                    contrasenaDb = Seguridad.desEncriptar(contrasenaDb);
                    if (contrasenaDb.Equals(contrasena))
                    {
                        tipoCuenta = (int)reader["tipoCuenta"];
                        idUsuarioActual = (int)reader["idusuario"];
                        reader.Dispose();
                        cerrarConexion();
                        session = true;
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

    public List<Usuario> obtenerContactoPersonas() {
        List<Usuario> listaUsuarios = new List<Usuario>();

        iniciarConexion();
        MySqlCommand instruccion = conexion.CreateCommand();
        instruccion.CommandText = "call obtenerContactosPersonas("+ idUsuarioActual +")";

        // La consulta podría generar errores
        try
        {
            MySqlDataReader reader = instruccion.ExecuteReader();
            while (reader.Read())
            {
                listaUsuarios.Add(new Usuario(reader["Nombre"].ToString(), reader["Primer_Apellido"].ToString(),
                    reader["Segundo_Apellido"].ToString(), reader["Direccion"].ToString(), reader["correo"].ToString(),
                    reader["Telefono"].ToString(),
                    "<a href='#' onclick='borrarContacto(" + reader["id"] +
                    ")'><span class='glyphicon glyphicon - remove'></span><span class='glyphicon -class'>Borrar</span></a>"));
            }

            reader.Dispose();
            cerrarConexion();
        }
        catch (MySqlException ex)
        {
            MessageBox.Show("Falló la operación " + ex.Message);
        }

        return listaUsuarios;
    }

    public List<Empresa> obtenerContactoEmpresas()
    {
        List<Empresa> listaEmpresas = new List<Empresa>();
        iniciarConexion();
        MySqlCommand instruccion = conexion.CreateCommand();
        instruccion.CommandText = "call obtenerContactosEmpresas("+ idUsuarioActual +")";

        // La consulta podría generar errores
        try
        {
            MySqlDataReader reader = instruccion.ExecuteReader();
            while (reader.Read())
            {
                listaEmpresas.Add(new Empresa((int)reader["id"],reader["Nombre"].ToString(),  reader["Direccion"].ToString(), reader["correo"].ToString(),
                    reader["Telefono"].ToString(),
                    "<a href='#' onclick='borrarContactoEmpresa(" + reader["id"]
                    + ")'><span class='glyphicon glyphicon - remove'></span><span class='glyphicon -class'>Borrar</span></a>"));

            }

            reader.Dispose();
            cerrarConexion();
        }
        catch (MySqlException ex)
        {
            MessageBox.Show("Falló la operación " + ex.Message);
        }

        return listaEmpresas;
    }

    public List<Usuario> obtenerPersonas()
    {
        List<Usuario> listaUsuarios = new List<Usuario>();

        iniciarConexion();
        MySqlCommand instruccion = conexion.CreateCommand();
        instruccion.CommandText = "call obtenerPersonas(" + idUsuarioActual + ")";

        // La consulta podría generar errores
        try
        {
            MySqlDataReader reader = instruccion.ExecuteReader();
            while (reader.Read())
            {
                listaUsuarios.Add(new Usuario(reader["Nombre"].ToString(), reader["Primer_Apellido"].ToString(),
                    reader["Segundo_Apellido"].ToString(), reader["Direccion"].ToString(), reader["correo"].ToString(),
                    reader["Telefono"].ToString(),
                    "<a href='#' onclick='agregarContacto(" + reader["id"] +
                    ")'><span class='glyphicon glyphicon - remove'></span><span class='glyphicon -class'>Agregar</span></a>"));
            }

            reader.Dispose();
            cerrarConexion();
        }
        catch (MySqlException ex)
        {
            MessageBox.Show("Falló la operación " + ex.Message);
        }

        return listaUsuarios;
    }

    

    public Boolean registarContactoPersona(int idPersona)
    {
        iniciarConexion();
        MySqlCommand instruccion = conexion.CreateCommand();
        instruccion.CommandText = "call registarContactoPersona(" + idUsuarioActual + ", "+ idPersona + ")";
         
        // La consulta podría generar errores
        try
        {
            if (instruccion.ExecuteNonQuery() == 1) {
                cerrarConexion();
                return true;
            }
        }
        catch (MySqlException ex)
        {
            MessageBox.Show("Falló la operación " + ex.Message);
        }
        cerrarConexion();
        return false;
    }

    public Boolean borrarContacto(int idPersona)
    {

        iniciarConexion();
        MySqlCommand instruccion = conexion.CreateCommand();
        instruccion.CommandText = "call borrarContacto(" + idUsuarioActual + ", " + idPersona + ")";

        // La consulta podría generar errores
        try
        {
            if (instruccion.ExecuteNonQuery() == 1)
            {
                cerrarConexion();
                return true;
            }
        }
        catch (MySqlException ex)
        {
            MessageBox.Show("Falló la operación " + ex.Message);
        }
        cerrarConexion();
        return false;
    }

    public List<Empresa> obtenerEmpresas()
    {
        List<Empresa> listaEmpresas = new List<Empresa>();

        iniciarConexion();
        MySqlCommand instruccion = conexion.CreateCommand();
        instruccion.CommandText = "call obtenerEmpresasLibres(" + idUsuarioActual + ")";

        // La consulta podría generar errores
        try
        {
            MySqlDataReader reader = instruccion.ExecuteReader();
            while (reader.Read())
            {
                listaEmpresas.Add(new Empresa((int)reader["id"], reader["Nombre"].ToString(), reader["Direccion"].ToString(), reader["correo"].ToString(),
                    reader["Telefono"].ToString(),
                    "<a href='#' onclick='agregarContactoEmpresa(" + reader["id"]
                    + ")'><span class='glyphicon glyphicon - remove'></span><span class='glyphicon -class'>Agregar</span></a>"));
            }

            reader.Dispose();
            cerrarConexion();
        }
        catch (MySqlException ex)
        {
            MessageBox.Show("Falló la operación " + ex.Message);
        }

        return listaEmpresas;
    }

    public Boolean registarContactoEmpresa(int idEmpresa)
    {

        iniciarConexion();
        MySqlCommand instruccion = conexion.CreateCommand();
        instruccion.CommandText = "call registarContactoEmpresa(" + idUsuarioActual + ", " + idEmpresa + ")";

        // La consulta podría generar errores
        try
        {
            if (instruccion.ExecuteNonQuery() == 1)
            {
                cerrarConexion();
                return true;
            }
        }
        catch (MySqlException ex)
        {
            MessageBox.Show("Falló la operación " + ex.Message);
        }
        cerrarConexion();
        return false;
    }


    public Boolean borrarContactoEmpresa(int idEmpresa)
    {

        iniciarConexion();
        MySqlCommand instruccion = conexion.CreateCommand();
        instruccion.CommandText = "call borrarContactoEmpresa(" + idUsuarioActual + ", " + idEmpresa + ")";

        // La consulta podría generar errores
        try
        {
            if (instruccion.ExecuteNonQuery() == 1)
            {
                cerrarConexion();
                return true;
            }
        }
        catch (MySqlException ex)
        {
            MessageBox.Show("Falló la operación " + ex.Message);
        }
        cerrarConexion();
        return false;
    }
}
