using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Web.UI;

namespace ProyectoQA
{
    public static class Verificador
    {
        private static List<String> estados = new List<String> { "Aceptado" , "Rechazado" , "Sin especificar" };
        public static void mostrarMensaje(String mensaje, Page pagina)
        {
            ScriptManager.RegisterStartupScript(pagina, pagina.GetType(), "showError",
            "alert('" + mensaje + "');", true);
        }
        public static void mostrarMensaje(Page pagina)
        {
            mostrarMensaje("El servicio no está disponible en este, inténtelo de nuevo más tarde", pagina);
        }

        public static Boolean verificarCorreo(String pCorreo)
        {
            String formato;
            formato = "\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*";
            if (Regex.IsMatch(pCorreo, formato))
            {
                if (Regex.Replace(pCorreo, formato, String.Empty).Length == 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
        public static Boolean verificarTamanoTelefono(String pTelefono)
        {
            if (pTelefono.Length < 8 || pTelefono.Length >= 20)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public static Boolean verificarNumerosTelefono(String pTelefono)
        {
            for (int i = 0; i < pTelefono.Length; i++)
            {
                if (!Char.IsNumber(pTelefono, i))
                {
                    if (!Char.IsWhiteSpace(pTelefono, i))
                    {
                        return false;
                    }

                }
            }
            return true;
        }
        public static Boolean verificarEstado(String estado)
        {
            estados.Sort();
            int indice = estados.BinarySearch(estado);
            if (indice < 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public static Boolean verificarContraseñaCorta(String pContrasena)
        {
            if (pContrasena.Length < 6 )
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public static Boolean verificarContraseñaLarga(String pContrasena)
        {
            if (pContrasena.Length > 20)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}