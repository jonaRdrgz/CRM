
using System;
using System.Data;


namespace ProyectoQA
{
    public interface IConexion
    {
        Boolean AbrirConexion();
        Boolean CerrarConexion();
        Boolean setCommandText(String comando);
        IDataReader getResultados();
    }
}
