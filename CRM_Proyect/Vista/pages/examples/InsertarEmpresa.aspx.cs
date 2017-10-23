using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text.RegularExpressions;

namespace CRM_Proyect.pages.examples
{
    public partial class InsertarEmpresa : System.Web.UI.Page
    {
        const int EXITO_DE_INSERCION = 0;
        const int FALLO_DE_INSERCION = -1;
        const int USUARIO_INVALIDO = 1;
        const int CORREO_INVALIDO = 2;
        const int CONTRASEÑA_MUY_CORTA = -2;
        const int USUARIO_MUY_CORTO = -3;
        const int CONTRASEÑA_MUY_LARGA = -4;
        const int NO_CONTIENE_LETRAS = -5;
        const int NO_CONTIENE_NUMEROS = -6;
        const int TELEFONO_NO_NUMERICO = -7;

        Controlador controlador = Controlador.getInstance();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        static bool IsNumeric(string sValue)
        {
            return Regex.IsMatch(sValue, "^[0-9]+$");
        }

        protected void registrarEmpresa(object sender, EventArgs e)
        {
            string contrasena = TextBoxContraseña.Text;
            string reContrasena = TextBoxReContraseña.Text;
            string usuario = TextBoxUsuario.Text;
            string telefono = TextBoxTelefono.Text;

            if (!IsNumeric(telefono))
            {
                string str = "El teléfono deben ser números";
                Response.Write("<script language=javascript>alert('" + str + "');</script>");
                TextBoxTelefono.Focus();
                return;
            }
            bool tieneNumeros = contrasena.Any(c => char.IsDigit(c));
            bool tieneLetras = contrasena.Any(c => char.IsLetter(c));
            if (!tieneNumeros)
            {
                string str = "La contraseña debe tener al menos 1 número";
                Response.Write("<script language=javascript>alert('" + str + "');</script>");
                TextBoxContraseña.Focus();
            }
            else if (!tieneLetras)
            {
                string str = "La contraseña debe tener al menos una letra";
                Response.Write("<script language=javascript>alert('" + str + "');</script>");
                TextBoxContraseña.Focus();
            }

            else if (contrasena.Length < 7)
            {

                string str = "La contraseña debe tener al menos 7 caracteres";
                Response.Write("<script language=javascript>alert('" + str + "');</script>");
                TextBoxContraseña.Focus();
            }
            else if (contrasena.Length > 50)
            {
                string str = "La contraseña no debe tener más de 50 caracteres";
                Response.Write("<script language=javascript>alert('" + str + "');</script>");
                TextBoxContraseña.Focus();

            }
            else if (!contrasena.Equals(reContrasena))
            {
                string str = "Las contraseñas no coinciden";
                Response.Write("<script language=javascript>alert('" + str + "');</script>");
                TextBoxReContraseña.Focus();

            }
            else if (usuario.Length < 5)
            {
                string str = "El nombre de usuario debe tener al menos 5 caracteres";
                Response.Write("<script language=javascript>alert('" + str + "');</script>");
                TextBoxUsuario.Focus();

            }

            else
            {
                if (Page.IsValid)
                {
                    string nombre = TextBoxNombre.Text;
                    string direccion = TextBoxDireccion.Text;
                    string correo = TextBoxCorreo.Text;

                    int resultadoControlador = controlador.insertarEmpresa(nombre, correo,
                        direccion, telefono, usuario, contrasena);
                    switch (resultadoControlador)
                    {
                        case EXITO_DE_INSERCION:
                            string str = "insertado";
                            Response.Write("<script language=javascript>alert('" + str + "');</script>");
                            break;
                        case CORREO_INVALIDO:
                            string correoInvalido = "El correo ya esta registrado";
                            Response.Write("<script language=javascript>alert('" + correoInvalido + "');</script>");
                            break;
                        case TELEFONO_NO_NUMERICO:
                            string telefonoNoNumerico = "El telefono debe ser numérico";
                            Response.Write("<script language=javascript>alert('" + telefonoNoNumerico + "');</script>");
                            break;
                        default:
                            string noOperacion = "No se puede realizar la operación";
                            Response.Write("<script language=javascript>alert('" + noOperacion + "');</script>");
                            break;
                    }

                    //Response.Write("<script language=javascript>alert('" + idBoton + "');</script>");
                    //Response.Redirect("../../index.aspx");
                }
            }
        }
    }
}