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
    class Tests_Productos
    {
        private int EXITO_DE_INSERCION = 0;
        private int DATO_NO_NUMERICO = -7;

        [Test]

        public void agregarProducto_AgregarProducto_ReturnsEXITO_DE_INSERCION()
        {
            var instancia = new ConsultaProducto();
            var resultado = instancia.agregarProducto("Computadora DELL", "Computadora DELL LATITUDE E6410", "300000");
            Assert.AreEqual(resultado, EXITO_DE_INSERCION);

        }

        [Test]

        public void agregarProducto_FormatoPrecioNoNumerico_ReturnsDATO_NO_NUMERICO()
        {
            var instancia = new Controlador();
            var resultado = instancia.agregarProducto("Computadora DELL", "Computadora DELL LATITUDE E6410", "30a00o");
            Assert.AreEqual(resultado, DATO_NO_NUMERICO);

        }


        [Test]

        public void obtenerProductos_ObtenerProductos_ReturnsList<Producto>()
        {
            var instancia = new ConsultaProducto();
            List<Producto> lista = new List<Producto>();
            var resultado = instancia.obtenerProductos();
            Assert.IsNotNull(resultado);

        }

        [Test]

        public void borrarProducto_BorrarProducto_ReturnsTrue()
        {
            var instancia = new ConsultaProducto();
            var resultado = instancia.borrarProducto(2);
            Assert.AreEqual(resultado, true);

        }

        [Test]

        public void obtenerProductosDisponibles_ObtenerProductosDisponibles_ReturnsList<Producto>()
        {
            var instancia = new ConsultaProducto();
            List<Producto> lista = new List<Producto>();
            var resultado = instancia.obtenerProductosDisponibles();
            Assert.IsNotNull(resultado);

        }

        [Test]

        public void agregarAlCarrito_AgregarAlCarritoDeVentas_ReturnsTrue()
        {
            var instancia = new ConsultaProducto();
            var resultado = instancia.agregarAlCarrito(3);
            Assert.AreEqual(resultado, true);

        }

        [Test]

        public void obtenerProductosCarrito_ObtenerProductosDeCarritoDeVentas_ReturnsList<Producto>()
        {
            var instancia = new ConsultaProducto();
            List<Producto> lista = new List<Producto>();
            var resultado = instancia.obtenerProductosCarrito();
            Assert.IsNotNull(resultado);


        }

        [Test]

        public void eliminarDelCarrito_EliminarDelCarritoDeVentas_ReturnsTrue()
        {
            var instancia = new ConsultaProducto();
            var resultado = instancia.eliminarDelCarrito(3);
            Assert.AreEqual(resultado, true);

        }
    }
}
