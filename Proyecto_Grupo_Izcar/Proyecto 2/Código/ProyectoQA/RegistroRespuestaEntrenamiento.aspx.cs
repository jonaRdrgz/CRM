using System;


namespace ProyectoQA
{
    public partial class RegistroRespuestaEntrenamiento : System.Web.UI.Page
    {
        private IConexion conexion;

        public RegistroRespuestaEntrenamiento()
        {
          
            conexion = new Conexion("localhost", "mydb", "root", "root", "3306");
        }
        public RegistroRespuestaEntrenamiento(IConexion pConexion)
        {
            conexion = pConexion;
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            conexion = new Conexion("localhost", "mydb", "root", "root", "3306");
            
        }

      
        public Boolean verificarDatosRespuesta(String pRespuesta, String pEstado, String pFecha)
        {
            if (String.IsNullOrEmpty(pRespuesta))
            {
                Verificador.mostrarMensaje("La respuesta no debe ser vacía", Page);
                return false;
            }
            else if (String.IsNullOrEmpty(pEstado))
            {
                Verificador.mostrarMensaje("Debe elegir un estado", Page);
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
        public Boolean insertarRespuesta(String pRespuesta, String pEstado, String pFecha, String pIdEntrenamiento, String idUsuario)
        {
            try
            {
                conexion.AbrirConexion();
                conexion.setCommandText("call updateRespuestaEntrenamiento('" + pEstado + "','" +
                    pFecha + "','" + pRespuesta + "','" + pIdEntrenamiento + "','" + idUsuario + "');");
                conexion.getResultados();
                conexion.CerrarConexion();
                return true;
            }
            catch 
            {
                return false;
            }
        }
        public void registrarRespuesta(object sender, EventArgs e)
        {
            String estado = this.ddEstado.Text.Trim();
            String fecha = this.fecha.Text.Trim();
            String respuesta = this.respuesta.Text.Trim();
            String idEntrenamiento = Request.QueryString["idEntrenamiento"].ToString();
            String idUsuario = Session["idUsuario"].ToString();

            if (verificarDatosRespuesta(respuesta, estado, fecha) &&
                insertarRespuesta(respuesta, estado, fecha, idEntrenamiento, idUsuario))
            {
                Verificador.mostrarMensaje("La respuesta fue registrada", Page);
                Response.Redirect(url: "Entrenamientos.aspx");
            }
            else
            {
                Verificador.mostrarMensaje(Page);
               
                Response.Redirect(url: "Entrenamientos.aspx");
            }
        }
    }
}