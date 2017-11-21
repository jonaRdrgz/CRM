<%@ Page Title="" Language="C#" MasterPageFile="~/ClienteHome.Master" AutoEventWireup="true" CodeBehind="RegistroRespuestaEntrenamiento.aspx.cs" Inherits="ProyectoQA.RegistroRespuestaEntrenamiento" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder4" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="col-lg-12" >
        <h3>Registrar Respuesta Entrenamiento</h3>
                        
        <form method="post" class="form-horizontal" runat ="server" display="Dynamic">

            <div class="form-group">
                <label class="control-label" >Fecha del Entrenamiento</label>
                <asp:TextBox ID="fecha" CssClass ="form-control" runat="server" type="date" required=""></asp:TextBox>    
            </div>
        
            <div class="hr-line-dashed"></div>
            <div class="form-group">
                <label class="control-label">Estado</label>
                <asp:DropDownList ID="ddEstado" CssClass ="form-control" runat="server" required="">
                    <asp:ListItem value ="No"> No especificado</asp:ListItem>
                    <asp:ListItem value ="Asistiré"> Asistiré</asp:ListItem>
                    <asp:ListItem value ="Quizá Asista"> Quizá asista</asp:ListItem>
                    <asp:ListItem value ="No asistiré"> No asistiré</asp:ListItem>
                </asp:DropDownList>
            </div>

            <div class="hr-line-dashed"></div>                        
            <div class="form-group">
                <label class="control-label" >Respuesta</label>
                <asp:TextBox ID="respuesta" CssClass ="form-control" runat="server" required="" value="Sin respuesta"></asp:TextBox>
            </div>

            <div class="hr-line-dashed"></div>
            <div class="form-group">
                <div class="col-sm-8">
                    <asp:Button ID="registrarRespuestaButton" type="submit" Onclick ="registrarRespuesta" href ="Entrenamientos.aspx" CssClass ="btn btn-primary" runat="server" Text ="Registrar respuesta" />
                    <asp:LinkButton ID="cancelarRespuesta" CssClass="btn btn-default" href="javascript:history.go(-1)"  runat="server" Text="Cancelar" />
                </div>
            </div>

        </form>

    </div>
</asp:Content>
