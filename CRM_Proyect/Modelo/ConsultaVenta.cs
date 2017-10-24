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
using System.Web;
using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace CRM_Proyect.Modelo
{
    public class ConsultaVenta
    {
        private int EXITO_DE_INSERCION = 0;
        private int FALLO_DE_INSERCION = -1;
        const int PRODUCTOS_INSUFICIENTES = -2;
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
                    listaVentas.Add(new Venta("<a href='#' onclick='verProductos(" + reader["id"] +
                        ")'><span class='glyphicon glyphicon - remove'></span><span class='glyphicon -class'>Productos</span></a>", reader["fecha"].ToString(),
                        reader["Precio"].ToString(),
                        reader["Descuento"].ToString(), reader["Comision"].ToString(), reader["Nombre"].ToString(), ""));
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
    }
}