using NUnit.Framework;
using System;


namespace ProyectoQA.Tests
{
    [TestFixture]
    public class TestRegistroRespuestas
    {
        [TestCase]
        public void verificarDatosRespuesta_RespuestaInvalida_ReturnFalse()
        {
            RegistroRespuestas registroRespuestas = new RegistroRespuestas();
            Assert.AreEqual(false, (registroRespuestas.verificarDatosRespuesta("", "Aceptado", DateTime.Now.ToString())));
        }
        [TestCase]
        public void verificarDatosRespuesta_EstadoVacio_ReturnFalse()
        {
            RegistroRespuestas registroRespuestas = new RegistroRespuestas();
            Assert.AreEqual(false, (registroRespuestas.verificarDatosRespuesta("Buen precio", "", DateTime.Now.ToString())));
        }
        [TestCase]
        public void verificarDatosRespuesta_EstadoInvalido_ReturnFalse()
        {
            RegistroRespuestas registroRespuestas = new RegistroRespuestas();
            Assert.AreEqual(false, (registroRespuestas.verificarDatosRespuesta("Buen precio", "Estado inválido", DateTime.Now.ToString())));
        }
        [TestCase]
        public void verificarDatosRespuesta_FechaInvalida_ReturnFalse()
        {
            RegistroRespuestas registroRespuestas = new RegistroRespuestas();
            Assert.AreEqual(false, (registroRespuestas.verificarDatosRespuesta("Buen precio", "Aceptado", "")));
        }
        [TestCase]
        public void verificarDatosRespuesta_DatosValido_ReturnTrue()
        {
            RegistroRespuestas registroRespuestas = new RegistroRespuestas();
            Assert.AreEqual(true, (registroRespuestas.verificarDatosRespuesta("Buen precio", "Aceptado", DateTime.Now.ToString())));
        }
        [TestCase]
        public void insertarRespuesta_NoException_ReturnTrue()
        {
            IConexion fakeConexion = new FakeConexion(true, true, true, true);
            RegistroRespuestas registroRespuestas = new RegistroRespuestas(fakeConexion);
            Assert.AreEqual(true, (registroRespuestas.insertarRespuesta("No estoy interesado", "Rechazado", DateTime.Now.ToString(), "1")));
        }
        [TestCase]
        public void insertarRespuesta_ThrowException_ReturnFalse()
        {
            IConexion fakeConexion = new FakeConexion(true, true, true, true, true);
            RegistroRespuestas registroRespuestas = new RegistroRespuestas(fakeConexion);
            Assert.AreEqual(false, (registroRespuestas.insertarRespuesta("No estoy interesado", "Rechazado", DateTime.Now.ToString(), "1")));
        }
    }
}