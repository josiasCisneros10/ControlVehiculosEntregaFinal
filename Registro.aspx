<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="Registro.aspx.vb" Inherits="ControlVehiculos.Registro" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="card p-4 shadow-sm">

        <h2 class="mb-4">Registro de Usuario</h2>
        <asp:Label ID="lblMensaje" runat="server" ForeColor="Red"></asp:Label>

        <div class="mb-3">
            <asp:Label ID="lblUsuario" runat="server" Text="Usuario:"></asp:Label>
            <asp:TextBox ID="txtUsuario" runat="server" CssClass="form-control"></asp:TextBox>
        </div>

        <div class="mb-3">
            <asp:Label ID="lblEmail" runat="server" Text="Email:"></asp:Label>
            <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control"></asp:TextBox>
        </div>

        <div class="mb-3">
            <asp:Label ID="lblPassword" runat="server" Text="Contraseña:"></asp:Label>
            <asp:TextBox ID="txtPassword" runat="server" CssClass="form-control" TextMode="Password"></asp:TextBox>
        </div>

        <div class="mb-4">
            <asp:Label ID="lblConfirmarPassword" runat="server" Text="Confirmar Contraseña:"></asp:Label>
            <asp:TextBox ID="txtConfirmarPassword" runat="server" CssClass="form-control" TextMode="Password"></asp:TextBox>
        </div>

        <asp:Button ID="btnRegistrar" runat="server"
            Text="Registrar"
            OnClick="btnRegistrar_Click"
            CssClass="btn btn-success w-100" />
    </div>
</asp:Content>
