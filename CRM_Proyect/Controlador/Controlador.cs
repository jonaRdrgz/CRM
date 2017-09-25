/**
 *	Clase Controlador
 *	
 *	Version 1.0
 *	
 *	24/09/2017
 *
 *	Jonathan Rodríguez
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/**
 *  Clase Controlador, con el patron Singleton
 *  */

public class Controlador{

    private static Controlador instancia = null;
    private Consulta consultas = new Consulta();

    protected Controlador() {
        
    }

    public static Controlador getInstance() {
        if (instancia == null) {
            instancia = new Controlador();

        }
        return instancia;
    }


    public Boolean validarUsuario(string usuario, string contrasena) {
        return consultas.validarUsuario(usuario, contrasena);
    }

    public string obtenerContactoPersonas() {
        return consultas.obtenerContactoPersonas();
    }

    public string obtenerContactoEmpresas()
    {
        return consultas.obtenerContactoEmpresas();
    }

}