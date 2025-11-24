<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="FormPropietario.aspx.vb" Inherits="ControlVehiculos.FormPropietario" %>

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

        <%-- Persona (ddl) --%>
        <asp:Label ID="lblPersona" runat="server" Text="" CssClass="form-label"></asp:Label>
        <asp:DropDownList ID="ddlPersona" runat="server" CssClass="form-select">
        </asp:DropDownList>

        <asp:RequiredFieldValidator ID="rfvPersona" runat="server"
            ControlToValidate="ddlPersona"
            InitialValue="0"
            ValidationGroup="vgPropietario"
            Display="Dynamic"
            CssClass="alert alert-warning"
            ErrorMessage="Debe seleccionar una persona">
        </asp:RequiredFieldValidator>

        <asp:Button ID="btnGuardar" runat="server"
            CssClass="btn btn-primary btn-hover-move"
            Text="Guardar"
            OnClick="btnGuardar_Click"
            ValidationGroup="vgPropietario" />

        <asp:Button ID="btnActualizar" runat="server"
            Visible="false"
            CssClass="btn btn-success btn-hover-move"
            Text="Actualizar"
            OnClick="btnActualizar_Click"
            ValidationGroup="vgPropietario" />

        <asp:Button ID="btnCancelar" runat="server"
            Visible="false"
            CssClass="btn btn-danger btn-hover-move"
            Text="Cancelar"
            OnClick="btnCancelar_Click" />

        <asp:Label ID="lblMensaje" runat="server" Text=""></asp:Label>

        <asp:ValidationSummary ID="vsPropietario" ValidationGroup="vgPropietario" runat="server"
            ShowSummary="true"
            CssClass="alert alert-warning"
            HeaderText="Corrige los siguientes errores:"
            DisplayMode="BulletList" />

    </div>

    <%-- DataSource para listar propietarios (JOIN con Personas para mostrar nombre completo) --%>
    <asp:SqlDataSource ID="SqlDataSourcePropietarios" runat="server"
        ConnectionString="<%$ ConnectionStrings:II-46ConnectionString %>"
        SelectCommand="
            SELECT 
                p.Idpropietario AS IdPropietario,
                p.IdPersona,
                (per.Nombre + ' ' + per.Apellido1 + ' ' + ISNULL(per.Apellido2, '')) AS NombreCompleto
            FROM Propietarios p
            INNER JOIN Personas per ON p.IdPersona = per.idPersona"></asp:SqlDataSource>

    <asp:GridView ID="gvPropietarios" runat="server"
        CssClass="table table-striped table-hover table-success"
        AutoGenerateColumns="False"
        DataKeyNames="IdPropietario"
        DataSourceID="SqlDataSourcePropietarios"
        OnRowDeleting="gvPropietarios_RowDeleting"
        OnSelectedIndexChanged="gvPropietarios_SelectedIndexChanged"
        Width="100%">

        <Columns>
            <asp:CommandField ShowSelectButton="True" ControlStyle-CssClass="btn btn-success" />

            <asp:BoundField DataField="IdPropietario" HeaderText="IdPropietario"
                ReadOnly="True" SortExpression="IdPropietario" />

            <asp:BoundField DataField="IdPersona" HeaderText="IdPersona"
                SortExpression="IdPersona" />

            <asp:BoundField DataField="NombreCompleto" HeaderText="Nombre completo"
                SortExpression="NombreCompleto" />

            <asp:CommandField ShowDeleteButton="True" ControlStyle-CssClass="btn btn-danger" />
        </Columns>
    </asp:GridView>

</asp:Content>
