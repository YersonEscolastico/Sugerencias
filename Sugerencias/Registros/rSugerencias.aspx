<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMaster.Master" AutoEventWireup="true" CodeBehind="rSugerencias.aspx.cs" Inherits="Sugerencias.Registros.rSugerencias" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

     <div class="card">
        <div class="panel" style="background-color: #0094ff">
            <div class="panel-heading" style="font-family: Arial Black; font-size: 20px; text-align: center; color: Black">Registro de sugerencias</div>
        </div>

        <div class="panel-body">
            <div class="card-body">
                <div class="container">
                    <div class="form-row">

                        <%--SugerenciaId--%>
                        <div class="col-md-2 col-md-offset-3">
                            <asp:Label ID="SugerenciaIdLabel" Text="SugerenciaId" runat="server" />
                            <asp:TextBox ID="SugerenciaIdTextBox" class="form-control input-sm" TextMode="Number" runat="server" placeholder="0"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RFVId" ValidationGroup="Buscar" ControlToValidate="SugerenciaIdTextBox" runat="server" ErrorMessage="*" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                        </div>

                            <%--Buscar Button--%>
                        <div class="col-md-2 col-sm-2 col-xs-3">
                            <div class="input-group-append">
                                <br />
                                <asp:Button Text="Buscar" class="btn btn-primary" runat="server" ID="BuscarButton" OnClick="BuscarButton_Click1" />
                            </div>
                        </div>


                        <%--Fecha--%>
                        <div class="col-md-3 col-md-3-offset-3">
                            <asp:Label Text="Fecha" runat="server" />
                            <asp:TextBox ID="FechaTextBox" class="form-control input-sm" TextMode="Date" runat="server"></asp:TextBox>
                        </div>


                        <!--Descripcion-->
                        <div class="col-md-4 col-md-offset-3">
                            <asp:Label ID="Label4" runat="server" Text="Descripcion">Descripcion</asp:Label><br />

                            <asp:TextBox ID="DescripcionTextBox" runat="server" onkeypress="return isLetterKey(event)" placeholder="Ej. Actualizar Db" class="form-control input-sm" Style="font-size: small"></asp:TextBox>
                        </div>
                    </div>
                </div>


                <br />
                <br />
                <br />
                <div class="col-md-3 col-md-offset-5">
                    <div class="panel">
                        <div class="text-center">

                            <div class="form-group">
                                <asp:Button ID="NuevoButton" runat="server" Text="Nuevo" class="btn btn-primary"  OnClick="NuevoButton_Click" />
                                <asp:Button ID="GuardarButton" runat="server" Text="Guardar" class="btn btn-success" ValidationGroup="Guardar" OnClick="GuardarButton_Click" />
                                <asp:Button ID="EliminarButton" runat="server" Text="Eliminar" class="btn btn-danger" OnClick="EliminarButton_Click" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>