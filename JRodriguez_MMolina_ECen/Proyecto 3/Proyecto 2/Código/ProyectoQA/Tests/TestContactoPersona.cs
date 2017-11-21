using NUnit.Framework;
using Rhino.Mocks;
using System.Data;
using System.Web.UI.HtmlControls;

namespace ProyectoQA.Tests
{
    [TestFixture]
    public class TestContactoPersona
    {
        [TestCase]
        public void verificarDatosPersona_DatosValidos_ReturnTrue()
        {
            IConexion fakeConexion = new FakeConexion(true, true, true, true);
            ContactoPersonaForm contactoPersona = new ContactoPersonaForm(fakeConexion);
            Assert.AreEqual(true, (contactoPersona.verificarDatosPersona("Jeffrey", "Alvarado", "La trinidad", "86959260",
                                                                          "jefalva10296@gmail.com")));
        }
        [TestCase]
        public void verificarDatosPersona_NombreVacio_ReturnFalse()
        {
            IConexion fakeConexion = new FakeConexion(true, true, true, true);
            ContactoPersonaForm contactoPersona = new ContactoPersonaForm(fakeConexion);
            Assert.AreEqual(false, (contactoPersona.verificarDatosPersona("", "Alvarado", "La trinidad", "86959260",
                                                                          "jefalva10296@gmail.com")));
        }
        [TestCase]
        public void verificarDatosPersona_ApellidoVacio_ReturnFalse()
        {
            IConexion fakeConexion = new FakeConexion(true, true, true, true);
            ContactoPersonaForm contactoPersona = new ContactoPersonaForm(fakeConexion);
            Assert.AreEqual(false, (contactoPersona.verificarDatosPersona("Jeffrey", "", "La trinidad", "86959260",
                                                                          "jefalva10296@gmail.com")));
        }
        [TestCase]
        public void verificarDatosPersona_DireccionVacia_ReturnFalse()
        {
            IConexion fakeConexion = new FakeConexion(true, true, true, true);
            ContactoPersonaForm contactoPersona = new ContactoPersonaForm(fakeConexion);
            Assert.AreEqual(false, (contactoPersona.verificarDatosPersona("Jeffrey", "Alvarado", "", "86959260",
                                                                          "jefalva10296@gmail.com")));
        }
        [TestCase]
        public void verificarDatosPersona_CorreoVacio_ReturnFalse()
        {
            IConexion fakeConexion = new FakeConexion(true, true, true, true);
            ContactoPersonaForm contactoPersona = new ContactoPersonaForm(fakeConexion);
            Assert.AreEqual(false, (contactoPersona.verificarDatosPersona("Jeffrey", "Alvarado", "La trinidad", "86959260",
                                                                          "")));
        }
        [TestCase]
        public void verificarDatosPersona_CorreoInvalido_ReturnFalse()
        {
            IConexion fakeConexion = new FakeConexion(true, true, true, true);
            ContactoPersonaForm contactoPersona = new ContactoPersonaForm(fakeConexion);
            Assert.AreEqual(false, (contactoPersona.verificarDatosPersona("Jeffrey", "Alvarado", "La trinidad", "86959260",
                                                                          "jefalva10296gmail.com")));
        }
        [TestCase]
        public void verificarDatosPersona_TelefonoVacio_ReturnFalse()
        {
            IConexion fakeConexion = new FakeConexion(true, true, true, true);
            ContactoPersonaForm contactoPersona = new ContactoPersonaForm(fakeConexion);
            Assert.AreEqual(false, (contactoPersona.verificarDatosPersona("Jeffrey", "Alvarado", "La trinidad", "",
                                                                          "jefalva10296@gmail.com")));
        }
        [TestCase]
        public void verificarDatosPersona_TelefonoInvalido_ReturnFalse()
        {
            IConexion fakeConexion = new FakeConexion(true, true, true, true);
            ContactoPersonaForm contactoPersona = new ContactoPersonaForm(fakeConexion);
            Assert.AreEqual(false, (contactoPersona.verificarDatosPersona("Jeffrey", "Alvarado", "La trinidad", "666262y2hh27",
                                                                          "jefalva10296@gmail.com")));
        }
        [TestCase]
        public void insertarPersona_NoException_ReturnTrue()
        {
            IConexion fakeConexion = new FakeConexion(true, true, true, true);
            ContactoPersonaForm contactoPersona = new ContactoPersonaForm(fakeConexion);
            Assert.AreEqual(true, (contactoPersona.insertarPersona("Jeffrey", "Alvarado", "Quiros", "86959260",
                                                                    "La trinidad", "ITDesigners", "jefalva10296@gmail.com",
                                                                    "1")));
        }
        [TestCase]
        public void insertarPersona_ThrowException_ReturnFalse()
        {
            IConexion fakeConexion = new FakeConexion(true, true, true, true, true);
            ContactoPersonaForm contactoPersona = new ContactoPersonaForm(fakeConexion);
            Assert.AreEqual(false, (contactoPersona.insertarPersona("Jeffrey", "Alvarado", "Quiros", "86959260",
                                                                    "La trinidad", "ITDesigners", "jefalva10296@gmail.com",
                                                                    "1")));
        }
        [TestCase]
        public void crearVistaContactoPersona_CreaStringContacto_ReturnString()
        {
            IDataReader readerStub = MockRepository.GenerateStub<IDataReader>();
            readerStub.Stub(x => x.Read()).Return(true).Repeat.Times(1);
            for (int i = 0; i < 10; i++)
            {
                readerStub.Stub(x => x[i]).Return(i);
            }
            IConexion fakeConexion = new FakeConexion(true, true, true, true);
            ContactoPersonaForm contactoPersona = new ContactoPersonaForm(fakeConexion);
            Assert.AreNotEqual("", contactoPersona.crearVistaContacto(readerStub));
        }
        [TestCase]
        public void crearVistaContactoPersona_NoCreaStringContacto_ReturnStringVacio()
        {
            IDataReader readerStub = MockRepository.GenerateStub<IDataReader>();
            readerStub.Stub(x => x.Read()).Return(false);
            IConexion fakeConexion = new FakeConexion(true, true, true, true);
            ContactoPersonaForm contactoPersona = new ContactoPersonaForm(fakeConexion);
            Assert.AreEqual("", contactoPersona.crearVistaContacto(readerStub));
        }
        [TestCase]
        public void consultarContactoPersona_NoException_ReturnTrue()
        {
            HtmlGenericControl fakeTag = MockRepository.GenerateStub<HtmlGenericControl>();
            IConexion fakeConexion = new FakeConexion(true, true, true, false);
            ContactoPersonaForm contactoPersona = new ContactoPersonaForm(fakeConexion);
            Assert.AreEqual(true, contactoPersona.consultarContactoPersona("1", fakeTag));
        }
        [TestCase]
        public void consultarContactoPersona_ThrowException_ReturnFalse()
        {
            HtmlGenericControl fakeTag = MockRepository.GenerateStub<HtmlGenericControl>();
            IConexion fakeConexion = new FakeConexion(true, true, true, false, true);
            ContactoPersonaForm contactoPersona = new ContactoPersonaForm(fakeConexion);
            Assert.AreEqual(false, contactoPersona.consultarContactoPersona("1", fakeTag));
        }
    }
}