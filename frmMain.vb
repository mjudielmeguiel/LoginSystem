Imports MySql.Data.MySqlClient

Public Class frmMain

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        If MsgBox("Are you sure you want to logout?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "Logout") = MsgBoxResult.No Then
            Return
        End If

        Try
            connection()
            sql = "UPDATE users SET AccountStatus='Offline' WHERE FullName=@fname"
            cmd = New MySqlCommand(sql, cn)
            cmd.Parameters.AddWithValue("@fname", LoggedFullname)
            cmd.ExecuteNonQuery()
            CloseConnection()
        Catch ex As Exception
            MsgBox("Error updating status: " & ex.Message, MsgBoxStyle.Critical)
        End Try

        LoggedFullname = ""
        Me.Hide()
        Application.Restart()
    End Sub

    Private Sub frmMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Menupanel.Visible = False

        Panel2.Controls.Clear()
        Dim Home As New frmHome
        Home.TopLevel = False
        Home.FormBorderStyle = FormBorderStyle.None
        Home.Dock = DockStyle.Fill
        Panel2.Controls.Add(Home)
        Home.Show()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Menupanel.Visible = Not Menupanel.Visible
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Panel2.Controls.Clear()
        Dim Home As New frmHome
        Home.TopLevel = False
        Home.FormBorderStyle = FormBorderStyle.None
        Home.Dock = DockStyle.Fill
        Panel2.Controls.Add(Home)
        Home.Show()
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        Panel2.Controls.Clear()
        Dim User As New frmuserInformation
        User.TopLevel = False
        User.FormBorderStyle = FormBorderStyle.None
        User.Dock = DockStyle.Fill
        Panel2.Controls.Add(User)
        User.Show()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        frmcreateuser.Show()
        frmcreateuser.TopMost = True
        Me.TopMost = False
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        frmInformation.Show()
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        frmChangePassword.Show()
    End Sub
End Class