Imports MySql.Data.MySqlClient

Public Class frmHome

    Private Sub frmHome_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadUserInfoAndCounts()
        lblDateTime.Text = DateTime.Now.ToString("F")
    End Sub

    Private Sub LoadUserInfoAndCounts()
        Try
            connection()
            Dim deptID As Integer = 0
            Dim deptName As String = ""

            sql = "SELECT AdminID, Department FROM admin WHERE FullName=@name"
            cmd = New MySqlCommand(sql, cn)
            cmd.Parameters.AddWithValue("@name", LoggedFullname)
            dr = cmd.ExecuteReader()

            If dr.Read() Then
                deptID = Convert.ToInt32(dr("AdminID"))
                deptName = dr("Department").ToString()
            Else
                dr.Close()
                sql = "SELECT DepartmentID FROM users WHERE FullName=@name"
                cmd = New MySqlCommand(sql, cn)
                cmd.Parameters.AddWithValue("@name", LoggedFullname)
                dr = cmd.ExecuteReader()
                If dr.Read() Then
                    deptID = Convert.ToInt32(dr("DepartmentID"))
                End If
            End If
            dr.Close()

            lblWelcome.Text = "Welcome - " & LoggedFullname
            lblDept.Text = deptName

        Catch ex As Exception
            MsgBox("Error loading data: " & ex.Message, MsgBoxStyle.Critical)
        Finally
            CloseConnection()
        End Try
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        lblDateTime.Text = DateTime.Now.ToString("F")
    End Sub

End Class