using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prueba_Programada
{
    public class Calculadora
    {
        int memoria;
        public int Sumar(int a, int b)
        {
            int suma = a + b;
            return suma;
        }
        public int Restar(int a, int b)
        {
            int resta = a - b;
            return resta;
        }
        public int Multiplicar(int a, int b)
        {
            int multi = a * b;
            return multi;
        }
        public int Dividir(int a, int b)
        {

            if (b == 0)
            {
                return -1;
            }
            else
            {
                int divi = a / b;
                return divi;
            }
        }

        public int Salvar_A_Memoria(int a)
        {
            memoria = a;
            return memoria;
        }

        public int Borrar_Memoria()
        {
            memoria = 0;
            return memoria;
        }

        public int Leer_Memoria()
        {
            return memoria;

        }

    }
}
