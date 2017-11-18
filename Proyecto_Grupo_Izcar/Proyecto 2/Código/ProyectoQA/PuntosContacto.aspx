<%@ Page Language="C#"  MasterPageFile="~/ClienteHome.Master"  AutoEventWireup="true" CodeBehind="PuntosContacto.aspx.cs" Inherits="ProyectoQA.PuntosContacto" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Vendedores</h1>
    <div id ="verVendedores"  runat ="server" onload ="verContactosVendedores" >
        
    </div>
</asp:Content>

