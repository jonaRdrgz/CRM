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
            DateTime fechaHora = DateTime.Now;
            string date = fechaHora.ToString("yyyy-MM-dd H:mm:ss");
            instruccion.CommandText = "call registarPropuestaVenta('" + precio + "', '" + descuento + "', '" 
                + comision + "', '"+ date + "', '" + Consulta.idUsuarioActual + "')";
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

        public List<PropuestasVenta> obtenerPropuestasVenta()
        {
            List<PropuestasVenta> listaPropuestas = new List<PropuestasVenta>();

            iniciarConexion();
            MySqlCommand instruccion = conexion.CreateCommand();
            instruccion.CommandText = "call obtenerPropuestasVenta()";

            // La consulta podría generar errores
            try
            {
                MySqlDataReader reader = instruccion.ExecuteReader();
                while (reader.Read())
                {
                    listaPropuestas.Add(new PropuestasVenta("<a href='#' onclick='verProductos(" + reader["id"] +
                        ")'><span class='glyphicon glyphicon - remove'></span><span class='glyphicon -class'>Productos</span></a>", reader["Precio"].ToString(),
                        reader["Descuento"].ToString(), reader["Comision"].ToString(), reader["fecha"].ToString(), reader["respuesta"].ToString() +" "+
                        "<a href='#' onclick='cambiarRespuesta(" + reader["id"] +
                        ")'><span class='glyphicon -class'>Cambiar</span></a>",
                        "<a href='#' onclick='verComentarios(" + reader["id"] +
                        ")'><span class='glyphicon glyphicon - remove'></span><span class='glyphicon -class'>Ver</span></a>", "<a href='#' onclick='borrarPropuesta(" 
                        + reader["id"] +
                        ")'><span class='glyphicon glyphicon - remove'></span><span class='glyphicon -class'>Borrar</span></a>"));
                }

                reader.Dispose();
                cerrarConexion();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Falló la operación " + ex.Message);
            }

            return listaPropuestas;
        }

        public List<Producto> verProductosPropuesta(int idPropuesta)
        {
            List<Producto> listaProductos = new List<Producto>();

            iniciarConexion();
            MySqlCommand instruccion = conexion.CreateCommand();
            instruccion.CommandText = "call obtenerProductoPropuestasVenta('" + idPropuesta + "')";

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
        public List<PropuestasVenta> obtenerPropuestasVentaCompra()
        {
            List<PropuestasVenta> listaPropuestas = new List<PropuestasVenta>();

            iniciarConexion();
            MySqlCommand instruccion = conexion.CreateCommand();
            instruccion.CommandText = "call obtenerPropuestasVenta()";

            // La consulta podría generar errores
            try
            {
                MySqlDataReader reader = instruccion.ExecuteReader();
                while (reader.Read())
                {
                    listaPropuestas.Add(new PropuestasVenta("<a href='#' onclick='verProductos(" + reader["id"] +
                        ")'><span class='glyphicon glyphicon - remove'></span><span class='glyphicon -class'>Productos</span></a>", reader["Precio"].ToString(),
                        reader["Descuento"].ToString(), reader["Comision"].ToString(), reader["fecha"].ToString(), reader["respuesta"].ToString(),
                        "", "<a href='#' onclick='comprar("
                        + reader["id"] +
                        ")'><span class='glyphicon glyphicon - remove'></span><span class='glyphicon -class'>Comprar</span></a>"));
                }

                reader.Dispose();
                cerrarConexion();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Falló la operación " + ex.Message);
            }

            return listaPropuestas;
        }

        public Boolean comprar(int idPropuesta)
        {

            iniciarConexion();
            MySqlCommand instruccion = conexion.CreateCommand();
            DateTime fechaHora = DateTime.Now;
            string date = fechaHora.ToString("yyyy-MM-dd H:mm:ss");
            instruccion.CommandText = "call comprar('" + date + "', '" + idPropuesta + "', '" + Consulta.idUsuarioActual + "')";

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

        public List<PropuestasVenta> obtenerPropuestasDeVentaUsuario()
        {
            List<PropuestasVenta> listaPropuestas = new List<PropuestasVenta>();

            iniciarConexion();
            MySqlCommand instruccion = conexion.CreateCommand();
            instruccion.CommandText = "call obtenerPropuestasVenta()";

            // La consulta podría generar errores
            try
            {
                MySqlDataReader reader = instruccion.ExecuteReader();
                while (reader.Read())
                {
                    listaPropuestas.Add(new PropuestasVenta("<a href='#' onclick='verProductos(" + reader["id"] +
                        ")'><span class='glyphicon glyphicon - remove'></span><span class='glyphicon -class'>Productos</span></a>", reader["Precio"].ToString(),
                        reader["Descuento"].ToString(), reader["Comision"].ToString(), "","","", "<a href='#' onclick='comentar("
                        + reader["id"] +
                        ")'><span class='glyphicon glyphicon - remove'></span><span class='glyphicon -class'>Comentar</span></a>"));
                }

                reader.Dispose();
                cerrarConexion();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Falló la operación " + ex.Message);
            }

            return listaPropuestas;
        }

        public Boolean comentarPropuesta(int idPropuesta, string comentario)
        {

            iniciarConexion();
            MySqlCommand instruccion = conexion.CreateCommand();
            instruccion.CommandText = "call comentarPropuesta('"  + idPropuesta + "', '" + comentario +
                "', '" + Consulta.idUsuarioActual + "')";

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
        public Boolean cambiarRespuesta(int idPropuesta, string respuesta)
        {

            iniciarConexion();
            MySqlCommand instruccion = conexion.CreateCommand();
            instruccion.CommandText = "call actualizarRespuesta('" + idPropuesta + "', '" + respuesta +"')";

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