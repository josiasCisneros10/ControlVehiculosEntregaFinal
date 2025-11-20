Imports System.Data.SqlClient
Imports System.Security.Cryptography

Public Class dbPersona
    Private ReadOnly connectionString As String = ConfigurationManager.ConnectionStrings("II-46ConnectionString").ConnectionString
    Dim dbHelper = New DbHelper() ' Clase para manejar conexiones y consultas

    Public Function create(Persona As Persona) As Boolean
        Try
            Dim sql As String = "INSERT INTO Personas (Nombre, Apellido1, Apellido2, Nacionalidad, FechaNacimiento, Telefono) " &
                                "VALUES (@Nombre, @Apellido1, @Apellido2, @Nacionalidad, @FechaNacimiento, @Telefono)"
            Dim Parametros As New List(Of SqlParameter) From {
                New SqlParameter("@Nombre", Persona.Nombre),
                New SqlParameter("@Apellido1", Persona.Apellido1),
                New SqlParameter("@Apellido2", Persona.Apellido2),
                New SqlParameter("@Nacionalidad", Persona.Nacionalidad),
                New SqlParameter("@FechaNacimiento", Persona.FechaNacimiento),
                New SqlParameter("@Telefono", Persona.Telefono)
            }
            dbHelper.ExecuteNonQuery(sql, Parametros)
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

    Public Function delete(ByRef id As Integer) As String
        Try
            Dim sql As String = "DELETE FROM Personas WHERE idPersona = @idPersona"
            Dim Parametros As New List(Of SqlParameter) From {
            New SqlParameter("@idPersona", id)
        }
            Using connetion As New SqlConnection(connectionString)
                Using command As New SqlCommand(sql, connetion)
                    command.Parameters.AddRange(Parametros.ToArray())
                    connetion.Open()
                    command.ExecuteNonQuery()
                End Using
            End Using
        Catch ex As Exception
        End Try
        Return "Persona eliminada"
    End Function

    Public Function update(ByRef Persona As Persona) As String
        Try
            Dim sql As String = "UPDATE Personas SET Nombre = @Nombre, Apellido1 = @Apellido1, Apellido2 = @Apellido2, Nacionalidad = @Nacionalidad, FechaNacimiento = @FechaNacimiento, Telefono = @Telefono WHERE idPersona = @idPersona"
            Dim Parametros As New List(Of SqlParameter) From {
                New SqlParameter("@idPersona", Persona.IdPersona),
                New SqlParameter("@Nombre", Persona.Nombre),
                New SqlParameter("@Apellido1", Persona.Apellido1),
                New SqlParameter("@Apellido2", Persona.Apellido2),
                New SqlParameter("@Nacionalidad", Persona.Nacionalidad),
                New SqlParameter("@FechaNacimiento", Persona.FechaNacimiento),
                New SqlParameter("@Telefono", Persona.Telefono)
            }

            Using connetion As New SqlConnection(connectionString)
                Using command As New SqlCommand(sql, connetion)
                    command.Parameters.AddRange(Parametros.ToArray())
                    connetion.Open()
                    command.ExecuteNonQuery()
                End Using
            End Using
        Catch ex As Exception
        End Try
        Return "Persona actualizada"
    End Function

    Public Function Consulta() As DataTable
        Try
            Dim sql As String =
            "SELECT " &
            "idPersona AS IdPersona, " &
            "CONCAT(Nombre, ' ', Apellido1, ' ', ISNULL(Apellido2, '')) AS NombreCompleto " &
            "FROM Personas"

            Return dbHelper.ExecuteQuery(sql, New List(Of SqlParameter)())
        Catch ex As Exception
            Return New DataTable()
        End Try
    End Function
End Class
