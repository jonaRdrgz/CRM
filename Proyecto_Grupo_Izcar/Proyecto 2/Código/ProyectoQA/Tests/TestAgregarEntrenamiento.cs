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
    public class TestAgregarEntrenamiento
    {
        [TestCase]
        public void verificarDatosEntrenamiento_NombreVacio_ReturnFalse()
        {
            IConexion fakeConexion = new FakeConexion(true, true, true, true);
            AgregarEntrenamiento entrenamiento = new AgregarEntrenamiento(fakeConexion);
            Assert.AreEqual(false, (entrenamiento.verificarDatosEntrenamiento("", DateTime.Now.ToString(),"9:00 am", "11:00 am", "La Trinidad de Moravia", "1")));
        }
        [TestCase]
        public void verificarDatosEntrenamiento_FechaVacia_ReturnFalse()
        {
            IConexion fakeConexion = new FakeConexion(true, true, true, true);
            AgregarEntrenamiento entrenamiento = new AgregarEntrenamiento(fakeConexion);
            Assert.AreEqual(false, (entrenamiento.verificarDatosEntrenamiento("Nombre", "", "9:00 am", "11:00 am", "La Trinidad de Moravia", "1")));
        }
        [TestCase]
        public void verificarDatosEntrenamiento_HoraInicioVacia_ReturnFalse()
        {
            IConexion fakeConexion = new FakeConexion(true, true, true, true);
            AgregarEntrenamiento entrenamiento = new AgregarEntrenamiento(fakeConexion);
            Assert.AreEqual(false, (entrenamiento.verificarDatosEntrenamiento("Nombre", DateTime.Now.ToString(), "", "11:00 am", "La Trinidad de Moravia", "1")));
        }
        [TestCase]
        public void verificarDatosEntrenamiento_HoraFinVacia_ReturnFalse()
        {
            IConexion fakeConexion = new FakeConexion(true, true, true, true);
            AgregarEntrenamiento entrenamiento = new AgregarEntrenamiento(fakeConexion);
            Assert.AreEqual(false, (entrenamiento.verificarDatosEntrenamiento("Nombre", DateTime.Now.ToString(), "9:00am", "", "La Trinidad de Moravia", "1")));
        }
        [TestCase]
        public void verificarDatosEntrenamiento_HoraUbicacionVacia_ReturnFalse()
        {
            IConexion fakeConexion = new FakeConexion(true, true, true, true);
            AgregarEntrenamiento entrenamiento = new AgregarEntrenamiento(fakeConexion);
            Assert.AreEqual(false, (entrenamiento.verificarDatosEntrenamiento("Nombre", DateTime.Now.ToString(), "9:00am", "11:00", "", "1")));
        }

        [TestCase]
        public void insertarEntrenamiento_NoException_ReturnTrue()
        {
            IConexion fakeConexion = new FakeConexion(true, true, true, true);
            AgregarEntrenamiento entrenamiento = new AgregarEntrenamiento(fakeConexion);
            Assert.AreEqual(true, (entrenamiento.insertarEntrenamiento("Nombre", DateTime.Now.ToString(), "9:00am", "11:00", "12:00", "1")));
        }
        [TestCase]
        public void insertarEntrenamiento_ThrowException_ReturnFalse()
        {
            IConexion fakeConexion = new FakeConexion(true, true, true, true, true);
            AgregarEntrenamiento entrenamiento = new AgregarEntrenamiento(fakeConexion);
            Assert.AreEqual(false, (entrenamiento.insertarEntrenamiento("Nombre", DateTime.Now.ToString(), "9:00am", "11:00", "12:00", "1")));
        }
        [TestCase]
        public void crearVistaEntrenamientos_CreaStringEntrenamiento_ReturnString()
        {
            IDataReader readerStub = MockRepository.GenerateStub<IDataReader>();
            readerStub.Stub(x => x.Read()).Return(true).Repeat.Times(1);
            for (int i = 0; i < 8; i++)
            {
                readerStub.Stub(x => x[i]).Return(i);
            }
            IConexion fakeConexion = new FakeConexion(true, true, true, true);
            AgregarEntrenamiento entrenamiento = new AgregarEntrenamiento(fakeConexion);
            Assert.AreNotEqual("", entrenamiento.crearVistaEntrenamiento(readerStub));
        }

        [TestCase]
        public void crearVistaEntrenameiento_NoCreaStringEntrenamiento_ReturnStringVacio()
        {
            IDataReader readerStub = MockRepository.GenerateStub<IDataReader>();
            readerStub.Stub(x => x.Read()).Return(false);
            IConexion fakeConexion = new FakeConexion(true, true, true, true);
            AgregarEntrenamiento entrenamiento = new AgregarEntrenamiento(fakeConexion);
            Assert.AreNotEqual("", entrenamiento.crearVistaEntrenamiento(readerStub));
        }
        [TestCase]
        public void consultarEntrenamiento_NoException_ReturnTrue()
        {
            HtmlGenericControl fakeTag = MockRepository.GenerateStub<HtmlGenericControl>();
            IConexion fakeConexion = new FakeConexion(true, true, true, false);
            AgregarEntrenamiento entrenamiento = new AgregarEntrenamiento(fakeConexion);
            Assert.AreEqual(true, entrenamiento.consultarEntrenamientos("1", fakeTag));
        }
        [TestCase]
        public void consultarEntrenamiento_ThrowException_ReturnFalse()
        {
            HtmlGenericControl fakeTag = MockRepository.GenerateStub<HtmlGenericControl>();
            IConexion fakeConexion = new FakeConexion(true, true, true, false, true);
            AgregarEntrenamiento entrenamiento = new AgregarEntrenamiento(fakeConexion);
            Assert.AreEqual(true, entrenamiento.consultarEntrenamientos("1", fakeTag));
        }
    }
}