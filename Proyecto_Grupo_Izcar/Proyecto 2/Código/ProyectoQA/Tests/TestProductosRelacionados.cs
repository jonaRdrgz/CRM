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
    public class TestProductosRelacionados
    {
        [TestCase]
        public void crearVistaContacto_CreaStringProducto_ReturnString()
        {
            IDataReader readerStub = MockRepository.GenerateStub<IDataReader>();
            readerStub.Stub(x => x.Read()).Return(true).Repeat.Times(1);
            for (int i = 0; i < 8; i++)
            {
                readerStub.Stub(x => x[i]).Return(i);
            }
            IConexion fakeConexion = new FakeConexion(true, true, true, true);
            ProductosRelacionados productos = new ProductosRelacionados(fakeConexion);
            Assert.AreNotEqual("", productos.crearVistaProductosRelacionados(readerStub));
        }

        [TestCase]
        public void crearVistaContactoProducto_NoCreaStringProductosRelacionados_ReturnStringVacio()
        {
            IDataReader readerStub = MockRepository.GenerateStub<IDataReader>();
            readerStub.Stub(x => x.Read()).Return(false);
            IConexion fakeConexion = new FakeConexion(true, true, true, true);
            ProductosRelacionados productos = new ProductosRelacionados(fakeConexion);
            Assert.AreEqual("", productos.crearVistaProductosRelacionados(readerStub));
        }
        [TestCase]
        public void consultarProductoRelacionado_NoException_ReturnTrue()
        {
            HtmlGenericControl fakeTag = MockRepository.GenerateStub<HtmlGenericControl>();
            IConexion fakeConexion = new FakeConexion(true, true, true, false);
            ProductosRelacionados productos = new ProductosRelacionados(fakeConexion);
            Assert.AreEqual(true, productos.consultarProductosRelacionados("1", fakeTag));
        }

        [TestCase]
        public void consultarProductoRelacionado_ThrowException_ReturnFalse()
        {
            HtmlGenericControl fakeTag = MockRepository.GenerateStub<HtmlGenericControl>();
            IConexion fakeConexion = new FakeConexion(true, true, true, false, true);
            ProductosRelacionados productos = new ProductosRelacionados(fakeConexion);
            Assert.AreEqual(false, productos.consultarProductosRelacionados("1", fakeTag));
        }
    }
}