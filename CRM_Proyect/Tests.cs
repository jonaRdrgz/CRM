using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NUnit.Framework;

namespace CRM_Proyect
{

    [TestFixture]
    public class Tests
    {
        [TestCase]
        public void Prueba_Usuario_Contraseña_Validos()
        {
            var instancia = new Consulta();
            var resultado1 = instancia.validarUsuario("JonaRdrgz", "PassWord123");
            Assert.AreEqual(resultado1,true);

        }

        [TestCase]
        public void Prueba_Usuario_Registrado_Contraseña_Incorrecta()
        {
            var instancia = new Consulta();
            var resultado1 = instancia.validarUsuario("JonaRdrgz", "PassIncorrecta");
            Assert.AreEqual(resultado1, false);

        }

        [TestCase]
        public void Prueba_Usuario_Invalido_Contraseña_Correcta()
        {
            var instancia = new Consulta();
            var resultado1 = instancia.validarUsuario("Jona", "PassWord123");
            Assert.AreEqual(resultado1, false);

        }

        [TestCase]
        public void Prueba_Verificar_Correo()
        {
            var instancia = new InsertarUsuario();
            // Este caso no esta bien, rocio.com no es un correo valido no deberia retornar true, debe retornar false
            
            var resultado1 = instancia.validarCorreo("rocio.com");
            Assert.AreEqual(resultado1, false);

        }
       /* [TestCase]
        public void Prueba_mensaje_error()
        {
            var instancia = new InsertarUsuario();

            var resultado1 = instancia.InsertarUsuarioBD("Rocío", "Hidalgo", "Rodríguez", "marcos.com.com", "Bebedero,Escazú 400 oeste del Restaurante Tiquicia", "rociohr", "rociohr1308g", "88197746");
            Assert.AreEqual(resultado1, 2);

        }*/

    }
}