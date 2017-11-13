using MySql.Data.MySqlClient;
using Rhino.Mocks;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace ProyectoQA
{
    public class FakeConexion : IConexion
    {
        private Boolean resultAbrir;
        private Boolean resultCerrar;
        private Boolean resultCommand;
        private Boolean resultResultados;
        private Boolean throwException = false;

        public FakeConexion(Boolean pResultAbrir, Boolean pResultCerrar, Boolean pResultCommand, Boolean pResultResultados)
        {
            resultAbrir = pResultAbrir;
            resultCerrar = pResultCerrar;
            resultCommand = pResultCommand;
            resultResultados = pResultResultados;
        }

        public FakeConexion(Boolean pResultAbrir, Boolean pResultCerrar, Boolean pResultCommand, 
                            Boolean pResultResultados, Boolean pThrowException)
        {
            resultAbrir = pResultAbrir;
            resultCerrar = pResultCerrar;
            resultCommand = pResultCommand;
            resultResultados = pResultResultados;
            throwException = pThrowException;
        }

        public Boolean AbrirConexion()
        {
            return resultAbrir;
        }
        public Boolean CerrarConexion()
        {
            return resultCerrar;
        }
        public Boolean setCommandText(String comando)
        {
            return resultCommand;
        }

        public IDataReader getResultados()
        {
            IDataReader reader = MockRepository.GenerateStub<IDataReader>();
            reader.Stub(x => x.GetInt64(0)).Return(1);
            for (int i = 0; i < 10; i++)
            {
                reader.Stub(x => x[i]).Return(i);
            }
            if (!throwException)
            {
                if (resultResultados)
                {
                    reader.Stub(x => x.Read()).Return(resultResultados).Repeat.Times(1);
                }
                else
                {
                    reader.Stub(x => x.Read()).Return(resultResultados);
                }
                return reader;
            }
            else
            {
                throw new System.Exception("No se puede acceder a la base de datos.");
            }
        }
    }
}