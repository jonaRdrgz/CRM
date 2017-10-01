﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using System.Windows.Forms;
using CRM_Proyect.Modelo;
using System.Web.SessionState;

using System.Web.UI;
using System.Web.UI.WebControls;


public class Consulta

{

    private MySqlConnection conexion;
    String cadenaDeConexion;
    public int idUsuarioActual ;
    private Boolean session = false;
    public Consulta() {
        
    }

    public Boolean getSession()
    {
        return session;
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
        string contrasenaDb = null;
        instruccion.CommandText = "call obtenerContrasena('" + usuario + "')";

        try {
            MySqlDataReader reader = instruccion.ExecuteReader();
            while (reader.Read())
            {
                contrasenaDb = reader["Contraseña"].ToString();
                idUsuarioActual = (int) reader["idUsuario"];
                if (contrasenaDb != null)
                {
                    if (contrasenaDb.Equals(contrasena))
                    {
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
                listaEmpresas.Add(new Empresa(reader["Nombre"].ToString(),  reader["Direccion"].ToString(), reader["correo"].ToString(),
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
                listaEmpresas.Add(new Empresa(reader["Nombre"].ToString(), reader["Direccion"].ToString(), reader["correo"].ToString(),
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
