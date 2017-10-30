/**
 *	Clase Tests_Seguridad
 *	
 *	Version 1.0
 *	
 *	25/10/2017
 *
 *	Jonathan Rodríguez
 *	Melissa Molina Corrales
 *	Edwin Cen Xu
 */
using NUnit.Framework;
using CRM_Proyect.Modelo;

namespace CRM_Tests
{
    [TestFixture]

    /**
    *	Clase para realizar pruebas de seguridad del sistema como encriptar y desencriptar la contraseña de un usuario.
    *
    */
    class Tests_Seguridad
    {

        [Test]
        public void encriptar_EncriptarContraseñaCorrecto_ReturnsContraseñaEncriptada()
        {
            var resultado = Seguridad.encriptar("950904mc");
            Assert.AreEqual(resultado, "OQA1ADAAOQAwADQAbQBjAA==");

        }

        [Test]
        public void encriptar_EncriptarContraseñaCadenaNula_ReturnsCadenaNula()
        {
            var resultado = Seguridad.encriptar("");
            Assert.AreEqual(resultado, "");

        }

        [Test]
        public void desEncriptar_DesencriptarContraseñaCadenaNoNula_ReturnsContraseñaDesencriptada()
        {

            var resultado = Seguridad.desEncriptar("OQA1ADAAOQAwADQAbQBjAA==");
            Assert.AreEqual(resultado, "950904mc");
        }

        [Test]
        public void desEncriptar_DesencriptarContraseñaCadenaNula_ReturnsCadenaNula()
        {
            var resultado = Seguridad.desEncriptar("");
            Assert.AreEqual(resultado, "");
        }


    }
}
