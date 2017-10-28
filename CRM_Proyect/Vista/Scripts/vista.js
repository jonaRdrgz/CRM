function mostrarContactos() {
    $("#botonContactos").on("click", function () {
        dtUsers();
    });
}

function dtUsers() {
    var table = $("#tablaContactos").DataTable({
        destroy: true,
        responsive: true,
        ajax: {
            method: "POST",
            url: "/Vista/Contactos.aspx/obtenerUsuarios",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            data: function (d) {
                return JSON.stringify(d);
            },
            dataSrc: "d.data"
        },
        columns: [
            { "data": "nombre" },
            { "data": "primerApellido" },
            { "data": "segundoApellido" },
            { "data": "direccion" },
            { "data": "correo" },
            { "data": "telefono" },
            { "data": "accion" }
        ]
    });
}

function mostrarEmpresas() {
    $("#botonEmpresa").on("click", function () {
        deplegarTablaEmpresa();
    });
}

function deplegarTablaEmpresa() {
    var table = $("#tablaEmpresa").DataTable({
        destroy: true,
        responsive: true,
        ajax: {
            method: "POST",
            url: "/Vista/InfoEmpresas.aspx/obtenerEmpresas",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            data: function (d) {
                return JSON.stringify(d);
            },
            dataSrc: "d.data"
        },
        columns: [
            { "data": "nombre" },
            { "data": "direccion" },
            { "data": "correo" },
            { "data": "telefono" },
            { "data": "accion" }

        ]
    });
}


function mostrarPersonas() {
    $("#botonListarPersonas").on("click", function () {
        desplagarTablaPersonas();
    });
}

function desplagarTablaPersonas() {
    var table = $("#tablaAgregarPersonas").DataTable({
        destroy: true,
        responsive: true,
        ajax: {
            method: "POST",
            url: "/Vista/AgregarPersonas.aspx/obtenerPersonas",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            data: function (d) {
                return JSON.stringify(d);
            },
            dataSrc: "d.data"
        },
        columns: [
            { "data": "nombre" },
            { "data": "primerApellido" },
            { "data": "segundoApellido" },
            { "data": "direccion" },
            { "data": "correo" },
            { "data": "telefono" },
            { "data": "accion" }

        ]
    });
}

function agregarContacto(id) {
    var data = {user : id}
    $.ajax({

        method: "POST",
        url: "/Vista/AgregarPersonas.aspx/agregarContacto",
        data: JSON.stringify(data),
        contentType: "application/json; charset=utf-8",
        dataType: "json"

    }).done(function (info) {
        //Respuesta del servidor
        console.log(info);
        desplagarTablaPersonas();
    });
}

function borrarContacto(id) {
    var data = { user: id }
    $.ajax({

        method: "POST",
        url: "/Vista/Contactos.aspx/borrarContacto",
        data: JSON.stringify(data),
        contentType: "application/json; charset=utf-8",
        dataType: "json"

    }).done(function (info) {
        //Respuesta del servidor
        console.log(info);
        dtUsers();
    });
}

function mostrarEmpresasLibre() {
    $("#botonEmpresaLibre").on("click", function () {
        deplegarTablaEmpresaLibre();
    });
}

function deplegarTablaEmpresaLibre() {
    var table = $("#tablaEmpresaLibre").DataTable({
        destroy: true,
        responsive: true,
        ajax: {
            method: "POST",
            url: "/Vista/AgregarEmpresa.aspx/mostrarEmpresas",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            data: function (d) {
                return JSON.stringify(d);
            },
            dataSrc: "d.data"
        },
        columns: [
            { "data": "nombre" },
            { "data": "direccion" },
            { "data": "correo" },
            { "data": "telefono" },
            { "data": "accion" }

        ]
    });
}

function agregarContactoEmpresa(id) {
    var data = { user: id }
    $.ajax({

        method: "POST",
        url: "/Vista/AgregarEmpresa.aspx/agregarContactoEmpresa",
        data: JSON.stringify(data),
        contentType: "application/json; charset=utf-8",
        dataType: "json"

    }).done(function (info) {
        //Respuesta del servidor
        console.log(info);
        deplegarTablaEmpresaLibre();
    });
}

function borrarContactoEmpresa(id) {
    var data = { idEmpresa: id }
    $.ajax({

        method: "POST",
        url: "/Vista/InfoEmpresas.aspx/borrarContactoEmpresa",
        data: JSON.stringify(data),
        contentType: "application/json; charset=utf-8",
        dataType: "json"

    }).done(function (info) {
        //Respuesta del servidor
        console.log(info);
        deplegarTablaEmpresa();
    });
}

function cerrarSesion() {
    $.ajax({

        method: "POST",
        url: "/Vista/index.aspx/cerrarSession",
        data: {},
        contentType: "application/json; charset=utf-8",
        dataType: "json"

    }).done(function (info) {
        //Respuesta del servidor
        console.log(info);
    });
}



function mostrarProductos() {
    $("#botonProductos").on("click", function () {
        tablaProductos();
    });
}

function tablaProductos() {
    var table = $("#tablaProductos").DataTable({
        destroy: true,
        responsive: true,
        ajax: {
            method: "POST",
            url: "/Vista/EliminarProducto.aspx/mostrarProductos",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            data: function (d) {
                return JSON.stringify(d);
            },
            dataSrc: "d.data"
        },
        columns: [
            { "data": "nombre" },
            { "data": "descripcion" },
            { "data": "precio" },
            { "data": "accion" },
        ]
    });
}

function eliminarProducto(id) {
    var data = { idProducto: id }
    $.ajax({

        method: "POST",
        url: "/Vista/EliminarProducto.aspx/borrarProducto",
        data: JSON.stringify(data),
        contentType: "application/json; charset=utf-8",
        dataType: "json"

    }).done(function (info) {
        //Respuesta del servidor
        console.log(info);
        tablaProductos();
    });
}

function mostrarProductosDisponibles() {
    $("#botonProductosDisponibles").on("click", function () {
        tablaProductosDisponibles();
    });
}
function mostrarProductosCarrito() {
    $("#botonProductosCarrito").on("click", function () {
        tablaProductosCarrito();
    });
}
function tablaProductosDisponibles() {
    var table = $("#tablaProductosDisponibles").DataTable({
        destroy: true,
        responsive: true,
        ajax: {
            method: "POST",
            url: "/Vista/CrearPropuesta.aspx/mostrarProductosDisponibles",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            data: function (d) {
                return JSON.stringify(d);
            },
            dataSrc: "d.data"
        },
        columns: [
            { "data": "nombre" },
            { "data": "descripcion" },
            { "data": "precio" },
            { "data": "accion" },
        ]
    });
}

function tablaProductosCarrito() {
    var table = $("#tablaProductosCarrito").DataTable({
        destroy: true,
        responsive: true,
        ajax: {
            method: "POST",
            url: "/Vista/CrearPropuesta.aspx/mostrarProductosCarrito",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            data: function (d) {
                return JSON.stringify(d);
            },
            dataSrc: "d.data"
        },
        columns: [
            { "data": "nombre" },
            { "data": "descripcion" },
            { "data": "precio" },
            { "data": "accion" },
        ]
    });
}

function agregarAlCarrito(id) {
    var data = { idProducto: id }
    $.ajax({

        method: "POST",
        url: "/Vista/CrearPropuesta.aspx/agregarAlCarrito",
        data: JSON.stringify(data),
        contentType: "application/json; charset=utf-8",
        dataType: "json"

    }).done(function (info) {
        //Respuesta del servidor
        console.log(info);
        tablaProductosDisponibles();
        tablaProductosCarrito();
    });

}

function eliminarDelCarrito(id) {
    var data = { idProducto: id }
    $.ajax({

        method: "POST",
        url: "/Vista/CrearPropuesta.aspx/eliminarDelCarrito",
        data: JSON.stringify(data),
        contentType: "application/json; charset=utf-8",
        dataType: "json"

    }).done(function (info) {
        //Respuesta del servidor
        console.log(info);
        tablaProductosDisponibles();
        tablaProductosCarrito();
    });
}
function crearPropuesta() {

    $precio = $("#precio").val();
    $descuento = $("#descuento").val();
    $comision = $("#comision").val();
    $idComprador = $("#empresa").val();
    var data = {
        precio: $precio,
        descuento: $descuento,
        comision: $comision,
        idComprador : $idComprador
    }
    $.ajax({

        method: "POST",
        url: "/Vista/CrearPropuesta.aspx/crearPropuesta",
        data: JSON.stringify(data),
        contentType: "application/json; charset=utf-8",
        dataType: "json"

    }).done(function (info) {
        //Respuesta del servidor
        console.log(info);
        alert(info.d);
    });
}

function agregarProducto() {

    $nombre = $("#nombre").val();
    $descripcion = $("#descripcion").val();
    $precio = $("#precio").val();
    var data = {
        nombre: $nombre,
        descripcion: $descripcion,
        precio: $precio
    }
    $.ajax({

        method: "POST",
        url: "/Vista/AgregarProducto.aspx/insertarProducto",
        data: JSON.stringify(data),
        contentType: "application/json; charset=utf-8",
        dataType: "json"

    }).done(function (info) {
        console.log(info);
        alert(info.d);
    });
}

function mostrarPropuestasVenta() {
    $("#botonVerPropuestaVenta").on("click", function () {
        tablaPropuestaDeVenta();
        actualizarTablaProductoPropuesta();
    });
}

function tablaPropuestaDeVenta() {
    var table = $("#tablaPropuestasVenta").DataTable({
        destroy: true,
        responsive: true,
        ajax: {
            method: "POST",
            url: "/Vista/VerPropuestas.aspx/obtenerPropuestasDeVenta",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            data: function (d) {
                return JSON.stringify(d);
            },
            dataSrc: "d.data"
        },
        columns: [
            { "data": "productos" },
            { "data": "precio" },
            { "data": "descuento" },
            { "data": "comision" },
            { "data": "fecha" },
            { "data": "respuesta" },
            { "data": "comprador" }
        ]
    });
}

function verProductos(id) {
    actualizarTablaProductoPropuesta();
    var data = { idPropuesta: id }
    $.ajax({

        method: "POST",
        url: "/Vista/VerPropuestas.aspx/verProductosPropuesta",
        data: JSON.stringify(data),
        contentType: "application/json; charset=utf-8",
        dataType: "json"

    }).done(function (info) {
        $.each(info.d.data, function (index, value) {
            llenarTablaProductoPropuesta(info.d.data, index, value);
        });
    });
}

function llenarTablaProductoPropuesta(response, index, value)
{
    $('#tablaProductoPropuesta').DataTable({
        "destroy": true,
        "data": response,
        "columns":[
            {"data":"nombre"},
            {"data":"descripcion"},
            {"data":"precio"}
        ]
    });
}

function verComentarios(id) {
    actualizarTablaComentariosPropuesta();
    var data = { idPropuesta: id }
    $.ajax({

        method: "POST",
        url: "/Vista/VerPropuestas.aspx/verComentariosPropuesta",
        data: JSON.stringify(data),
        contentType: "application/json; charset=utf-8",
        dataType: "json"

    }).done(function (info) {
        $.each(info.d.data, function (index, value) {
            llenarTablaComentariosPropuesta(info.d.data, index, value);
        });
    });
}

function llenarTablaComentariosPropuesta(response, index, value) {
    $('#tablaComentarios').DataTable({
        "destroy": true,
        "data": response,
        "columns": [
            { "data": "nombre" },
            { "data": "apellidoUno" },
            { "data": "apellidoDos" },
            { "data": "comentario" }
        ]
    });
}

function actualizarTablaProductoPropuesta() {
    $("#tablaProductoPropuesta tr>td").remove();
}

function actualizarTablaComentariosPropuesta() {
    $("#tablaComentarios tr>td").remove();
}

function mostrarPropuestasVentaCompras() {
    $("#botonVerPropuestaVenta").on("click", function () {
        tablaPropuestaDeVentaCompra();
        actualizarTablaProductoPropuestaCompra();
    });
}

function tablaPropuestaDeVentaCompra() {
    var table = $("#tablaPropuestasVenta").DataTable({
        destroy: true,
        responsive: true,
        ajax: {
            method: "POST",
            url: "/Vista/Compras.aspx/obtenerPropuestasDeVenta",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            data: function (d) {
                return JSON.stringify(d);
            },
            dataSrc: "d.data"
        },
        columns: [
            { "data": "productos" },
            { "data": "precio" },
            { "data": "descuento" },
            { "data": "accion" }
        ]
    });
}

function actualizarTablaProductoPropuestaCompra() {
    $("#tablaProductoPropuesta tr>td").remove();
}

function comprar(id) {
    var data = { idPropuesta: id }
    $.ajax({

        method: "POST",
        url: "/Vista/Compras.aspx/comprar",
        data: JSON.stringify(data),
        contentType: "application/json; charset=utf-8",
        dataType: "json"

    }).done(function (info) {
        //Respuesta del servidor
        console.log(info);
        tablaPropuestaDeVentaCompra();
    });

}

function mostrarVentas() {
    $("#botonVerPropuestaVenta").on("click", function () {
        tablaVentas();
        actualizarTablaVentas();
    });
}

function tablaVentas() {
    var table = $("#tablaPropuestasVenta").DataTable({
        destroy: true,
        responsive: true,
        ajax: {
            method: "POST",
            url: "/Vista/VerVentas.aspx/obtenerVentas",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            data: function (d) {
                return JSON.stringify(d);
            },
            dataSrc: "d.data"
        },
        columns: [
            { "data": "productos" },
            { "data": "fecha" },
            { "data": "precio" },
            { "data": "descuento" },
            { "data": "comision" },
            { "data": "vendedor" },
            { "data": "comprador" }
        ]
    });
}

function actualizarTablaVentas() {
    $("#tablaProductoPropuesta tr>td").remove();
}


//
function mostrarPropuestasVentaComprasUsuario() {
    $("#botonVerPropuestaVenta").on("click", function () {
        tablaPropuestaDeVentaCompraUsuario();
        actualizarTablaProductoPropuestaCompraUsuario();
    });
}

function tablaPropuestaDeVentaCompraUsuario() {
    var table = $("#tablaPropuestasVenta").DataTable({
        destroy: true,
        responsive: true,
        ajax: {
            method: "POST",
            url: "/Vista/ComentarPropuesta.aspx/obtenerPropuestasDeVenta",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            data: function (d) {
                return JSON.stringify(d);
            },
            dataSrc: "d.data"
        },
        columns: [
            { "data": "productos" },
            { "data": "precio" },
            { "data": "descuento" },
            { "data": "accion" }
        ]
    });
}

function actualizarTablaProductoPropuestaCompraUsuario() {
    $("#tablaProductoPropuesta tr>td").remove();
}

function comentar(id) {
    document.getElementById("botonComentar").disabled = false;
    document.getElementById("botonComentar").value = id;
}

function agregarComentario() {
    $comentario = $('#comentario').val();
    $id = document.getElementById("botonComentar").value;
    var data = {
        idPropuesta: $id,
        comentario : $comentario
    }
    $.ajax({

        method: "POST",
        url: "/Vista/ComentarPropuesta.aspx/comentarPropuesta",
        data: JSON.stringify(data),
        contentType: "application/json; charset=utf-8",
        dataType: "json"

    }).done(function (info) {
        //Respuesta del servidor
        console.log(info);
        document.getElementById("botonComentar").disabled = true;
        $('#comentario').val('');
    });
}

function cambiarRespuesta(id) {
    document.getElementById("botonRespuesta").disabled = false;
    document.getElementById("botonRespuesta").value = id;
}

function actualizarRespuesta() {
    $respuesta = $('#respuesta').val();
    $id = document.getElementById("botonRespuesta").value;
    var data = {
        idPropuesta: $id,
        respuesta: $respuesta
    }
    $.ajax({

        method: "POST",
        url: "/Vista/VerPropuestas.aspx/cambiarRespuesta",
        data: JSON.stringify(data),
        contentType: "application/json; charset=utf-8",
        dataType: "json"

    }).done(function (info) {
        //Respuesta del servidor
        console.log(info);
        document.getElementById("botonRespuesta").disabled = true;
        $('#respuesta').val('');
    });
}


function crearVenta() {
    $precio = $("#precio").val();
    $descuento = $("#descuento").val();
    $comision = $("#comision").val();
    $idComprador = $("#empresa").val();
    
    var data = {
        precio: $precio,
        descuento: $descuento,
        comision: $comision,
        idComprador : $idComprador
    }
    $.ajax({

        method: "POST",
        url: "/Vista/CrearVenta.aspx/crearVenta",
        data: JSON.stringify(data),
        contentType: "application/json; charset=utf-8",
        dataType: "json"

    }).done(function (info) {
        //Respuesta del servidor
        console.log(info);
        alert(info.d)
        //alert("exito");
    });
}

function verProductosVenta(id) {
    actualizarTablaProductoPropuesta();
    var data = { idVenta: id }
    $.ajax({

        method: "POST",
        url: "/Vista/VerVentas.aspx/verProductosVenta",
        data: JSON.stringify(data),
        contentType: "application/json; charset=utf-8",
        dataType: "json"

    }).done(function (info) {
        $.each(info.d.data, function (index, value) {
            llenarTablaProductoPropuesta(info.d.data, index, value);
        });
    });
}