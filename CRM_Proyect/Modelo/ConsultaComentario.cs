using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using System.Windows.Forms;
namespace CRM_Proyect.Modelo
{
    public class ConsultaComentario
    {
        private int EXITO_DE_INSERCION = 0;
        private int FALLO_DE_INSERCION = -1;
        private MySqlConnection conexion;
        String cadenaDeConexion;

        private void iniciarConexion()
        {
            try
            {
                conexion = new MySqlConnection();
                cadenaDeConexion = ";server=localhost;user id=root;database=crm;password=root";
                conexion.ConnectionString = cadenaDeConexion;
                conexion.Open();

            }
            catch (MySqlException)
            {
                MessageBox.Show("Conexion sin exito");
            }
        }

        private void cerrarConexion()
        {
            conexion.Close();
        }

        public List<Comentario> verComentariosPropuesta(int idPropuesta)
        {
            List<Comentario> listaComentarios = new List<Comentario>();

            iniciarConexion();
            MySqlCommand instruccion = conexion.CreateCommand();
            instruccion.CommandText = "call obtenerComentarioPersonaPropuestas('" + idPropuesta + "')";

            // La consulta podría generar errores
            try
            {
                MySqlDataReader reader = instruccion.ExecuteReader();
                while (reader.Read())
                {
                    listaComentarios.Add(new Comentario(reader["Nombre"].ToString(), reader["Primer_Apellido"].ToString(),
                        reader["Segundo_Apellido"].ToString(), reader["descripcion"].ToString()));
                }

                reader.Dispose();
                cerrarConexion();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Falló la operación " + ex.Message);
            }
            
            return listaComentarios;
        }
        public List<Comentario> verComentariosEmpresasPropuesta(int idPropuesta)
        {
            List<Comentario> listaComentarios = new List<Comentario>();

            iniciarConexion();
            MySqlCommand instruccion = conexion.CreateCommand();
            instruccion.CommandText = "call obtenerComentarioEmpresaPropuestas('" + idPropuesta + "')";

            // La consulta podría generar errores
            try
            {
                MySqlDataReader reader = instruccion.ExecuteReader();
                while (reader.Read())
                {
                    listaComentarios.Add(new Comentario(reader["Nombre"].ToString(), "",
                        "", reader["descripcion"].ToString()));
                }

                reader.Dispose();
                cerrarConexion();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Falló la operación " + ex.Message);
            }

            return listaComentarios;
        }
    }
}