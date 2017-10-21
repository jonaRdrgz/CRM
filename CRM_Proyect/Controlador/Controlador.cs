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
using CRM_Proyect.Modelo;
using System.Text.RegularExpressions;

/**
 *  Clase Controlador, con el patron Singleton
 *  */

public class Controlador{
    private int CONTRASEÑA_MUY_CORTA = -2;
    private int CONTRASEÑA_MUY_LARGA = -4;
    private int USUARIO_MUY_CORTO = -3;
    private int NO_CONTIENE_LETRAS = -5;
    private int NO_CONTIENE_NUMEROS = -6;
    private int TELEFONO_NO_NUMERICO = -7;

    private static Controlador instancia = null;
    private Consulta consultas = new Consulta();
    private InsertarUsuario insertar = new InsertarUsuario();

    protected Controlador() {
        
    }

    public static Controlador getInstance() {
        if (instancia == null) {
            instancia = new Controlador();

        }
        return instancia;
    }

    public Boolean getSession() {
        return consultas.getSession();
    }
    public void setSessionFalse()
    {
        consultas.setSessionFalse();
    }

    public Boolean validarUsuario(string usuario, string contrasena) {
        return consultas.validarUsuario(usuario, contrasena);
    }

    public  List<Usuario> obtenerContactoPersonas() {
        return consultas.obtenerContactoPersonas();
    }

    public List<Empresa> obtenerContactoEmpresas()
    {
        return consultas.obtenerContactoEmpresas();
    }

    public List<Usuario> obtenerPersonas()
    {
        return consultas.obtenerPersonas();
    }

    public Boolean registarContactoPersona(int idPersona) {
        return consultas.registarContactoPersona(idPersona);
    }

    public Boolean registarContactoEmpresa(int empresa)
    {
        return consultas.registarContactoEmpresa(empresa);
    }

    public Boolean borrarContacto(int idPersona)
    {
        return consultas.borrarContacto(idPersona);
    }


    public List<Empresa> obtenerEmpresas()
    {
        return consultas.obtenerEmpresas();
    }

    public Boolean borrarContactoEmpresa(int idEmpresa)
    {
        return consultas.borrarContactoEmpresa(idEmpresa);
    }

    public int insertarUsuario(string nombre, string primerApellido, string segundoApellido, string correo,
                        string direccion, string usuario, string contrasena, string telefono) {
        //Validando los parámetros
        if (contrasena.Length < 7) {
            return CONTRASEÑA_MUY_CORTA;

        } else if (contrasena.Length>50) {
            return CONTRASEÑA_MUY_LARGA;
        }
        
        if (usuario.Length < 5)
        {
            return USUARIO_MUY_CORTO;
        }
        if (!IsNumeric(telefono)) {
            return TELEFONO_NO_NUMERICO;
        }
        bool tieneNumeros = contrasena.Any(c => char.IsDigit(c));
        bool tieneLetras = contrasena.Any(c => char.IsLetter(c));
        if (!tieneNumeros) {
            return NO_CONTIENE_NUMEROS;
        }
        if (!tieneLetras)
        {
            return NO_CONTIENE_LETRAS;
        }

        int resultadoInsercion = insertar.InsertarUsuarioBD(nombre, primerApellido, segundoApellido, correo,
                        direccion, usuario, contrasena, telefono);
        return resultadoInsercion;

    }

    public int insertarEmpresa(string nombre, string correo,  string direccion, string telefono)
    {
        //Validando los parámetros

        if (!IsNumeric(telefono))
        {
            return TELEFONO_NO_NUMERICO;
        }

        int resultadoInsercion = insertar.insertarEmpresa(nombre, correo,direccion, telefono);
        return resultadoInsercion;
    }


    static bool IsNumeric(string sValue)
    {
        return Regex.IsMatch(sValue, "^[0-9]+$");
    }
}