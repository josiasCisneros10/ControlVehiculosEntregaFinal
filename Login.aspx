<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="Login.aspx.vb" Inherits="ControlVehiculos.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Iniciar Sesión</h2>

    <asp:Label ID="lblMensaje" runat="server" ForeColor="Red"></asp:Label>

    <asp:Panel ID="PanelLogin" runat="server">
        <div class="mb-3">
            <asp:Label ID="lblUsuario" runat="server" Text="Usuario:" AssociatedControlID="txtUsuario" CssClass="form-label"></asp:Label>
            <asp:TextBox ID="txtUsuario" runat="server" CssClass="form-control"></asp:TextBox>
        </div>

        <div class="mb-3">
            <asp:Label ID="lblContrasena" runat="server" Text="Contraseña:" AssociatedControlID="txtPassword" CssClass="form-label"></asp:Label>
            <asp:TextBox ID="txtPassword" runat="server" CssClass="form-control" TextMode="Password"></asp:TextBox>
        </div>

        <div class="mb-3">
            <asp:Button ID="btnIniciarSesion" runat="server" CssClass="btn btn-primary" Text="Iniciar Sesión" OnClick="btnIniciarSesion_Click" />
        </div>
    </asp:Panel>
</asp:Content>
