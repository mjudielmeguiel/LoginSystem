Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Reflection
Imports MySql.Data.MySqlClient

Public Class frmHome

    Private currentSelectedStatus As String = ""

    Private Sub frmHome_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        EnableDoubleBuffering(dgvApplicants)
        EnableDoubleBuffering(lvPositions)
        EnableDoubleBuffering(lvLocations)

        SetupPositionsListView()
        SetupLocationsListView()
        SetupApplicantsDataGridView()

        RefreshAllDashboardData()
    End Sub

    Public Sub RefreshAllDashboardData()
        LoadPositionsList()
        LoadLocationsList()
        LoadApplicantsGrid(txtSearchApplicant.Text.Trim(), currentSelectedStatus)
        LoadStatusCounts()
        LoadPositionsAndLocationsTotals()
    End Sub

    Private Sub EnableDoubleBuffering(control As Control)
        Dim doubleBufferProperty = GetType(Control).GetProperty("DoubleBuffered", BindingFlags.Instance Or BindingFlags.NonPublic)
        doubleBufferProperty?.SetValue(control, True, Nothing)
    End Sub

    Private Sub ApplyModernPortalGridStyle(dgv As DataGridView)
        With dgv
            .EnableHeadersVisualStyles = False
            .BorderStyle = BorderStyle.None
            .CellBorderStyle = DataGridViewCellBorderStyle.None
            .RowHeadersVisible = False
            .BackgroundColor = Color.White
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect

            .ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None
            .ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(235, 237, 245)
            .ColumnHeadersDefaultCellStyle.ForeColor = Color.FromArgb(20, 20, 35)
            .ColumnHeadersDefaultCellStyle.Font = New Font("Segoe UI Semibold", 9.5!, FontStyle.Bold)
            .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            .ColumnHeadersHeight = 42

            .RowsDefaultCellStyle.BackColor = Color.White
            .RowsDefaultCellStyle.ForeColor = Color.FromArgb(40, 40, 50)
            .RowsDefaultCellStyle.Font = New Font("Segoe UI", 9.0!, FontStyle.Regular)

            .AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(238, 240, 255)
            .AlternatingRowsDefaultCellStyle.ForeColor = Color.FromArgb(40, 40, 50)

            .DefaultCellStyle.SelectionBackColor = Color.FromArgb(210, 215, 240)
            .DefaultCellStyle.SelectionForeColor = Color.FromArgb(20, 20, 30)

            .RowTemplate.Height = 40
            .AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        End With
    End Sub

    Private Sub dgvApplicants_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles dgvApplicants.CellFormatting
        If e.RowIndex < 0 Then Exit Sub

        If e.ColumnIndex = 0 Then
            e.CellStyle.BackColor = Color.FromArgb(215, 220, 245)
            e.CellStyle.ForeColor = Color.FromArgb(20, 20, 35)
            e.CellStyle.Font = New Font("Segoe UI Semibold", 9.0!, FontStyle.Bold)
        End If
    End Sub

    Private Sub dgvApplicants_CellPainting(sender As Object, e As DataGridViewCellPaintingEventArgs) Handles dgvApplicants.CellPainting
        If e.RowIndex < 0 Then Exit Sub

        If e.ColumnIndex >= 0 AndAlso (dgvApplicants.Columns(e.ColumnIndex).Name = "btnEdit" OrElse dgvApplicants.Columns(e.ColumnIndex).Name = "btnReject") Then
            e.Paint(e.CellBounds, DataGridViewPaintParts.Background Or DataGridViewPaintParts.Border)

            Dim isEdit As Boolean = (dgvApplicants.Columns(e.ColumnIndex).Name = "btnEdit")
            Dim btnText As String = If(isEdit, "EDIT", "REJECT")
            Dim btnColor As Color = If(isEdit, Color.FromArgb(10, 25, 85), Color.FromArgb(180, 30, 30))

            Dim paddingV As Integer = 6
            Dim paddingH As Integer = 5
            Dim btnRect As New Rectangle(
                e.CellBounds.X + paddingH,
                e.CellBounds.Y + paddingV,
                e.CellBounds.Width - (paddingH * 2),
                e.CellBounds.Height - (paddingV * 2)
            )

            If btnRect.Width > 0 AndAlso btnRect.Height > 0 Then
                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias

                Using path As New GraphicsPath()
                    Dim diameter As Integer = btnRect.Height
                    path.AddArc(btnRect.X, btnRect.Y, diameter, diameter, 90, 180)
                    path.AddArc(btnRect.Right - diameter, btnRect.Y, diameter, diameter, 270, 180)
                    path.CloseFigure()

                    Using fillBrush As New SolidBrush(btnColor)
                        e.Graphics.FillPath(fillBrush, path)
                    End Using
                End Using

                TextRenderer.DrawText(e.Graphics, btnText, New Font("Segoe UI", 8.25!, FontStyle.Bold), btnRect, Color.White, TextFormatFlags.HorizontalCenter Or TextFormatFlags.VerticalCenter)
            End If

            e.Handled = True
        End If
    End Sub

    Private Sub txtSearchApplicant_TextChanged(sender As Object, e As EventArgs) Handles txtSearchApplicant.TextChanged
        LoadApplicantsGrid(txtSearchApplicant.Text.Trim(), currentSelectedStatus)
    End Sub

    Private Sub FilterByStatus(statusName As String)
        currentSelectedStatus = statusName
        LoadApplicantsGrid(txtSearchApplicant.Text.Trim(), currentSelectedStatus)
    End Sub

    Private Sub Card_Screened_Click(sender As Object, e As EventArgs) Handles lblCountScreened.Click
        FilterByStatus("Screened")
    End Sub

    Private Sub Card_HRAvatar_Click(sender As Object, e As EventArgs) Handles lblCountHRAvatar.Click
        FilterByStatus("HR Avatar")
    End Sub

    Private Sub Card_FinalInterview_Click(sender As Object, e As EventArgs) Handles lblCountFinalInterview.Click
        FilterByStatus("Final Interview")
    End Sub

    Private Sub Card_JobOffer_Click(sender As Object, e As EventArgs) Handles lblCountJobOffer.Click
        FilterByStatus("Job Offer")
    End Sub

    Private Sub Card_Hired_Click(sender As Object, e As EventArgs) Handles lblCountHired.Click
        FilterByStatus("Hired")
    End Sub

    Private Sub Card_Ongoing_Click(sender As Object, e As EventArgs) Handles lblCountOngoing.Click
        FilterByStatus("Ongoing Requirements")
    End Sub

    Private Sub Card_Orientation_Click(sender As Object, e As EventArgs) Handles lblCountOrientation.Click
        FilterByStatus("For Orientation")
    End Sub

    Private Sub Card_Deployed_Click(sender As Object, e As EventArgs) Handles lblCountDeployed.Click
        FilterByStatus("Deployed")
    End Sub

    Private Sub Card_Rejected_Click(sender As Object, e As EventArgs) Handles lblCountRejected.Click
        FilterByStatus("Rejected")
    End Sub

    Private Sub Card_Pooling_Click(sender As Object, e As EventArgs) Handles lblCountPooling.Click
        FilterByStatus("Pooling")
    End Sub

    Private Sub Card_Backout_Click(sender As Object, e As EventArgs) Handles lblCountBackout.Click
        FilterByStatus("Backout")
    End Sub

    Private Sub Card_Inactive_Click(sender As Object, e As EventArgs) Handles lblCountInactive.Click
        FilterByStatus("Inactive")
    End Sub

    Private Sub btnRefresh_Click(sender As Object, e As EventArgs) Handles btnRefresh.Click
        txtSearchApplicant.Clear()
        currentSelectedStatus = "ALL"
        RefreshAllDashboardData()
    End Sub

    Private Sub SetupPositionsListView()
        With lvPositions
            .View = View.Details
            .GridLines = True
            .FullRowSelect = True
            .Columns.Clear()
            .Columns.Add("Position Title", 180, HorizontalAlignment.Left)
            .Columns.Add("Slots Available", 100, HorizontalAlignment.Center)
            .Columns.Add("Hired Count", 90, HorizontalAlignment.Center)
            .Columns.Add("Remaining Slots", 110, HorizontalAlignment.Center)
        End With
    End Sub

    Private Sub SetupLocationsListView()
        With lvLocations
            .View = View.Details
            .GridLines = True
            .FullRowSelect = True
            .Columns.Clear()
            .Columns.Add("Location / Site", 180, HorizontalAlignment.Left)
            .Columns.Add("Slots Available", 100, HorizontalAlignment.Center)
            .Columns.Add("Hired Count", 90, HorizontalAlignment.Center)
            .Columns.Add("Remaining Slots", 110, HorizontalAlignment.Center)
        End With
    End Sub

    Private Sub SetupApplicantsDataGridView()
        With dgvApplicants
            .Columns.Clear()
            .AutoGenerateColumns = False

            .Columns.Add(New DataGridViewTextBoxColumn With {
                .Name = "ApplicantID",
                .HeaderText = "Control No.",
                .DataPropertyName = "ApplicantID",
                .FillWeight = 40,
                .ReadOnly = True
            })

            .Columns.Add(New DataGridViewTextBoxColumn With {
                .Name = "NAME",
                .HeaderText = "Applicant Name",
                .DataPropertyName = "NAME",
                .FillWeight = 110,
                .ReadOnly = True
            })

            .Columns.Add(New DataGridViewTextBoxColumn With {
                .Name = "POSITION",
                .HeaderText = "Position",
                .DataPropertyName = "POSITION",
                .FillWeight = 100,
                .ReadOnly = True
            })

            .Columns.Add(New DataGridViewTextBoxColumn With {
                .Name = "SITE",
                .HeaderText = "Site / Location",
                .DataPropertyName = "SITE",
                .FillWeight = 90,
                .ReadOnly = True
            })

            .Columns.Add(New DataGridViewTextBoxColumn With {
                .Name = "CURRENT_STATUS",
                .HeaderText = "Status",
                .DataPropertyName = "CURRENT_STATUS",
                .FillWeight = 80,
                .ReadOnly = True
            })

            .Columns.Add(New DataGridViewButtonColumn With {
                .Name = "btnEdit",
                .HeaderText = "Action",
                .FillWeight = 50,
                .FlatStyle = FlatStyle.Flat
            })

            .Columns.Add(New DataGridViewButtonColumn With {
                .Name = "btnReject",
                .HeaderText = "",
                .FillWeight = 50,
                .FlatStyle = FlatStyle.Flat
            })
        End With

        ApplyModernPortalGridStyle(dgvApplicants)
    End Sub

    Public Sub LoadPositionsList()
        Try
            connection()
            If cn.State <> ConnectionState.Open Then Exit Sub

            Dim query As String = "SELECT position_title, slots_available, hired_count FROM positions ORDER BY position_title ASC"

            Using cmd As New MySqlCommand(query, cn), dr As MySqlDataReader = cmd.ExecuteReader()
                lvPositions.BeginUpdate()
                lvPositions.Items.Clear()

                While dr.Read()
                    Dim title As String = If(dr.IsDBNull(0), "N/A", dr.GetString(0))
                    Dim slots As Integer = If(dr.IsDBNull(1), 0, dr.GetInt32(1))
                    Dim hired As Integer = If(dr.IsDBNull(2), 0, dr.GetInt32(2))
                    Dim remaining As Integer = slots - hired

                    Dim item As New ListViewItem(title)
                    item.UseItemStyleForSubItems = True
                    item.SubItems.Add(slots.ToString())
                    item.SubItems.Add(hired.ToString())
                    item.SubItems.Add(remaining.ToString())

                    item.ForeColor = If(remaining <= 0, Color.Red, Color.DarkGreen)
                    lvPositions.Items.Add(item)
                End While
            End Using

        Catch ex As Exception
            MsgBox("Error loading positions list: " & ex.Message, MsgBoxStyle.Critical)
        Finally
            lvPositions.EndUpdate()
            CloseConnection()
        End Try
    End Sub

    Public Sub LoadLocationsList()
        Try
            connection()
            If cn.State <> ConnectionState.Open Then Exit Sub

            Dim query As String = "SELECT Site, slots_available, hired_count FROM Location ORDER BY Site ASC"

            Using cmd As New MySqlCommand(query, cn), dr As MySqlDataReader = cmd.ExecuteReader()
                lvLocations.BeginUpdate()
                lvLocations.Items.Clear()

                While dr.Read()
                    Dim siteName As String = If(dr.IsDBNull(0), "N/A", dr.GetString(0))
                    Dim slots As Integer = If(dr.IsDBNull(1), 0, dr.GetInt32(1))
                    Dim hired As Integer = If(dr.IsDBNull(2), 0, dr.GetInt32(2))
                    Dim remaining As Integer = slots - hired

                    Dim item As New ListViewItem(siteName)
                    item.UseItemStyleForSubItems = True
                    item.SubItems.Add(slots.ToString())
                    item.SubItems.Add(hired.ToString())
                    item.SubItems.Add(remaining.ToString())

                    item.ForeColor = If(remaining <= 0, Color.Red, Color.DarkGreen)
                    lvLocations.Items.Add(item)
                End While
            End Using

        Catch ex As Exception
            MsgBox("Error loading locations list: " & ex.Message, MsgBoxStyle.Critical)
        Finally
            lvLocations.EndUpdate()
            CloseConnection()
        End Try
    End Sub

    Public Sub LoadApplicantsGrid(Optional searchKeyword As String = "", Optional statusFilter As String = "")
        Try
            connection()
            If cn.State <> ConnectionState.Open Then Exit Sub

            Dim query As String = "SELECT ApplicantID, NAME, POSITION, SITE, CURRENT_STATUS " &
                                  "FROM applicant_masterlist WHERE 1=1 "

            If statusFilter.ToUpper() = "ALL" Then
            ElseIf Not String.IsNullOrWhiteSpace(statusFilter) Then
                query &= "AND CURRENT_STATUS = @statusFilter "
            Else
                query &= "AND CURRENT_STATUS NOT IN ('Rejected', 'Deployed') "
            End If

            If Not String.IsNullOrWhiteSpace(searchKeyword) Then
                query &= "AND (NAME LIKE @search OR POSITION LIKE @search OR SITE LIKE @search OR CURRENT_STATUS LIKE @search) "
            End If

            query &= "ORDER BY ApplicantID DESC"

            Using cmd As New MySqlCommand(query, cn)
                If Not String.IsNullOrWhiteSpace(statusFilter) AndAlso statusFilter.ToUpper() <> "ALL" Then
                    cmd.Parameters.AddWithValue("@statusFilter", statusFilter)
                End If

                If Not String.IsNullOrWhiteSpace(searchKeyword) Then
                    cmd.Parameters.AddWithValue("@search", "%" & searchKeyword & "%")
                End If

                Using adapter As New MySqlDataAdapter(cmd)
                    Dim dt As New DataTable()
                    adapter.Fill(dt)
                    dgvApplicants.DataSource = dt
                End Using
            End Using

            Dim formattedStatus As String = statusFilter.Trim().ToLower()
            Dim shouldHideActions As Boolean = (formattedStatus = "rejected" OrElse formattedStatus = "backout")

            If dgvApplicants.Columns.Contains("btnEdit") Then
                dgvApplicants.Columns("btnEdit").Visible = Not shouldHideActions
            End If

            If dgvApplicants.Columns.Contains("btnReject") Then
                dgvApplicants.Columns("btnReject").Visible = Not shouldHideActions
            End If

        Catch ex As Exception
            MsgBox("Error loading applicants list: " & ex.Message, MsgBoxStyle.Critical)
        Finally
            CloseConnection()
        End Try
    End Sub

    Private Sub dgvApplicants_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvApplicants.CellContentClick
        If e.RowIndex < 0 Then Exit Sub

        Dim colName As String = dgvApplicants.Columns(e.ColumnIndex).Name
        Dim applicantID As Integer = Convert.ToInt32(dgvApplicants.Rows(e.RowIndex).Cells("ApplicantID").Value)
        Dim applicantName As String = dgvApplicants.Rows(e.RowIndex).Cells("NAME").Value.ToString()

        If colName = "btnEdit" Then
            MsgBox($"Opening details for: {applicantName} (ID: {applicantID})", MsgBoxStyle.Information, "Edit Applicant")

        ElseIf colName = "btnReject" Then
            If MsgBox($"Are you sure you want to mark '{applicantName}' as Rejected?", MsgBoxStyle.YesNo Or MsgBoxStyle.Question, "Confirm Rejection") = MsgBoxResult.Yes Then
                RejectApplicant(applicantID)
            End If
        End If
    End Sub

    Private Sub RejectApplicant(id As Integer)
        Try
            connection()
            If cn.State <> ConnectionState.Open Then Exit Sub

            Dim query As String = "UPDATE applicant_masterlist SET CURRENT_STATUS='Rejected', REJECTED_DATE=NOW() WHERE ApplicantID=@id"
            Using cmd As New MySqlCommand(query, cn)
                cmd.Parameters.AddWithValue("@id", id)
                cmd.ExecuteNonQuery()
            End Using

            MsgBox("Applicant marked as Rejected.", MsgBoxStyle.Information, "Status Updated")

            LoadApplicantsGrid(txtSearchApplicant.Text.Trim(), currentSelectedStatus)
            LoadStatusCounts()

        Catch ex As Exception
            MsgBox("Error updating applicant status: " & ex.Message, MsgBoxStyle.Critical)
        Finally
            CloseConnection()
        End Try
    End Sub

    Public Sub LoadStatusCounts()
        Dim labels = {lblCountScreened, lblCountHRAvatar, lblCountFinalInterview,
                      lblCountJobOffer, lblCountHired, lblCountOngoing,
                      lblCountOrientation, lblCountDeployed, lblCountRejected,
                      lblCountPooling, lblCountBackout, lblCountInactive}

        For Each lbl In labels
            If lbl IsNot Nothing Then lbl.Text = "0"
        Next

        Try
            connection()
            If cn.State <> ConnectionState.Open Then Exit Sub

            Dim query As String = "SELECT CURRENT_STATUS, COUNT(*) AS TotalCount " &
                                  "FROM applicant_masterlist " &
                                  "WHERE CURRENT_STATUS IS NOT NULL " &
                                  "GROUP BY CURRENT_STATUS"

            Using cmd As New MySqlCommand(query, cn), dr As MySqlDataReader = cmd.ExecuteReader()
                While dr.Read()
                    Dim statusName As String = dr("CURRENT_STATUS").ToString().Trim().ToLower()
                    Dim countVal As String = dr("TotalCount").ToString()

                    Select Case statusName
                        Case "screened" : lblCountScreened.Text = countVal
                        Case "hr avatar" : lblCountHRAvatar.Text = countVal
                        Case "final interview" : lblCountFinalInterview.Text = countVal
                        Case "job offer" : lblCountJobOffer.Text = countVal
                        Case "hired" : lblCountHired.Text = countVal
                        Case "ongoing requirements", "ongoing" : lblCountOngoing.Text = countVal
                        Case "for orientation" : lblCountOrientation.Text = countVal
                        Case "deployed" : lblCountDeployed.Text = countVal
                        Case "rejected" : lblCountRejected.Text = countVal
                        Case "pooling" : lblCountPooling.Text = countVal
                        Case "backout" : lblCountBackout.Text = countVal
                        Case "inactive" : lblCountInactive.Text = countVal
                    End Select
                End While
            End Using

        Catch ex As Exception
            MsgBox("Error loading applicant status counts: " & ex.Message, MsgBoxStyle.Critical)
        Finally
            CloseConnection()
        End Try
    End Sub

    Public Sub LoadPositionsAndLocationsTotals()
        lblTotalPositionSlots.Text = "0"
        lblTotalPositionHired.Text = "0"
        lblTotalLocationSlots.Text = "0"
        lblTotalLocationHired.Text = "0"

        Try
            connection()
            If cn.State <> ConnectionState.Open Then Exit Sub

            Dim queryPositions As String = "SELECT IFNULL(SUM(slots_available), 0) AS TotalSlots, IFNULL(SUM(hired_count), 0) AS TotalHired FROM positions"
            Using cmd As New MySqlCommand(queryPositions, cn), dr As MySqlDataReader = cmd.ExecuteReader()
                If dr.Read() Then
                    lblTotalPositionSlots.Text = dr("TotalSlots").ToString()
                    lblTotalPositionHired.Text = dr("TotalHired").ToString()
                End If
            End Using

            Dim queryLocations As String = "SELECT IFNULL(SUM(slots_available), 0) AS TotalSlots, IFNULL(SUM(hired_count), 0) AS TotalHired FROM Location"
            Using cmd As New MySqlCommand(queryLocations, cn), dr As MySqlDataReader = cmd.ExecuteReader()
                If dr.Read() Then
                    lblTotalLocationSlots.Text = dr("TotalSlots").ToString()
                    lblTotalLocationHired.Text = dr("TotalHired").ToString()
                End If
            End Using

        Catch ex As Exception
            MsgBox("Error loading positions and locations totals: " & ex.Message, MsgBoxStyle.Critical)
        Finally
            CloseConnection()
        End Try
    End Sub

    Private Sub Button13_Click(sender As Object, e As EventArgs) Handles Button13.Click
        frmAddApplicant.ShowDialog()
        RefreshAllDashboardData()
    End Sub

End Class