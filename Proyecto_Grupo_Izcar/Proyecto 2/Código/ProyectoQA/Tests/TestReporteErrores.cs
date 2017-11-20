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
    public class TestReporteErrores
    {
        [TestCase]
        public void verificarDatosReporte_NombreVacio_ReturnFalse()
        {
            IConexion fakeConexion = new FakeConexion(true, true, true, true);
            ReporteErrores reporteError = new ReporteErrores(fakeConexion);
            Assert.AreEqual(false, (reporteError.verificarDatosReporte("", "Error 1", DateTime.Now.ToString(), "juan@gmail.com")));
        }
        [TestCase]
        public void verificarDatosReporte_DescripcionVacia_ReturnFalse()
        {
            IConexion fakeConexion = new FakeConexion(true, true, true, true);
            ReporteErrores reporteError = new ReporteErrores(fakeConexion);
            Assert.AreEqual(false, (reporteError.verificarDatosReporte("1", "", DateTime.Now.ToString(), "juan@gmail.com")));
        }
        [TestCase]
        public void verificarDatosReporte_FechaVacio_ReturnFalse()
        {
            IConexion fakeConexion = new FakeConexion(true, true, true, true);
            ReporteErrores reporteError = new ReporteErrores(fakeConexion);
            Assert.AreEqual(false, (reporteError.verificarDatosReporte("1", "Error 1", "", "juan@gmail.com")));
        }
        [TestCase]
        public void verificarDatosReporte_UsuarioInvalido_ReturnFalse()
        {
            IConexion fakeConexion = new FakeConexion(true, true, true, true);
            ReporteErrores reporteError = new ReporteErrores(fakeConexion);
            Assert.AreEqual(false, (reporteError.verificarDatosReporte("1", "Error 1", DateTime.Now.ToString(), "")));
        }
        [TestCase]
        public void insertarReporte_NoException_ReturnTrue()
        {
            IConexion fakeConexion = new FakeConexion(true, true, true, true);
            ReporteErrores reporteError = new ReporteErrores(fakeConexion);
            Assert.AreEqual(true, (reporteError.insertarReporteError("1","Error 1", DateTime.Now.ToString(), "juan@gmail.com","1","1")));
        }
        [TestCase]
        public void insertarReporte_ThrowException_ReturnFalse()
        {
            IConexion fakeConexion = new FakeConexion(true, true, true, true, true);
            ReporteErrores reporteError = new ReporteErrores(fakeConexion);
            Assert.AreEqual(false, (reporteError.insertarReporteError("1", "Error 1", DateTime.Now.ToString(), "juan@gmail.com", "1", "1")));
        }
        [TestCase]
        public void crearVistaReporte_CreaStringReporte_ReturnString()
        {
            IDataReader readerStub = MockRepository.GenerateStub<IDataReader>();
            readerStub.Stub(x => x.Read()).Return(true).Repeat.Times(1);
            for (int i = 0; i < 8; i++)
            {
                readerStub.Stub(x => x[i]).Return(i);
            }
            IConexion fakeConexion = new FakeConexion(true, true, true, true);
            ReporteErrores reporteError = new ReporteErrores(fakeConexion);
            Assert.AreNotEqual("", reporteError.crearVistaReporteError(readerStub));
        }
        [TestCase]
        public void crearVistaReporte_NoCreaStringReporte_ReturnStringVacio()
        {
            IDataReader readerStub = MockRepository.GenerateStub<IDataReader>();
            readerStub.Stub(x => x.Read()).Return(false);
            IConexion fakeConexion = new FakeConexion(true, true, true, true);
            ReporteErrores reporteError = new ReporteErrores(fakeConexion);
            Assert.AreEqual("", reporteError.crearVistaReporteError(readerStub));
        }
        [TestCase]
        public void consultarReporte_NoException_ReturnTrue()
        {
            HtmlGenericControl fakeTag = MockRepository.GenerateStub<HtmlGenericControl>();
            IConexion fakeConexion = new FakeConexion(true, true, true, false);
            ReporteErrores reporteError = new ReporteErrores(fakeConexion);
            Assert.AreEqual(true, reporteError.consultarReportes("1", fakeTag));
        }
        [TestCase]
        public void consultarReporte_ThrowException_ReturnFalse()
        {
            HtmlGenericControl fakeTag = MockRepository.GenerateStub<HtmlGenericControl>();
            IConexion fakeConexion = new FakeConexion(true, true, true, false, true);
            ReporteErrores reporteError = new ReporteErrores(fakeConexion);
            Assert.AreEqual(false, reporteError.consultarReportes("1", fakeTag));
        }

    }
}