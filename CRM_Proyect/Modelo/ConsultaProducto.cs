﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace CRM_Proyect.Modelo
{
    public class ConsultaProducto
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
    }
}