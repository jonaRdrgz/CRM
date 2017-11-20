using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProyectoQA.Classes
{
    public class FakePuntosdeContacto : IPuntosContacto
    {

        public List<Usuario> listaVendedores = new List<Usuario>();

        public List<Usuario> consultarVendedores()
        {
            return listaVendedores;
        }
    }
}