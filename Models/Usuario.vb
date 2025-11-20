Public Class Usuario
    Public Property IdUsuario As Integer
    Public Property NombreUsuario As String
    Public Property Contrasena As String
    Public Property Email As String
    Public Property Rol As String
    Public Property Activo As Boolean

    Public Sub New(nombreUsuario As String, contrasena As String)
        Me.NombreUsuario = nombreUsuario
        Me.Contrasena = contrasena
    End Sub

    Public Sub New()
    End Sub

    Public Sub New(idUsuario As Integer, nombreUsuario As String, contrasena As String, email As String, rol As String, activo As Boolean)
        Me.IdUsuario = idUsuario
        Me.NombreUsuario = nombreUsuario
        Me.Contrasena = contrasena
        Me.Email = email
        Me.Rol = rol
        Me.Activo = activo
    End Sub
End Class
