using NUnit.Framework;
using Rhino.Mocks;
using System;
using System.Data;
using System.Web.UI.HtmlControls;

namespace ProyectoQA.Tests
{
    [TestFixture]
    public class TestPropuestaVentas
    {
        [TestCase]
        public void verificarDatosPropuesta_ProductoInvalido_ReturnFalse()
        {
            PropuestaVentas propuestaVentas = new PropuestaVentas();
            Assert.AreEqual(false, (propuestaVentas.verificarDatosPropuesta("", "10000", DateTime.Now.ToString(), "19")));
        }
        [TestCase]
        public void verificarDatosPropuesta_PrecioInvalido_ReturnFalse()
        {
            PropuestaVentas propuestaVentas = new PropuestaVentas();
            Assert.AreEqual(false, (propuestaVentas.verificarDatosPropuesta("5", "", DateTime.Now.ToString(), "19")));
        }
        [TestCase]
        public void verificarDatosPropuesta_FechaInvalido_ReturnFalse()
        {
            PropuestaVentas propuestaVentas = new PropuestaVentas();
            Assert.AreEqual(false, (propuestaVentas.verificarDatosPropuesta("5", "10000", "", "19")));
        }
        [TestCase]
        public void verificarDatosPropuesta_ContactoInvalido_ReturnFalse()
        {
            PropuestaVentas propuestaVentas = new PropuestaVentas();
            Assert.AreEqual(false, (propuestaVentas.verificarDatosPropuesta("", "10000", DateTime.Now.ToString(), "")));
        }
        [TestCase]
        public void verificarDatosPropuesta_DatosValidos_ReturnTrue()
        {
            PropuestaVentas propuestaVentas = new PropuestaVentas();
            Assert.AreEqual(true, (propuestaVentas.verificarDatosPropuesta("5", "10000", DateTime.Now.ToString(), "19")));
        }
        [TestCase]
        public void insertarPropuestaVenta_NoException_ReturnTrue()
        {
            IConexion fakeConexion = new FakeConexion(true, true, true, true);
            PropuestaVentas propuestaVentas = new PropuestaVentas(fakeConexion);
            Assert.AreEqual(true, (propuestaVentas.insertarPropuestaVenta("1", "3000", DateTime.Now.ToString(), "1", "1")));
        }
        [TestCase]
        public void insertarPropuestaVenta_ThrowException_ReturnFalse()
        {
            IConexion fakeConexion = new FakeConexion(true, true, true, true, true);
            PropuestaVentas propuestaVentas = new PropuestaVentas(fakeConexion);
            Assert.AreEqual(false, (propuestaVentas.insertarPropuestaVenta("1", "3000", DateTime.Now.ToString(), "1", "1")));
        }
        [TestCase]
        public void crearVistaPropuestaVenta_CreaStringContacto_ReturnString()
        {
            IDataReader readerStub = MockRepository.GenerateStub<IDataReader>();
            readerStub.Stub(x => x.Read()).Return(true).Repeat.Times(1);
            for (int i = 0; i < 8; i++)
            {
                readerStub.Stub(x => x[i]).Return(i);
            }
            IConexion fakeConexion = new FakeConexion(true, true, true, true);
            PropuestaVentas contactoPersona = new PropuestaVentas(fakeConexion);
            Assert.AreNotEqual("", contactoPersona.crearVistaPropuestaVenta(readerStub));
        }
        [TestCase]
        public void crearVistaPropuestaVenta_NoCreaStringContacto_ReturnStringVacio()
        {
            IDataReader readerStub = MockRepository.GenerateStub<IDataReader>();
            readerStub.Stub(x => x.Read()).Return(false);
            IConexion fakeConexion = new FakeConexion(true, true, true, true);
            PropuestaVentas contactoPersona = new PropuestaVentas(fakeConexion);
            Assert.AreEqual("", contactoPersona.crearVistaPropuestaVenta(readerStub));
        }
        [TestCase]
        public void consultarPropuestaVenta_NoException_ReturnTrue()
        {
            HtmlGenericControl fakeTag = MockRepository.GenerateStub<HtmlGenericControl>();
            IConexion fakeConexion = new FakeConexion(true, true, true, false);
            PropuestaVentas propuestaVentas = new PropuestaVentas(fakeConexion);
            Assert.AreEqual(true, propuestaVentas.consultarPropuestaVenta("1", fakeTag));
        }
        [TestCase]
        public void consultarPropuestaVenta_ThrowException_ReturnFalse()
        {
            HtmlGenericControl fakeTag = MockRepository.GenerateStub<HtmlGenericControl>();
            IConexion fakeConexion = new FakeConexion(true, true, true, false, true);
            PropuestaVentas propuestaVentas = new PropuestaVentas(fakeConexion);
            Assert.AreEqual(false, propuestaVentas.consultarPropuestaVenta("22", fakeTag));
        }
    }
}