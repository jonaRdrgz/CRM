using MySql.Data.MySqlClient;
using ProyectoQA.Classes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace ProyectoQA
{
    public partial class ProductosRelacionados : System.Web.UI.Page
    {
        private IConexion conexion;
        public ProductosRelacionados()
        {
            //conexion = new Conexion("icampos.me", "mydb", "root", "nT4LZIYR5LYzoHAjAKtw", "32769");
            conexion = new Conexion("localhost", "mydb", "root", "root", "3306");
        }
        public ProductosRelacionados(IConexion pConexion)
        {
            conexion = pConexion;
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            conexion = new Conexion("localhost", "mydb", "root", "root", "3306");
            //conexion = new Conexion("icampos.me", "mydb", "root", "nT4LZIYR5LYzoHAjAKtw", "32769");
        }

        public Boolean consultarProductosRelacionados(String pIdUsuario, HtmlGenericControl etiqueta)
        {
            String productosRelacionados = "";
            try
            {
                conexion.AbrirConexion();
                conexion.setCommandText("call getProductosRelacionados();");
                IDataReader resultadosQuery = conexion.getResultados();
                productosRelacionados = crearVistaProductosRelacionados(resultadosQuery);
                conexion.CerrarConexion();
                GUIBuilder.inyectarHTML(productosRelacionados, etiqueta);
                return true;
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Falló la operación " + ex.Message);
                return false;
            }
        }
        public String crearVistaProductosRelacionados(IDataReader reader)
        {
            String nombre;
            String precio;
            String idProducto;

            String productoRelacionado = "";
            while (reader.Read())
            {
                nombre = reader[1].ToString();
                precio = reader[2].ToString();
                idProducto = reader[0].ToString();
                productoRelacionado += "<tr>" +
                            "<td>" + nombre + "</td>" +
                            "<td>" + precio + "$ </td>";
            }
            return productoRelacionado;
        }
        public void verProductosRelacionados(object sender, EventArgs e)
        {
            String idUsuario = Session["idUsuario"].ToString();

            if (consultarProductosRelacionados(idUsuario, vistaProductosRelacionados))
            {
                Page_Load(sender, e);
            }
            else
            {
                Verificador.mostrarMensaje(Page);
            }
        }
    }
}