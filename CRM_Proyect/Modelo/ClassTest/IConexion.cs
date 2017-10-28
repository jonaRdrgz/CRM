using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
namespace CRM_Proyect.Modelo.ClassTest
{
    interface IConexion
    {
        Boolean abrirConexion();
        Boolean cerrarConexion();
        Boolean command(String comando);
        IDataReader obtenerResultados();
    }
}
