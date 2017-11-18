using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProyectoQA
{
    public partial class RegistrarEstadoReportes : System.Web.UI.Page
    {
        private IConexion conexion;

        public RegistrarEstadoReportes()
        {
            //conexion = new Conexion("icampos.me", "mydb", "root", "nT4LZIYR5LYzoHAjAKtw", "32769");
            conexion = new Conexion("localhost", "mydb", "root", "root", "3306");
        }
        public RegistrarEstadoReportes(IConexion pConexion)
        {
            conexion = pConexion;
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            conexion = new Conexion("localhost", "mydb", "root", "root", "3306");
            //conexion = new Conexion("icampos.me", "mydb", "root", "nT4LZIYR5LYzoHAjAKtw", "32769");
        }

        //Registro (Probado)
        public Boolean verificarDatosEstadoReporte(String pDiagnostico, String pEstado, String pFecha)
        {
            if (String.IsNullOrEmpty(pDiagnostico))
            {
                Verificador.mostrarMensaje("El diagnóstico no debe ser vacío", Page);
                return false;
            }
            else if (String.IsNullOrEmpty(pEstado))
            {
                Verificador.mostrarMensaje("Debe elegir un estado", Page);
                return false;
            }
            else if (!Verificador.verificarEstado(pEstado))
            {
                Verificador.mostrarMensaje("El estado no es válido", Page);
                return false;
            }
            else if (String.IsNullOrEmpty(pFecha))
            {
                Verificador.mostrarMensaje("La fecha no es válida", Page);
                return false;
            }
            else
            {
                return true;
            }

        }
        public Boolean insertarEstadoReporte(String pDiagnostico, String pEstado, String pFecha, String pIdReporte)
        {
            try
            {
                conexion.AbrirConexion();
                conexion.setCommandText("call updateEstadoReporte('" + pEstado + "','" +
                    pFecha + "','" + pDiagnostico + "','" + pIdReporte + "');");
                conexion.getResultados();
                conexion.CerrarConexion();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public void registrarEstadoReporte(object sender, EventArgs e)
        {
            String estado = this.ddEstado.Text.Trim().ToString();
            String fecha = this.fecha.Text.Trim();
            String diagnostico = this.diagnostico.Text.Trim();
            String idReporte = Request.QueryString["idReporte"].ToString();

            if (verificarDatosEstadoReporte(diagnostico, estado, fecha) &&
                insertarEstadoReporte(diagnostico, estado, fecha, idReporte))
            {
                Verificador.mostrarMensaje("El estado del reporte fue realizado", Page);
                Response.Redirect(url: "ReportesErroresVendedor.aspx");
            }
            else
            {
                Verificador.mostrarMensaje(Page);
                Response.Redirect(url: "ReportesErroresVendedor.aspx");
            }
        }
    }
}