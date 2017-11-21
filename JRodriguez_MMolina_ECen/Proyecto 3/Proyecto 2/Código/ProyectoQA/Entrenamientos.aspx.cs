/**
 *	Clase Entrenamientos
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
using System.Data;
using System.Web.UI.HtmlControls;



namespace ProyectoQA
{

    /**
    *	Clase para crear visualizaciones de entrenamientos
    *
    */
    public partial class Entrenamientos : System.Web.UI.Page
    {
        private IConexion conexion;
        public Entrenamientos()
        {
           
            conexion = new Conexion("localhost", "mydb", "root", "root", "3306");
        }
        public Entrenamientos(IConexion pConexion)
        {
            conexion = pConexion;
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            conexion = new Conexion("localhost", "mydb", "root", "root", "3306");
            
        }

        public Boolean consultarEntrenamientos(String pIdUsuario, HtmlGenericControl etiqueta)
        {
            String entrenamientos = "";
            try
            {
                conexion.AbrirConexion();
                conexion.setCommandText("call getEntrenamientosClientes('"+ pIdUsuario+"');");
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
            String estado;
            String idEntrenamiento;

            String entrenamiento = "";
            while (reader.Read())
            {
                nombre = reader[1].ToString();
                horaInicio = reader[3].ToString();
                horaFin = reader[4].ToString();
                fecha = reader[2].ToString();
                ubicacion = reader[5].ToString();
                empresa = reader[6].ToString();
                estado = reader[7].ToString();
                idEntrenamiento = reader[0].ToString();
                entrenamiento += "<tr>" +
                            "<td>" + nombre + "</td>" +
                            "<td>" + fecha + "</td>" +
                            "<td>" + horaInicio + "</td>" +
                            "<td>" + horaFin + "</td>" +
                            "<td>" + ubicacion + "</td>" +
                            "<td>" + empresa + "</td>" +
                            "<td>" + estado + "</td>" +
                            "<td>" + "<a href='RegistroRespuestaEntrenamiento.aspx?idEntrenamiento=" + idEntrenamiento + "'>Editar respuesta</a>" + "</td>" +
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

    }
}