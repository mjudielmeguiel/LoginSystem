Imports MySql.Data.MySqlClient

Public Class frmApplicantList

    Private Sub frmApplicantList_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Set hand cursor for all status labels
        lblScreened.Cursor = Cursors.Hand
        lblHRAvatar.Cursor = Cursors.Hand
        lblFinalInterview.Cursor = Cursors.Hand
        lblJobOffer.Cursor = Cursors.Hand
        lblHired.Cursor = Cursors.Hand
        lblOngoingRequirements.Cursor = Cursors.Hand
        lblForOrientation.Cursor = Cursors.Hand
        lblDeployed.Cursor = Cursors.Hand

        ' Load all applicants initially
        LoadApplicants()
    End Sub

    ' --- LOAD ALL APPLICANTS INTO DATAGRIDVIEW ---
    Public Sub LoadApplicants(Optional filterStatus As String = "", Optional searchQuery As String = "")
        connection()
        If cn.State <> ConnectionState.Open Then Exit Sub

        Try
            sql = "SELECT ApplicantID, NAME, POSITION, CONTACT_NO, EMAIL_ADDRESS, CURRENT_STATUS, SITE, DATE FROM applicant_masterlist WHERE 1=1"

            If Not String.IsNullOrEmpty(filterStatus) Then
                sql &= " AND CURRENT_STATUS = @status"
            End If

            If Not String.IsNullOrEmpty(searchQuery) Then
                sql &= " AND (NAME LIKE @search OR POSITION LIKE @search OR EMAIL_ADDRESS LIKE @search)"
            End If

            sql &= " ORDER BY ApplicantID DESC"

            cmd = New MySqlCommand(sql, cn)

            If Not String.IsNullOrEmpty(filterStatus) Then
                cmd.Parameters.AddWithValue("@status", filterStatus)
            End If

            If Not String.IsNullOrEmpty(searchQuery) Then
                cmd.Parameters.AddWithValue("@search", "%" & searchQuery.Trim() & "%")
            End If

            Dim da As New MySqlDataAdapter(cmd)
            Dim dt As New DataTable()
            da.Fill(dt)

            dgvApplicants.DataSource = dt

            If dgvApplicants.Columns.Count > 0 Then
                dgvApplicants.Columns("ApplicantID").HeaderText = "ID"
                dgvApplicants.Columns("NAME").HeaderText = "Applicant Name"
                dgvApplicants.Columns("POSITION").HeaderText = "Position Applied"
                dgvApplicants.Columns("CONTACT_NO").HeaderText = "Contact No."
                dgvApplicants.Columns("EMAIL_ADDRESS").HeaderText = "Email Address"
                dgvApplicants.Columns("CURRENT_STATUS").HeaderText = "Current Status"
                dgvApplicants.Columns("SITE").HeaderText = "Site"
                dgvApplicants.Columns("DATE").HeaderText = "Date Applied"
                dgvApplicants.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
            End If

        Catch ex As Exception
            MsgBox("Error loading applicants: " & ex.Message, MsgBoxStyle.Critical)
        Finally
            CloseConnection()
        End Try
    End Sub

    ' --- SEARCH BOX & REFRESH ---
    Private Sub txtSearch_TextChanged(sender As Object, e As EventArgs) Handles txtSearch.TextChanged
        LoadApplicants("", txtSearch.Text.Trim())
    End Sub

    Private Sub btnRefresh_Click(sender As Object, e As EventArgs) Handles btnRefresh.Click
        txtSearch.Clear()
        ResetLabelStyles()
        LoadApplicants()
    End Sub

    ' --- LABEL CLICK HANDLERS FOR STATUS FILTERING ---
    Private Sub StatusLabel_Click(sender As Object, e As EventArgs) Handles _
        lblScreened.Click, lblHRAvatar.Click, lblFinalInterview.Click,
        lblJobOffer.Click, lblHired.Click, lblOngoingRequirements.Click,
        lblForOrientation.Click, lblDeployed.Click

        Dim selectedLabel As Label = CType(sender, Label)

        ' Reset standard text color on all status labels
        ResetLabelStyles()

        ' Highlight selected status label in bold active blue
        selectedLabel.ForeColor = Color.FromArgb(0, 103, 184)
        selectedLabel.Font = New Font(selectedLabel.Font, FontStyle.Bold)

        ' Filter grid by the text of the clicked Label
        LoadApplicants(selectedLabel.Text.Trim())
    End Sub

    Private Sub ResetLabelStyles()
        Dim statusLabels As Label() = {lblScreened, lblHRAvatar, lblFinalInterview, lblJobOffer, lblHired, lblOngoingRequirements, lblForOrientation, lblDeployed}

        For Each lbl As Label In statusLabels
            If lbl IsNot Nothing Then
                lbl.ForeColor = Color.Black
                lbl.Font = New Font(lbl.Font, FontStyle.Regular)
            End If
        Next
    End Sub

    ' --- OPTIONAL: HOVER VISUAL EFFECTS ---
    Private Sub StatusLabel_MouseEnter(sender As Object, e As EventArgs) Handles _
        lblScreened.MouseEnter, lblHRAvatar.MouseEnter, lblFinalInterview.MouseEnter,
        lblJobOffer.MouseEnter, lblHired.MouseEnter, lblOngoingRequirements.MouseEnter,
        lblForOrientation.MouseEnter, lblDeployed.MouseEnter

        Dim lbl As Label = CType(sender, Label)
        If lbl.Font.Style <> FontStyle.Bold Then
            lbl.ForeColor = Color.FromArgb(0, 103, 184)
        End If
    End Sub

    Private Sub StatusLabel_MouseLeave(sender As Object, e As EventArgs) Handles _
        lblScreened.MouseLeave, lblHRAvatar.MouseLeave, lblFinalInterview.MouseLeave,
        lblJobOffer.MouseLeave, lblHired.MouseLeave, lblOngoingRequirements.MouseLeave,
        lblForOrientation.MouseLeave, lblDeployed.MouseLeave

        Dim lbl As Label = CType(sender, Label)
        If lbl.Font.Style <> FontStyle.Bold Then
            lbl.ForeColor = Color.Black
        End If
    End Sub

End Class