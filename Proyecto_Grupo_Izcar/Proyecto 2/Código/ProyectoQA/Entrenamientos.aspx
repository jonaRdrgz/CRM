<%@ Page Title="" Language="C#" MasterPageFile="~/ClienteHome.Master" AutoEventWireup="true" CodeBehind="Entrenamientos.aspx.cs" Inherits="ProyectoQA.Entrenamientos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Entrenamientos</h1>
    <div id ="Element"  runat ="server" onload ="verEntrenamientos">
        
    </div>

</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">
    <li class="dropdown">
        <a href="#">
            <i class="pe-7s-plus"
                data-toggle="modal" data-target="#mymodal"></i>
        </a>
    </li>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="ContentPlaceHolder4" runat="server">
    <li>
        <a href="#">
            <i class=""
                data-toggle="modal" data-target="#mymodal">Agregar Empresa</i>
        </a>
    </li>
</asp:Content>

