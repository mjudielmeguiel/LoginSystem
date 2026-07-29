Imports MySql.Data.MySqlClient

Public Class frmHome

    Private Sub frmHome_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadAdminInfo()
        LoadDashboardCounts()
        lblDateTime.Text = DateTime.Now.ToString("F")
    End Sub

    Private Sub LoadAdminInfo()
        Try
            connection()

            lblWelcome.Text = "Welcome - " & LoggedFullname

            cmd = New MySqlCommand("SELECT Department, FullName FROM admin WHERE FullName=@name", cn)
            cmd.Parameters.AddWithValue("@name", LoggedFullname)
            dr = cmd.ExecuteReader()

            If dr.Read() Then
                lblDept.Text = dr("Department").ToString()
                lblWelcome.Text = "Welcome - " & dr("FullName").ToString()
            End If
            dr.Close()

        Catch ex As Exception
            MsgBox("Error loading data: " & ex.Message, MsgBoxStyle.Critical)
        Finally
            CloseConnection()
        End Try
    End Sub

    Private Sub LoadDashboardCounts()
        Try
            connection()
            Dim adminDeptID As Integer = 0

            ' Kunin muna ang DepartmentID ng Admin
            sql = "SELECT AdminID FROM admin WHERE FullName=@adminname"
            cmd = New MySqlCommand(sql, cn)
            cmd.Parameters.AddWithValue("@adminname", LoggedFullname)
            dr = cmd.ExecuteReader()

            If dr.Read() Then
                adminDeptID = Convert.ToInt32(dr("AdminID"))
            End If
            dr.Close()

            ' Bilangin lang ang mga User na nasa parehong DepartmentID
            cmd = New MySqlCommand("SELECT COUNT(UserID) FROM users WHERE DepartmentID=@deptid", cn)
            cmd.Parameters.AddWithValue("@deptid", adminDeptID)
            lblTotalUsers.Text = cmd.ExecuteScalar().ToString()

            cmd = New MySqlCommand("SELECT COUNT(UserID) FROM users WHERE DepartmentID=@deptid AND AccountStatus = 'Active'", cn)
            cmd.Parameters.AddWithValue("@deptid", adminDeptID)
            lblActiveUsers.Text = cmd.ExecuteScalar().ToString()

            cmd = New MySqlCommand("SELECT COUNT(UserID) FROM users WHERE DepartmentID=@deptid AND AccountStatus = 'Locked'", cn)
            cmd.Parameters.AddWithValue("@deptid", adminDeptID)
            lblLockedAccounts.Text = cmd.ExecuteScalar().ToString()

        Catch ex As Exception
            MsgBox("Error loading counts: " & ex.Message, MsgBoxStyle.Critical)
        Finally
            CloseConnection()
        End Try
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        lblDateTime.Text = DateTime.Now.ToString("F")
    End Sub

End Class