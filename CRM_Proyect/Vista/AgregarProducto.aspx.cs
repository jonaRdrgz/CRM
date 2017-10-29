/**
 *	Clase AgregarProducto
 *	
 *	Version 1.0
 *	
 *	24/09/2017
 *
 *	Jonathan Rodríguez
 *	Melissa Molina Corrales
 *	Edwin Cen Xu
 */


using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text.RegularExpressions;
using System.Web.Services;

namespace CRM_Proyect
{
    public partial class AgregarProducto : System.Web.UI.Page
    {
        const int CONTRASEÑA_MUY_CORTA = -2;
        const int CONTRASEÑA_MUY_LARGA = -4;
        const int USUARIO_MUY_CORTO = -3;
        const int NO_CONTIENE_LETRAS = -5;
        const int NO_CONTIENE_NUMEROS = -6;
        const int DATO_NO_NUMERICO = -7;
        const int USUARIO_MUY_LARGO = -8;
        const int ESPACIO_VACIO = -9;
        const int NOMBRE_MUY_LARGO = -10;
        const int DESCRIPCION_MUY_LARGO = -11;
        const int DATO_VACIO = -12;
        const int EXITO_DE_INSERCION = 0;
        const int FALLO_DE_INSERCION = -1;
        private static string respuesta;


        Controlador controlador = Controlador.getInstance();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        [WebMethod]
        public static string insertarProducto(string nombre, string descripcion, string precio)
        {
            //Validación de parámetros
            if (!validarParametros(precio, nombre, descripcion)) {
                return respuesta;
            }

            Controlador controlador = Controlador.getInstance();
            int respuestaControlador = controlador.agregarProducto(nombre, descripcion, precio);
            if (respuestaControlador == EXITO_DE_INSERCION)
            {
                return "Éxito";
            }
            //Respuesta del controlador
            else if (respuestaControlador == NOMBRE_MUY_LARGO) {
                return "Nombre muy largo";
            }

            else if (respuestaControlador == DESCRIPCION_MUY_LARGO)
            {
                return "Descripcón muy larga";
            }
            else if (respuestaControlador == DATO_NO_NUMERICO)
            {
                return "Precio debe ser numerico";
            }
            else if (respuestaControlador == DATO_VACIO)
            {
                return "Los datos no deben ser vacíos";
            }
            return "Falló la inserción";

        }

        private static Boolean validarParametros(String precio, String nombre, String descripcion) {
            if (precio.Equals(""))
            {
                respuesta = "Precio no debe ser vacío";
                return false;
            }

            if (!isNumeric(precio))
            {
                respuesta = "El precio debe ser numérico";
                return false;
            }

            if (nombre.Equals(""))
            {
                respuesta = "Nombre no debe ser vacío";
                return false;
            }
            


            if (descripcion.Equals(""))
            {
                respuesta = "Descripción no debe ser vacío";
                return false;
            }
            else if (precio.Count() > 11) {
                respuesta = "El precio debe tener máximo 11 dígitos";
                return false;
            }
            else if (descripcion.Count() > 200)
            {
                respuesta = "La descripción  debe tener máximo 200 caracteres";
                return false;
            }
            else if (nombre.Count() > 45)
            {
                respuesta = "El nombre  debe tener máximo 45 caracteres";
                return false;
            }
            else {
                return true;
            }
        }

        static bool isNumeric(string sValue)
        {
            return Regex.IsMatch(sValue, "^[0-9]+$");
        }


    }
}