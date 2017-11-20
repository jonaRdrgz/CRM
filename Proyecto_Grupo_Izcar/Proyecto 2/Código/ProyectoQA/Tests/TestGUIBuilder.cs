using NUnit.Framework;
using ProyectoQA.Classes;
using Rhino.Mocks;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace ProyectoQA.Tests
{
    [TestFixture]
    public class TestGUIBuilder
    {
        [TestCase]
        public void inyectarHTML_CambiaTag()
        {
            HtmlGenericControl fakeTag = MockRepository.GenerateStub<HtmlGenericControl>();
            GUIBuilder.inyectarHTML("Test", fakeTag);
            Assert.AreEqual("Test", (fakeTag.InnerHtml));
        }
        [TestCase]
        public void getProductos_UnaRepeticion_ReturnList()
        {
            IConexion fakeConexion = new FakeConexion(true, true, true, true);
            List<KeyValuePair<String, String>> resultados = GUIBuilder.getProductos(fakeConexion);
            Assert.AreEqual(1, (resultados.Count));
        }
        [TestCase]
        public void getProductos_NoRepeticion_ReturnEmptyList()
        {
            IConexion fakeConexion = new FakeConexion(true, true, true, false);
            List<KeyValuePair<String, String>> resultados = GUIBuilder.getProductos(fakeConexion);
            Assert.AreEqual(0, (resultados.Count));
        }
        [TestCase]
        public void getProductos_ThrowsExeption()
        {
            IConexion fakeConexion = new FakeConexion(true, true, true, true, true);
            Assert.Catch<Exception>(() => GUIBuilder.getProductos(fakeConexion));
        }
        [TestCase]
        public void getPersonas_UnaRepeticion_ReturnList()
        {
            IConexion fakeConexion = new FakeConexion(true, true, true, true);
            List<KeyValuePair<String, String>> resultados = GUIBuilder.getPersonas("1", fakeConexion);
            Assert.AreEqual(1, (resultados.Count));
        }
        [TestCase]
        public void getPersonas_NoRepeticion_ReturnEmptyList()
        {
            IConexion fakeConexion = new FakeConexion(true, true, true, false);
            List<KeyValuePair<String, String>> resultados = GUIBuilder.getPersonas("1", fakeConexion);
            Assert.AreEqual(0, (resultados.Count));
        }
        [TestCase]
        public void getPersonas_ThrowsExeption()
        {
            IConexion fakeConexion = new FakeConexion(true, true, true, true, true);
            Assert.Catch<Exception>(() => GUIBuilder.getPersonas("1", fakeConexion));
        }
        [TestCase]
        public void getEmpresas_UnaRepeticion_ReturnList()
        {
            IConexion fakeConexion = new FakeConexion(true, true, true, true);
            List<KeyValuePair<String, String>> resultados = GUIBuilder.getEmpresas("1", fakeConexion);
            Assert.AreEqual(1, (resultados.Count));
        }
        [TestCase]
        public void getEmpresas_NoRepeticion_ReturnEmptyList()
        {
            IConexion fakeConexion = new FakeConexion(true, true, true, false);
            List<KeyValuePair<String, String>> resultados = GUIBuilder.getEmpresas("1", fakeConexion);
            Assert.AreEqual(0, (resultados.Count));
        }
        [TestCase]
        public void getEmpresas_ThrowsExeption()
        {
            IConexion fakeConexion = new FakeConexion(true, true, true, true, true);
            Assert.Catch<Exception>(() => GUIBuilder.getEmpresas("1", fakeConexion));
        }
        [TestCase]
        public void getContactos_UnaRepeticion_ReturnList()
        {
            IConexion fakeConexion = new FakeConexion(true, true, true, true);
            List<KeyValuePair<String, String>> resultados = GUIBuilder.getContactos("1", fakeConexion);
            Assert.AreEqual(2, (resultados.Count));
        }
        [TestCase]
        public void getContactos_NoRepeticion_ReturnEmptyList()
        {
            IConexion fakeConexion = new FakeConexion(true, true, true, false);
            List<KeyValuePair<String, String>> resultados = GUIBuilder.getContactos("1", fakeConexion);
            Assert.AreEqual(0, (resultados.Count));
        }
        [TestCase]
        public void getContactos_ThrowsExeption()
        {
            IConexion fakeConexion = new FakeConexion(true, true, true, true, true);
            Assert.Catch<Exception>(() => GUIBuilder.getContactos("1", fakeConexion));
        }
        [TestCase]
        public void crearVistaPropuestaVentaXContacto_NoData_ReturnEmptyString()
        {
            IDataReader readerStub = MockRepository.GenerateStub<IDataReader>();
            readerStub.Stub(x => x.Read()).Return(false);
            String vista = GUIBuilder.crearVistaPropuestaVentaXContacto(readerStub);
            Assert.AreEqual("", vista);
        }
        [TestCase]
        public void crearVistaPropuestaVentaXContacto_Data_ReturnString()
        {
            IDataReader readerStub = MockRepository.GenerateStub<IDataReader>();
            for (int i = 0; i < 10; i++)
            {
                readerStub.Stub(x => x[i]).Return(i);
            }
            readerStub.Stub(x => x.Read()).Return(true).Repeat.Times(1);
            String vista = GUIBuilder.crearVistaPropuestaVentaXContacto(readerStub);
            Assert.AreNotEqual("", vista);
        }
        [TestCase]
        public void crearVistaVentaXContacto_NoData_ReturnEmptyString()
        {
            IDataReader readerStub = MockRepository.GenerateStub<IDataReader>();
            readerStub.Stub(x => x.Read()).Return(false);
            String vista = GUIBuilder.crearVistaVentaXContacto(readerStub);
            Assert.AreEqual("", vista);
        }
        [TestCase]
        public void crearVistaVentaXContacto_Data_ReturnString()
        {
            IDataReader readerStub = MockRepository.GenerateStub<IDataReader>();
            for (int i = 0; i < 10; i++)
            {
                readerStub.Stub(x => x[i]).Return(i);
            }
            readerStub.Stub(x => x.Read()).Return(true).Repeat.Times(1);
            String vista = GUIBuilder.crearVistaVentaXContacto(readerStub);
            Assert.AreNotEqual("", vista);
        }
        [TestCase]
        public void propuestaVentaXContacto_NoData_ReturnEmptyString()
        {
            IConexion fakeConexion = new FakeConexion(true, true, true, false);
            String propuestaVentaXContacto = GUIBuilder.propuestaVentaXContacto(1, "1", fakeConexion);
            Assert.AreEqual("", propuestaVentaXContacto);
        }
        [TestCase]
        public void propuestaVentaXContacto_Data_ReturnString()
        {
            IConexion fakeConexion = new FakeConexion(true, true, true, true);
            String propuestaVentaXContacto = GUIBuilder.propuestaVentaXContacto(1, "1", fakeConexion);
            Assert.AreNotEqual("", propuestaVentaXContacto);
        }
        [TestCase]
        public void propuestaVentaXContacto_ThrowsExeption()
        {
            IConexion fakeConexion = new FakeConexion(true, true, true, true, true);
            Assert.Catch<Exception>(() => GUIBuilder.propuestaVentaXContacto(1, "1", fakeConexion));
        }
        [TestCase]
        public void ventaXContacto_NoData_ReturnEmptyString()
        {
            IConexion fakeConexion = new FakeConexion(true, true, true, false);
            String ventaXContacto = GUIBuilder.ventaXContacto(1, "1", fakeConexion);
            Assert.AreEqual("", ventaXContacto);
        }
        [TestCase]
        public void ventaXContacto_Data_ReturnString()
        {
            IConexion fakeConexion = new FakeConexion(true, true, true, true);
            String ventaXContacto = GUIBuilder.ventaXContacto(1, "1", fakeConexion);
            Assert.AreNotEqual("", ventaXContacto);
        }
        [TestCase]
        public void ventaXContacto_ThrowsExeption()
        {
            IConexion fakeConexion = new FakeConexion(true, true, true, true, true);
            Assert.Catch<Exception>(() => GUIBuilder.ventaXContacto(1, "1", fakeConexion));
        }
        [TestCase]
        public void getVendedores_UnaRepeticion_ReturnList()
        {
            IConexion fakeConexion = new FakeConexion(true, true, true, true);
            List<KeyValuePair<String, String>> resultados = GUIBuilder.getVendedores(fakeConexion);
            Assert.AreEqual(1, (resultados.Count));
        }
        [TestCase]
        public void getVendedores_NoRepeticion_ReturnEmptyList()
        {
            IConexion fakeConexion = new FakeConexion(true, true, true, false);
            List<KeyValuePair<String, String>> resultados = GUIBuilder.getVendedores(fakeConexion);
            Assert.AreEqual(0, (resultados.Count));
        }
        [TestCase]
        public void getVendedores_ThrowsExeption()
        {
            IConexion fakeConexion = new FakeConexion(true, true, true, true, true);
            Assert.Catch<Exception>(() => GUIBuilder.getVendedores(fakeConexion));
        }
    }
}