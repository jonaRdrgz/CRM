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
using CRM_Proyect.Modelo;
using System;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using CRM_Tests.Fakes;

namespace CRM_Tests
{
    [TestFixture]
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

