<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="FormPersona.aspx.vb" Inherits="ControlVehiculos.FormPersona" %>

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

        <%-- Nombre --%>
        <asp:TextBox ID="txtNombre" CssClass="form-control" placeholder="Nombre" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="rfvNombre" runat="server" ValidationGroup="vgPersona"
            Display="Dynamic"
            CssClass="alert alert-warning"
            ErrorMessage="Se requiere el Nombre"
            ControlToValidate="txtNombre"></asp:RequiredFieldValidator>

        <%-- Primer Apellido --%>
        <asp:TextBox ID="txtApellido1" CssClass="form-control" placeholder="Primer Apellido" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="rfvApellido1" runat="server" ValidationGroup="vgPersona"
            Display="Dynamic"
            CssClass="alert alert-warning"
            ErrorMessage="Se requiere el primer apellido"
            ControlToValidate="txtApellido1"></asp:RequiredFieldValidator>

        <%-- Segundo Apellido (opcional) --%>
        <asp:TextBox ID="TxtApellido2" CssClass="form-control" placeholder="Segundo Apellido" runat="server"></asp:TextBox>

        <%-- Nacionalidad --%>
        <asp:TextBox ID="txtNacionalidad" CssClass="form-control" placeholder="Nacionalidad" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="rfvNacionalidad" runat="server" ValidationGroup="vgPersona"
            Display="Dynamic"
            CssClass="alert alert-warning"
            ErrorMessage="Se requiere la nacionalidad"
            ControlToValidate="txtNacionalidad"></asp:RequiredFieldValidator>

        <%-- Fecha de nacimiento --%>
        <asp:TextBox ID="txtFechanac" CssClass="form-control" placeholder="Fecha de Nacimiento" TextMode="Date" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="rfvFechaNac" runat="server" ValidationGroup="vgPersona"
            Display="Dynamic"
            CssClass="alert alert-warning"
            ErrorMessage="Se requiere la fecha de nacimiento"
            ControlToValidate="txtFechanac"></asp:RequiredFieldValidator>

        <%-- Teléfono --%>
        <asp:TextBox ID="txtTelefono" CssClass="form-control" placeholder="Teléfono" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="rfvTelefono" runat="server" ValidationGroup="vgPersona"
            Display="Dynamic"
            CssClass="alert alert-warning"
            ErrorMessage="Se requiere el teléfono"
            ControlToValidate="txtTelefono"></asp:RequiredFieldValidator>

        <asp:Button ID="btnGuardar" runat="server"
            CssClass="btn btn-primary btn-hover-move"
            Text="Guardar"
            OnClick="btn_guardar"
            ValidationGroup="vgPersona" />

        <asp:Button ID="btnActualizar" runat="server"
            Visible="false"
            CssClass="btn btn-success btn-hover-move"
            Text="Actualizar"
            OnClick="btnActualizar_Click"
            ValidationGroup="vgPersona" />

        <asp:Button ID="btnCancelar" runat="server"
            Visible="false"
            CssClass="btn btn-danger btn-hover-move"
            Text="Cancelar"
            OnClick="btnCancelar_Click" />

        <asp:Label ID="lblMensaje" runat="server" Text=""></asp:Label>

        <asp:ValidationSummary ID="vsPersona" ValidationGroup="vgPersona" runat="server" ShowSummary="true"
            CssClass="alert alert-warning"
            HeaderText="Corrige los siguientes errores:"
            DisplayMode="BulletList" />
    </div>

    <asp:SqlDataSource ID="SqlDataSource1" runat="server"
        ConnectionString="<%$ ConnectionStrings:II-46ConnectionString %>"
        SelectCommand="SELECT * FROM [Personas]"></asp:SqlDataSource>

    <asp:GridView ID="gvPersonas" runat="server"
        CssClass="table table-striped table-hover table-success"
        AutoGenerateColumns="False"
        DataKeyNames="idPersona"
        DataSourceID="SqlDataSource1"
        OnRowDeleting="gvPersonas_RowDeleting"
        OnRowEditing="gvPersonas_RowEditing"
        OnRowCancelingEdit="gvPersonas_RowCancelingEdit"
        OnRowUpdating="gvPersonas_RowUpdating"
        OnSelectedIndexChanged="gvPersonas_SelectedIndexChanged"
        Width="100%">

        <Columns>
            <asp:CommandField ShowSelectButton="True" ControlStyle-CssClass="btn btn-success" />
            <asp:CommandField ShowEditButton="True" ControlStyle-CssClass="btn btn-primary" />
            <asp:BoundField DataField="idPersona" HeaderText="ID" InsertVisible="False" ReadOnly="True" SortExpression="idPersona" />
            <asp:BoundField DataField="Nombre" HeaderText="Nombre" SortExpression="Nombre" />
            <asp:BoundField DataField="Apellido1" HeaderText="Apellido 1" SortExpression="Apellido1" />
            <asp:BoundField DataField="Apellido2" HeaderText="Apellido 2" SortExpression="Apellido2" />
            <asp:BoundField DataField="Nacionalidad" HeaderText="Nacionalidad" SortExpression="Nacionalidad" />
            <asp:BoundField DataField="FechaNacimiento" HeaderText="Fecha Nacimiento" SortExpression="FechaNacimiento" />
            <asp:BoundField DataField="Telefono" HeaderText="Teléfono" SortExpression="Telefono" />
            <asp:CommandField ShowDeleteButton="True" ControlStyle-CssClass="btn btn-danger" />
        </Columns>
    </asp:GridView>

</asp:Content>



