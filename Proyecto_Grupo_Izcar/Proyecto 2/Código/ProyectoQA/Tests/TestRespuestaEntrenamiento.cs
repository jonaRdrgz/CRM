using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProyectoQA.Tests
{

    [TestFixture]
    public class TestRespuestaEntrenamiento
    {
        [TestCase]
        public void verificarDatosRespuesta_RespuestaInvalida_ReturnFalse()
        {
            RegistroRespuestaEntrenamiento registroRespuestas = new RegistroRespuestaEntrenamiento();
            Assert.AreEqual(false, (registroRespuestas.verificarDatosRespuesta("", "Aceptado", DateTime.Now.ToString())));
        }
        [TestCase]
        public void verificarDatosRespuesta_EstadoVacio_ReturnFalse()
        {
            RegistroRespuestaEntrenamiento registroRespuestas = new RegistroRespuestaEntrenamiento();
            Assert.AreEqual(false, (registroRespuestas.verificarDatosRespuesta("Buen precio", "", DateTime.Now.ToString())));
        }

        [TestCase]
        public void verificarDatosRespuesta_FechaInvalida_ReturnFalse()
        {
            RegistroRespuestaEntrenamiento registroRespuestas = new RegistroRespuestaEntrenamiento();
            Assert.AreEqual(false, (registroRespuestas.verificarDatosRespuesta("Buen precio", "Aceptado", "")));
        }
        [TestCase]
        public void verificarDatosRespuesta_DatosValido_ReturnTrue()
        {
            RegistroRespuestaEntrenamiento registroRespuestas = new RegistroRespuestaEntrenamiento();
            Assert.AreEqual(true, (registroRespuestas.verificarDatosRespuesta("Buen precio", "Aceptado", DateTime.Now.ToString())));
        }
        [TestCase]
        public void insertarRespuesta_NoException_ReturnTrue()
        {
            IConexion fakeConexion = new FakeConexion(true, true, true, true);
            RegistroRespuestaEntrenamiento registroRespuestas = new RegistroRespuestaEntrenamiento(fakeConexion);
            Assert.AreEqual(true, (registroRespuestas.insertarRespuesta("No estoy interesado", "Rechazado", DateTime.Now.ToString(), "1", "1")));
        }
        [TestCase]
        public void insertarRespuesta_ThrowException_ReturnFalse()
        {
            IConexion fakeConexion = new FakeConexion(true, true, true, true, true);
            RegistroRespuestaEntrenamiento registroRespuestas = new RegistroRespuestaEntrenamiento(fakeConexion);
            Assert.AreEqual(false, (registroRespuestas.insertarRespuesta("No estoy interesado", "Rechazado", DateTime.Now.ToString(), "1", "1")));
        }
    }
}