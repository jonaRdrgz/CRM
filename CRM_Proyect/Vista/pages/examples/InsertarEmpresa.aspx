<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="InsertarEmpresa.aspx.cs" Inherits="CRM_Proyect.pages.examples.InsertarEmpresa" %>

<!DOCTYPE html>
<html>
<head>
  <meta charset="utf-8">
  <meta http-equiv="X-UA-Compatible" content="IE=edge">
  <title>Sistema CRM | Página de registro</title>
  <!-- Tell the browser to be responsive to screen width -->
  <meta content="width=device-width, initial-scale=1, maximum-scale=1, user-scalable=no" name="viewport">
  <!-- Bootstrap 3.3.7 -->
  <link rel="stylesheet" href="../../bower_components/bootstrap/dist/css/bootstrap.min.css">
  <!-- Font Awesome -->
  <link rel="stylesheet" href="../../bower_components/font-awesome/css/font-awesome.min.css">
  <!-- Ionicons -->
  <link rel="stylesheet" href="../../bower_components/Ionicons/css/ionicons.min.css">
  <!-- Theme style -->
  <link rel="stylesheet" href="../../dist/css/AdminLTE.min.css">
  <!-- iCheck -->
  <link rel="stylesheet" href="../../plugins/iCheck/square/blue.css">

  <!-- HTML5 Shim and Respond.js IE8 support of HTML5 elements and media queries -->
  <!-- WARNING: Respond.js doesn't work if you view the page via file:// -->
  <!--[if lt IE 9]>
  <script src="https://oss.maxcdn.com/html5shiv/3.7.3/html5shiv.min.js"></script>
  <script src="https://oss.maxcdn.com/respond/1.4.2/respond.min.js"></script>
  <![endif]-->

  <!-- Google Font -->
  <link rel="stylesheet" href="https://fonts.googleapis.com/css?family=Source+Sans+Pro:300,400,600,700,300italic,400italic,600italic">
    <style type="text/css">
        .auto-style1 {
            font-weight: bold;
            color: #444444;
        }
        .auto-style2 {
            position: relative;
            min-height: 1px;
            float: left;
            width: 39%;
            left: -3px;
            top: 0px;
            padding-left: 15px;
            padding-right: 15px;
        }
    </style>
</head>
<body class="hold-transition register-page">
<div class="register-box">
  <div class="register-logo">
      <a href="#"><span class="auto-style1">Systema</span></a>CRM
  </div>

  <div class="register-box-body">
    <p class="login-box-msg">Ingrese una empresa</p>

      <form id="form1" runat="server">
      <div class="form-group has-feedback">
        <asp:TextBox CssClass="form-control" ID="TextBoxNombre" placeholder="Nombre"  runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator CssClass="help-block" runat="server" id="RequiredFieldValidator2" controltovalidate="TextBoxNombre" errormessage="¡Por favor ingrese el nombre de la empresa!" ForeColor="Red" />
        <span class="glyphicon glyphicon-user form-control-feedback"></span>
      </div>
       <div class="form-group has-feedback">
        <asp:TextBox CssClass="form-control" ID="TextBoxDireccion" placeholder="Dirección"  runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator CssClass="help-block" runat="server" id="RequiredFieldValidator4" controltovalidate="TextBoxDireccion" errormessage="¡Por favor ingrese la dirección de la empresa!" ForeColor="Red" />
        <span class="glyphicon glyphicon-user form-control-feedback"></span>
      </div>
      <div class="form-group has-feedback">
        <asp:TextBox CssClass="form-control" ID="TextBoxTelefono" placeholder="Teléfono"  runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator CssClass="help-block" Display = "Dynamic" runat="server" id="RequiredFieldValidator6" controltovalidate="TextBoxTelefono" errormessage="¡Por favor ingrese el telefono de la empresa!" ForeColor="Red" />
        <span class="glyphicon glyphicon-user form-control-feedback"></span>
      </div>
       <div class="form-group has-feedback">
        <asp:TextBox CssClass="form-control" ID="TextBoxCorreo" placeholder="Correo" textMode="Email"  runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator CssClass="help-block" runat="server" Display = "Dynamic" id="RequiredFieldValidator5" controltovalidate="TextBoxCorreo" errormessage="¡Por favor ingrese un correo válido!" ForeColor="Red" />
        <span class="glyphicon glyphicon-user form-control-feedback"></span>
      </div>
        <div class="form-group has-feedback">
        <asp:TextBox CssClass="form-control" ID="TextBoxUsuario" placeholder="Usuario"  runat="server"></asp:TextBox>
        <asp:RegularExpressionValidator Display = "Dynamic" ControlToValidate = "TextBoxUsuario" ID="RegularExpressionValidator3" ValidationExpression = "^[\s\S]{5,20}$" runat="server" ErrorMessage="El usuario debe ser mínimo 5, máximo 20 *" ForeColor="Red"></asp:RegularExpressionValidator>
        <span class="glyphicon glyphicon-user form-control-feedback"></span>
      </div>
      <div class="form-group has-feedback" >
        <asp:TextBox CssClass="form-control" ID="TextBoxContraseña" placeholder="Contraseña" textMode="Password"  runat="server"></asp:TextBox>
        <asp:RegularExpressionValidator Display = "Dynamic" ControlToValidate = "TextBoxContraseña" ID="RegularExpressionValidator2" ValidationExpression = "^[\s\S]{7,50}$" runat="server" ErrorMessage="Contraseña debe tener al menos 7 caracteres, máximo 50 *" ForeColor="Red"></asp:RegularExpressionValidator>
        <span class="glyphicon glyphicon-user form-control-feedback"></span>
      </div>
      <div class="form-group has-feedback">
        <asp:TextBox CssClass="form-control" ID="TextBoxReContraseña" placeholder="Confirmar Contraseña" textMode="Password"  runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator CssClass="help-block" Display = "Dynamic" runat="server" id="RequiredFieldValidator7" controltovalidate="TextBoxReContraseña" errormessage="¡Debe llenar este campo!" ForeColor="Red" />
        <span class="glyphicon glyphicon-user form-control-feedback"></span>
      </div>
      <div class="row">
        <!-- /.col -->
        <div class="auto-style2">
           <asp:Button ID="Button1" runat="server" class="btn btn-primary btn-block btn-flat" Text="Registrar Empresa" OnClick="registrarEmpresa" Width="163px" />
 
        </div>
        <!-- /.col -->
      </div>
      </form>

    <div class="social-auth-links text-center">
      <p>- OR -</p>
      <a href="#" class="btn btn-block btn-social btn-facebook btn-flat"><i class="fa fa-facebook"></i>Registrarse con
        Facebook</a>
      <a href="#" class="btn btn-block btn-social btn-google btn-flat"><i class="fa fa-google-plus"></i> Registrarse con
        Google+</a>
    </div>

    <a href="login.aspx" class="text-center">Ir al Login</a>
  </div>
  <!-- /.form-box -->
</div>
<!-- /.register-box -->

<!-- jQuery 3 -->
<script src="../../bower_components/jquery/dist/jquery.min.js"></script>
<!-- Bootstrap 3.3.7 -->
<script src="../../bower_components/bootstrap/dist/js/bootstrap.min.js"></script>
<!-- iCheck -->
<script src="../../plugins/iCheck/icheck.min.js"></script>
<script>
  $(function () {
    $('input').iCheck({
      checkboxClass: 'icheckbox_square-blue',
      radioClass: 'iradio_square-blue',
      increaseArea: '20%' // optional
    });
  });
</script>
</body>
</html>

