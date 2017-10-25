/**
 *	Clase Seguridad
 *	
 *	Version 1.0
 *	
 *	26/09/2017
 *
 *	Jonathan Rodríguez
 *	Melissa Molina Corrales
 *	Edwin Cen Xu
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CRM_Proyect.Modelo
{
  /**
  *	Clase Seguridad, para encriptar y desencriptar la contraseña del usuario
  *	
  *	Version 1.0
  *	
  *	24/09/2017
  *
  *	Jonathan Rodríguez
  */

    public static class Seguridad
    {

        /// Encripta una cadena
        public static string encriptar(this string cadenaAencriptar)
        {
            string result = string.Empty;
            byte[] encryted = System.Text.Encoding.Unicode.GetBytes(cadenaAencriptar);
            result = Convert.ToBase64String(encryted);
            return result;
        }

        /// Esta función desencripta la cadena que le envíamos en el parámentro de entrada.
        public static string desEncriptar(this string cadenaAdesencriptar)
        {
            string result = string.Empty;
            byte[] decryted = Convert.FromBase64String(cadenaAdesencriptar);
            //result = System.Text.Encoding.Unicode.GetString(decryted, 0, decryted.ToArray().Length);
            result = System.Text.Encoding.Unicode.GetString(decryted);
            return result;
        }
    }
}