<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="FormVehiculo.aspx.vb" Inherits="ControlVehiculos.FormVehiculo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <style>
        .btn-hover-move {
            transition: transform 0.5s ease, box-shadow 0.2s;
        }

            .btn-hover-move:hover {
                transform: translateY(-4px) scale(1.04);
                box-shadow: 0 6px 18px rgba(0,0,0,0.15);
            }
    </style>

    <asp:HiddenField ID="editando" runat="server" />

    <div class="container d-flex flex-column mb-3 gap-2">

        <%-- Placa --%>
        <asp:TextBox ID="txtPlaca" CssClass="form-control" placeholder="Placa" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="rfvPlaca" runat="server" ValidationGroup="vgVehiculo"
            Display="Dynamic"
            CssClass="alert alert-warning"
            ErrorMessage="Se requiere la placa"
            ControlToValidate="txtPlaca"></asp:RequiredFieldValidator>

        <%-- Marca --%>
        <asp:TextBox ID="txtMarca" CssClass="form-control" placeholder="Marca" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="rfvMarca" runat="server" ValidationGroup="vgVehiculo"
            Display="Dynamic"
            CssClass="alert alert-warning"
            ErrorMessage="Se requiere la marca"
            ControlToValidate="txtMarca"></asp:RequiredFieldValidator>

        <%-- Modelo --%>
        <asp:TextBox ID="txtModelo" CssClass="form-control" placeholder="Modelo" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="rfvModelo" runat="server" ValidationGroup="vgVehiculo"
            Display="Dynamic"
            CssClass="alert alert-warning"
            ErrorMessage="Se requiere el modelo"
            ControlToValidate="txtModelo"></asp:RequiredFieldValidator>

        <%-- IdPropietario --%>
        <asp:TextBox ID="txtIdPropietario" CssClass="form-control" placeholder="Id Propietario" runat="server" TextMode="Number"></asp:TextBox>
        <asp:RequiredFieldValidator ID="rfvIdPropietario" runat="server" ValidationGroup="vgVehiculo"
            Display="Dynamic"
            CssClass="alert alert-warning"
            ErrorMessage="Se requiere el Id del propietario"
            ControlToValidate="txtIdPropietario"></asp:RequiredFieldValidator>

        <asp:Button ID="btnGuardar" runat="server"
            CssClass="btn btn-primary btn-hover-move"
            Text="Guardar"
            OnClick="btn_guardar"
            ValidationGroup="vgVehiculo" />

        <asp:Button ID="btnActualizar" runat="server"
            Visible="false"
            CssClass="btn btn-success btn-hover-move"
            Text="Actualizar"
            OnClick="btnActualizar_Click"
            ValidationGroup="vgVehiculo" />

        <asp:Button ID="btnCancelar" runat="server"
            Visible="false"
            CssClass="btn btn-danger btn-hover-move"
            Text="Cancelar"
            OnClick="btnCancelar_Click" />

        <asp:Label ID="lblMensaje" runat="server" Text=""></asp:Label>

        <asp:ValidationSummary ID="vsVehiculo" ValidationGroup="vgVehiculo" runat="server" ShowSummary="true"
            CssClass="alert alert-warning"
            HeaderText="Corrige los siguientes errores:"
            DisplayMode="BulletList" />
    </div>

    <asp:SqlDataSource ID="SqlDataSourceVehiculos" runat="server"
        ConnectionString="<%$ ConnectionStrings:II-46ConnectionString %>"
        SelectCommand="SELECT IdVehiculo, Placa, Marca, Modelo, IdPropietario FROM Vehiculos"></asp:SqlDataSource>

    <asp:GridView ID="gvVehiculo" runat="server"
        CssClass="table table-striped table-hover table-success"
        AutoGenerateColumns="False"
        DataKeyNames="IdVehiculo"
        DataSourceID="SqlDataSourceVehiculos"
        OnRowDeleting="gvVehiculo_RowDeleting"
        OnRowEditing="gvVehiculo_RowEditing"
        OnRowCancelingEdit="gvVehiculo_RowCancelingEdit"
        OnRowUpdating="gvVehiculo_RowUpdating"
        OnSelectedIndexChanged="gvVehiculo_SelectedIndexChanged"
        Width="100%">

        <Columns>
            <asp:CommandField ShowSelectButton="True" ControlStyle-CssClass="btn btn-success" />
            <asp:CommandField ShowEditButton="True" ControlStyle-CssClass="btn btn-primary" />

            <asp:BoundField DataField="IdVehiculo" HeaderText="IdVehiculo" InsertVisible="False" ReadOnly="True" SortExpression="IdVehiculo" />
            <asp:BoundField DataField="Placa" HeaderText="Placa" SortExpression="Placa" />
            <asp:BoundField DataField="Marca" HeaderText="Marca" SortExpression="Marca" />
            <asp:BoundField DataField="Modelo" HeaderText="Modelo" SortExpression="Modelo" />
            <asp:BoundField DataField="IdPropietario" HeaderText="Id Propietario" SortExpression="IdPropietario" />

            <asp:CommandField ShowDeleteButton="True" ControlStyle-CssClass="btn btn-danger" />
        </Columns>
    </asp:GridView>

</asp:Content>
