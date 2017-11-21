using NUnit.Framework;
using Rhino.Mocks;
using System.Data;
using System.Web.UI.HtmlControls;

namespace ProyectoQA.Tests
{
    [TestFixture]
    public class TestContactoEmpresa
    {
        [TestCase]
        public void verificarDatosEmpresa_NombreVacio_ReturnFalse()
        {
            IConexion fakeConexion = new FakeConexion(true, true, true, true);
            ContactoEmpresaForm contactoEmpresa = new ContactoEmpresaForm(fakeConexion);
            Assert.AreEqual(false, (contactoEmpresa.verificarDatosEmpresa("", "La Trinidad de Moravia", "86959260")));
        }
        [TestCase]
        public void verificarDatosEmpresa_DireccionVacia_ReturnFalse()
        {
            IConexion fakeConexion = new FakeConexion(true, true, true, true);
            ContactoEmpresaForm contactoEmpresa = new ContactoEmpresaForm(fakeConexion);
            Assert.AreEqual(false, (contactoEmpresa.verificarDatosEmpresa("IT Designers", "", "86959260")));
        }
        [TestCase]
        public void verificarDatosEmpresa_TelefonoVacio_ReturnFalse()
        {
            IConexion fakeConexion = new FakeConexion(true, true, true, true);
            ContactoEmpresaForm contactoEmpresa = new ContactoEmpresaForm(fakeConexion);
            Assert.AreEqual(false, (contactoEmpresa.verificarDatosEmpresa("IT Designers", "La Trinidad de Moravia", "")));
        }
        [TestCase]
        public void verificarDatosEmpresa_TelefonoInvalido_ReturnFalse()
        {
            IConexion fakeConexion = new FakeConexion(true, true, true, true);
            ContactoEmpresaForm contactoEmpresa = new ContactoEmpresaForm(fakeConexion);
            Assert.AreEqual(false, (contactoEmpresa.verificarDatosEmpresa("IT Designers", "La Trinidad de Moravia", "qwerty")));
        }
        [TestCase]
        public void insertarEmpresa_NoException_ReturnTrue()
        {
            IConexion fakeConexion = new FakeConexion(true, true, true, true);
            ContactoEmpresaForm contactoEmpresa = new ContactoEmpresaForm(fakeConexion);
            Assert.AreEqual(true, (contactoEmpresa.insertarEmpresa("IT Designers", "La Trinidad de Moravia", "86959260", "1")));
        }
        [TestCase]
        public void insertarEmpresa_ThrowException_ReturnFalse()
        {
            IConexion fakeConexion = new FakeConexion(true, true, true, true, true);
            ContactoEmpresaForm contactoEmpresa = new ContactoEmpresaForm(fakeConexion);
            Assert.AreEqual(false, (contactoEmpresa.insertarEmpresa("IT Designers", "La Trinidad de Moravia", "86959260", "1")));
        }
        [TestCase]
        public void crearVistaContactoEmpresa_CreaStringContacto_ReturnString()
        {
            IDataReader readerStub = MockRepository.GenerateStub<IDataReader>();
            readerStub.Stub(x => x.Read()).Return(true).Repeat.Times(1);
            for (int i = 0; i < 8; i++)
            {
                readerStub.Stub(x => x[i]).Return(i);
            }
            IConexion fakeConexion = new FakeConexion(true, true, true, true);
            ContactoEmpresaForm contactoEmpresa = new ContactoEmpresaForm(fakeConexion);
            Assert.AreNotEqual("", contactoEmpresa.crearVistaContacto(readerStub));
        }
        [TestCase]
        public void crearVistaContactoEmpresa_NoCreaStringContacto_ReturnStringVacio()
        {
            IDataReader readerStub = MockRepository.GenerateStub<IDataReader>();
            readerStub.Stub(x => x.Read()).Return(false);
            IConexion fakeConexion = new FakeConexion(true, true, true, true);
            ContactoEmpresaForm contactoEmpresa = new ContactoEmpresaForm(fakeConexion);
            Assert.AreEqual("", contactoEmpresa.crearVistaContacto(readerStub));
        }
        [TestCase]
        public void consultarContactoEmpresa_NoException_ReturnTrue()
        {
            HtmlGenericControl fakeTag = MockRepository.GenerateStub<HtmlGenericControl>();
            IConexion fakeConexion = new FakeConexion(true, true, true, false);
            ContactoEmpresaForm contactoEmpresa = new ContactoEmpresaForm(fakeConexion);
            Assert.AreEqual(true, contactoEmpresa.consultarContactoEmpresa("1", fakeTag));
        }
        [TestCase]
        public void consultarContactoEmpresa_ThrowException_ReturnFalse()
        {
            HtmlGenericControl fakeTag = MockRepository.GenerateStub<HtmlGenericControl>();
            IConexion fakeConexion = new FakeConexion(true, true, true, false, true);
            ContactoEmpresaForm contactoEmpresa = new ContactoEmpresaForm(fakeConexion);
            Assert.AreEqual(false, contactoEmpresa.consultarContactoEmpresa("1", fakeTag));
        }
    }
}