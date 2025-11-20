

Imports System.Data.SqlClient
Imports ControlVehiculos.Utils


Public Class FormPropietario
    Inherits System.Web.UI.Page

    Protected dbHelper As New dbPersona()
    Private ReadOnly connectionString As String =
        ConfigurationManager.ConnectionStrings("II-46ConnectionString").ConnectionString

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            CargarPersonas()
            gvPropietarios.DataBind()
        End If
    End Sub

    Public Sub CargarPersonas()
        ddlPersona.DataSource = dbHelper.Consulta()
        ddlPersona.DataTextField = "NombreCompleto"
        ddlPersona.DataValueField = "IdPersona"
        ddlPersona.DataBind()
        ddlPersona.Items.Insert(0, New ListItem("Seleccione una persona", "0"))
    End Sub

    Protected Sub btnGuardar_Click(sender As Object, e As EventArgs)

        If ddlPersona.SelectedValue Is Nothing OrElse ddlPersona.SelectedValue = "0" Then
            ShowSwalError(Me, "Debe seleccionar una persona")
            lblMensaje.Text = "Debe seleccionar una persona"
            lblMensaje.CssClass = "alert alert-danger"
            Return
        End If

        Dim idPersona As Integer
        If Not Integer.TryParse(ddlPersona.SelectedValue, idPersona) OrElse idPersona <= 0 Then
            ShowSwalError(Me, "IdPersona inválido")
            lblMensaje.Text = "IdPersona inválido"
            lblMensaje.CssClass = "alert alert-danger"
            Return
        End If

        Dim yaExiste As Boolean = False
        Try
            Using conn As New SqlConnection(connectionString)
                Using cmd As New SqlCommand("SELECT COUNT(*) FROM Propietarios WHERE IdPersona = @IdPersona", conn)
                    cmd.Parameters.AddWithValue("@IdPersona", idPersona)
                    conn.Open()
                    Dim count As Integer = Convert.ToInt32(cmd.ExecuteScalar())
                    yaExiste = (count > 0)
                End Using
            End Using
        Catch ex As Exception
            ShowSwalError(Me, "Error al validar propietario: " & ex.Message)
            lblMensaje.Text = "Error al validar propietario: " & ex.Message
            lblMensaje.CssClass = "alert alert-danger"
            Return
        End Try

        If yaExiste Then
            ShowSwalError(Me, "Esta persona ya está registrada como propietario")
            lblMensaje.Text = "Esta persona ya está registrada como propietario"
            lblMensaje.CssClass = "alert alert-warning"
            Return
        End If

        Try
            Using conn As New SqlConnection(connectionString)
                Using cmd As New SqlCommand("INSERT INTO Propietarios (IdPersona) VALUES (@IdPersona)", conn)
                    cmd.Parameters.AddWithValue("@IdPersona", idPersona)
                    conn.Open()
                    cmd.ExecuteNonQuery()
                End Using
            End Using

            ShowSwal(Me, "Propietario registrado")
            lblMensaje.Text = "Propietario registrado correctamente"
            lblMensaje.CssClass = "alert alert-success"
            LimpiarCampos()

        Catch ex As Exception
            ShowSwalError(Me, "Error al registrar propietario: " & ex.Message)
            lblMensaje.Text = "Error al registrar propietario: " & ex.Message
            lblMensaje.CssClass = "alert alert-danger"
            Return
        End Try

        gvPropietarios.DataBind()
    End Sub

    Protected Sub gvPropietarios_RowDeleting(sender As Object, e As GridViewDeleteEventArgs)
        Try
            Dim idPropietario As Integer = Convert.ToInt32(gvPropietarios.DataKeys(e.RowIndex).Value)

            Using conn As New SqlConnection(connectionString)
                Using cmd As New SqlCommand("DELETE FROM Propietarios WHERE Idpropietario = @IdPropietario", conn)
                    cmd.Parameters.AddWithValue("@IdPropietario", idPropietario)
                    conn.Open()
                    cmd.ExecuteNonQuery()
                End Using
            End Using

            ShowSwal(Me, "Propietario eliminado")
            lblMensaje.Text = "Propietario eliminado correctamente"
            lblMensaje.CssClass = "alert alert-success"

            e.Cancel = True
            gvPropietarios.DataBind()

        Catch ex As Exception
            Dim msg As String = "Error al eliminar el propietario: " & ex.Message
            ShowSwalError(Me, msg)
            lblMensaje.Text = msg
            lblMensaje.CssClass = "alert alert-danger"
        End Try
    End Sub

    Protected Sub gvPropietarios_SelectedIndexChanged(sender As Object, e As EventArgs)
        Dim row As GridViewRow = gvPropietarios.SelectedRow()
        Dim idPropietario As Integer
        Integer.TryParse(gvPropietarios.SelectedDataKey.Value?.ToString(), idPropietario)

        Dim idPersona As String = row.Cells(2).Text

        If ddlPersona.Items.FindByValue(idPersona) IsNot Nothing Then
            ddlPersona.SelectedValue = idPersona
        End If

        editando.Value = idPropietario.ToString()

        btnActualizar.Visible = True
        btnGuardar.Visible = False
        btnCancelar.Visible = True
    End Sub

    Protected Sub btnActualizar_Click(sender As Object, e As EventArgs)

        If String.IsNullOrWhiteSpace(editando.Value) Then
            ShowSwalError(Me, "No hay propietario seleccionado para actualizar")
            lblMensaje.Text = "No hay propietario seleccionado para actualizar"
            lblMensaje.CssClass = "alert alert-danger"
            Return
        End If

        If ddlPersona.SelectedValue Is Nothing OrElse ddlPersona.SelectedValue = "0" Then
            ShowSwalError(Me, "Debe seleccionar una persona")
            lblMensaje.Text = "Debe seleccionar una persona"
            lblMensaje.CssClass = "alert alert-danger"
            Return
        End If

        Dim idPropietario As Integer
        If Not Integer.TryParse(editando.Value, idPropietario) OrElse idPropietario <= 0 Then
            ShowSwalError(Me, "IdPropietario inválido")
            lblMensaje.Text = "IdPropietario inválido"
            lblMensaje.CssClass = "alert alert-danger"
            Return
        End If

        Dim idPersona As Integer
        If Not Integer.TryParse(ddlPersona.SelectedValue, idPersona) OrElse idPersona <= 0 Then
            ShowSwalError(Me, "IdPersona inválido")
            lblMensaje.Text = "IdPersona inválido"
            lblMensaje.CssClass = "alert alert-danger"
            Return
        End If

        Try
            Using conn As New SqlConnection(connectionString)
                Using cmd As New SqlCommand("UPDATE Propietarios SET IdPersona = @IdPersona WHERE Idpropietario = @IdPropietario", conn)
                    cmd.Parameters.AddWithValue("@IdPersona", idPersona)
                    cmd.Parameters.AddWithValue("@IdPropietario", idPropietario)
                    conn.Open()
                    cmd.ExecuteNonQuery()
                End Using
            End Using

            ShowSwal(Me, "Propietario actualizado")
            lblMensaje.Text = "Propietario actualizado correctamente"
            lblMensaje.CssClass = "alert alert-success"

        Catch ex As Exception
            Dim msg As String = "Error al actualizar el propietario: " & ex.Message
            ShowSwalError(Me, msg)
            lblMensaje.Text = msg
            lblMensaje.CssClass = "alert alert-danger"
            Return
        End Try

        gvPropietarios.DataBind()
        LimpiarCampos()
    End Sub

    Protected Sub btnCancelar_Click(sender As Object, e As EventArgs)
        LimpiarCampos()
    End Sub

    Private Sub LimpiarCampos()
        ddlPersona.SelectedValue = "0"
        editando.Value = ""

        btnGuardar.Visible = True
        btnActualizar.Visible = False
        btnCancelar.Visible = False

        lblMensaje.Text = ""
        lblMensaje.CssClass = ""
    End Sub

End Class
