/**
 *	Clase AgregarEntrenamiento
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
    *	Clase para el manejo de entrenamientos
    *
    */
    public partial class AgregarEntrenamiento : System.Web.UI.Page
    {
        private IConexion conexion;

        public AgregarEntrenamiento()
        {
            
            conexion = new Conexion("localhost", "mydb", "root", "root", "3306");
        }
        public AgregarEntrenamiento(IConexion pConexion)
        {
            conexion = pConexion;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            conexion = new Conexion("localhost", "mydb", "root", "root", "3306");
        }

      
        public Boolean verificarDatosEntrenamiento(String pNombre, String pFecha, String pHoraInicio, String pHoraFin, String pUbicacion, String pIdEmpresa)
        {
            if (String.IsNullOrEmpty(pNombre))
            {
                Verificador.mostrarMensaje("Nombre inválido", Page);
                return false;
            }
            else if (String.IsNullOrEmpty(pHoraInicio))
            {
                Verificador.mostrarMensaje("Hora Inicio inválida", Page);
                return false;
            }
            else if (String.IsNullOrEmpty(pHoraFin))
            {
                Verificador.mostrarMensaje("Hora Inicio inválida", Page);
                return false;
            }
            else if (String.IsNullOrEmpty(pUbicacion))
            {
                Verificador.mostrarMensaje("Ubicación inválida", Page);
                return false;
            }
            else if (String.IsNullOrEmpty(pFecha))
            {
                Verificador.mostrarMensaje("Fecha inválida", Page);
                return false;
            }
            else if (String.IsNullOrEmpty(pIdEmpresa))
            {
                Verificador.mostrarMensaje("Id Empresa inválida", Page);
                return false;
            }
            else
            {
                return true;
            }
        }

        public Boolean insertarEntrenamiento(String pNombre, String pFecha, String pHoraInicio, String pHoraFin, String pUbicacion, String pIdEmpresa)
       {
            try
            {
                conexion.AbrirConexion();
                conexion.setCommandText("call insertEntrenamiento('" + pNombre + "','" + pFecha + "','" + pHoraInicio +
                                        "','" + pHoraFin + "','" + pUbicacion + "','" + pIdEmpresa + "');");
                conexion.getResultados();
                conexion.CerrarConexion();
                return true;
            }
            catch
            {
                return false;
            }

        }

        public void registrarEntrenamiento(object sender, EventArgs e)
        {

            String nombre = this.nombreEntrenamiento.Text.Trim();
            String fecha = this.fecha.Text.Trim();
            String horaInicio = this.horaInicio.Text.Trim();
            String horaFin = this.horaFin.Text.Trim();
            String ubicacion = this.ubicacion.Text.Trim();
            String idEmpresa = this.ddIdEmpresa.Text.Trim();

            if (verificarDatosEntrenamiento(nombre, fecha, horaInicio, horaFin, ubicacion, idEmpresa) &&
                insertarEntrenamiento(nombre, fecha, horaInicio, horaFin, ubicacion, idEmpresa))
            {
                Verificador.mostrarMensaje("El entrenamiento fue registrado", Page);
                Response.Redirect(url: "AgregarEntrenamiento.aspx");
            }
            else
            {
                Verificador.mostrarMensaje(Page);
            }
        }

       
        public Boolean consultarEntrenamientos(String pIdUsuario, HtmlGenericControl etiqueta)
        {
            String entrenamientos = "";
            try
            {
                conexion.AbrirConexion();
                conexion.setCommandText("call getEntrenamientos();");
                IDataReader resultadosQuery = conexion.getResultados();
                entrenamientos = crearVistaEntrenamiento(resultadosQuery);
                conexion.CerrarConexion();
                GUIBuilder.inyectarHTML(entrenamientos, etiqueta);
                return true;
            }
            catch
            {
                return false;
            }
        }
        public string crearVistaEntrenamiento(IDataReader reader)
        {
            String nombre;
            String horaInicio;
            String horaFin;
            String fecha;
            String ubicacion;
            String empresa;

            String entrenamiento = "";
            while (reader.Read())
            {
                nombre = reader[1].ToString();
                horaInicio = reader[3].ToString();
                horaFin = reader[4].ToString();
                fecha = reader[2].ToString();
                ubicacion = reader[5].ToString();
                empresa = reader[6].ToString();
                entrenamiento += "<tr>" +
                            "<td>" + nombre + "</td>" +
                            "<td>" + fecha + "</td>" +
                            "<td>" + horaInicio + "</td>" +
                            "<td>" + horaFin + "</td>" +
                            "<td>" + ubicacion + "</td>" +
                            "<td>" + empresa + "</td>" +
                        "</tr>";
            }
            return entrenamiento;
        }

        public void verEntrenamientos(object sender, EventArgs e)
        {
            String idUsuario = Session["idUsuario"].ToString();

            if (consultarEntrenamientos(idUsuario, vistaEntrenamientos))
            {
                Page_Load(sender, e);
            }
            else
            { 
                Verificador.mostrarMensaje(Page);
            }
        }


        public void popularEmpresa(object sender, EventArgs e)
        {
            String idUsuario = Session["idUsuario"].ToString();
            try
            {
                List<KeyValuePair<String, String>> contactos = GUIBuilder.getEmpresas(idUsuario, conexion);
                foreach (KeyValuePair<String, String> c in contactos)
                {
                    ddIdEmpresa.Items.Add(new ListItem(c.Key, c.Value));
                }
                ddIdEmpresa.Items.Insert(0, new ListItem("Seleccione una empresa", ""));
            }
            catch
            {
                Verificador.mostrarMensaje(Page);
            }

        }
    }
}