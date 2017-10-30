/**
 *	Clase Tests_Producto
 *	
 *	Version 1.0
 *	
 *	24/10/2017
 *
 *	Jonathan Rodríguez
 *	Melissa Molina Corrales
 *	Edwin Cen Xu
 */

using NUnit.Framework;
using CRM_Proyect.Modelo;
using System;
using System.Collections.Generic;
using CRM_Tests.Fakes;


namespace CRM_Tests
{
    [TestFixture]

    /**
    *	Clase para realizar pruebas de manejo de productos en el sistema.
    *
    */
    class Tests_Productos
    {
        private int Exito_De_Insercion = 0;
        private int Dato_No_Numerico = -7;
        private int Nombre_Muy_Largo = -10;
        private int Descripcion_Muy_Larga = -11;
        private int Datos_Vacios = -12;

        [Test]
        public void agregarProducto_AgregarProductoCorrecto_ReturnsExito_De_Insercion()
        {
            FakeConsultaProducto fakeManager = new FakeConsultaProducto();
            fakeManager.resultadoExitoso = 0;
            ValidadorProductos producto = new ValidadorProductos(fakeManager);
            int  resultado = producto.agregarProducto("Computadora DELL", 
                "Computadora DELL LATITUDE E6410", "300000");
            Assert.AreEqual(resultado, Exito_De_Insercion);


        }

        [Test]
        public void agregarProducto_PrecioNoNumerico_ReturnsDato_No_Numerico()
        {
            var instancia = new Controlador();
            var resultado = instancia.agregarProducto("Clear View Cam ", "Graba de noche y de dia sin problemas", "4a00p");
            Assert.AreEqual(resultado, Dato_No_Numerico);

        }

        [Test]
        public void agregarProducto_NombreMuyLargo_ReturnsNombre_Muy_Largo()
        {
            var instancia = new Controlador();
            var resultado = instancia.agregarProducto("Estimulador Muscular Electromagnético En"+
                " Forma De Pluma Click & Care - Blanco", "Alivia el dolor de forma rápida y natural,"+
                " sin medicamentos", "15000");
            Assert.AreEqual(resultado, Nombre_Muy_Largo);

        }


        [Test]
        public void agregarProducto_DescripcionMuyLarga_ReturnsDescripcion_Muy_Larga()
        {
            var instancia = new Controlador();
            var resultado = instancia.agregarProducto("Sistema De Control De Plagas Riddex", "Deja atrás "+
                "los productos químicos que tanto daño causan a tu salud así como las molestas trampas que "+
                "tienes que colocar y retirar con frecuencia para eliminar esos bichos, insectos y roedores "+
                "que asechan tu hogar, pues desde ahora deshacerte de ellos será muy fácil con ayuda del Riddex"+
                " Plus.Sólo basta conectar este Riddex Plus a la red eléctrica del hogar para que comience a producir"+
                " ondas eléctricas, las cuales serán un escudo eficaz para mantener todos los espacios de tu hogar "+
                "libres de estos huéspedes incómodos.", "4500");
            Assert.AreEqual(resultado, Descripcion_Muy_Larga);

        }

        [Test]
        public void agregarProducto_DatosVacios_ReturnsDatos_Vacios()
        {
            var instancia = new Controlador();
            var resultado = instancia.agregarProducto("","","2312");
            Assert.AreEqual(resultado, Datos_Vacios);

        }

        [Test]
        public void obtenerProductos_ObtenerProductos_ReturnsList()
        {
            FakeConsultaProducto fakeManager = new FakeConsultaProducto();
            fakeManager.resultadoExitoso = 0;
            ValidadorProductos producto = new ValidadorProductos(fakeManager);
            List<Producto> resultado = producto.obtenerProductos();
            Assert.IsNotNull(resultado);

        }

        [Test]
        public void borrarProducto_BorrarProducto_ReturnsTrue()
        {
            FakeConsultaProducto fakeManager = new FakeConsultaProducto();
            fakeManager.debeResponder = true;
            ValidadorProductos producto = new ValidadorProductos(fakeManager);
            Boolean resultado = producto.borrarProducto(2);
            Assert.AreEqual(resultado, true);

        }

        [Test]
        public void obtenerProductosDisponibles_ObtenerProductosDisponibles_ReturnsList()
        {
            FakeConsultaProducto fakeManager = new FakeConsultaProducto();
            ValidadorProductos producto = new ValidadorProductos(fakeManager);
            List<Producto> resultado = producto.obtenerProductosDisponibles();
            Assert.IsNotNull(resultado);

        }

        [Test]
        public void agregarAlCarrito_AgregarAlCarritoDeVentas_ReturnsTrue()
        {
            FakeConsultaProducto fakeManager = new FakeConsultaProducto();
            fakeManager.debeResponder = true;
            ValidadorProductos producto = new ValidadorProductos(fakeManager);
            Boolean resultado = producto.agregarAlCarrito(3);
            Assert.AreEqual(resultado, true);

        }

        [Test]
        public void obtenerProductosCarrito_ObtenerProductosDeCarritoDeVentas_ReturnsList()
        {
            FakeConsultaProducto fakeManager = new FakeConsultaProducto();
            ValidadorProductos producto = new ValidadorProductos(fakeManager);
            List<Producto> resultado = producto.obtenerProductosCarrito();
            Assert.IsNotNull(resultado);


        }

        [Test]
        public void eliminarDelCarrito_EliminarDelCarritoDeVentas_ReturnsTrue()
        {
            FakeConsultaProducto fakeManager = new FakeConsultaProducto();
            fakeManager.debeResponder = true;
            ValidadorProductos producto = new ValidadorProductos(fakeManager);
            Boolean resultado = producto.eliminarDelCarrito(3);
            Assert.AreEqual(resultado, true);

        }
    }
}
