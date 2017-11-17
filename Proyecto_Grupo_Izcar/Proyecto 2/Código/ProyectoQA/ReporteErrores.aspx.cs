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
    public partial class ReporteErrores : System.Web.UI.Page
    {
        private IConexion conexion;

        public ReporteErrores()
        {
            //conexion = new Conexion("icampos.me", "mydb", "root", "nT4LZIYR5LYzoHAjAKtw", "32769");
            conexion = new Conexion("localhost", "mydb", "root", "root", "3306");
        }

        public ReporteErrores(IConexion pConexion)
        {
            conexion = pConexion;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            //conexion = new Conexion("localhost", "mydb", "root", "", "3306");
            //conexion = new Conexion("icampos.me", "mydb", "root", "nT4LZIYR5LYzoHAjAKtw", "32769");
            //popularProductos();
        }

        //Registro (Probado)
        public Boolean verificarDatosReporte(String pIdProducto, String pDescripcion, String pFecha, String pCorreo)
        {
            if (String.IsNullOrEmpty(pIdProducto))
            {
                Verificador.mostrarMensaje("Producto inválido", Page);
                return false;
            }

            else if (String.IsNullOrEmpty(pDescripcion))
            {
                Verificador.mostrarMensaje("Descripción inválida, no puede estar vacía", Page);
                return false;
            }
            else if (String.IsNullOrEmpty(pCorreo))
            {
                Verificador.mostrarMensaje("Correo inválido, no puede estar vacío", Page);
                return false;
            }
            else if (String.IsNullOrEmpty(pFecha))
            {
                Verificador.mostrarMensaje("Fecha inválida", Page);
                return false;
            }
            else
            {
                return true;
            }
        }
        public Boolean insertarReporteError(String pIdProducto, String pDescripcion, String pFecha, String pCorreo, String pIdCliente)
        {
            try
            {
                conexion.AbrirConexion();
                conexion.setCommandText("call insertReporteError('" + pDescripcion + "','" + pFecha + "','" + pIdProducto + "','" + pIdCliente + "','" + pCorreo + "');");         
                conexion.getResultados();
                conexion.CerrarConexion();
                return true;
            }
            catch(MySqlException ex)
            {
                MessageBox.Show("Falló la operación " + ex.Message);
                return false;
            }
        }
        public void registrarReporteError(object sender, EventArgs e)
        {
            String idProducto = this.ddIdProducto.Text.Trim();
            String descripcion = this.descripcionError.Text.Trim();
            String fecha = this.fecha.Text.Trim();
            String correo = this.correoUsuario.Text.Trim();
            String idCliente = Session["idUsuario"].ToString();

            if (verificarDatosReporte(idProducto, descripcion, fecha, correo) &&
                insertarReporteError(idProducto, descripcion, fecha, correo, idCliente))
            {
                Verificador.mostrarMensaje("El reporte de error fue registrado correctamente", Page);
                Response.Redirect(url: "ReporteErrores.aspx");
            }


            else
            {
                Verificador.mostrarMensaje(Page);
            }
        }

        //Vista (Probado)
        public Boolean consultarReportes(String pIdUsuario, HtmlGenericControl etiqueta)
        {
            String reportes = "";
            try
            {
                conexion.AbrirConexion();
                conexion.setCommandText("call getReportesErrores('" + pIdUsuario + "');");
                IDataReader resultadosQuery = conexion.getResultados();
                reportes = crearVistaReporteError(resultadosQuery);
                conexion.CerrarConexion();
                GUIBuilder.inyectarHTML(reportes, etiqueta);
                return true;
            }
            catch
            {
                return false;
            }
        }
        public string crearVistaReporteError(IDataReader reader)
        {
            String nombreProducto;
            String descripcion;
            String fecha;
            String correo;

            String reporte = "";
            while (reader.Read())
            {
                nombreProducto = reader[0].ToString();
                descripcion = reader[1].ToString();
                fecha = reader[2].ToString();
                correo = reader[3].ToString();
                reporte += "<tr>" +
                            "<td>" + nombreProducto + "</td>" +
                            "<td>" + descripcion + "</td>" +
                            "<td>" + fecha + "% </td>" +
                            "<td>" + correo + "$ </td>" +
                        "</tr>";
            }
            return reporte;
        }
        public void verReporteErrores(object sender, EventArgs e)
        {
            String idUsuario = Session["idUsuario"].ToString();

            if (consultarReportes(idUsuario, vistaReporteErrores))
            {
                Page_Load(sender, e);
            }
            else
            {
                Verificador.mostrarMensaje(Page);
            }
        }


        //SelectBox (Probado)
        public void popularProductos(object sender, EventArgs e)
        {
            try
            {
                List<KeyValuePair<String, String>> productos = GUIBuilder.getProductos(conexion);
                foreach (KeyValuePair<String, String> p in productos)
                {
                    ddIdProducto.Items.Add(new ListItem(p.Key, p.Value));
                }
                ddIdProducto.Items.Insert(0, new ListItem("Seleccione un producto", ""));
            }
            catch
            {
                Verificador.mostrarMensaje(Page);
            }
        }
    }

}

