<%@ Page Title="" Language="C#" MasterPageFile="~/Vista/Home.Master" AutoEventWireup="true" CodeBehind="AgregarProducto.aspx.cs" Inherits="CRM_Proyect.AgregarProducto" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <!-- left column -->
        <div class="col-md-6">
          <!-- general form elements -->
          <div class="box box-primary">
            <div class="box-header with-border">
              <h3 class="box-title">Agregar Producto</h3>
            </div>
            <!-- /.box-header -->
            <!-- form start -->
            <form role="form">
              <div class="box-body">
                <div class="form-group">
                  <label for="nombre">Nombre</label>
                  <input  class="form-control" id="nombre" >
                </div>
                <div class="form-group">
                  <label for="descripcion">Descripcion</label>
                  <input  class="form-control" id="descripcion">
                </div>  
                  <div class="form-group">
                  <label for="precio">Precio</label>
                  <input class="form-control" id="precio">
                </div> 
              </div>
              <!-- /.box-body -->

              <div class="box-footer">
                <button type="button" onclick='agregarProducto()' class="btn btn-primary" >Agregar</button>
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
</asp:Content>
