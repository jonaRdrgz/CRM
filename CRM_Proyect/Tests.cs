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
            Assert.AreEqual(resultado1, true);

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
            // var resultado1 = instancia.validarCorreo("rocio.com");
            var resultado1 = instancia.InsertarUsuarioBD("Rocío", "Hidalgo", "Rodríguez", "rocio.com", "Bebedero 400 oeste del Restaurante Tiquicia", "rociohr", "rociohr1308g", "88197746");
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
        [TestCase]
        public void Prueba_Contraseña_Corta()
        {
            var instancia = new Controlador();
            var resultado1 = instancia.insertarUsuario("Gabriel", "Hernández", "Picado", "gabrielhp@gmail.com", "San Rafael Abajo, Desamparados", "gabo13hp", "gab13", "84167767");
            Assert.AreEqual(resultado1, -2);

        }

        [TestCase]
        public void Prueba_Contraseña_Muy_Larga()
        {
            var instancia = new Controlador();
            var resultado1 = instancia.insertarUsuario("Alejandra", "Carranza", "Chaves", "alecarranza04@gmail.com", "San Antonio,Escazú", "ale56cc", "Esta_es_una_contraseña_muy_larga_para_pruebas_solamente", "85169767");
            Assert.AreEqual(resultado1, -4);

        }

        [TestCase]
        public void Prueba_Usuario_Muy_Corto()
        {
            var instancia = new Controlador();
            var resultado1 = instancia.insertarUsuario("Jonnathan", "Perez", "Picado", "jonapicado@gmail.com", "San Rafael Arriba, Desamparados", "Jona", "jona45pp", "82145767");
            Assert.AreEqual(resultado1, -3);

        }

        [TestCase]
        public void Prueba_Usuario_Muy_Largo()
        {
            var instancia = new Controlador();
            var resultado1 = instancia.insertarUsuario("Melissa", "Molina", "Corrales", "melimolinacorrales@gmail.com", "Bebedero, Escazú", "Melissa_04_MolinaCorrales", "meli04mc", "83410868");
            Assert.AreEqual(resultado1, -8);

        }

        [TestCase]
        public void Prueba_Verificar_Telefono()
        {
            var instancia = new Controlador();
            var resultado1 = instancia.insertarUsuario("Sandra", "Hernández", "Pizarro", "sandrahp05@gmail.com", "El Carmen, Escazú", "sandra15cc", "sandra15hp", "2a2b8h2o");
            Assert.AreEqual(resultado1, -7);

        }

        [TestCase]
        public void Prueba_Contraseña_Sin_Letras()
        {
            var instancia = new Controlador();
            var resultado1 = instancia.insertarUsuario("Liza", "Fernández", "Parajeles", "lizach07@gmail.com", "Sabanilla, San Pedro", "lizchv07", "987987904", "85187797");
            Assert.AreEqual(resultado1, -5);

        }

        [TestCase]
        public void Prueba_Contraseña_Con_Numeros()
        {
            var instancia = new Controlador();
            var resultado1 = instancia.insertarUsuario("María", "Arce", "Montoya", "maria78am@gmail.com", "San Joaquín de Flores, Heredia", "maria78am", "PassWord", "86225767");
            Assert.AreEqual(resultado1, -6);

        }

        [TestCase]
        public void Prueba_Espacios_Vacios()
        {
            var instancia = new Controlador();
            var resultado1 = instancia.insertarUsuario("Daniel", "", "Mendez", " ", "Santo Domingo, Heredia", "daniel79m", "", "81245767");
            Assert.AreEqual(resultado1, -9);

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


        /*Pruebas para Productos*/

        [TestCase]

        public void Prueba_Agregar_Producto()
        {
            var instancia = new ConsultaProducto();
            var resultado1 = instancia.agregarProducto("Computadora DELL", "Computadora DELL LATITUDE E6410", "300000");
            Assert.AreEqual(resultado1, 0);

        }

        [TestCase]

        public void Prueba_Verificar_Precio()
        {
            var instancia = new ConsultaProducto();
            var resultado1 = instancia.agregarProducto("Computadora DELL", "Computadora DELL LATITUDE E6410", "30a00o");
            Assert.AreEqual(resultado1, -7);

        }


        [TestCase]

        public void Prueba_Obtener_Productos()
        {
            var instancia = new ConsultaProducto();
            List<Producto> lista = new List<Producto>();
            var resultado1 = instancia.obtenerProductos();
            Assert.AreEqual(resultado1, lista);

        }

        [TestCase]

        public void Prueba_Borrar_Producto()
        {
            var instancia = new ConsultaProducto();

            var resultado1 = instancia.borrarProducto(2);
            Assert.AreEqual(resultado1, true);

        }

        [TestCase]

        public void Prueba_Obtener_Productos_Disponibles()
        {
            var instancia = new ConsultaProducto();
            List<Producto> lista = new List<Producto>();
            var resultado1 = instancia.obtenerProductosDisponibles();
            Assert.AreEqual(resultado1, lista);

        }

        [TestCase]

        public void Prueba_Agregar_Al_Carrito()
        {
            var instancia = new ConsultaProducto();
            var resultado1 = instancia.agregarAlCarrito(3);
            Assert.AreEqual(resultado1, true);

        }

        [TestCase]

        public void Prueba_Obtener_Productos_Carrito()
        {
            var instancia = new ConsultaProducto();
            List<Producto> lista = new List<Producto>();
            var resultado1 = instancia.obtenerProductosCarrito();
            Assert.AreEqual(resultado1, lista);

        }

        [TestCase]

        public void Prueba_Eliminar_Del_Carrito()
        {
            var instancia = new ConsultaProducto();
            var resultado1 = instancia.eliminarDelCarrito(3);
            Assert.AreEqual(resultado1, true);

        }

        /*Pruebas para Propuestas de Ventas*/

        [TestCase]

        public void Prueba_InsertarProductoAPropuesta()
        {
            var instancia = new ConsultaPropuestaVenta();
            var resultado1 = instancia.insertarProductoAPropuesta(2);
            Assert.AreEqual(resultado1, 0);

        }
        [TestCase]

        public void Prueba_Crear_Propuesta_De_Venta()
        {
            var instancia = new ConsultaPropuestaVenta();
            var resultado1 = instancia.crearPropuestaVenta("5500", "25%", "6%");
            Assert.AreEqual(resultado1, 0);

        }

        [TestCase]

        public void Prueba_VerificarNumeroProductosCarrito()
        {
            var instancia = new ConsultaPropuestaVenta();
            var resultado1 = instancia.verificarNumeroProductosCarrito();
            Assert.AreEqual(resultado1, true);

        }

        [TestCase]

        public void Prueba_Obtener_Propuestas_Venta()
        {
            var instancia = new ConsultaPropuestaVenta();
            List<PropuestasVenta> lista = new List<PropuestasVenta>();
            var resultado1 = instancia.obtenerPropuestasVenta();
            Assert.AreEqual(resultado1, lista);

        }

        [TestCase]

        public void Prueba_Ver_Productos_Propuesta()
        {
            var instancia = new ConsultaPropuestaVenta();
            List<Producto> lista = new List<Producto>();
            var resultado1 = instancia.verProductosPropuesta(3);
            Assert.AreEqual(resultado1, lista);

        }

        /*Pruebas comentarios de propuestas de ventas*/

        [TestCase]

        public void Prueba_Ver_Comentarios_Propuesta()
        {
            var instancia = new ConsultaComentario();
            List<Comentario> lista = new List<Comentario>();
            var resultado1 = instancia.verComentariosPropuesta(1);
            Assert.AreEqual(resultado1, lista);

        }

        [TestCase]

        public void Prueba_Ver_Comentarios_Empresas_Propuesta()
        {
            var instancia = new ConsultaComentario();
            List<Comentario> lista = new List<Comentario>();
            var resultado1 = instancia.verComentariosEmpresasPropuesta(2);
            Assert.AreEqual(resultado1, lista);

        }

    }
}