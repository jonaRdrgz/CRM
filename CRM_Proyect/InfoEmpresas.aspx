<%@ Page Title="" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="InfoEmpresas.aspx.cs" Inherits="CRM_Proyect.InfoEmpresas" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        Contenido Empresas
    <% obtenerEmpresas(); %>
</asp:Content>
