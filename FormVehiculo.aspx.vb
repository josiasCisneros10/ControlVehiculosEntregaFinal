Imports ControlVehiculos.Utils

Public Class FormVehiculo
    Inherits System.Web.UI.Page
    Public vehiculo As New Vehiculo()
    Protected dbVehiculo As New dbVehiculo

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub btn_guardar(sender As Object, e As EventArgs)

        If String.IsNullOrWhiteSpace(txtPlaca.Text) OrElse
           String.IsNullOrWhiteSpace(txtMarca.Text) OrElse
           String.IsNullOrWhiteSpace(txtModelo.Text) OrElse
           String.IsNullOrWhiteSpace(txtIdPropietario.Text) Then

            ShowSwalError(Me, "Debe completar todos los campos")
            Return
        End If

        Dim idPropietario As Integer
        If Not Integer.TryParse(txtIdPropietario.Text, idPropietario) OrElse idPropietario <= 0 Then
            ShowSwalError(Me, "IdPropietario debe ser un número mayor a cero")
            lblMensaje.Text = "IdPropietario inválido"
            lblMensaje.CssClass = "alert alert-danger"
            Return
        End If

        Dim vehiculo As New Vehiculo With {
            .Placa = txtPlaca.Text.Trim(),
            .Marca = txtMarca.Text.Trim(),
            .Modelo = txtModelo.Text.Trim(),
            .IdPropietario = idPropietario
        }

        If dbVehiculo.create(vehiculo) Then
            ShowSwal(Me, "Vehículo creado")
            lblMensaje.Text = "Vehículo creado correctamente"
            lblMensaje.CssClass = "alert alert-success"
            LimpiarCampos()
        Else
            ShowSwalError(Me, "Ocurrió un error al crear el vehículo")
            lblMensaje.Text = "Ocurrió un error al crear el vehículo"
            lblMensaje.CssClass = "alert alert-danger"
        End If

        gvVehiculo.DataBind()
    End Sub

    Protected Sub gvVehiculo_RowDeleting(sender As Object, e As GridViewDeleteEventArgs)
        Try
            Dim id As Integer = Convert.ToInt32(gvVehiculo.DataKeys(e.RowIndex).Value)
            Dim mensaje As String = dbVehiculo.delete(id)

            If mensaje IsNot Nothing AndAlso mensaje.Contains("Error") Then
                ShowSwalError(Me, mensaje)
                lblMensaje.Text = mensaje
                lblMensaje.CssClass = "alert alert-danger"
            Else
                ShowSwal(Me, mensaje)
                lblMensaje.Text = mensaje
                lblMensaje.CssClass = "alert alert-success"
            End If

            e.Cancel = True
            gvVehiculo.DataBind()

        Catch ex As Exception
            Dim mensaje As String = "Error al eliminar el vehículo: " & ex.Message
            ShowSwalError(Me, mensaje)
            lblMensaje.Text = mensaje
            lblMensaje.CssClass = "alert alert-danger"
        End Try
    End Sub

    Protected Sub gvVehiculo_RowEditing(sender As Object, e As GridViewEditEventArgs)
        gvVehiculo.EditIndex = e.NewEditIndex
        gvVehiculo.DataBind()
    End Sub

    Protected Sub gvVehiculo_RowCancelingEdit(sender As Object, e As GridViewCancelEditEventArgs)
        gvVehiculo.EditIndex = -1
        gvVehiculo.DataBind()
    End Sub

    Protected Sub gvVehiculo_RowUpdating(sender As Object, e As GridViewUpdateEventArgs)
        e.Cancel = True

        Dim id As Integer = Convert.ToInt32(gvVehiculo.DataKeys(e.RowIndex).Value)

        Dim idPropietario As Integer
        Dim idPropObj = e.NewValues("IdPropietario")
        If Not Integer.TryParse(Convert.ToString(idPropObj), idPropietario) OrElse idPropietario <= 0 Then
            Dim msg As String = "IdPropietario inválido en la fila"
            ShowSwalError(Me, msg)
            lblMensaje.Text = msg
            lblMensaje.CssClass = "alert alert-danger"
            Return
        End If

        Dim vehiculo As New Vehiculo With {
            .IdVehiculo = id,
            .Placa = Convert.ToString(e.NewValues("Placa")),
            .Marca = Convert.ToString(e.NewValues("Marca")),
            .Modelo = Convert.ToString(e.NewValues("Modelo")),
            .IdPropietario = idPropietario
        }

        Dim mensaje As String = dbVehiculo.update(vehiculo)

        If mensaje IsNot Nothing AndAlso mensaje.Contains("Error") Then
            ShowSwalError(Me, mensaje)
            lblMensaje.Text = mensaje
            lblMensaje.CssClass = "alert alert-danger"
            Return
        Else
            ShowSwal(Me, mensaje)
            lblMensaje.Text = mensaje
            lblMensaje.CssClass = "alert alert-success"
        End If

        gvVehiculo.DataBind()
        gvVehiculo.EditIndex = -1
        btnGuardar.Visible = True
    End Sub

    Protected Sub gvVehiculo_SelectedIndexChanged(sender As Object, e As EventArgs)
        Dim row As GridViewRow = gvVehiculo.SelectedRow()
        Dim idVehiculo As Integer
        Integer.TryParse(gvVehiculo.SelectedDataKey.Value?.ToString(), idVehiculo)

        txtPlaca.Text = row.Cells(3).Text
        txtMarca.Text = row.Cells(4).Text
        txtModelo.Text = row.Cells(5).Text
        txtIdPropietario.Text = row.Cells(6).Text

        editando.Value = idVehiculo.ToString()

        btnActualizar.Visible = True
        btnGuardar.Visible = False
        btnCancelar.Visible = True
    End Sub

    Protected Sub btnActualizar_Click(sender As Object, e As EventArgs)

        If String.IsNullOrWhiteSpace(editando.Value) Then
            ShowSwalError(Me, "No hay vehículo seleccionado para actualizar")
            lblMensaje.Text = "No hay vehículo seleccionado para actualizar"
            lblMensaje.CssClass = "alert alert-danger"
            Return
        End If

        If String.IsNullOrWhiteSpace(txtPlaca.Text) OrElse
           String.IsNullOrWhiteSpace(txtMarca.Text) OrElse
           String.IsNullOrWhiteSpace(txtModelo.Text) OrElse
           String.IsNullOrWhiteSpace(txtIdPropietario.Text) Then

            ShowSwalError(Me, "Debe completar todos los campos")
            Return
        End If

        Dim idPropietario As Integer
        If Not Integer.TryParse(txtIdPropietario.Text, idPropietario) OrElse idPropietario <= 0 Then
            ShowSwalError(Me, "IdPropietario inválido")
            lblMensaje.Text = "IdPropietario inválido"
            lblMensaje.CssClass = "alert alert-danger"
            Return
        End If

        Dim vehiculo As New Vehiculo With {
            .IdVehiculo = Convert.ToInt32(editando.Value),
            .Placa = txtPlaca.Text.Trim(),
            .Marca = txtMarca.Text.Trim(),
            .Modelo = txtModelo.Text.Trim(),
            .IdPropietario = idPropietario
        }

        Dim mensaje As String = dbVehiculo.update(vehiculo)

        If mensaje IsNot Nothing AndAlso mensaje.Contains("Error") Then
            ShowSwalError(Me, mensaje)
            lblMensaje.Text = mensaje
            lblMensaje.CssClass = "alert alert-danger"
            Return
        Else
            ShowSwal(Me, mensaje)
            lblMensaje.Text = mensaje
            lblMensaje.CssClass = "alert alert-success"
        End If

        gvVehiculo.DataBind()
        gvVehiculo.EditIndex = -1

        LimpiarCampos()
    End Sub

    Protected Sub btnCancelar_Click(sender As Object, e As EventArgs)
        LimpiarCampos()
    End Sub

    Private Sub LimpiarCampos()
        btnActualizar.Visible = False
        btnGuardar.Visible = True
        btnCancelar.Visible = False

        txtPlaca.Text = ""
        txtMarca.Text = ""
        txtModelo.Text = ""
        txtIdPropietario.Text = ""
        editando.Value = ""
        lblMensaje.Text = ""
        lblMensaje.CssClass = ""
    End Sub

End Class