Public Class Persona

    Private _idPersona As Integer
    Private _nombre As String
    Private _apellido1 As String
    Private _apellido2 As String
    Private _nacionalidad As String
    Private _fechaNacimiento As Date
    Private _telefono As String

    Public Sub New()
    End Sub

    Public Sub New(idPersona As Integer, nombre As String, apellido1 As String, apellido2 As String, nacionalidad As String, fechaNacimiento As Date, telefono As String)
        Me.IdPersona = idPersona
        Me.Nombre = nombre
        Me.Apellido1 = apellido1
        Me.Apellido2 = apellido2
        Me.Nacionalidad = nacionalidad
        Me.FechaNacimiento = fechaNacimiento
        Me.Telefono = telefono
    End Sub

    Public Property IdPersona As Integer
        Get
            Return _idPersona
        End Get
        Set(value As Integer)
            _idPersona = value
        End Set
    End Property

    Public Property Nombre As String
        Get
            Return _nombre
        End Get
        Set(value As String)
            _nombre = value
        End Set
    End Property

    Public Property Apellido1 As String
        Get
            Return _apellido1
        End Get
        Set(value As String)
            _apellido1 = value
        End Set
    End Property
    Public Property Apellido2 As String
        Get
            Return _apellido2
        End Get
        Set(value As String)
            _apellido2 = value
        End Set
    End Property

    Public Property Nacionalidad As String
        Get
            Return _nacionalidad
        End Get
        Set(value As String)
            _nacionalidad = value
        End Set
    End Property

    Public Property FechaNacimiento As Date
        Get
            Return _fechaNacimiento
        End Get
        Set(value As Date)
            _fechaNacimiento = value
        End Set
    End Property

    Public Property Telefono As String
        Get
            Return _telefono
        End Get
        Set(value As String)
            _telefono = value
        End Set
    End Property
End Class
