/**
 *	Clase ConsultaProducto
 *	
 *	Version 1.0
 *	
 *	21/10/2017
 *
 *	Jonathan Rodríguez
 *	Melissa Molina Corrales
 *	Edwin Cen Xu
 */

using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using System.Windows.Forms;
using CRM_Proyect.Modelo.ClassTest;

namespace CRM_Proyect.Modelo
{
    /**
    *	Clase que contiene los métodos necesarios para realizar consultas a la base de datos relacionadas con los productos.
    *
    */
    public class ConsultaProducto:IConsultaProducto
    {
        private int EXITO_DE_INSERCION = 0;
        private int FALLO_DE_INSERCION = -1;
        private MySqlConnection conexion;
        String cadenaDeConexion;
        public ConsultaProducto()
        {

        }

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

        public int agregarProducto(String nombre, String descripcion, String precio)
        {
            iniciarConexion();
            MySqlCommand instruccion = conexion.CreateCommand();
            instruccion.CommandText = "call insertarProducto('" + nombre + "', '" + descripcion + "', '" + precio + "')";

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

        public List<Producto> obtenerProductos()
        {
            List<Producto> listaProductos = new List<Producto>();

            iniciarConexion();
            MySqlCommand instruccion = conexion.CreateCommand();
            instruccion.CommandText = "call obtenerProductos()";

            // La consulta podría generar errores
            try
            {
                MySqlDataReader reader = instruccion.ExecuteReader();
                while (reader.Read())
                {
                    listaProductos.Add(new Producto(reader["Nombre"].ToString(), reader["Descripcion"].ToString(), reader["Precio"].ToString(),
                        "<a href='#' onclick='eliminarProducto(" + reader["id"]
                        + ")'><span class='glyphicon glyphicon - remove'></span><span class='glyphicon -class'>Eliminar</span></a>"));
                }

                reader.Dispose();
                cerrarConexion();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Falló la operación " + ex.Message);
            }

            return listaProductos;
        }
        public Boolean borrarProducto(int idProducto)
        {

            iniciarConexion();
            MySqlCommand instruccion = conexion.CreateCommand();
            instruccion.CommandText = "call eliminarProducto(" + idProducto+ ")";

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

        public List<Producto> obtenerProductosDisponibles()
        {
            List<Producto> listaProductos = new List<Producto>();

            iniciarConexion();
            MySqlCommand instruccion = conexion.CreateCommand();
            instruccion.CommandText = "call obtenerProductos()";

            // La consulta podría generar errores
            try
            {
                MySqlDataReader reader = instruccion.ExecuteReader();
                while (reader.Read())
                {
                    listaProductos.Add(new Producto(reader["Nombre"].ToString(), reader["Descripcion"].ToString(), reader["Precio"].ToString(),
                        "<a href='#' onclick='agregarAlCarrito(" + reader["id"]
                        + ")'><span class='glyphicon -class'>Agregar</span></a>"));
                }

                reader.Dispose();
                cerrarConexion();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Falló la operación " + ex.Message);
            }

            return listaProductos;
        }

        public Boolean agregarAlCarrito(int idProducto)
        {

            iniciarConexion();
            MySqlCommand instruccion = conexion.CreateCommand();
            instruccion.CommandText = "call agregarAlCarrito(" + idProducto + ")";

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

        public List<Producto> obtenerProductosCarrito()
        {
            List<Producto> listaProductos = new List<Producto>();

            iniciarConexion();
            MySqlCommand instruccion = conexion.CreateCommand();
            instruccion.CommandText = "call obtenerProductosCarrito()";

            // La consulta podría generar errores
            try
            {
                MySqlDataReader reader = instruccion.ExecuteReader();
                while (reader.Read())
                {
                    listaProductos.Add(new Producto(reader["Nombre"].ToString(), reader["Descripcion"].ToString(), reader["Precio"].ToString(),
                        "<a href='#' onclick='eliminarDelCarrito(" + reader["id"]
                        + ")'><span class='glyphicon -class'>Eliminar</span></a>"));
                }

                reader.Dispose();
                cerrarConexion();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Falló la operación " + ex.Message);
            }

            return listaProductos;
        }

        public Boolean eliminarDelCarrito(int idProducto)
        {

            iniciarConexion();
            MySqlCommand instruccion = conexion.CreateCommand();
            instruccion.CommandText = "call eliminarProductoDelCarrito(" + idProducto + ")";

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
}