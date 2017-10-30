/**
 *	Clase Tests_Respuestas_Propuestas_Ventas
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
using System;
using CRM_Tests.Fakes;

namespace CRM_Tests
{
    [TestFixture]

    /**
    *	Clase para realizar pruebas de manejo de respuestas de propuestas de ventas en el sistema.
    *
    */
    class Tests_Respuestas_Propuestas_Ventas
    {
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

