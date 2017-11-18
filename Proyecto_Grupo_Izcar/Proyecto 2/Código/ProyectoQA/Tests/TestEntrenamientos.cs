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
    public class TestEntrenamientos
    {
        [TestCase]
        public void crearVistaEntrenamiento_CreaStringEntrenamiento_ReturnString()
        {
            IDataReader readerStub = MockRepository.GenerateStub<IDataReader>();
            readerStub.Stub(x => x.Read()).Return(true).Repeat.Times(1);
            for (int i = 0; i < 8; i++)
            {
                readerStub.Stub(x => x[i]).Return(i);
            }
            IConexion fakeConexion = new FakeConexion(true, true, true, true);
            Entrenamientos entrenamiento = new Entrenamientos(fakeConexion);
            Assert.AreNotEqual("", entrenamiento.crearVistaEntrenamiento(readerStub));
        }

        [TestCase]
        public void crearVistaEntrenamiento_NoCreaStringEntrenamiento_ReturnStringVacio()
        {
            IDataReader readerStub = MockRepository.GenerateStub<IDataReader>();
            readerStub.Stub(x => x.Read()).Return(false);
            IConexion fakeConexion = new FakeConexion(true, true, true, true);
            Entrenamientos entrenamiento = new Entrenamientos(fakeConexion);
            Assert.AreEqual("", entrenamiento.crearVistaEntrenamiento(readerStub));
        }
        [TestCase]
        public void consultarEntrenamiento_NoException_ReturnTrue()
        {
            HtmlGenericControl fakeTag = MockRepository.GenerateStub<HtmlGenericControl>();
            IConexion fakeConexion = new FakeConexion(true, true, true, false);
            Entrenamientos entrenamiento = new Entrenamientos(fakeConexion);
            Assert.AreEqual(true, entrenamiento.consultarEntrenamientos("1", fakeTag));
        }

        [TestCase]
        public void consultarEntrenamiento_ThrowException_ReturnFalse()
        {
            HtmlGenericControl fakeTag = MockRepository.GenerateStub<HtmlGenericControl>();
            IConexion fakeConexion = new FakeConexion(true, true, true, false, true);
            Entrenamientos entrenamiento = new Entrenamientos(fakeConexion);
            Assert.AreEqual(false, entrenamiento.consultarEntrenamientos("1", fakeTag));
        }
    }
}