using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Data;
using System.Web.SessionState;

namespace ProyectoQA
{
    public partial class AutenticacionCliente : System.Web.UI.Page
    {
        public static IConexion conexion;

        public AutenticacionCliente()
        {
            conexion = new Conexion("localhost", "mydb", "root", "root", "3306");
        }

        public AutenticacionCliente(IConexion pConexion)
        {
            conexion = pConexion;
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            conexion = new Conexion("localhost", "mydb", "root", "root", "3306");
           
        }


        public void registrarRef(object sender, EventArgs e)
        {
            Response.Redirect(url: "RegistroCliente.aspx");
        }

        //Autenticación
        public void autenticar(String pUsername, String pPassword)
        {
            conexion.AbrirConexion();
            conexion.setCommandText("call getIdCliente('" + pUsername + "','" + pPassword + "');");
            IDataReader resultado = conexion.getResultados();
            if (resultado.Read())
            {
                Session["idUsuario"] = resultado.GetInt64(0);
                Response.Redirect("ContactoPersona.aspx");
            }
            else
            {
                Verificador.mostrarMensaje("Acceso denegado", Page);
            }
            conexion.CerrarConexion();
        }

        protected void ingresar(object sender, EventArgs e)
        {
            String username = textUsername.Text;
            String pass = textPassword.Text;

            try
            {
                autenticar(username, pass);
            }
            catch
            {
                Verificador.mostrarMensaje(Page);
            }

        }
    }
}