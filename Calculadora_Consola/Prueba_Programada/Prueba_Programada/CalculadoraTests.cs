using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Prueba_Programada
{
    [TestFixture]
    public class Tests
    {
        [TestCase]
        public void sumarTest()
        {
       
            var instancia = new Calculadora();
            var resultado1 = instancia.Sumar(10, 10);
            Assert.AreEqual(resultado1, 20);

            var resultado2 = instancia.Sumar(5, 5);
            Assert.AreEqual(resultado2, 10);

            var resultado3 = instancia.Sumar(0, 2);
            Assert.AreEqual(resultado3, 2);

            var resultado4 = instancia.Sumar(0, 0);
            Assert.AreEqual(resultado4, 0);

        }

        [TestCase]

        public void restarTest()
        {
            var instancia = new Calculadora();
            var resultado1 = instancia.Restar(1, 10);
            Assert.AreEqual(resultado1, -9);

            var resultado2 = instancia.Restar(10, 3);
            Assert.AreEqual(resultado2, 7);

            var resultado3 = instancia.Restar(11, 1);
            Assert.AreEqual(resultado3, 10);

            var resultado4 = instancia.Restar(10, 0);
            Assert.AreEqual(resultado4, 10);

            var resultado5 = instancia.Restar(0, 8);
            Assert.AreEqual(resultado5, -8);

        }

        [TestCase]

        public void dividirTest()
        {
            var instancia = new Calculadora();
            var resultado1 = instancia.Dividir(10, 2);
            Assert.AreEqual(resultado1, 5);

            var resultado2 = instancia.Dividir(20, 2);
            Assert.AreEqual(resultado2, 10);

            var resultado3 = instancia.Dividir(10, 0);
            Assert.AreEqual(resultado3, -1);

            var resultado4 = instancia.Dividir(200, 4);
            Assert.AreEqual(resultado4, 50);
        }


        [TestCase]

        public void multiplicarTest()
        {
            var instancia = new Calculadora();
            var resultado1 = instancia.Multiplicar(10, 2);
            Assert.AreEqual(resultado1, 20);

            var resultado2 = instancia.Multiplicar(20, 2);
            Assert.AreEqual(resultado2, 40);

            var resultado3 = instancia.Multiplicar(0, 3);
            Assert.AreEqual(resultado3, 0);

            var resultado4 = instancia.Multiplicar(-2, 4);
            Assert.AreEqual(resultado4, -8);
        }


        [TestCase]

        public void Salvar_A_MemoriaTest()
        {
            var instancia = new Calculadora();
            var suma = instancia.Sumar(10, 5);
            var resultado1 = instancia.Salvar_A_Memoria(suma);
            Assert.AreEqual(resultado1, 15);

            var resta = instancia.Restar(10, 5);
            var resultado2 = instancia.Salvar_A_Memoria(resta);
            Assert.AreEqual(resultado2, 5);

            var multiplicacion = instancia.Multiplicar(10, 2);
            var resultado3 = instancia.Salvar_A_Memoria(multiplicacion);
            Assert.AreEqual(resultado3, 20);

            var dividir = instancia.Dividir(20, 2);
            var resultado4 = instancia.Salvar_A_Memoria(dividir);
            Assert.AreEqual(resultado4, 10);
        }

        [TestCase]

        public void Borrar_MemoriaTest()
        {
            var instancia = new Calculadora();
            var salvar_memoria = instancia.Salvar_A_Memoria(10);
            var resultado1 = instancia.Borrar_Memoria();
            Assert.AreEqual(resultado1, 0);
        }


        [TestCase]
        public void Leer_MemoriaTest()
        {
            var instancia = new Calculadora();
            var salvar_memoria = instancia.Salvar_A_Memoria(30);
            var resultado1 = instancia.Leer_Memoria();
            Assert.AreEqual(resultado1, 30);

        }


    }
}
