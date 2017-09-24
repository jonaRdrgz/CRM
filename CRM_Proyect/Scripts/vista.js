function ingresar() {
    $contrasena = $("#TextBoxContraseña").val();
    $correo = $("#TextBoxCorreo").val();
    if ($contrasena == "" || $correo == "") {
        alert("Debe completar todos los campos");
        return;
    }
    $.ajax({

        type: "POST",
        url: "/pages/examples/login.aspx/DoWork",
        cache: false,
        async: false,
        dataType: "json",
        data: {correo: $correo, contrasena:$contrasena},
        success: function (response) {
            location.href = "../../index.aspx";
        },
        error: function (response) {
            alert(response.d);
        }
    });
}