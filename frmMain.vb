Imports System.Drawing.Drawing2D
Imports MySql.Data.MySqlClient

Public Class frmMain

    Private Sub frmMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Menupanel.Visible = False

        lblUserRole.Text = $"{LoggedRole.ToUpper()}"

        Select Case LoggedRole.ToUpper()
            Case "ADMINISTRATOR", "SYSTEM ADMIN"
                'Button3.Visible = True
                Button7.Visible = True
            Case Else
                'Button3.Visible = False
                Button7.Visible = False
        End Select

        ' Apply circular clip to the profile PictureBox
        MakeCircularPictureBox(picProfile)

        Panel2.Controls.Clear()
        Dim Home As New frmHome
        Home.TopLevel = False
        Home.FormBorderStyle = FormBorderStyle.None
        Home.Dock = DockStyle.Fill
        Panel2.Controls.Add(Home)
        Home.Show()
    End Sub

    ' --- CIRCULAR PICTURE BOX SETUP ---
    Private Sub MakeCircularPictureBox(pic As PictureBox)
        pic.SizeMode = PictureBoxSizeMode.StretchImage
        Dim path As New GraphicsPath()
        path.AddEllipse(0, 0, pic.Width, pic.Height)
        pic.Region = New Region(path)
    End Sub

    ' Modern circular border outline around profile picture
    Private Sub picProfile_Paint(sender As Object, e As PaintEventArgs) Handles picProfile.Paint
        e.Graphics.SmoothingMode = SmoothingMode.AntiAlias
        Using pen As New Pen(Color.FromArgb(0, 103, 184), 2) ' Modern Edge Blue Accent Border
            e.Graphics.DrawEllipse(pen, 1, 1, picProfile.Width - 3, picProfile.Height - 3)
        End Using
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        If MsgBox("Are you sure you want to logout?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "Logout") = MsgBoxResult.No Then
            Return
        End If

        Try
            connection()
            sql = "UPDATE users SET Status='Offline' WHERE FullName=@fname"
            cmd = New MySqlCommand(sql, cn)
            cmd.Parameters.AddWithValue("@fname", LoggedFullname)
            cmd.ExecuteNonQuery()
            CloseConnection()
        Catch ex As Exception
            MsgBox("Error updating status: " & ex.Message, MsgBoxStyle.Critical)
        End Try

        LoggedFullname = ""
        LoggedRole = ""
        Me.Hide()
        Application.Restart()
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
        Dim ApplicantList As New frmApplicantList
        ApplicantList.TopLevel = False
        ApplicantList.FormBorderStyle = FormBorderStyle.None
        ApplicantList.Dock = DockStyle.Fill
        Panel2.Controls.Add(ApplicantList)
        ApplicantList.Show()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs)
        frmcreateuser.Show()
        frmcreateuser.TopMost = True
        Me.TopMost = False
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        frmChangePassword.Show()
        frmChangePassword.TopMost = True
        Me.TopMost = False
    End Sub

    Private Sub Button3_Click_1(sender As Object, e As EventArgs) Handles Button3.Click
        frmAddApplicant.Show()
    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        frmcreateuser.Show()
    End Sub
End Class