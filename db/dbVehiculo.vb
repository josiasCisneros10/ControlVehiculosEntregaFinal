Imports System.Data.SqlClient

Public Class dbVehiculo
    Private ReadOnly connectionString As String = ConfigurationManager.ConnectionStrings("II-46ConnectionString").ConnectionString
    Public Function create(vehiculo As Vehiculo) As Boolean
        Try
            Dim sql As String =
                "INSERT INTO Vehiculos (Placa, Marca, Modelo, IdPropietario) 
                 VALUES (@Placa, @Marca, @Modelo, @IdPropietario)"

            Dim parametros As New List(Of SqlParameter) From {
                New SqlParameter("@Placa", vehiculo.Placa),
                New SqlParameter("@Marca", vehiculo.Marca),
                New SqlParameter("@Modelo", vehiculo.Modelo),
                New SqlParameter("@IdPropietario", vehiculo.IdPropietario)
            }

            Using connection As New SqlConnection(connectionString)
                Using command As New SqlCommand(sql, connection)
                    command.Parameters.AddRange(parametros.ToArray())
                    connection.Open()
                    command.ExecuteNonQuery()
                End Using
            End Using

        Catch ex As Exception
            Return False
        End Try

        Return True
    End Function

    Public Function delete(ByVal id As Integer) As String
        Try
            Dim sql As String =
                "DELETE FROM Vehiculos WHERE IdVehiculo = @IdVehiculo"

            Dim parametros As New List(Of SqlParameter) From {
                New SqlParameter("@IdVehiculo", id)
            }

            Using connection As New SqlConnection(connectionString)
                Using command As New SqlCommand(sql, connection)
                    command.Parameters.AddRange(parametros.ToArray())
                    connection.Open()
                    command.ExecuteNonQuery()
                End Using
            End Using

            Return "Vehículo eliminado correctamente"

        Catch ex As Exception
            Return "Error al eliminar el vehículo: " & ex.Message
        End Try
    End Function

    Public Function update(ByVal vehiculo As Vehiculo) As String
        Try
            Dim sql As String =
                "UPDATE Vehiculos 
                 SET Placa = @Placa,
                     Marca = @Marca,
                     Modelo = @Modelo,
                     IdPropietario = @IdPropietario
                 WHERE IdVehiculo = @IdVehiculo"

            Dim parametros As New List(Of SqlParameter) From {
                New SqlParameter("@IdVehiculo", vehiculo.IdVehiculo),
                New SqlParameter("@Placa", vehiculo.Placa),
                New SqlParameter("@Marca", vehiculo.Marca),
                New SqlParameter("@Modelo", vehiculo.Modelo),
                New SqlParameter("@IdPropietario", vehiculo.IdPropietario)
            }

            Using connection As New SqlConnection(connectionString)
                Using command As New SqlCommand(sql, connection)
                    command.Parameters.AddRange(parametros.ToArray())
                    connection.Open()
                    command.ExecuteNonQuery()
                End Using
            End Using

            Return "Vehículo actualizado correctamente"

        Catch ex As Exception
            Return "Error al actualizar el vehículo: " & ex.Message
        End Try
    End Function
End Class
