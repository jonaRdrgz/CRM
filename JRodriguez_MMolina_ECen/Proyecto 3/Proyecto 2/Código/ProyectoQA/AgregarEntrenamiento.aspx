<%@ Page Title="" Language="C#" MasterPageFile="~/home.Master" AutoEventWireup="true" CodeBehind="AgregarEntrenamiento.aspx.cs" Inherits="ProyectoQA.AgregarEntrenamiento" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <div class="modal fade" id="mymodal">
            <div class="modal-dialog">
                <div class="modal-content">
                    <div class="modal-header">
                        <a class="close" data-dismiss="modal">&times;</a>
                        <h3 class="modal-title">Agregar Entrenamiento</h3>
                    </div>
                    <div class="modal-body">
                        <form method="post" class="form-horizontal" runat ="server" display="Dynamic">

                        <div class="hr-line-dashed"></div>              
                        <div class="form-group">
                            <label class="control-label" >Nombre</label>
                            <asp:TextBox ID="nombreEntrenamiento" CssClass ="form-control" runat="server" required="" value=""></asp:TextBox>
                        </div>

                        <div class="hr-line-dashed"></div>
                         <div class="form-group">
                            <label class="control-label" >Fecha del Entrenamiento</label>
                            <asp:TextBox ID="fecha" CssClass ="form-control" runat="server" type="date" required=""></asp:TextBox>    
                        </div>

                       <div class="hr-line-dashed"></div>                        
                        <div class="form-group">
                            <label class="control-label" >Hora Inicio</label>
                            <asp:TextBox ID="horaInicio" CssClass ="form-control" runat="server" required="" value=""></asp:TextBox>
                        </div>

                        <div class="hr-line-dashed"></div>                        
                        <div class="form-group">
                            <label class="control-label" >Hora Fin</label>
                            <asp:TextBox ID="horaFin"  CssClass ="form-control" runat="server" required="" value=""></asp:TextBox>
                        </div>

                        <div class="hr-line-dashed"></div>                        
                        <div class="form-group">
                            <label class="control-label" >Ubicación</label>
                            <asp:TextBox ID="ubicacion"  CssClass ="form-control" runat="server" required="" value=""></asp:TextBox>
                        </div>

                        <div class="form-group">
                            <label class="control-label">Empresa</label>
                            <asp:DropDownList ID="ddIdEmpresa" CssClass ="form-control" runat="server" required="" onload ="popularEmpresa">
                            </asp:DropDownList>
                        </div>

                        <div class="hr-line-dashed"></div>
                        <div class="form-group">
                            <div class="col-sm-8">
                                <asp:Button ID="registrarEntrenamientoButton" type ="submit" Onclick ="registrarEntrenamiento" href ="AgregarEntrenamiento.aspx" CssClass ="btn btn-primary" runat="server" Text ="Agregar Entrenamiento" />
                                <asp:Button ID="cancelarRegistroEntrenamiento" CssClass ="btn btn-default" data-dismiss="modal" href="ReporteErrores.aspx"  runat="server" Text="Cancelar" />   
                            </div>
                        </div>

                        </form>

                    <div class="modal-footer">
                    </div>

                </div>

            </div>

        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder4" runat="server">
    <li>
        <a href="#">
            <i class=""
                data-toggle="modal" data-target="#mymodal">Entrenamientos</i>
        </a>
    </li>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">
    <li class="dropdown">
        <a href="#">
            <i class="pe-7s-plus"
                data-toggle="modal" data-target="#mymodal"></i>
        </a>
    </li>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="col-lg-12">
        <div class="hpanel">
            <div class="panel-heading">
                <div class="panel-tools">
                    <a class="showhide"><i class="fa fa-chevron-up"></i></a>
                    <a class="closebox"><i class="fa fa-times"></i></a>
                </div>
                <h1>Entrenamientos</h1>
            </div>
            <div class="panel-body">
                <div class="table-responsive">
                <table cellpadding="1" cellspacing="1" class="table table-bordered table-striped">
                    <thead>
                    <tr>
                        <th>Nombre</th>
                        <th>Fecha</th>
                        <th>Hora Inicio</th>
                        <th>Hora Fin</th>
                        <th>Ubicación</th>
                        <th>Empresa</th>
                    </tr>
                    </thead>
                    <tbody id ="vistaEntrenamientos"  runat ="server" onload ="verEntrenamientos">
                
                    </tbody>
                </table>
                </div>

            </div>
            <div class="panel-footer">
                Entrenamientos
            </div>
        </div>
    </div>
</asp:Content>