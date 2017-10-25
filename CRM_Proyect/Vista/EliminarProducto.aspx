<%@ Page Title="" Language="C#" MasterPageFile="~/Vista/Home.Master" AutoEventWireup="true" CodeBehind="EliminarProducto.aspx.cs" Inherits="CRM_Proyect.EliminarProducto" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
            <div class="col-md-3 col-sm-3 col-xs-3">
                <h2 class="text-center">Eliminar Producto</h2>                
            </div>
            <div class="col-md-4 col-sm-4 col-xs-4">
                <button type="button" id="botonProductos" class="btn btn-success">
                    <span class="glyphicon glyphicon-list" aria-hidden="true"></span> Listar
                </button>
            </div>
        </div>
     <br />
        <div class="row">
        <div class="col-xs-12">
          <div class="box">
            <div class="box-header">
              <h3 class="box-title">Tabla Productos</h3>
            </div>
            <!-- /.box-header -->
            <div class="box-body">
              <table id="tablaProductos" class="table table-responsive  table-bordered table-hover">
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
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">
    <script src="bower_components/datatables.net/js/jquery.dataTables.min.js"></script>
<script src="bower_components/datatables.net-bs/js/dataTables.bootstrap.min.js"></script>
<!-- AdminLTE for demo purposes -->
<script src="dist/js/demo.js"></script>
<script src="Scripts/vista.js"></script>
<script>
  $(function () {
      $('#tablaProductos').DataTable({
          'paging': true,
          'lengthChange': true,
          'searching': true,
          'ordering': true,
          'info': true,
          'autoWidth': true,
          'destroy': true,
          'responsive': true,
    });
    mostrarProductos();

  })
</script>
</asp:Content>
