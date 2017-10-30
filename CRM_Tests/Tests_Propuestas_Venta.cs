/**
 *	Clase Tests_Propuestas_Venta
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
    *	Clase para realizar pruebas de manejo de propuestas de venta en el sistema.
    *
    */
    class Tests_Propuestas_Venta
    {
        private int Exito_De_Insercion = 0;
        private string Precio_No_Numerico = "Precio debe ser numérico";
        private string Precio_Mayor_A_11_Digitos = "Precio debe tener como máximo 11 dígitos";
        private string Descuento_No_Numerico = "Descuento debe ser numérico";
        private string Descuento_Mayor_A_11_Digitos = "Descuento debe tener como máximo 11 dígitos";
        private string Comision_No_Numerico = "Comision debe ser numérico";
        private string Comision_Mayor_A_11_Digitos = "Comision debe tener como máximo 11 dígitos";


        [Test]
        public void crearPropuestaVenta_CrearPropuestaDeVentaCorrecto_ReturnsExito_De_Insercion()
        {
            FakePropuestaVenta fakeManager = new FakePropuestaVenta();
            fakeManager.exitoRetorno = 0;
            ValidadorPropuestaVenta instancia = new ValidadorPropuestaVenta(fakeManager);
            var resultado = instancia.crearPropuestaVenta("5500", "200", "600", 2);
            Assert.AreEqual(resultado, Exito_De_Insercion);

        }

        [Test]
        public void crearPropuestaVenta_FormatoPrecioNoNumerico_ReturnsPrecio_No_Numerico()
        {
            var instancia = new Controlador();
           var resultado = instancia.crearPropuestaVenta("5ra00", "300", "80", 2);
           Assert.AreEqual(resultado, Precio_No_Numerico);

        }

        [Test]
        public void crearPropuestaVenta_PrecioMayorA11Digitos_ReturnsPrecio_Mayor_A_11_Digitos()
        {
            var instancia = new Controlador();
            var resultado = instancia.crearPropuestaVenta("550000000000", "600", "500", 2);
            Assert.AreEqual(resultado, Precio_Mayor_A_11_Digitos);

        }

        [Test]
        public void crearPropuestaVenta_DescuentoNoNumerico_ReturnsDescuento_No_Numerico()
        {
            var instancia = new Controlador();
            var resultado = instancia.crearPropuestaVenta("6500", "descuento", "900",2);
            Assert.AreEqual(resultado, Descuento_No_Numerico);

        }

        [Test]
        public void crearPropuestaVenta_DescuentoMayorA11Digitos_ReturnsDescuento_Mayor_A_11_Digitos()
        {
            var instancia = new Controlador();
            var resultado = instancia.crearPropuestaVenta("8700", "7558000000000", "760",2);
            Assert.AreEqual(resultado, Descuento_Mayor_A_11_Digitos);

        }

        [Test]
        public void crearPropuestaVenta_ComisionNoNumerico_ReturnsComision_No_Numerico()
        {
            var instancia = new Controlador();
            var resultado = instancia.crearPropuestaVenta("8500", "700", "comision",2);
            Assert.AreEqual(resultado, Comision_No_Numerico);

        }

        [Test]
        public void crearPropuestaVenta_ComisionMayorA11Digitos_ReturnsComision_Mayor_A_11_Digitos()
        {
            var instancia = new Controlador();
            var resultado = instancia.crearPropuestaVenta("8500", "700", "95600000000000",2);
            Assert.AreEqual(resultado, Comision_Mayor_A_11_Digitos);

        }

        [Test]
        public void insertarProductoAPropuesta_InsertarProductoAPropuesta_ReturnsExito_De_Insercion()
        {
            FakePropuestaVenta fakeManager = new FakePropuestaVenta();
            fakeManager.exitoRetorno = 0;
            ValidadorPropuestaVenta instancia = new ValidadorPropuestaVenta(fakeManager);
            var resultado = instancia.insertarProductoAPropuesta(2);
            Assert.AreEqual(resultado, Exito_De_Insercion);

        }


        [Test]
        public void verificarNumeroProductosCarrito_VerificarNumeroProductosCarrito_ReturnsTrue()
        {
            FakePropuestaVenta fakeManager = new FakePropuestaVenta();
            fakeManager.exitoConsulta = true;
            ValidadorPropuestaVenta instancia = new ValidadorPropuestaVenta(fakeManager);
            Boolean resultado = instancia.verificarNumeroProductosCarrito();
            Assert.AreEqual(resultado, true);

        }

        [Test]
        public void obtenerPropuestasVenta_ObtenerPropuestasDeVenta_ReturnsList()
        {
            FakePropuestaVenta fakeManager = new FakePropuestaVenta();
            fakeManager.exitoConsulta = true;
            ValidadorPropuestaVenta instancia = new ValidadorPropuestaVenta(fakeManager);
            List<PropuestasVenta> resultado = instancia.obtenerPropuestasVenta();
            Assert.IsNotNull(resultado);

        }

        [Test]
        public void verProductosPropuesta_VerProductosPropuesta_ReturnsList()
        {
            FakePropuestaVenta fakeManager = new FakePropuestaVenta();
            fakeManager.exitoConsulta = true;
            ValidadorPropuestaVenta instancia = new ValidadorPropuestaVenta(fakeManager);
            List<Producto> resultado = instancia.verProductosPropuesta(3);
            Assert.IsNotNull(resultado);

        }

        [Test]
        public void obtenerPropuestasVentaCompra_VerProductosPropuestasVentaCompra_ReturnsList()
        {
            FakePropuestaVenta fakeManager = new FakePropuestaVenta();
            fakeManager.exitoConsulta = true;
            ValidadorPropuestaVenta instancia = new ValidadorPropuestaVenta(fakeManager);
            List<PropuestasVenta> resultado = instancia.obtenerPropuestasVentaCompra();
            Assert.IsNotNull(resultado);

        }


        [Test]
        public void obtenerPropuestasDeVentaUsuario_VerPropuestasDeVentaUsuario_ReturnsList()
        {
            FakePropuestaVenta fakeManager = new FakePropuestaVenta();
            fakeManager.exitoConsulta = true;
            ValidadorPropuestaVenta instancia = new ValidadorPropuestaVenta(fakeManager);
            List<PropuestasVenta> resultado = instancia.obtenerPropuestasDeVentaUsuario();
            Assert.IsNotNull(resultado);

        }

        [Test]
        public void comentarPropuesta_ComentarPropuestaCorrecto_ReturnsTrue()
        {
            FakePropuestaVenta fakeManager = new FakePropuestaVenta();
            fakeManager.exitoConsulta = true;
            ValidadorPropuestaVenta instancia = new ValidadorPropuestaVenta(fakeManager);
            Boolean resultado = instancia.comentarPropuesta(1, "Aceptada");
            Assert.AreEqual(resultado, true);

        }

        [Test]
        public void cambiarRespuesta_CambiarRespuestaCorrecto_ReturnsTrue()
        {
            FakePropuestaVenta fakeManager = new FakePropuestaVenta();
            fakeManager.exitoConsulta = true;
            ValidadorPropuestaVenta instancia = new ValidadorPropuestaVenta(fakeManager);
            Boolean resultado = instancia.comentarPropuesta(1, "Rechazada");
            Assert.AreEqual(resultado, true);

        }

    }

}


