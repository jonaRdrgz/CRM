using System.Collections.Generic;
using NUnit.Framework;


namespace CRM_Tests
{
    [TestFixture]
    class Tests_Manejo_Contactos
    {
        [Test]
        public void registrarContactoPersona_AgregarContactoPersona_ReturnsTrue()
        {
            var instancia = new Consulta();
            instancia.setIdUsuarioActual(1);
            var resultado = instancia.registarContactoPersona(1);
            Assert.AreEqual(resultado, true);
        }

        [Test]
        public void registrarContactoEmpresa_AgregarContactoEmpresa_ReturnsTrue()
        {
            var instancia = new Consulta();
            instancia.setIdUsuarioActual(1);
            var resultado = instancia.registarContactoEmpresa(2);
            Assert.AreEqual(resultado, true);

        }
        [Test]
        public void borrarContacto_BorrarContactoPersona_ReturnsTrue()
        {
            var instancia = new Consulta();
            instancia.setIdUsuarioActual(1);
            var resultado = instancia.borrarContacto(2);
            Assert.AreEqual(resultado, true);

        }

        [Test]
        public void borrarContactoEmpresa_BorrarContactoEmpresas_ReturnsTrue()
        {
            var instancia = new Consulta();
            instancia.setIdUsuarioActual(1);
            var resultado = instancia.borrarContactoEmpresa(2);
            Assert.AreEqual(resultado, true);

        }

        [Test]

        public void obtenerContactoPersonas_ObtenerContactosPersonas_ReturnsList<Usuario>()
        {
            var instancia = new Consulta();
            var resultado = instancia.obtenerContactoPersonas();
            List<Usuario> lista = new List<Usuario>();
            Assert.IsNotNull(resultado);

        }

        [Test]

        public void obtenerContactoEmpresas_ObtenerContactosEmpresas_ReturnsList<Empresa>()
        {
            var instancia = new Consulta();
            var resultado = instancia.obtenerContactoEmpresas();
            List<Empresa> lista = new List<Empresa>();
            Assert.IsNotNull(resultado);

        }


    }
}
