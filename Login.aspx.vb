Imports System.Data.SqlClient
Imports ControlVehiculos.Utils

Public Class Login
    Inherits System.Web.UI.Page
    Protected dbHelper As New dbLogin()

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub btnIniciarSesion_Click(sender As Object, e As EventArgs) Handles btnIniciarSesion.Click
        Dim Usuario As String = txtUsuario.Text
        Dim Password As String = txtPassword.Text
        Dim encrypter As New Simple3Des("MiClaveSecreta123") ' Clave de encriptación
        Dim pass As String = encrypter.EncryptData(Password) ' Encriptar la contraseña
        Dim dbHelper As New dbLogin()
        Dim isValid As Boolean = dbHelper.ValidateLogin(Usuario, pass)
        If isValid Then
            ' Inicio de sesión exitoso
            Dim User As Usuario = dbHelper.GetUser(Usuario) ' Obtener el usuario
            Session("Usuario") = User ' Guardar el usuario en la sesión
            If User.Rol = "2" Then
                Response.Redirect("Admin.aspx") ' Redirigir a la página de administración
                Return
            End If
            Response.Redirect("Home.aspx") ' Redirigir a la página principal
        Else
            ' Credenciales incorrectas
            SwalUtils.ShowSwalError(Me, "Error de inicio de sesión", "Credenciales incorrectas.")
        End If

    End Sub
End Class