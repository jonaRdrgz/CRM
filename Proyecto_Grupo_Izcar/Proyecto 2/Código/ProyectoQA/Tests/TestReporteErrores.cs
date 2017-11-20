using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProyectoQA.Tests
{
    [TestFixture]
    public class TestReporteErrores
    {
        [TestCase]
        public void verificarDatosReporte_NombreProductoVacio_ReturnFalse()
        {
            ReporteErrores reporteError = new ReporteErrores();
            Assert.AreEqual(false, (reporteError.verificarDatosReporte("", "Aceptado", DateTime.Now.ToString(), "juan@gmail.com")));
        }

        [TestCase]
        public void verificarDatosReporte_NombreProductoNoVacio_ReturnTrue()
        {
            ReporteErrores reporteError = new ReporteErrores();
            Assert.AreEqual(true, (reporteError.verificarDatosReporte("1", "Aceptado", DateTime.Now.ToString(), "juan@gmail.com")));
        }


        [TestCase]
        public void verificarDatosReporte_NombreUsuarioVacio_ReturnFalse()
        {
            ReporteErrores reporteError = new ReporteErrores();
            Assert.AreEqual(false, (reporteError.verificarDatosReporte("1", "Aceptado", DateTime.Now.ToString(), "")));
        }

        [TestCase]
        public void verificarDatosReporte_NombreUsuarioNoVacio_ReturnTrue()
        {
            ReporteErrores reporteError = new ReporteErrores();
            Assert.AreEqual(true, (reporteError.verificarDatosReporte("1", "Aceptado", DateTime.Now.ToString(), "juan@gmail.com")));
        }

        [TestCase]
        public void verificarDatosReporte_DescripcionVacio_ReturnFalse()
        {
            ReporteErrores reporteError = new ReporteErrores();
            Assert.AreEqual(false, (reporteError.verificarDatosReporte("1", "", DateTime.Now.ToString(), "juan@gmail.com")));
        }

        [TestCase]
        public void verificarDatosReporte_DescripcionNoVacio_ReturnFalse()
        {
            ReporteErrores reporteError = new ReporteErrores();
            Assert.AreEqual(true, (reporteError.verificarDatosReporte("1", "Aceptado", DateTime.Now.ToString(), "juan@gmail.com")));
        }

        //[TestCase]
        //public void insertarReporteError_EnviarReporteError_ReturnTrue()
        //{
            //ReporteErrores reporteError = new ReporteErrores();
            //Assert.AreEqual(true, (insertarReporteError("1", "Aceptado", DateTime.Now.ToString(), "juan@gmail.com")));
        //}

    }
}