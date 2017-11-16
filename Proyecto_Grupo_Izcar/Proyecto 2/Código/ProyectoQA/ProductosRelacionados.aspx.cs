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

namespace ProyectoQA
{
    public partial class ProductosRelacionados : System.Web.UI.Page
    {
        private IConexion conexion;
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        public Boolean consultarPropuestaVenta(String pIdUsuario, HtmlGenericControl etiqueta)
        {
            String propuestaVentas = "";
            try
            {
                //conexion.AbrirConexion();
                //conexion.setCommandText("call getPropuestaVenta('" + pIdUsuario + "');");
                //IDataReader resultadosQuery = conexion.getResultados();
                //propuestaVentas = crearVistaPropuestaVenta(resultadosQuery);
                //conexion.CerrarConexion();
                //GUIBuilder.inyectarHTML(propuestaVentas, etiqueta);
                return true;
            }
            catch (MySqlException ex)
            {

                return false;
            }
        }

        public void verProductosRelacionados(object sender, EventArgs e)
        {
            String idUsuario = Session["idUsuario"].ToString();

            if (consultarPropuestaVenta(idUsuario, vistaProductosRelacionados))
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