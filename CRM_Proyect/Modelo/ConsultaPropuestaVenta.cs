using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using System.Windows.Forms;
namespace CRM_Proyect.Modelo
{
    public class ConsultaPropuestaVenta
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
        public int crearPropuestaVenta(String precio, String descuento, String comision) {
            if (!verificarNumeroProductosCarrito()) {
                return PRODUCTOS_INSUFICIENTES;
            }
           
            iniciarConexion();
            MySqlCommand instruccion = conexion.CreateCommand();
            instruccion.CommandText = "call registarPropuestaVenta('" + precio + "', '" + descuento + "', '" + comision + "', '" + Consulta.idUsuarioActual + "')";
            int idPropuesta;
            // La consulta podría generar errores
            try
            {
                MySqlDataReader reader = instruccion.ExecuteReader();
                while (reader.Read())
                {
                    idPropuesta = (int)reader["idPropuesta"];     
                    reader.Dispose();
                    cerrarConexion();
                    return insertarProductoAPropuesta(idPropuesta);  
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
            indicesCarrito = new List <int>() ;
            // La consulta podría generar errores
            try
            {
                MySqlDataReader reader = instruccionVerificarUsuario.ExecuteReader();
                while (reader.Read())
                {
                    indicesCarrito.Add((int)reader["idProducto"]);                    

                }
                if(indicesCarrito.Count > 0)
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

        public int  insertarProductoAPropuesta(int idPropuesta)
        {
            for (int i = 0; i < indicesCarrito.Count; i++) {
                iniciarConexion();
                MySqlCommand instruccionInsertarProductoPropuesta = conexion.CreateCommand();
                instruccionInsertarProductoPropuesta.CommandText = "call insertarPropuctosPropuesta('" + idPropuesta + "', '" + indicesCarrito.ElementAt(i) + "')";
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
    }
}