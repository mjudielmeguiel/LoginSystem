Imports System.Drawing.Drawing2D
Imports MySql.Data.MySqlClient

Public Class frmMain
    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Panel2.Controls.Clear()
        Dim Applicant As New frmApplicantList
        Applicant.TopLevel = False
        Applicant.FormBorderStyle = FormBorderStyle.None
        Applicant.Dock = DockStyle.Fill
        Panel2.Controls.Add(Applicant)
        Applicant.Show()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Panel2.Controls.Clear()
        Dim Home As New frmHome
        Home.TopLevel = False
        Home.FormBorderStyle = FormBorderStyle.None
        Home.Dock = DockStyle.Fill
        Panel2.Controls.Add(Home)
        Home.Show()
    End Sub
End Class