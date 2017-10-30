/**
 *	Clase Tests_Ventas
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
using System.Collections.Generic;
using CRM_Tests.Fakes;

namespace CRM_Tests
{
    [TestFixture]

    /**
    *	Clase para realizar pruebas de manejo de ventas en el sistema.
    *
    */
    class Tests_Ventas
    {
        private int Exito_De_Insercion = 0;
        private int Falla_De_Insercion = 0;
        private string Precio_No_Numerico = "Precio debe ser numérico";
        private string Precio_Mayor_A_11_Digitos = "Precio debe tener como máximo 11 dígitos";
        private string Descuento_No_Numerico = "Descuento debe ser numérico";
        private string Descuento_Mayor_A_11_Digitos = "Descuento debe tener como máximo 11 dígitos";
        private string Comision_No_Numerico = "Comision debe ser numérico";
        private string Comision_Mayor_A_11_Digitos = "Comision debe tener como máximo 11 dígitos";


        [Test]
        public void crearVenta_PrecioNoNumerico_ReturnsPrecio_No_Numerico()
        {
            var instancia = new Controlador();
            var resultado = instancia.crearVenta("800abc", "200", "400", 2);
            Assert.AreEqual(resultado, Precio_No_Numerico);

        }

        [Test]
        public void crearVenta_PrecioMayorA11Digitos_ReturnsPrecio_Mayor_A_11_Digitos()
        {
            var instancia = new Controlador();
            var resultado = instancia.crearVenta("80000000000000", "300", "100",2);
            Assert.AreEqual(resultado, Precio_Mayor_A_11_Digitos);

        }

        [Test]
        public void crearVenta_DescuentoNoNumerico_ReturnsDescuento_No_Numerico()
        {
            var instancia = new Controlador();
            var resultado = instancia.crearVenta("1500", "descuento", "400",2);
             Assert.AreEqual(resultado, Descuento_No_Numerico);

        }

        [Test]
        public void crearVenta_DescuentoMayorA11Digitos_ReturnsDescuento_Mayor_A_11_Digitos()
        {
            var instancia = new Controlador();
            var resultado = instancia.crearVenta("15000", "458500000000000", "900",2);
            Assert.AreEqual(resultado, Descuento_Mayor_A_11_Digitos);

        }

        [Test]
        public void crearVenta_ComisionNoNumerico_ReturnsComision_No_Numerico()
        {
            var instancia = new Controlador();
            var resultado = instancia.crearVenta("15600", "4585", "comision",2);
            Assert.AreEqual(resultado, Comision_No_Numerico);

        }

        [Test]
        public void crearVenta_ComisionMayorA11Digitos_ReturnsComision_Mayor_A_11_Digitos()
        {
            var instancia = new Controlador();
            var resultado = instancia.crearVenta("16600", "4895", "670000000000000",2);
            Assert.AreEqual(resultado, Comision_Mayor_A_11_Digitos);

        }
        [Test]
        public void crearVenta_CrearVentaCorrecto_ReturnsExito_De_Insercion()
        {
            FakeVenta fakeManager = new FakeVenta();
            fakeManager.exitoConsulta = true;
            ValidadorVenta instancia = new ValidadorVenta(fakeManager);
            int  resultado = instancia.crearVenta("7500", "700", "300",2);
            Assert.AreEqual(resultado, Exito_De_Insercion);

        }

        [Test]
        public void crearVenta_CrearVentaIncorrecto_ReturnsFalla_De_Insercion()
        {
            FakeVenta fakeManager = new FakeVenta();
            fakeManager.exitoConsulta = false;
            ValidadorVenta instancia = new ValidadorVenta(fakeManager);
            int resultado = instancia.crearVenta("7500", "700", "30", 2);
            Assert.AreEqual(resultado, Falla_De_Insercion);

        }

        [Test]
        public void obtenerVentas_ObtenerVentasCorrecto_ReturnsList()
        {
            FakeVenta fakeManager = new FakeVenta();
            ValidadorVenta instancia = new ValidadorVenta(fakeManager);
            List<Venta> resultado = instancia.obtenerVentas();
            Assert.IsNotNull(resultado);

        }

        [Test]
        public void verProductosVenta_VerProductosVentaCorrecto_ReturnsList()
        {
            FakeVenta fakeManager = new FakeVenta();
            ValidadorVenta instancia = new ValidadorVenta(fakeManager);
            List<Producto> resultado = instancia.verProductosVenta(3);
            Assert.IsNotNull(resultado);

        }
        [Test]
        public void obtenerVentas_ObtenerVentasFalso_ReturnNull()
        {
            FakeVenta fakeManager = new FakeVenta();
            fakeManager.listaVenta = null;
            ValidadorVenta instancia = new ValidadorVenta(fakeManager);
            List<Venta> resultado = instancia.obtenerVentas();
            Assert.IsNull(resultado);

        }

        [Test]
        public void verProductosVenta_VerProductosVentaFalso_ReturnNull()
        {
            FakeVenta fakeManager = new FakeVenta();
            fakeManager.listaProducto = null;
            ValidadorVenta instancia = new ValidadorVenta(fakeManager);
            List<Producto> resultado = instancia.verProductosVenta(3);
            Assert.IsNull(resultado);

        }


    }
}
