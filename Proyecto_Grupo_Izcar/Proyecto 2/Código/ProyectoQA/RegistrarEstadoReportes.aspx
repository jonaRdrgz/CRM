<%@ Page Language="C#" MasterPageFile="~/home.Master" AutoEventWireup="true" CodeBehind="RegistrarEstadoReportes.aspx.cs" Inherits="ProyectoQA.RegistrarEstadoReportes" %>

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
        <h3>Registrar Estado del Producto</h3>
                        
        <form method="post" class="form-horizontal" runat ="server" display="Dynamic">

            <div class="form-group">
                <label class="control-label" >Fecha del reporte</label>
                <asp:TextBox ID="fecha" CssClass ="form-control" runat="server" type="date" required=""></asp:TextBox>    
            </div>
        
            <div class="hr-line-dashed"></div>
            <div class="form-group">
                <label class="control-label">Estado</label>
                <asp:DropDownList ID="ddEstado" CssClass ="form-control" runat="server" required="">
                    <asp:ListItem value ="Noespecificado">No especificado</asp:ListItem>
                    <asp:ListItem value ="Reparado">Reparado</asp:ListItem>
                    <asp:ListItem value ="NoReparado">No Reparado</asp:ListItem>
                </asp:DropDownList>
            </div>

            <div class="hr-line-dashed"></div>                        
            <div class="form-group">
                <label class="control-label" >Diagnóstico</label>
                <asp:TextBox ID="diagnostico" CssClass ="form-control" runat="server" required="" value=""></asp:TextBox>
            </div>

            <div class="hr-line-dashed"></div>
            <div class="form-group">
                <div class="col-sm-8">
                    <asp:Button ID="registrarEstadoButton" type="submit" Onclick ="registrarEstadoReporte" href ="ReportesErroresVendedor.aspx" CssClass ="btn btn-primary" runat="server" Text ="Registrar estado del producto" />
                    <asp:LinkButton ID="cancelarRespuesta" CssClass="btn btn-default" href="javascript:history.go(-1)"  runat="server" Text="Cancelar" />
                </div>
            </div>

        </form>

    </div>
</asp:Content>