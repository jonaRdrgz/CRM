using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProyectoQA.Tests
{
    [TestFixture]
    public class TestRegistrarEstadoReportes
    {

        [TestCase]
        public void verificarDatosEstadoReporte_DiagnosticoVacio_ReturnFalse()
        {
            RegistrarEstadoReportes estadoReporte = new RegistrarEstadoReportes();
            Assert.AreEqual(false, (estadoReporte.verificarDatosEstadoReporte(null, "Rechazado", DateTime.Now.ToString())));
        }

        [TestCase]
        public void verificarDatosEstadoReporte_DiagnosticoNoVacio_ReturnTrue()
        {
            RegistrarEstadoReportes estadoReporte = new RegistrarEstadoReportes();
            Assert.AreEqual(true, (estadoReporte.verificarDatosEstadoReporte("Revision Completa", "Rechazado", DateTime.Now.ToString())));
        }

        [TestCase]
        public void verificarDatosEstadoReporte_EstadoVacio_ReturnFalse()
        {
            RegistrarEstadoReportes estadoReporte = new RegistrarEstadoReportes();
            Assert.AreEqual(false, (estadoReporte.verificarDatosEstadoReporte("Revision Completa", null, DateTime.Now.ToString())));
        }

        [TestCase]
        public void verificarDatosEstadoReporte_EstadoVacio_ReturnTrue()
        {
            RegistrarEstadoReportes estadoReporte = new RegistrarEstadoReportes();
            Assert.AreEqual(true, (estadoReporte.verificarDatosEstadoReporte("Revision Completa", "Rechazado", DateTime.Now.ToString())));
        }

        [TestCase]
        public void verificarDatosEstadoReporte_FechaVacio_ReturnFalse()
        {
            RegistrarEstadoReportes estadoReporte = new RegistrarEstadoReportes();
            Assert.AreEqual(false, (estadoReporte.verificarDatosEstadoReporte("Revision Completa", "Rechazado", null)));
        }

        [TestCase]
        public void verificarDatosEstadoReporte_FechaNoVacio_ReturnTrue()
        {
            RegistrarEstadoReportes estadoReporte = new RegistrarEstadoReportes();
            Assert.AreEqual(true, (estadoReporte.verificarDatosEstadoReporte("Revision Completa", "Rechazado", DateTime.Now.ToString())));
        }


        public void insertarEstadoReporte_RegistrarEstado_ReturnTrue()
        {
            RegistrarEstadoReportes estadoReporte = new RegistrarEstadoReportes();
            Assert.AreEqual(true, (estadoReporte.insertarEstadoReporte("Revision Completa", "Rechazado", DateTime.Now.ToString(),"1")));
        }

    }
}