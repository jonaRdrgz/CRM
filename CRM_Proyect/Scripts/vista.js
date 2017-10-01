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
            url: "/Contactos.aspx/obtenerUsuarios",
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
            url: "/InfoEmpresas.aspx/obtenerEmpresas",
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
            url: "/AgregarPersonas.aspx/obtenerPersonas",
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
        url: "/AgregarPersonas.aspx/agregarContacto",
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
        url: "/Contactos.aspx/borrarContacto",
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
            url: "/AgregarEmpresa.aspx/mostrarEmpresas",
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
        url: "/AgregarEmpresa.aspx/agregarContactoEmpresa",
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
        url: "/InfoEmpresas.aspx/borrarContactoEmpresa",
        data: JSON.stringify(data),
        contentType: "application/json; charset=utf-8",
        dataType: "json"

    }).done(function (info) {
        //Respuesta del servidor
        console.log(info);
        deplegarTablaEmpresa();
    });
}