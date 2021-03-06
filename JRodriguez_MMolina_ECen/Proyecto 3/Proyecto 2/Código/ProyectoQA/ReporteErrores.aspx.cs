﻿/**
 *	Clase ReporteErrores
 *	
 *	Version 1.0
 *	
 *	10/11/2017
 *
 *	Jonathan Rodríguez
 *	Melissa Molina Corrales
 *	Edwin Cen Xu
 */

using ProyectoQA.Classes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;


namespace ProyectoQA
{
    /**
    *	Clase para crear visualizacion de los reportes de errores
    *
    */
    public partial class ReporteErrores : System.Web.UI.Page
    {
        private IConexion conexion;

        public ReporteErrores()
        {
            conexion = new Conexion("localhost", "mydb", "root", "root", "3306");
        }

        public ReporteErrores(IConexion pConexion)
        {
            conexion = pConexion;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            conexion = new Conexion("localhost", "mydb", "root", "", "3306");

        }

       
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

        public Boolean insertarReporteError(String pIdProducto, String pDescripcion, String pFecha, String pCorreo, String pIdCliente, String pIdVendedor)
        {
            try
            {
                conexion.AbrirConexion();
                conexion.setCommandText("call insertReporteError('" + pDescripcion + "','" + pFecha + "','" + pIdProducto +
                                        "','" + pIdCliente + "','" + pCorreo + "','" + pIdVendedor + "');");

                conexion.getResultados();
                conexion.CerrarConexion();
                return true;
            }
            catch
            {
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
            String idVendedor = this.ddIdVendedor.Text.Trim();

            if (verificarDatosReporte(idProducto, descripcion, fecha, correo) &&
                insertarReporteError(idProducto, descripcion, fecha, correo, idCliente,idVendedor))
            {
                Verificador.mostrarMensaje("El reporte de error fue registrado correctamente", Page);
                Response.Redirect(url: "ReporteErrores.aspx");
            }


            else
            {
                Verificador.mostrarMensaje(Page);
            }
        }

      
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
            String vendedor;
            String estado;
            String diagnostico;

            String reporte = "";
                while (reader.Read())
                {
                    nombreProducto = reader[0].ToString();
                
                    descripcion = reader[1].ToString();
                    fecha = reader[2].ToString();
                    correo = reader[3].ToString();
                    vendedor = reader[4].ToString();
                    estado = reader[5].ToString();
                    diagnostico = reader[6].ToString();

                reporte += "<tr>" +
                                "<td>" + nombreProducto + "</td>" +
                                "<td>" + descripcion + "</td>" +
                                "<td>" + fecha + "</td>" +
                                "<td>" + correo + "</td>" +
                                "<td>" + vendedor + "</td>" +
                                "<td>" + estado + "</td>" +
                                "<td>" + diagnostico + "</td>" +
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

        public void popularVendedores(object sender, EventArgs e)
        {
            try
            {
                List<KeyValuePair<String, String>> vendedores = GUIBuilder.getVendedores(conexion);
                foreach (KeyValuePair<String, String> p in vendedores)
                {
                    ddIdVendedor.Items.Add(new ListItem(p.Key, p.Value));
                }
                ddIdVendedor.Items.Insert(0, new ListItem("Seleccione un vendedor", ""));
            }
            catch
            {
                Verificador.mostrarMensaje(Page);
            }
        }
    }

}

