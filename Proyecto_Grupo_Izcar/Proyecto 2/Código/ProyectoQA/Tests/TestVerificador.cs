using NUnit.Framework;
using Rhino.Mocks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.HtmlControls;

namespace ProyectoQA.Tests
{
    [TestFixture]
    public class TestVerificador
    {
        [TestCase]
        public void verificarCorreo_CorreoValido_ReturnTrue()
        {
            Assert.AreEqual(true, (Verificador.verificarCorreo("jefalva10296@gmail.com")));
        }
        [TestCase]
        public void verificarCorreo_CorreoInvalido_ReturnFalse()
        {
            Assert.AreEqual(false, (Verificador.verificarCorreo("jefalva10296gmail.com")));
        }
        [TestCase]
        public void verificarTamanoTelefono_TelefonoValido_ReturnTrue()
        {
            Assert.AreEqual(true, (Verificador.verificarTamanoTelefono("12345678")));
        }
        [TestCase]
        public void verificarTamanoTelefono_TelefonoCorto_ReturnFalse()
        {
            Assert.AreEqual(false, (Verificador.verificarTamanoTelefono("123456")));
        }
        [TestCase]
        public void verificarTamanoTelefono_TelefonoLargo_ReturnFalse()
        {
            Assert.AreEqual(false, (Verificador.verificarTamanoTelefono("012345678901234567890")));
        }
        [TestCase]
        public void verificarNumerosTelefono_TelefonoValido_ReturnTrue()
        {
            Assert.AreEqual(true, (Verificador.verificarNumerosTelefono("901234567890")));
        }
        [TestCase]
        public void verificarNumerosTelefono_TelefonoInvalido_ReturnFalse()
        {
            Assert.AreEqual(false, (Verificador.verificarNumerosTelefono("9a123q567890")));
        }
        [TestCase]
        public void verificarEstado_EstadoInvalido_ReturnFalse()
        {
            Assert.AreEqual(false, (Verificador.verificarEstado("Aprobado")));
        }
        [TestCase]
        public void verificarEstado_EstadoValido_ReturnTrue()
        {
            Assert.AreEqual(true, (Verificador.verificarEstado("Aceptado")));
        }
        [TestCase]
        public void verificarLargoContrasena_ContrasenaCorta_ReturnFalse()
        {
            Assert.AreEqual(false, (Verificador.verificarLargoContrasena("1234")));
        }
        [TestCase]
        public void verificarLargoContrasena_ContrasenaLarga_ReturnFalse()
        {
            Assert.AreEqual(false, (Verificador.verificarLargoContrasena("1234137892731273712893771289737129837812793712")));
        }
        [TestCase]
        public void verificarLargoContrasena_ContrasenaValida_ReturnTrue()
        {
            Assert.AreEqual(true, (Verificador.verificarLargoContrasena("12345678")));
        }
    }
}