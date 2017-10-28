<%@ Page Title="" Language="C#" MasterPageFile="~/Vista/Home.Master" AutoEventWireup="true" CodeBehind="CrearVenta.aspx.cs" Inherits="CRM_Proyect.CrearVenta1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
            <div class="col-md-3 col-sm-3 col-xs-3">
                <h2 class="text-center">Crear Venta</h2>                
            </div>
            <div class="col-md-4 col-sm-4 col-xs-4">
                <button type="button" id="botonProductosDisponibles" class="btn btn-success">
                    <span class="glyphicon glyphicon-list" aria-hidden="true"></span> Listar
                </button>
            </div>
        </div>
     <br />
        <div class="row">
        <div class="col-xs-12">
          <div class="box">
            <div class="box-header">
              <h3 class="box-title">Tabla Productos Disponibles</h3>
            </div>
            <!-- /.box-header -->
            <div class="box-body">
              <table id="tablaProductosDisponibles" class="table table-responsive  table-bordered table-hover">
                <thead>
                <tr>
                  <th>Nombre</th>
                  <th>Descripción</th>
                  <th>Precio</th>
                  <th>Acción</th>
                </tr>
                </thead>
                
                <tfoot>
                <tr>
                  <th>Nombre</th>
                  <th>Descripción</th>
                  <th>Precio</th>
                  <th>Acción</th>
                </tr>
                </tfoot>
              </table>
            </div>
            <!-- /.box-body -->
          </div>
          <!-- /.box -->
       </div>
       </div>
    <br/>
    <div class="row">
            <div class="col-md-4 col-sm-4 col-xs-4">
                <button type="button" id="botonProductosCarrito" class="btn btn-success">
                    <span class="glyphicon glyphicon-list" aria-hidden="true"></span> Refrescar
                </button>
            </div>
        </div>
        <div class="row">
        <div class="col-xs-12">
          <div class="box">
            <div class="box-header">
              <h3 class="box-title">Tabla Productos Venta</h3>
            </div>
            <!-- /.box-header -->
            <div class="box-body">
              <table id="tablaProductosCarrito" class="table table-responsive  table-bordered table-hover">
                <thead>
                <tr>
                  <th>Nombre</th>
                  <th>Descripción</th>
                  <th class="numero">Precio</th>
                  <th>Acción</th>
                </tr>
                </thead>
                
                <tfoot>
                <tr>
                  <th>Nombre</th>
                  <th>Descripción</th>
                  <th class="numero">Precio</th>
                  <th>Acción</th>
                </tr>
                </tfoot>
              </table>
            </div>
            <!-- /.box-body -->
          </div>
          <!-- /.box -->
       </div>
        <div class="col-md-6">
          <!-- general form elements -->
          <div class="box box-primary">
            <div class="box-header with-border">
              <h3 class="box-title">Datos adicionales</h3>
            </div>
            <!-- /.box-header -->
            <!-- form start -->
            <form role="form">
              <div class="box-body">
                <div class="form-group">
                  <label for="precio">Precio</label>
                  <input  class="form-control" id="precio" >
                </div>
                <div class="form-group">
                  <label for="descuento">Descuento</label>
                  <input  class="form-control" id="descuento">
                </div>  
                  <div class="form-group">
                  <label for="comision">Comisión</label>
                  <input class="form-control" id="comision">
                </div> 
                  <div class="form-group ">
                    <label class="control-label col-lg-4">Empresa</label>
                     <div class="col-lg-8">
                     <select id = "empresa" name = "style" class="form-control m-bot15">
                     <%obtenerEmpresas(); %> 
                     </select>
                     </div>

                    </div>
              </div>
              <!-- /.box-body -->

              <div class="box-footer">
                <button type="button" onclick='crearVenta()' class="btn btn-primary" >Agregar</button>
              </div>
            </form>
          </div>
        </div>
       </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">
    <script src="bower_components/datatables.net/js/jquery.dataTables.min.js"></script>
<script src="bower_components/datatables.net-bs/js/dataTables.bootstrap.min.js"></script>
<!-- AdminLTE for demo purposes -->
<script src="dist/js/demo.js"></script>
<script src="Scripts/vista.js"></script>
<script>
  $(function () {
      $('#tablaProductosDisponibles').DataTable({
          'paging': true,
          'lengthChange': true,
          'searching': true,
          'ordering': true,
          'info': true,
          'autoWidth': true,
          'destroy': true,
          'responsive': true,
      });
      $('#tablaProductosCarrito').DataTable({
          'paging': true,
          'lengthChange': true,
          'searching': true,
          'ordering': true,
          'info': true,
          'autoWidth': true,
          'destroy': true,
          'responsive': true,
      });
      mostrarProductosDisponibles();
      mostrarProductosCarrito();
  })
</script>
</asp:Content>
