using System;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Data;
using ProyectoQA.Classes;
using System.Windows.Forms;

namespace ProyectoQA
{
    public partial class ReportesErroresVendedor : System.Web.UI.Page
    {
       
            private IConexion conexion;

            public ReportesErroresVendedor()
            {
                //conexion = new Conexion("icampos.me", "mydb", "root", "nT4LZIYR5LYzoHAjAKtw", "32769");
                conexion = new Conexion("localhost", "mydb", "root", "root", "3306");
            }

            public ReportesErroresVendedor(IConexion pConexion)
            {
                conexion = pConexion;
            }

            protected void Page_Load(object sender, EventArgs e)
            {
                //conexion = new Conexion("localhost", "mydb", "root", "", "3306");
                //conexion = new Conexion("icampos.me", "mydb", "root", "nT4LZIYR5LYzoHAjAKtw", "32769");
                //popularProductos();
            }

       

        //Vista (Probado)
        public Boolean consultarReportesVendedor(String pIdUsuario, HtmlGenericControl etiqueta)
            {
                String reportes = "";
                try
                {
                    conexion.AbrirConexion();
                    conexion.setCommandText("call getReportesErroresVendedores('" + pIdUsuario + "');");
                    IDataReader resultadosQuery = conexion.getResultados();
                    reportes = crearVistaReporteErrorVendedores(resultadosQuery);
                    conexion.CerrarConexion();
                    GUIBuilder.inyectarHTML(reportes, etiqueta);
                    return true;
                }
                catch (MySqlException ex)

                {
                    MessageBox.Show("Falló la operación " + ex.Message);
                    return false;
                }
            }
            public string crearVistaReporteErrorVendedores(IDataReader reader)
            {
                String nombreProducto;
                String descripcion;
                String fecha;
                String cliente;
               
                String estado;
                String diagnostico;
                String idReporte;

            String reporte = "";
                while (reader.Read())
                {
                    nombreProducto = reader[0].ToString();
                    descripcion = reader[1].ToString();
                    fecha = reader[2].ToString();
                    cliente = reader[3].ToString();
                    estado = reader[4].ToString();
                    diagnostico = reader[5].ToString();
                    idReporte = reader[6].ToString();


                reporte += "<tr>" +
                                    "<td>" + nombreProducto + "</td>" +
                                    "<td>" + descripcion + "</td>" +
                                    "<td>" + fecha + "</td>" +
                                    "<td>" + cliente + "</td>" +
                                    "<td>" + estado + "</td>" +
                                    "<td>" + diagnostico + "</td>" +
                                    "<td>" + "<a href='RegistrarEstadoReportes.aspx?idReporte=" + idReporte + "'>Editar estado del reporte</a>" + "</td>" +
                                "</tr>";
                }
                return reporte;


            }
            public void verReporteErroresVendedor(object sender, EventArgs e)
            {
                String idUsuario = Session["idUsuario"].ToString();

                if (consultarReportesVendedor(idUsuario, vistaReporteErroresVendedor))
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
