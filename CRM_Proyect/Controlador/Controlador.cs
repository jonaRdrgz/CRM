/**
 *	Clase Controlador
 *	
 *	Version 1.0
 *	
 *	24/09/2017
 *
 *	Jonathan Rodríguez
 *	Melissa Molina Corrales
 *	Edwin Cen Xu
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CRM_Proyect.Modelo;
using System.Text.RegularExpressions;

    /**
     *  Clase Controlador, con el patron Singleton
     * 
     */

public class Controlador{

    private int CONTRASEÑA_MUY_CORTA = -2;
    const int PRODUCTOS_INSUFICIENTES = -2;
    const int EXITO_DE_INSERCION = 0;
    const int FALLO_DE_INSERCION = -1;
    private int CONTRASEÑA_MUY_LARGA = -4;
    private int USUARIO_MUY_CORTO = -3;
    private int NO_CONTIENE_LETRAS = -5;
    private int NO_CONTIENE_NUMEROS = -6;
    private int DATO_NO_NUMERICO = -7;
    private int USUARIO_MUY_LARGO = -8;
    private int ESPACIO_VACIO = -9;
    private int NOMBRE_MUY_LARGO = -10;
    private int DESCRIPCION_MUY_LARGO = -11;
    private int DATO_VACIO = -12;

    private static Controlador instancia = null;
    private Consulta consultas = new Consulta();
    private InsertarUsuario insertar = new InsertarUsuario();
    private ConsultaProducto producto = new ConsultaProducto();
    private ConsultaPropuestaVenta propuesta = new ConsultaPropuestaVenta();
    private ConsultaComentario comentario = new ConsultaComentario();
    private ConsultaVenta venta = new ConsultaVenta();

    public Controlador() {
        
    }
    
    public static Controlador getInstance() {
        if (instancia == null) {
            instancia = new Controlador();

        }
        return instancia;
    }

    public int getTipoCuenta()
    {
        return consultas.getTipoCuenta();
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
        if (usuario.Length > 20)
        {
            return USUARIO_MUY_LARGO;
        }

        if (nombre.Length.Equals(0) || primerApellido.Length.Equals(0) || segundoApellido.Length.Equals(0) || correo.Length.Equals(0)
            || direccion.Length.Equals(0) || usuario.Length.Equals(0) || contrasena.Length.Equals(0) || telefono.Length.Equals(0))
        {

            return ESPACIO_VACIO;
        }

        if (!IsNumeric(telefono)) {
            return DATO_NO_NUMERICO;
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

    public int insertarEmpresa(string nombre, string correo,  string direccion, string telefono, string usuario, string contrasena)
    {
        //Validando los parámetros
        if (nombre.Length > 45)
        {
            return CONTRASEÑA_MUY_CORTA;
        }

        if (usuario.Length < 5)
        {
            return USUARIO_MUY_CORTO;
        }
        if (usuario.Length > 20)
        {
            return USUARIO_MUY_LARGO;
        }
        if (!IsNumeric(telefono))
        {
            return DATO_NO_NUMERICO;
        }

        int resultadoInsercion = insertar.insertarEmpresa(nombre, correo,direccion, telefono, usuario, contrasena);
        return resultadoInsercion;
    }

    public int agregarProducto(string nombre, string descripcion, string precio)
    {
        //Validando los parámetros
        if (!IsNumeric(precio))
        {
            return DATO_NO_NUMERICO;
        }
        else if (nombre.Length > 45)
        {
            return NOMBRE_MUY_LARGO;
        }
        else if (descripcion.Length > 200)
        {
            return DESCRIPCION_MUY_LARGO;

        }
        else if (precio.Length == 0 || descripcion.Length == 0 || precio.Length ==0) {
            return DATO_VACIO;

        }

        int resultadoInsercion = producto.agregarProducto(nombre, descripcion, precio);
        return resultadoInsercion;
    }

    public List<Producto> obtenerProductos()
    {
        return producto.obtenerProductos();
    }

    public Boolean borrarProducto(int idProducto)
    {
        return producto.borrarProducto(idProducto);
    }

    public List<Producto> obtenerProductosDisponibles()
    {
        return producto.obtenerProductosDisponibles();
    }

    public Boolean agregarAlCarrito(int idProducto)
    {
        return producto.agregarAlCarrito(idProducto);
    }

    public List<Producto> obtenerProductosCarrito()
    {
        return producto.obtenerProductosCarrito();
    }

    public Boolean eliminarDelCarrito(int idProducto)
    {
        return producto.eliminarDelCarrito(idProducto);
    }

    static bool IsNumeric(string sValue)
    {
        return Regex.IsMatch(sValue, "^[0-9]+$");
    }

    public string  crearPropuestaVenta(string precio, string descuento, string comision, int idComprador)
    {
        //Validando los parámetros
        if (!IsNumeric(precio))
        {
            return "Precio debe ser numérico";
        }
        else if (precio.Length > 11)
        {
            return "Precio debe tener como máximo 11 dígitos" ;
        }
        if (!IsNumeric(descuento))
        {
            return "Descuento debe ser numérico";
        }
        else if (descuento.Length > 11)
        {
            return "Descuento debe tener como máximo 11 dígitos";
        }

        if (!IsNumeric(comision))
        {
            return "Comision debe ser numérico";
        }
        else if (comision.Length > 11)
        {
            return "Comision debe tener como máximo 11 dígitos";
        }

        int resultadoInsercion = propuesta.crearPropuestaVenta(precio, descuento, comision, idComprador);
        switch (resultadoInsercion)
        {
            case PRODUCTOS_INSUFICIENTES:
                return "Productos Insuficientes, Seleccione al menos un producto";

            case FALLO_DE_INSERCION:
                return "Falló la inserción";
            default:
                return "Éxito";
        }
   }

    public List<PropuestasVenta> obtenerPropuestasVenta()
    {
        return propuesta.obtenerPropuestasVenta();
    }

    public List<Producto> verProductosPropuesta(int idPropuesta)
    {
        return propuesta.verProductosPropuesta(idPropuesta);
    }

    public List<Comentario> verComentariosPropuesta(int idPropuesta)
    {
        return comentario.verComentariosPropuesta(idPropuesta);
    }

    public List<PropuestasVenta> obtenerPropuestasVentaCompra()
    {
        return propuesta.obtenerPropuestasVentaCompra();
    }

    public Boolean comprar(int idPropuesta)
    {
        return propuesta.comprar(idPropuesta);
    }

    public List<Venta> obtenerVentas()
    {
        return venta.obtenerVentas();
    }

    public List<PropuestasVenta> obtenerPropuestasDeVentaUsuario()
    {
        return propuesta.obtenerPropuestasDeVentaUsuario();
    }

    public Boolean comentarPropuesta(int idPropuesta, string comentario)
    {
        return propuesta.comentarPropuesta(idPropuesta, comentario);
    }

    public Boolean cambiarRespuesta(int idPropuesta, string respuesta)
    {
        return propuesta.cambiarRespuesta(idPropuesta, respuesta);
    }

    public string crearVenta(string precio, string descuento, string comision, int idComprador)
    {
        //Validando los parámetros

        if (!IsNumeric(precio))
        {
            return "Precio debe ser numérico";
        }
        else if (precio.Length > 11)
        {
            return "Precio debe tener como máximo 11 dígitos";
        }
        if (!IsNumeric(descuento))
        {
            return "Descuento debe ser numérico";
        }
        else if (descuento.Length > 11)
        {
            return "Descuento debe tener como máximo 11 dígitos";
        }

        if (!IsNumeric(comision))
        {
            return "Comision debe ser numérico";
        }
        else if (comision.Length > 11)
        {
            return "Comision debe tener como máximo 11 dígitos";
        }

        //Query
        int resultadoInsercion = venta.crearVenta(precio, descuento, comision, idComprador);
        switch (resultadoInsercion)
        {
            case PRODUCTOS_INSUFICIENTES:
                return "Productos Insuficientes, Seleccione al menos un producto";

            case FALLO_DE_INSERCION:
                return "Falló la inserción";
            default:
                return "Éxito";
        }
    }

    public List<Producto> verProductosVenta(int idVenta)
    {
        return venta.verProductosVenta(idVenta);
    }



}