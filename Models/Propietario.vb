Public Class Propietario
    Inherits Persona
    Private _idPropietario As Integer
    Private numVehiculos As Integer

    Public Sub New()
        MyBase.New()
    End Sub

    Public Sub New(idPropietario As Integer, numVehiculos As Integer, idPersona As Integer, nombre As String, apellido1 As String, apellido2 As String, nacionalidad As Integer, fechaNacimiento As Date, telefono As String)
        MyBase.New(idPersona, nombre, apellido1, apellido2, nacionalidad, fechaNacimiento, telefono)
        Me.IdPropietario = idPropietario
        Me.NumVehiculos1 = numVehiculos
    End Sub

    Public Sub New(idPropietario As Integer, numVehiculos1 As Integer)
        Me.IdPropietario = idPropietario
        Me.NumVehiculos1 = numVehiculos1
    End Sub

    Public Property IdPropietario As Integer
        Get
            Return _idPropietario
        End Get
        Set(value As Integer)
            _idPropietario = value
        End Set
    End Property

    Public Property NumVehiculos1 As Integer
        Get
            Return numVehiculos
        End Get
        Set(value As Integer)
            numVehiculos = value
        End Set
    End Property
End Class
