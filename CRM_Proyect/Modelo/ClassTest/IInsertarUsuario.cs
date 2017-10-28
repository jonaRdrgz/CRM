using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM_Proyect.Modelo.ClassTest
{
    public interface IInsertarUsuario
    {
        Boolean validarCorreo (string correo);
        Boolean validarUsuario(string usuario);
        int InsertarUsuarioBD(string nombre, string primerApellido, string segundoApellido, string correo,
                        string direccion, string usuario, string contrasena, string telefono);
        int insertarEmpresa(string nombre, string correo, string direccion, string telefono,
            string usuario, string contrasena);
    }
}
