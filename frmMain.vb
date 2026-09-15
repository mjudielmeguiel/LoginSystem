Imports System.Drawing.Drawing2D
Imports MySql.Data.MySqlClient

Public Class frmMain

    Private Sub frmMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Panel2.Controls.Clear()
        Dim Home As New frmHome
        Home.TopLevel = False
        Home.FormBorderStyle = FormBorderStyle.None
        Home.Dock = DockStyle.Fill
        Panel2.Controls.Add(Home)
        Home.Show()
    End Sub

    Private Sub ExitToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExitToolStripMenuItem.Click
        Application.Exit()
    End Sub

    Private Sub SwitchAccountToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SwitchAccountToolStripMenuItem.Click
        Application.Restart()
    End Sub

    Private Sub SettingsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SettingsToolStripMenuItem.Click
        Panel2.Controls.Clear()
        Dim Settings As New frmSettings
        Settings.TopLevel = False
        Settings.FormBorderStyle = FormBorderStyle.None
        Settings.Dock = DockStyle.Fill
        Panel2.Controls.Add(Settings)
        Settings.Show()
    End Sub

    Private Sub ApplicantMasterlistToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ApplicantMasterlistToolStripMenuItem.Click
        Panel2.Controls.Clear()
        Dim Applicant As New frmApplicantList
        Applicant.TopLevel = False
        Applicant.FormBorderStyle = FormBorderStyle.None
        Applicant.Dock = DockStyle.Fill
        Panel2.Controls.Add(Applicant)
        Applicant.Show()
    End Sub
End Class