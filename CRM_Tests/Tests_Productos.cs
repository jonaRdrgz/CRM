
using System.Collections.Generic;
using NUnit.Framework;
using CRM_Proyect.Modelo;

namespace CRM_Tests
{
    [TestFixture]
    class Tests_Productos
    {
        private int Exito_De_Insercion = 0;
        private int Dato_No_Numerico = -7;
        private int Nombre_Muy_Largo = -10;
        private int Descripcion_Muy_Larga = -11;
        private int Datos_Vacios = -12;

        [Test]

        public void agregarProducto_AgregarProducto_ReturnsExito_De_Insercion()
        {
            var instancia = new ConsultaProducto();
            var resultado = instancia.agregarProducto("Computadora DELL", "Computadora DELL LATITUDE E6410", "300000");
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
            var resultado = instancia.agregarProducto("Estimulador Muscular Electromagnético En Forma De Pluma Click & Care - Blanco", "Alivia el dolor de forma rápida y natural, sin medicamentos", "15000");
            Assert.AreEqual(resultado, Nombre_Muy_Largo);

        }


        [Test]

        public void agregarProducto_DescripcionMuyLarga_ReturnsDescripcion_Muy_Larga()
        {
            var instancia = new Controlador();
            var resultado = instancia.agregarProducto("Sistema De Control De Plagas Riddex", "Deja atrás los productos químicos que tanto daño causan a tu salud así como las molestas trampas que tienes que colocar y retirar con frecuencia para eliminar esos bichos, insectos y roedores que asechan tu hogar, pues desde ahora deshacerte de ellos será muy fácil con ayuda del Riddex Plus.Sólo basta conectar este Riddex Plus a la red eléctrica del hogar para que comience a producir ondas eléctricas, las cuales serán un escudo eficaz para mantener todos los espacios de tu hogar libres de estos huéspedes incómodos.", "4500");
            Assert.AreEqual(resultado, Descripcion_Muy_Larga);

        }

        [Test]

        public void agregarProducto_DatosVacios_ReturnsDatos_Vacios()
        {
            var instancia = new Controlador();
            var resultado = instancia.agregarProducto("","","");
            Assert.AreEqual(resultado, Datos_Vacios);

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
