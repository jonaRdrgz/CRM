﻿/**
 *	Clase TestPuntosContacto
 *	
 *	Version 1.0
 *	
 *	10/11/2017
 *
 *	Jonathan Rodríguez
 *	Melissa Molina Corrales
 *	Edwin Cen Xu
 */

using NUnit.Framework;
using Rhino.Mocks;
using System.Data;
using System.Web.UI.HtmlControls;

namespace ProyectoQA.Tests
{
    [TestFixture]

    /**
    *	Clase para realizar pruebas de visualizacion de contactos
    *
    */
    public class TestPuntosContacto {
        [TestCase]
        public void crearVistaPuntosContacto_CreaStringContacto_ReturnString() {
            IDataReader readerStub = MockRepository.GenerateStub<IDataReader>();
            readerStub.Stub(x => x.Read()).Return(true).Repeat.Times(1);
            for (int i = 0; i < 8; i++) {
                readerStub.Stub(x => x[i]).Return(i);
            }
            IConexion fakeConexion = new FakeConexion(true, true, true, true);
            PuntosContacto contactoVendedor = new PuntosContacto(fakeConexion);
            Assert.AreNotEqual("", contactoVendedor.crearVistaVendedores(readerStub));
        }

        [TestCase]
        public void crearVistaPuntosDeContacto_NoCreaStringContacto_ReturnStringVacio() {
            IDataReader readerStub = MockRepository.GenerateStub<IDataReader>();
            readerStub.Stub(x => x.Read()).Return(false);
            IConexion fakeConexion = new FakeConexion(true, true, true, true);
            PuntosContacto contactoVendedor = new PuntosContacto(fakeConexion);
            Assert.AreEqual("", contactoVendedor.crearVistaVendedores(readerStub));
        }

        [TestCase]
        public void consultarContactoVendedor_NoException_ReturnTrue() {
            HtmlGenericControl fakeTag = MockRepository.GenerateStub<HtmlGenericControl>();
            IConexion fakeConexion = new FakeConexion(true, true, true, false);
            PuntosContacto contactoVendedor = new PuntosContacto(fakeConexion);
            Assert.AreEqual(true, contactoVendedor.consultarVendedores(fakeTag));
        }

        [TestCase]
        public void consultarContactoVendedor_ThrowException_ReturnFalse() {
            HtmlGenericControl fakeTag = MockRepository.GenerateStub<HtmlGenericControl>();
            IConexion fakeConexion = new FakeConexion(true, true, true, false, true);
            PuntosContacto contactoVendedor = new PuntosContacto(fakeConexion);
            Assert.AreEqual(false, contactoVendedor.consultarVendedores(fakeTag));
        }

    }
}