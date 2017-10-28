using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using CRM_Proyect.Modelo;

namespace CRM_Tests
{
    [TestFixture]
    class Tests_Ventas
    {
        private int Exito_De_Insercion = 0;
        private string Precio_No_Numerico = "Precio debe ser numérico";
        private string Precio_Mayor_A_11_Digitos = "Precio debe tener como máximo 11 dígitos";
        private string Descuento_No_Numerico = "Descuento debe ser numérico";
        private string Descuento_Mayor_A_11_Digitos = "Descuento debe tener como máximo 11 dígitos";
        private string Comision_No_Numerico = "Comision debe ser numérico";
        private string Comision_Mayor_A_11_Digitos = "Comision debe tener como máximo 11 dígitos";

        [Test]

        public void crearVenta_CrearVentaCorrecto_ReturnsExito_De_Insercion()
        {
            var instancia = new ConsultaVenta();
            var resultado = instancia.crearVenta("7500", "700", "300");
            Assert.AreEqual(resultado, Exito_De_Insercion);

        }

        [Test]

        public void crearVenta_PrecioNoNumerico_ReturnsPrecio_No_Numerico()
        {
            var instancia = new Controlador();
            var resultado = instancia.crearVenta("800abc", "200", "400");
            Assert.AreEqual(resultado, Precio_No_Numerico);

        }

        [Test]

        public void crearVenta_PrecioMayorA11Digitos_ReturnsPrecio_Mayor_A_11_Digitos()
        {
            var instancia = new Controlador();
            var resultado = instancia.crearVenta("80000000000000", "300", "100");
            Assert.AreEqual(resultado, Precio_Mayor_A_11_Digitos);

        }

        [Test]

        public void crearVenta_DescuentoNoNumerico_ReturnsDescuento_No_Numerico()
        {
            var instancia = new Controlador();
            var resultado = instancia.crearVenta("1500", "descuento", "400");
            Assert.AreEqual(resultado, Precio_Mayor_A_11_Digitos);

        }

        [Test]
        public void crearVenta_DescuentoMayorA11Digitos_ReturnsDescuento_Mayor_A_11_Digitos()
        {
            var instancia = new Controlador();
            var resultado = instancia.crearVenta("15000", "458500000000000", "900");
            Assert.AreEqual(resultado, Descuento_Mayor_A_11_Digitos);

        }

        [Test]
        public void crearVenta_ComisionNoNumerico_ReturnsComision_No_Numerico()
        {
            var instancia = new Controlador();
            var resultado = instancia.crearVenta("15600", "4585", "comision");
            Assert.AreEqual(resultado, Comision_No_Numerico);

        }

        [Test]
        public void crearVenta_ComisionMayorA11Digitos_ReturnsComision_Mayor_A_11_Digitos()
        {
            var instancia = new Controlador();
            var resultado = instancia.crearVenta("16600", "4895", "670000000000000");
            Assert.AreEqual(resultado, Comision_Mayor_A_11_Digitos);

        }

        [Test]
        public void obtenerVentas_ObtenerVentasCorrecto_ReturnsList<Venta>()
        {
            var instancia = new ConsultaVenta();
            var resultado = instancia.obtenerVentas();
            Assert.IsNotNull(resultado);

        }

        [Test]
        public void verProductosVenta_VerProductosVentaCorrecto_ReturnsList<Producto>()
        {
            var instancia = new ConsultaVenta();
            var resultado = instancia.verProductosVenta(1);
            Assert.IsNotNull(resultado);

        }

       
    }
}
