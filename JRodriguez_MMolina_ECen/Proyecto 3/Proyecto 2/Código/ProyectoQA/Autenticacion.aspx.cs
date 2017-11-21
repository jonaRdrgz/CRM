using System;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Data;

namespace ProyectoQA
{
    public partial class Autenticacion : System.Web.UI.Page
    {
        public static IConexion conexion;

        public Autenticacion()
        {
            
            conexion = new Conexion("localhost", "mydb", "root", "root", "3306");
        }
        public Autenticacion(IConexion pConexion)
        {
            conexion = pConexion;
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            conexion = new Conexion("localhost", "mydb", "root", "root", "3306");
           
        }
        public void registrarRef(object sender, EventArgs e)
        {
            Response.Redirect(url: "Registro.aspx");
        }

      ¡
        public void autenticar(String pUsername, String pPassword)
        {
            conexion.AbrirConexion();
            conexion.setCommandText("call getIdUsuario('" + pUsername + "','" + pPassword + "');");
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
        public void autenticarCliente(String pUsername, String pPassword)
        {
            conexion.AbrirConexion();
            conexion.setCommandText("call getIdCliente('" + pUsername + "','" + pPassword + "');");
            IDataReader resultado = conexion.getResultados();
            if (resultado.Read())
            {
                Session["idUsuario"] = resultado.GetInt64(0);
                Response.Redirect("ProductosRelacionados.aspx");
            }
            else
            {
                Verificador.mostrarMensaje("Acceso denegado", Page);
            }
            conexion.CerrarConexion();
        }

        protected void ingresarCliente(object sender, EventArgs e)
        {
            String username = textUsername.Text;
            String pass = textPassword.Text;

            try
            {
                autenticarCliente(username, pass);
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Falló la operación " + ex.Message);
                Verificador.mostrarMensaje(Page);
            }

        }
    }
}