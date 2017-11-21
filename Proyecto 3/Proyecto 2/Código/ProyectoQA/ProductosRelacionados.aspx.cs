using ProyectoQA.Classes;
using System;
using System.Data;
using System.Web.UI.HtmlControls;


namespace ProyectoQA
{
    public partial class ProductosRelacionados : System.Web.UI.Page
    {
        private IConexion conexion;
        public ProductosRelacionados()
        {
            
            conexion = new Conexion("localhost", "mydb", "root", "root", "3306");
        }
        public ProductosRelacionados(IConexion pConexion)
        {
            conexion = pConexion;
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            conexion = new Conexion("localhost", "mydb", "root", "root", "3306");
           
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
            catch 
            {
                return false;
            }
        }

        public String crearVistaProductosRelacionados(IDataReader reader)
        {
            
            String productoRelacionado = "";
            int contador = 0;

            while (reader.Read())
            {
                if (contador % 4 == 0)
                {
                    productoRelacionado += "<div class = 'row'>";
                }
                productoRelacionado += "<div class='col-lg-3'>" +
                                       "<div class='hpanel hyellow contact-panel'>" +
                                           "<div class='panel-body'>" +
                                              
                                              "<div class='text-muted font-bold m-b-xs'>Nombre: " + reader[1].ToString() + "</div>" +
                                              "<div class='text-muted font-bold m-b-xs'>Precio: $" + reader[2].ToString() + "</div>" +
                                           
                                          "</div>" +
                                       "</div>" +
                                   "</div>";
                if (contador % 4 == 3)
                {
                    productoRelacionado += "</div>";
                }
                contador++;
            }
            return productoRelacionado;
        }

        public void verProductosRelacionados(object sender, EventArgs e)
        {
            String idUsuario = Session["idUsuario"].ToString();

            if (consultarProductosRelacionados(idUsuario,vistaProductosRelacionados))
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