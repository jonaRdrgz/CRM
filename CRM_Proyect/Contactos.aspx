<%@ Page Title="" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="Contactos.aspx.cs" Inherits="CRM_Proyect.Contactos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Contactos</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    Contenido Usuarios
    <br />
    <% codigoContactos(); %>
</asp:Content>
