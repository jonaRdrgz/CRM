/**
 *	Clase Tests_Manejo_Contactos
 *	
 *	Version 1.0
 *	
 *	22/10/2017
 *
 *	Jonathan Rodríguez
 *	Melissa Molina Corrales
 *	Edwin Cen Xu
 */

using System.Collections.Generic;
using NUnit.Framework;
using CRM_Tests.Fakes;
using CRM_Proyect.Modelo;

namespace CRM_Tests
{
    [TestFixture]

    /**
    *	Clase para realizar pruebas del manejo de contactos en el sistema.
    *
    */
    class Tests_Manejo_Contactos
    {
        [Test]
        public void registrarContactoPersona_AgregarContactoPersona_ReturnsTrue()
        {
            var instancia = new FakeConsulta();
            var resultado = instancia.registarContactoPersona(1);
            Assert.AreEqual(resultado, true);
        }

        [Test]
        public void registrarContactoPersona_AgregarContactoPersonaIncorrecta_ReturnsFalse()
        {
            var instancia = new FakeConsulta();
            var resultado = instancia.registarContactoPersona(3);
            Assert.AreEqual(resultado, false);
        }

        [Test]
        public void registrarContactoEmpresa_AgregarContactoEmpresa_ReturnsTrue()
        {
            var instancia = new FakeConsulta();
            var resultado = instancia.registarContactoEmpresa(1);
            Assert.AreEqual(resultado, true);
        }
        [Test]
        public void registrarContactoEmpresa_AgregarContactoEmpresaIncorrecta_ReturnsFalse()
        {
            var instancia = new FakeConsulta();
            var resultado = instancia.registarContactoEmpresa(3);
            Assert.AreEqual(resultado, false);
        }

        [Test]
        public void borrarContacto_BorrarContactoPersona_ReturnsTrue()
        {
            var instancia = new FakeConsulta();
            var resultado = instancia.borrarContacto(1);
            Assert.AreEqual(resultado, true);

        }

        [Test]
        public void borrarContacto_BorrarContactoPersonaIncorrecta_ReturnsFalse()
        {
            var instancia = new FakeConsulta();
            var resultado = instancia.borrarContacto(4);
            Assert.AreEqual(resultado, false);

        }

        [Test]
        public void borrarContactoEmpresa_BorrarContactoEmpresas_ReturnsTrue()
        {
            var instancia = new FakeConsulta();
            var resultado = instancia.borrarContactoEmpresa(1);
            Assert.AreEqual(resultado, true);

        }
        [Test]
        public void borrarContactoEmpresa_BorrarContactoEmpresasIncorrecta_ReturnsFalse()
        {
            var instancia = new FakeConsulta();
            var resultado = instancia.borrarContactoEmpresa(5);
            Assert.AreEqual(resultado, false);

        }

        [Test]
        public void obtenerContactoPersonas_ObtenerContactosPersonas_ReturnsList()
        {
            var instancia = new FakeConsulta();
            List<Usuario> resultado = instancia.obtenerContactoPersonas();
            Assert.IsNotNull(resultado);

        }

        [Test]
        public void obtenerContactoPersonas_ObtenerContactosPersonasNull_ReturnsListNull()
        {
            var instancia = new FakeConsulta();
            instancia.listaUsuarios = null;
            List<Usuario> resultado = instancia.obtenerContactoPersonas();
            Assert.IsNull(resultado);

        }

        [Test]
        public void obtenerContactoEmpresas_ObtenerContactosEmpresas_ReturnsList()
        {
            var instancia = new FakeConsulta();
            List<Empresa> resultado = instancia.obtenerContactoEmpresas();
            Assert.IsNotNull(resultado);

        }

        [Test]
        public void obtenerContactoEmpresas_ObtenerContactosEmpresasIncorrecta_ReturnsListNull()
        {
            var instancia = new FakeConsulta();
            instancia.listaEmpresas = null;
            List<Empresa> resultado = instancia.obtenerContactoEmpresas();
            Assert.IsNull(resultado);

        }


    }
}
