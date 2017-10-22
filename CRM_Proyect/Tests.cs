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
        /*Pruebas para Manejo de Acceso y Usuarios*/

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
        
        [TestCase]
        public void Prueba_Verificar_Usuario_Existente()
        {
            var instancia = new InsertarUsuario();
            var resultado1 = instancia.validarUsuario("JonaRdrgz");
            Assert.AreEqual(resultado1, true);

        }

        /*Pruebas para el manejo de contactos*/


        [TestCase]
        public void Prueba_Agregar_Contacto()
        {
            var instancia = new Consulta();
            instancia.setIdUsuarioActual(1);
            var resultado1 = instancia.registarContactoPersona(1);
            Assert.AreEqual(resultado1, true);

        }

        [TestCase]
        public void Prueba_Agregar_Empresa()
        {
            var instancia = new Consulta();
            instancia.setIdUsuarioActual(1);
            var resultado1 = instancia.registarContactoEmpresa(2);
            Assert.AreEqual(resultado1, true);

        }
        [TestCase]
        public void Prueba_Borrar_Contacto()
        {
            var instancia = new Consulta();
            instancia.setIdUsuarioActual(1);
            var resultado1 = instancia.borrarContacto(2);
            Assert.AreEqual(resultado1, true);

        }
        
        [TestCase]

        public void Prueba_Borrar_Contacto_Empresas()
        {
            var instancia = new Consulta();
            instancia.setIdUsuarioActual(1);
            var resultado1 = instancia.borrarContactoEmpresa(2);
            Assert.AreEqual(resultado1, true);

        }




    }
}