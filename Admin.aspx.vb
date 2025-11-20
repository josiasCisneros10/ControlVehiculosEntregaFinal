Public Class Admin
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim Usuario As Usuario = Session("Usuario")
        lblUsuario.Text = "Bienvenido " & Usuario.NombreUsuario
        lblEmail.Text = "Correo electronico: " & Usuario.Email
    End Sub

End Class