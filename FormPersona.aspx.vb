

Imports ControlVehiculos.Utils

Public Class FormPersona
    Inherits System.Web.UI.Page
    Public persona As New Persona()
    Protected dbPersona As New dbPersona

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub btn_guardar(sender As Object, e As EventArgs)

        ' Validaciones básicas de campos obligatorios
        If String.IsNullOrWhiteSpace(txtNombre.Text) OrElse
           String.IsNullOrWhiteSpace(txtApellido1.Text) OrElse
           String.IsNullOrWhiteSpace(txtNacionalidad.Text) OrElse
           String.IsNullOrWhiteSpace(txtFechanac.Text) OrElse
           String.IsNullOrWhiteSpace(txtTelefono.Text) Then

            ShowSwalError(Me, "Debe completar todos los campos obligatorios")
            Return
        End If

        ' Validar fecha
        Dim fechaNacimiento As DateTime
        If Not DateTime.TryParse(txtFechanac.Text, fechaNacimiento) Then
            ShowSwalError(Me, "Fecha de nacimiento inválida")
            lblMensaje.Text = "Fecha de nacimiento inválida"
            lblMensaje.CssClass = "alert alert-danger"
            Return
        End If

        Dim persona As New Persona With {
            .Nombre = txtNombre.Text.Trim(),
            .Apellido1 = txtApellido1.Text.Trim(),
            .Apellido2 = TxtApellido2.Text.Trim(),
            .Nacionalidad = txtNacionalidad.Text.Trim(),
            .FechaNacimiento = fechaNacimiento,
            .Telefono = txtTelefono.Text.Trim()
        }

        If dbPersona.create(persona) Then
            ShowSwal(Me, "Persona guardada")
            lblMensaje.Text = "Persona guardada correctamente"
            lblMensaje.CssClass = "alert alert-success"
            LimpiarCampos()
        Else
            ShowSwalError(Me, "Ocurrió un error al guardar la persona")
            lblMensaje.Text = "Ocurrió un error al guardar la persona"
            lblMensaje.CssClass = "alert alert-danger"
        End If

        gvPersonas.DataBind()
    End Sub

    Protected Sub gvPersonas_RowDeleting(sender As Object, e As GridViewDeleteEventArgs)
        Try
            Dim id As Integer = Convert.ToInt32(gvPersonas.DataKeys(e.RowIndex).Value)
            Dim mensaje As String = dbPersona.delete(id)

            If mensaje.Contains("Error") Then
                ShowSwalError(Me, mensaje)
                lblMensaje.Text = mensaje
                lblMensaje.CssClass = "alert alert-danger"
            Else
                ShowSwal(Me, mensaje)
                lblMensaje.Text = mensaje
                lblMensaje.CssClass = "alert alert-success"
            End If

            e.Cancel = True
            gvPersonas.DataBind()

        Catch ex As Exception
            Dim mensaje As String = "Error al eliminar la persona: " & ex.Message
            ShowSwalError(Me, mensaje)
            lblMensaje.Text = mensaje
            lblMensaje.CssClass = "alert alert-danger"
        End Try
    End Sub

    Protected Sub gvPersonas_RowEditing(sender As Object, e As GridViewEditEventArgs)
        gvPersonas.EditIndex = e.NewEditIndex
        gvPersonas.DataBind()
    End Sub

    Protected Sub gvPersonas_RowCancelingEdit(sender As Object, e As GridViewCancelEditEventArgs)
        gvPersonas.EditIndex = -1
        gvPersonas.DataBind()
    End Sub

    Protected Sub gvPersonas_RowUpdating(sender As Object, e As GridViewUpdateEventArgs)
        e.Cancel = True

        Dim id As Integer = Convert.ToInt32(gvPersonas.DataKeys(e.RowIndex).Value)

        Dim persona As New Persona With {
            .IdPersona = id,
            .Nombre = Convert.ToString(e.NewValues("Nombre")),
            .Apellido1 = Convert.ToString(e.NewValues("Apellido1")),
            .Apellido2 = Convert.ToString(e.NewValues("Apellido2")),
            .Nacionalidad = Convert.ToString(e.NewValues("Nacionalidad")),
            .Telefono = Convert.ToString(e.NewValues("Telefono"))
        }

        Dim fechaObj = e.NewValues("FechaNacimiento")
        Dim fechaNacimiento As DateTime
        If Not DateTime.TryParse(Convert.ToString(fechaObj), fechaNacimiento) Then
            Dim mensajeError As String = "Fecha de nacimiento inválida"
            ShowSwalError(Me, mensajeError)
            lblMensaje.Text = mensajeError
            lblMensaje.CssClass = "alert alert-danger"
            Return
        End If
        persona.FechaNacimiento = fechaNacimiento

        Dim mensajeUpdate As String = dbPersona.update(persona)

        If mensajeUpdate.Contains("Error") Then
            ShowSwalError(Me, mensajeUpdate)
            lblMensaje.Text = mensajeUpdate
            lblMensaje.CssClass = "alert alert-danger"
            Return
        Else
            ShowSwal(Me, mensajeUpdate)
            lblMensaje.Text = mensajeUpdate
            lblMensaje.CssClass = "alert alert-success"
        End If

        gvPersonas.DataBind()
        gvPersonas.EditIndex = -1
        btnGuardar.Visible = True
    End Sub

    Protected Sub gvPersonas_SelectedIndexChanged(sender As Object, e As EventArgs)
        Dim row As GridViewRow = gvPersonas.SelectedRow()
        Dim idPersona As Integer
        Integer.TryParse(gvPersonas.SelectedDataKey.Value?.ToString(), idPersona)

        txtNombre.Text = row.Cells(3).Text
        txtApellido1.Text = row.Cells(4).Text
        TxtApellido2.Text = row.Cells(5).Text
        txtNacionalidad.Text = row.Cells(6).Text
        txtFechanac.Text = row.Cells(7).Text
        txtTelefono.Text = row.Cells(8).Text

        editando.Value = idPersona.ToString()

        btnActualizar.Visible = True
        btnGuardar.Visible = False
        btnCancelar.Visible = True
    End Sub

    Protected Sub btnActualizar_Click(sender As Object, e As EventArgs)

        If String.IsNullOrWhiteSpace(editando.Value) Then
            ShowSwalError(Me, "No hay persona seleccionada para actualizar")
            lblMensaje.Text = "No hay persona seleccionada para actualizar"
            lblMensaje.CssClass = "alert alert-danger"
            Return
        End If

        If String.IsNullOrWhiteSpace(txtNombre.Text) OrElse
           String.IsNullOrWhiteSpace(txtApellido1.Text) OrElse
           String.IsNullOrWhiteSpace(txtNacionalidad.Text) OrElse
           String.IsNullOrWhiteSpace(txtFechanac.Text) OrElse
           String.IsNullOrWhiteSpace(txtTelefono.Text) Then

            ShowSwalError(Me, "Debe completar todos los campos obligatorios")
            Return
        End If

        Dim fechaNacimiento As DateTime
        If Not DateTime.TryParse(txtFechanac.Text, fechaNacimiento) Then
            ShowSwalError(Me, "Fecha inválida")
            lblMensaje.Text = "Fecha inválida"
            lblMensaje.CssClass = "alert alert-danger"
            Return
        End If

        Dim persona As New Persona With {
            .IdPersona = Convert.ToInt32(editando.Value),
            .Nombre = txtNombre.Text.Trim(),
            .Apellido1 = txtApellido1.Text.Trim(),
            .Apellido2 = TxtApellido2.Text.Trim(),
            .Nacionalidad = txtNacionalidad.Text.Trim(),
            .FechaNacimiento = fechaNacimiento,
            .Telefono = txtTelefono.Text.Trim()
        }

        Dim mensaje As String = dbPersona.update(persona)

        If mensaje.Contains("Error") Then
            ShowSwalError(Me, mensaje)
            lblMensaje.Text = mensaje
            lblMensaje.CssClass = "alert alert-danger"
            Return
        Else
            ShowSwal(Me, mensaje)
            lblMensaje.Text = mensaje
            lblMensaje.CssClass = "alert alert-success"
        End If

        gvPersonas.DataBind()
        gvPersonas.EditIndex = -1

        LimpiarCampos()
    End Sub

    Protected Sub btnCancelar_Click(sender As Object, e As EventArgs)
        LimpiarCampos()
    End Sub

    Protected Sub LimpiarCampos()
        btnActualizar.Visible = False
        btnGuardar.Visible = True
        btnCancelar.Visible = False

        txtNombre.Text = ""
        txtApellido1.Text = ""
        TxtApellido2.Text = ""
        txtNacionalidad.Text = ""
        txtFechanac.Text = ""
        txtTelefono.Text = ""
        editando.Value = ""
        lblMensaje.Text = ""
        lblMensaje.CssClass = ""
    End Sub

End Class