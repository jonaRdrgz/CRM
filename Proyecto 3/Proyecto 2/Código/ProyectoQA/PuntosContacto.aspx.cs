﻿/**
 *	Clase PuntosContacto
 *	
 *	Version 1.0
 *	
 *	10/11/2017
 *
 *	Jonathan Rodríguez
 *	Melissa Molina Corrales
 *	Edwin Cen Xu
 */

using System;
using ProyectoQA.Classes;
using System.Web.UI.HtmlControls;
using System.Data;

namespace ProyectoQA
{
    /**
    *	Clase para crear visualizaciones de puntos de contacto
    *
    */
    public partial class PuntosContacto : System.Web.UI.Page
    {

        private static IConexion conexion;

        public PuntosContacto()
        {
           
            conexion = new Conexion("localhost", "mydb", "root", "root", "3306");
        }

        public PuntosContacto(IConexion pConexion)
        {
            conexion = pConexion;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            conexion = new Conexion("localhost", "mydb", "root", "root", "3306");
          
        }
        public Boolean consultarVendedores(HtmlGenericControl etiqueta)
        {
            String contactoVendedor = "";
            try
            {
                conexion.AbrirConexion();
                conexion.setCommandText("call getVendedores();");
                IDataReader resultadosQuery = conexion.getResultados();
                contactoVendedor = crearVistaVendedores(resultadosQuery);
                conexion.CerrarConexion();
                GUIBuilder.inyectarHTML(contactoVendedor, etiqueta);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public String crearVistaVendedores(IDataReader reader)
        {
            int contador = 0;
            string contactoVendedor = "";
            while (reader.Read())
            {
                if (contador % 4 == 0)
                {
                    contactoVendedor += "<div class = 'row'>";
                }
                contactoVendedor += "<div class='col-lg-3'>" +
                                       "<div class='hpanel hyellow contact-panel'>" +
                                           "<div class='panel-body'>" +
                                              
                                              "<div class='text-muted font-bold m-b-xs'>Correo electrónico: " + reader[1].ToString() + "</div>" +
                                           
                                          "</div>" +
                                       "</div>" +
                                   "</div>";
                if (contador % 4 == 3)
                {
                    contactoVendedor += "</div>";
                }
                contador++;
            }
            return contactoVendedor;
        }

        public void verContactosVendedores(object sender, EventArgs e)
        {
           

            if (consultarVendedores(verVendedores))
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