/**
 *	Clase TestRegistrarEstadoReportes
 *	
 *	Version 1.0
 *	
 *	10/11/2017
 *
 *	Jonathan Rodríguez
 *	Melissa Molina Corrales
 *	Edwin Cen Xu
 */

using NUnit.Framework;
using Rhino.Mocks;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI.HtmlControls;
namespace ProyectoQA.Tests
{
    [TestFixture]

    /**
    *	Clase para realizar pruebas de registrar estados de los reportes
    *
    */
    public class TestRegistrarEstadoReportes
    {

        [TestCase]
        public void verificarDatosEstadoReporte_DiagnosticoVacio_ReturnFalse() {
            IConexion fakeConexion = new FakeConexion(true, true, true, true);
            RegistrarEstadoReportes estadoReporte = new RegistrarEstadoReportes(fakeConexion);
            Assert.AreEqual(false, (estadoReporte.verificarDatosEstadoReporte(null, "Rechazado", DateTime.Now.ToString())));
        }

        [TestCase]
        public void verificarDatosEstadoReporte_DiagnosticoNoVacio_ReturnTrue() {
            IConexion fakeConexion = new FakeConexion(true, true, true, true);
            RegistrarEstadoReportes estadoReporte = new RegistrarEstadoReportes(fakeConexion);
            Assert.AreEqual(true, (estadoReporte.verificarDatosEstadoReporte("Revision Completa", "Rechazado", DateTime.Now.ToString())));
        }

        [TestCase]
        public void verificarDatosEstadoReporte_EstadoVacio_ReturnFalse() {
            IConexion fakeConexion = new FakeConexion(true, true, true, true);
            RegistrarEstadoReportes estadoReporte = new RegistrarEstadoReportes(fakeConexion);
            Assert.AreEqual(false, (estadoReporte.verificarDatosEstadoReporte("Revision Completa", null, DateTime.Now.ToString())));
        }

        [TestCase]
        public void verificarDatosEstadoReporte_EstadoNoVacio_ReturnTrue() {
            IConexion fakeConexion = new FakeConexion(true, true, true, true);
            RegistrarEstadoReportes estadoReporte = new RegistrarEstadoReportes(fakeConexion);
            Assert.AreEqual(true, (estadoReporte.verificarDatosEstadoReporte("Revision Completa", "Rechazado", DateTime.Now.ToString())));
        }

        [TestCase]
        public void verificarDatosEstadoReporte_FechaVacio_ReturnFalse() {
            IConexion fakeConexion = new FakeConexion(true, true, true, true);
            RegistrarEstadoReportes estadoReporte = new RegistrarEstadoReportes(fakeConexion);
            Assert.AreEqual(false, (estadoReporte.verificarDatosEstadoReporte("Revision Completa", "Rechazado", null)));
        }

        [TestCase]
        public void verificarDatosEstadoReporte_FechaNoVacio_ReturnTrue() {
            IConexion fakeConexion = new FakeConexion(true, true, true, true);
            RegistrarEstadoReportes estadoReporte = new RegistrarEstadoReportes(fakeConexion);
            Assert.AreEqual(true, (estadoReporte.verificarDatosEstadoReporte("Revision Completa", "Rechazado", DateTime.Now.ToString())));
        }


        [TestCase]
        public void insertarEstadoReporte_NoException_ReturnTrue() {
            IConexion fakeConexion = new FakeConexion(true, true, true, true);
            RegistrarEstadoReportes reporteError = new RegistrarEstadoReportes(fakeConexion);
            Assert.AreEqual(true, (reporteError.insertarEstadoReporte( "Revision","Rechazado", DateTime.Now.ToString(), "1")));
        }

        [TestCase]
        public void insertarEstadoReporte_ThrowException_ReturnFalse() {
            IConexion fakeConexion = new FakeConexion(true, true, true, true, true);
            RegistrarEstadoReportes reporteError = new RegistrarEstadoReportes(fakeConexion);
            Assert.AreEqual(false, (reporteError.insertarEstadoReporte("Revision", "Rechazado", DateTime.Now.ToString(), "1")));
        }

    }
}
