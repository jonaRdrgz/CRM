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
    public class TestRegistroVentas
    {
        [TestCase]
        public void verificarDatosVenta_ProductoInvalido_ReturnFalse()
        {
            IConexion fakeConexion = new FakeConexion(true, true, true, true);
            RegistroVentas registroVentas = new RegistroVentas(fakeConexion);
            Assert.AreEqual(false, (registroVentas.verificarDatosVenta("", "20", "20", DateTime.Now.ToString(), "19")));            
        }
        [TestCase]
        public void verificarDatosVenta_ComisionInvalida_ReturnFalse()
        {
            IConexion fakeConexion = new FakeConexion(true, true, true, true);
            RegistroVentas registroVentas = new RegistroVentas(fakeConexion);
            Assert.AreEqual(false, (registroVentas.verificarDatosVenta("5", "20", "", DateTime.Now.ToString(), "19")));
        }
        [TestCase]
        public void verificarDatosVenta_DescuentoInvalido_ReturnFalse()
        {
            IConexion fakeConexion = new FakeConexion(true, true, true, true);
            RegistroVentas registroVentas = new RegistroVentas(fakeConexion);
            Assert.AreEqual(false, (registroVentas.verificarDatosVenta("5", "", "20", DateTime.Now.ToString(), "19")));
        }
        [TestCase]
        public void verificarDatosVenta_FechaInvalida_ReturnFalse()
        {
            IConexion fakeConexion = new FakeConexion(true, true, true, true);
            RegistroVentas registroVentas = new RegistroVentas(fakeConexion);
            Assert.AreEqual(false, (registroVentas.verificarDatosVenta("5", "20", "20", "", "19")));
        }
        [TestCase]
        public void verificarDatosVenta_ContactoInvalida_ReturnFalse()
        {
            IConexion fakeConexion = new FakeConexion(true, true, true, true);
            RegistroVentas registroVentas = new RegistroVentas(fakeConexion);
            Assert.AreEqual(false, (registroVentas.verificarDatosVenta("5", "20", "20", DateTime.Now.ToString(), "")));
        }
        [TestCase]
        public void verificarDatosVenta_DatosValidos_ReturnTrue()
        {
            IConexion fakeConexion = new FakeConexion(true, true, true, true);
            RegistroVentas registroVentas = new RegistroVentas(fakeConexion);
            Assert.AreEqual(true, (registroVentas.verificarDatosVenta("5", "20", "20", DateTime.Now.ToString(), "19")));
        }
        [TestCase]
        public void insertarVenta_NoException_ReturnTrue()
        {
            IConexion fakeConexion = new FakeConexion(true, true, true, true);
            RegistroVentas registroVentas = new RegistroVentas(fakeConexion);
            Assert.AreEqual(true, (registroVentas.insertarVenta("1", "10", "10", DateTime.Now.ToString(), "1", "1")));
        }
        [TestCase]
        public void insertarVenta_ThrowException_ReturnFalse()
        {
            IConexion fakeConexion = new FakeConexion(true, true, true, true, true);
            RegistroVentas registroVentas = new RegistroVentas(fakeConexion);
            Assert.AreEqual(false, (registroVentas.insertarVenta("1", "10", "10", DateTime.Now.ToString(), "1", "1")));
        }
        [TestCase]
        public void crearVistaRegistroVentas_CreaStringContacto_ReturnString()
        {
            IDataReader readerStub = MockRepository.GenerateStub<IDataReader>();
            readerStub.Stub(x => x.Read()).Return(true).Repeat.Times(1);
            for (int i = 0; i < 8; i++)
            {
                readerStub.Stub(x => x[i]).Return(i);
            }
            IConexion fakeConexion = new FakeConexion(true, true, true, true);
            RegistroVentas registroVentas = new RegistroVentas(fakeConexion);
            Assert.AreNotEqual("", registroVentas.crearVistaVenta(readerStub));
        }
        [TestCase]
        public void crearVistaRegistroVentas_NoCreaStringContacto_ReturnStringVacio()
        {
            IDataReader readerStub = MockRepository.GenerateStub<IDataReader>();
            readerStub.Stub(x => x.Read()).Return(false);
            IConexion fakeConexion = new FakeConexion(true, true, true, true);
            RegistroVentas registroVentas = new RegistroVentas(fakeConexion);
            Assert.AreEqual("", registroVentas.crearVistaVenta(readerStub));
        }
        [TestCase]
        public void consultarconsultarVentas_NoException_ReturnTrue()
        {
            HtmlGenericControl fakeTag = MockRepository.GenerateStub<HtmlGenericControl>();
            IConexion fakeConexion = new FakeConexion(true, true, true, false);
            RegistroVentas registroVentas = new RegistroVentas(fakeConexion);
            Assert.AreEqual(true, registroVentas.consultarVentas("1", fakeTag));
        }
        [TestCase]
        public void consultarconsultarVentas_ThrowException_ReturnFalse()
        {
            HtmlGenericControl fakeTag = MockRepository.GenerateStub<HtmlGenericControl>();
            IConexion fakeConexion = new FakeConexion(true, true, true, false, true);
            RegistroVentas registroVentas = new RegistroVentas(fakeConexion);
            Assert.AreEqual(false, registroVentas.consultarVentas("1", fakeTag));
        }
    }
}