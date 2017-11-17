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
    public partial class Entrenamientos : System.Web.UI.Page
    {
        private IConexion conexion;
        public Entrenamientos()
        {
            //conexion = new Conexion("icampos.me", "mydb", "root", "nT4LZIYR5LYzoHAjAKtw", "32769");
            conexion = new Conexion("localhost", "mydb", "root", "root", "3306");
        }
        public Entrenamientos(IConexion pConexion)
        {
            conexion = pConexion;
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            conexion = new Conexion("localhost", "mydb", "root", "root", "3306");
            //conexion = new Conexion("icampos.me", "mydb", "root", "nT4LZIYR5LYzoHAjAKtw", "32769");
        }

        public Boolean consultarEntrenamiento(String pIdUsuario, HtmlGenericControl etiqueta)
        {
            String entrenamiento = "";
            try
            {
                conexion.AbrirConexion();
                conexion.setCommandText("call getEntrenamientos();");
                IDataReader resultadosQuery = conexion.getResultados();
                entrenamiento = crearVistaContacto(resultadosQuery);
                conexion.CerrarConexion();
                GUIBuilder.inyectarHTML(entrenamiento, etiqueta);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public String crearVistaContacto(IDataReader reader)
        {
            int contador = 0;
            String entrenamiento = "";
            while (reader.Read())
            {
                if (contador % 4 == 0)
                {
                    entrenamiento += "<div class = 'row'>";
                }
                entrenamiento += "<div class='col-lg-3'>" +
                                "<div class='hpanel hred contact-panel'>" +
                                    "<div class='panel-body'>" +
                                       "<h3><a  value = " + reader[0].ToString() + ">" + reader[1].ToString() + "</a></h3>" +
                                       "<div class='text-muted font-bold m-b-xs'>Fecha: " + reader[2].ToString() + "</div>" +
                                       "<div class='text-muted font-bold m-b-xs'>Hora Inicio: " + reader[3].ToString() + "</div>" +
                                       "<div class='text-muted font-bold m-b-xs'>Hora Fin: " + reader[4].ToString() + "</div>" +
                                       "<div class='text-muted font-bold m-b-xs'>Ubicación: " + reader[5].ToString() + "</div>" +
                                       "<div class='text-muted font-bold m-b-xs'>Empresa: " + reader[6].ToString() + "</div>" +
                                   "</div>" +
                                "</div>" +
                            "</div>";
                if (contador % 4 == 3)
                {
                    entrenamiento += "</div>";
                }
                contador++;
            }
            return entrenamiento;
        }

        public void verEntrenamientos(object sender, EventArgs e)
        {
            String idUsuario = Session["idUsuario"].ToString();

            if (consultarEntrenamiento(idUsuario, Element))
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