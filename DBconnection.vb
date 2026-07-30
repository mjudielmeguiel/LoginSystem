Imports MySql.Data.MySqlClient

Module DBconnection
    Public cn As New MySqlConnection
    Public cmd As MySqlCommand
    Public dr As MySqlDataReader
    Public sql As String
    Public LoggedFullname As String
    ' ✅ DAGDAG: Ito ang nawawala kaya may error
    Public LoggedRole As String = ""

    Public Sub connection()
        Try
            If cn.State = ConnectionState.Open Then
                cn.Close()
            End If

            cn.ConnectionString = "server=localhost;user=root;password=;database=logindb"
            cn.Open()
            MsgBox("Connection Success!", MsgBoxStyle.Information) ' ✅ PINANATILING GAYA NG GUSTO MO
        Catch ex As Exception
            MsgBox("Connection Failed: " & ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Public Sub CloseConnection()
        If cn.State = ConnectionState.Open Then
            cn.Close()
        End If
    End Sub
End Module