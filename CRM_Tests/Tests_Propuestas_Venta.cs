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
    class Tests_Propuestas_Venta
    {
        private int EXITO_DE_INSERCION = 0;

        [Test]

        public void insertarProductoAPropuesta_InsertarProductoAPropuesta_ReturnsEXITO_DE_INSERCION()
        {
            var instancia = new ConsultaPropuestaVenta();
            var resultado = instancia.insertarProductoAPropuesta(2);
            Assert.AreEqual(resultado, EXITO_DE_INSERCION);

        }

        [Test]

        public void crearPropuestaVenta_CrearPropuestaDeVenta_ReturnsEXITO_DE_INSERCION()
        {
            var instancia = new ConsultaPropuestaVenta();
            var resultado = instancia.crearPropuestaVenta("5500", "25%", "6%");
            Assert.AreEqual(resultado, EXITO_DE_INSERCION);

        }

        [Test]

        public void verificarNumeroProductosCarrito_VerificarNumeroProductosCarrito_ReturnsTrue()
        {
            var instancia = new ConsultaPropuestaVenta();
            var resultado = instancia.verificarNumeroProductosCarrito();
            Assert.AreEqual(resultado, true);

        }

        [Test]

        public void obtenerPropuestasVenta_ObtenerPropuestasDeVenta_ReturnsList<PropuestasVenta>()
        {
            var instancia = new ConsultaPropuestaVenta();
            List<PropuestasVenta> lista = new List<PropuestasVenta>();
            var resultado = instancia.obtenerPropuestasVenta();
            Assert.IsNotNull(resultado);

        }

        [Test]

        public void verProductosPropuesta_VerProductosPropuesta_ReturnsList<Producto>()
        {
            var instancia = new ConsultaPropuestaVenta();
            List<Producto> lista = new List<Producto>();
            var resultado = instancia.verProductosPropuesta(3);
            Assert.IsNotNull(resultado);

        }

        /*Pruebas comentarios de propuestas de ventas*/

        [Test]

        public void verComentariosPropuesta_VerComentariosPropuesta_ReturnsList<Comentario>()
        {
            var instancia = new ConsultaComentario();
            List<Comentario> lista = new List<Comentario>();
            var resultado = instancia.verComentariosPropuesta(1);
            Assert.IsNotNull(resultado);

        }

        [Test]

        public void verComentariosEmpresasPropuesta_VerComentariosEmpresasPropuesta_ReturnsList<Comentario>()
        {
            var instancia = new ConsultaComentario();
            List<Comentario> lista = new List<Comentario>();
            var resultado = instancia.verComentariosEmpresasPropuesta(2);
            Assert.IsNotNull(resultado);

        }

    }
}

