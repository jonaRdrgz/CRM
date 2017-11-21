<%@ Page Language="C#" MasterPageFile="~/home.Master"  AutoEventWireup="true" CodeBehind="ReportesErroresVendedor.aspx.cs" Inherits="ProyectoQA.ReportesErroresVendedor" %>

<asp:Content ID="Content5" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="col-lg-12">
        <div class="hpanel">
            <div class="panel-heading">
                <div class="panel-tools">
                    <a class="showhide"><i class="fa fa-chevron-up"></i></a>
                    <a class="closebox"><i class="fa fa-times"></i></a>
                </div>
                <h1>Reportes de Errores</h1>
            </div>
            <div class="panel-body">
                <div class="table-responsive">
                <table cellpadding="1" cellspacing="1" class="table table-bordered table-striped">
                    <thead>
                    <tr>
                        <th>Producto</th>
                        <th>Descripción del error</th>
                        <th>Fecha del reporte</th>
                        <th>Cliente</th>
                        <th>Estado</th>
                        <th>Diagnóstico</th>
                        <th>Editar estado del producto</th>
                    </tr>
                    </thead>
                    <tbody id ="vistaReporteErroresVendedor"  runat ="server" onload ="verReporteErroresVendedor">
                
                    </tbody>
                </table>
                </div>

            </div>
            <div class="panel-footer">
                Reporte de Errores
            </div>
        </div>
    </div>
</asp:Content>



