using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NUnit.Framework;
using CRM_Proyect.Modelo;


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

        [TestCase]
        public void Prueba_Registrar_Usuario()
        {
            var instancia = new InsertarUsuario();
            var resultado1 = instancia.InsertarUsuarioBD("Carlos", "Gutierrez", "Rodríguez", "carlosgr@gmail.com", "San Rafael Abajo, Desamparados", "carlosgr", "carlosgr0508jt", "85167747");
            Assert.AreEqual(resultado1, 0);

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

        [TestCase]

        public void Prueba_ObtenerContactosPersonas()
        {
            var instancia = new Consulta();

            var resultado1 = instancia.obtenerContactoPersonas();
            List<Usuario> lista = new List<Usuario>();
            Assert.AreEqual(resultado1, lista);

        }

        [TestCase]

        public void Prueba_ObtenerContactosEmpresas()
        {
            var instancia = new Consulta();

            var resultado1 = instancia.obtenerContactoEmpresas();
            List<Empresa> lista = new List<Empresa>();
            Assert.AreEqual(resultado1, lista);

        }

        /*Pruebas de portabilidad*/

        /* [Test]
         public void Inicializar_Firefox() {
             FirefoxDriverService service = FirefoxDriverService.CreateDefaultService(@"C:\Users\Administrador\Desktop\geckodriver-v0.18.0-win64", "geckodriver.exe");

             //Give the path of the Firefox Browser        
             service.FirefoxBinaryPath = @"C:\Program Files (x86)\Mozilla Firefox\firefox.exe";

             IWebDriver driver = new FirefoxDriver(service);

             var instancia = new Consulta();
             instancia.iniciarConexion();
             driver.Navigate().GoToUrl("http://localhost:56374/pages/examples/login.aspx");

         }*/

        /*[Test]
         public void Inicializar_Chrome()
        {
            ChromeDriverService service = ChromeDriverService.CreateDefaultService(@"C:\Users\Administrador\Desktop\geckodriver-v0.18.0-win64", "geckodriver.exe");

            //Give the path of the Firefox Browser        
            service. = @"C:\Program Files (x86)\Mozilla Firefox\firefox.exe";

            IWebDriver driver = new FirefoxDriver(service);

            driver.Navigate().GoToUrl("http://localhost:56374/pages/examples/login.aspx");

        }*/




    }
}