<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="Home.aspx.vb" Inherits="ControlVehiculos.Home" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2 class="mb-4">Home</h2>

    <div class="p-3 border rounded shadow-sm bg-light w-50">
        <p class="mb-1">
            <strong>Bienvenido </strong>
            <asp:Label ID="lblUsuario" runat="server"></asp:Label>
        </p>
        <p class="mb-0">
            <strong>Correo electronico: </strong>
            <asp:Label ID="lblEmail" runat="server"></asp:Label>
        </p>
    </div>
</asp:Content>
