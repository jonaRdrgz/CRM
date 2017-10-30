/**
 *	Clase ConsultaVenta
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
using System.Linq;
using MySql.Data.MySqlClient;
using System.Windows.Forms;
using CRM_Proyect.Modelo.ClassTest;

namespace CRM_Proyect.Modelo
{

     /**
     *	Clase que contiene los métodos necesarios para realizar consultas a la base de datos relacionadas con las ventas.
     *
     */
    public class ConsultaVenta : IVenta
    {
        private int EXITO_DE_INSERCION = 0;
        private int FALLO_DE_INSERCION = -1;
        const int PRODUCTOS_INSUFICIENTES = -2;
        private MySqlConnection conexion;
        String cadenaDeConexion;
        List<int> indicesCarrito;

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

        public List<Venta> obtenerVentas()
        {
            List<Venta> listaVentas = new List<Venta>();

            iniciarConexion();
            MySqlCommand instruccion = conexion.CreateCommand();
            instruccion.CommandText = "call obtenerVentas()";

            // La consulta podría generar errores
            try
            {
                MySqlDataReader reader = instruccion.ExecuteReader();
                while (reader.Read())
                {
                    listaVentas.Add(new Venta("<a href='#' onclick='verProductosVenta(" + reader["id"] +
                        ")'><span class='glyphicon glyphicon - remove'></span><span class='glyphicon -class'>Productos</span></a>", reader["fecha"].ToString(),
                        reader["Precio"].ToString(),
                        reader["Descuento"].ToString(), reader["Comision"].ToString(), reader["Vendedor"].ToString(),reader["Comprador"].ToString(), ""));
                }
                reader.Dispose();
                cerrarConexion();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Falló la operación " + ex.Message);
            }

            return listaVentas;
        }

        public int crearVenta(String precio, String descuento, String comision, int idComprador)
        {
            if (!verificarNumeroProductosCarrito())
            {
                return PRODUCTOS_INSUFICIENTES;
            }

            iniciarConexion();
            MySqlCommand instruccion = conexion.CreateCommand();
            DateTime fechaHora = DateTime.Now;
            string date = fechaHora.ToString("yyyy-MM-dd H:mm:ss");
            instruccion.CommandText = "call registarVenta('" + precio + "', '" + descuento + "', '"
                + comision + "', '" + date + "', '" + Consulta.idUsuarioActual + "', '" + idComprador + "')";
            int idVenta;

            // La consulta podría generar errores
            try
            {
                MySqlDataReader reader = instruccion.ExecuteReader();
                while (reader.Read())
                {
                    idVenta = (int)reader["idVenta"];
                    reader.Dispose();
                    cerrarConexion();
                    return insertarProductoAVenta(idVenta);
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Falló la operación " + ex.Message);
            }
            cerrarConexion();
            return FALLO_DE_INSERCION;
        }

        public Boolean verificarNumeroProductosCarrito()
        {
            iniciarConexion();
            MySqlCommand instruccionVerificarUsuario = conexion.CreateCommand();
            instruccionVerificarUsuario.CommandText = "call verificarNumeroProductosCarrito()";
            indicesCarrito = new List<int>();

            // La consulta podría generar errores
            try
            {
                MySqlDataReader reader = instruccionVerificarUsuario.ExecuteReader();
                while (reader.Read())
                {
                    indicesCarrito.Add((int)reader["idProducto"]);

                }
                if (indicesCarrito.Count > 0)
                {
                    return true;
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

        public int insertarProductoAVenta(int idVenta)
        {
            for (int i = 0; i < indicesCarrito.Count; i++)
            {
                iniciarConexion();
                MySqlCommand instruccionInsertarProductoPropuesta = conexion.CreateCommand();
                instruccionInsertarProductoPropuesta.CommandText = "call insertarProductosVenta('" + idVenta + "', '" + indicesCarrito.ElementAt(i) + "')";
                try
                {
                    if (instruccionInsertarProductoPropuesta.ExecuteNonQuery() == 1)
                    {


                    }
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show("Falló la operación " + ex.Message);
                    return FALLO_DE_INSERCION;
                }
                cerrarConexion();
            }

            borrarCarrito();
            return EXITO_DE_INSERCION;
        }

        public void borrarCarrito()
        {
            iniciarConexion();
            MySqlCommand instruccionBorrarCarrito = conexion.CreateCommand();
            instruccionBorrarCarrito.CommandText = "call borrarCarrito()";
            try
            {
                if (instruccionBorrarCarrito.ExecuteNonQuery() == 1)
                {


                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Falló la operación " + ex.Message);
            }
            cerrarConexion();

        }

        public List<Producto> verProductosVenta(int idVenta)
        {
            List<Producto> listaProductos = new List<Producto>();

            iniciarConexion();
            MySqlCommand instruccion = conexion.CreateCommand();
            instruccion.CommandText = "call obtenerProductosVenta('" + idVenta + "')";

            // La consulta podría generar errores
            try
            {
                MySqlDataReader reader = instruccion.ExecuteReader();
                while (reader.Read())
                {
                    listaProductos.Add(new Producto(reader["Nombre"].ToString(), reader["Descripcion"].ToString(), reader["Precio"].ToString(),
                        ""));
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
    }
}