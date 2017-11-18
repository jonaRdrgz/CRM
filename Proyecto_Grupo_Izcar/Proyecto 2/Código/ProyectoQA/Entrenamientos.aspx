<%@ Page Title="" Language="C#" MasterPageFile="~/ClienteHome.Master" AutoEventWireup="true" CodeBehind="Entrenamientos.aspx.cs" Inherits="ProyectoQA.Entrenamientos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
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
                        <th>Respuesta</th>
                        <th>Editar Respuesta</th>
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


