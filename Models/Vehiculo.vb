Public Class Vehiculo

    Private _idVehiculo As Integer
    Private _placa As String
    Private _marca As String
    Private _modelo As String
    Private _idPropietario As Integer

    Public Sub New()
    End Sub

    Public Sub New(idVehiculo As Integer, placa As String, marca As String, modelo As String, idPropietario As Integer)
        Me.IdVehiculo = idVehiculo
        Me.Placa = placa
        Me.Marca = marca
        Me.Modelo = modelo
        Me.IdPropietario = idPropietario
    End Sub

    Public Property IdVehiculo As Integer
        Get
            Return _idVehiculo
        End Get
        Set(value As Integer)
            _idVehiculo = value
        End Set
    End Property

    Public Property Placa As String
        Get
            Return _placa
        End Get
        Set(value As String)
            _placa = value
        End Set
    End Property

    Public Property Marca As String
        Get
            Return _marca
        End Get
        Set(value As String)
            _marca = value
        End Set
    End Property

    Public Property Modelo As String
        Get
            Return _modelo
        End Get
        Set(value As String)
            _modelo = value
        End Set
    End Property

    Public Property IdPropietario As Integer
        Get
            Return _idPropietario
        End Get
        Set(value As Integer)
            _idPropietario = value
        End Set
    End Property

End Class