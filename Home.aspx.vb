Public Class Home
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim Usuario As Usuario = Session("Usuario")
        lblUsuario.Text = Usuario.NombreUsuario
        lblEmail.Text = Usuario.Email
    End Sub
End Class