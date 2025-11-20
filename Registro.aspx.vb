Imports ControlVehiculos.Utils
Public Class Registro
    Inherits System.Web.UI.Page
    Protected dbHelper As New dbLogin()

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub btnRegistrar_Click(sender As Object, e As EventArgs)
        Dim nombreUsuario = txtUsuario.Text
        Dim Password = txtPassword.Text
        Dim ConfirmPassword = txtConfirmarPassword.Text
        If Password <> ConfirmPassword Then
            ShowSwalError(Me, "Error de registro", "Las contraseñas no coinciden.")
            Return
        End If
        Dim encrypter As New Simple3Des("MiClaveSecreta123") ' Clave de encriptación
        Dim pass As String = encrypter.EncryptData(Password)
        Dim usuario As Usuario = New Usuario(nombreUsuario, pass)
        usuario.Email = txtEmail.Text

        Dim mensaje = dbHelper.RegisterUser(usuario)
        If mensaje.Contains("Error") Then
            ShowSwalError(Me, "Error", mensaje)
        Else
            ShowSwal(Me, mensaje)
        End If
    End Sub
End Class