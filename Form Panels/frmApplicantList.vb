Imports MySql.Data.MySqlClient
Imports System.Drawing.Drawing2D
Imports System.IO
Imports Excel = Microsoft.Office.Interop.Excel

Public Class frmApplicantList

    Private Sub frmApplicantList_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        lblScreened.Tag = "Screened"
        lblHRAvatar.Tag = "HR Avatar"
        lblFinalInterview.Tag = "Final Interview"
        lblJobOffer.Tag = "Job Offer"
        lblHired.Tag = "Hired"
        lblOngoingRequirements.Tag = "Ongoing Requirements"
        lblForOrientation.Tag = "For Orientation"
        lblDeployed.Tag = "Deployed"
        lblPooling.Tag = "Pooling"
        lblBackout.Tag = "Backout"
        lblRejected.Tag = "Rejected"
        lblInactive.Tag = "Inactive"

        Dim statusLabels As Label() = {lblScreened, lblHRAvatar, lblFinalInterview, lblJobOffer, lblHired, lblOngoingRequirements, lblForOrientation, lblDeployed, lblPooling, lblBackout, lblRejected, lblInactive}
        For Each lbl As Label In statusLabels
            If lbl IsNot Nothing Then lbl.Cursor = Cursors.Hand
        Next

        ApplyDataGridViewStyling()
        RefreshData()
    End Sub

    Private Sub ApplyDataGridViewStyling()
        With dgvApplicants
            .BorderStyle = BorderStyle.None
            .AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(245, 247, 250)
            .RowsDefaultCellStyle.BackColor = Color.White
            .CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal
            .DefaultCellStyle.SelectionBackColor = Color.FromArgb(215, 228, 242)
            .DefaultCellStyle.SelectionForeColor = Color.Black
            .BackgroundColor = Color.White
            .EnableHeadersVisualStyles = False

            With .ColumnHeadersDefaultCellStyle
                .BackColor = Color.FromArgb(24, 43, 73)
                .ForeColor = Color.White
                .Font = New Font(dgvApplicants.Font.FontFamily, 10, FontStyle.Bold)
                .Alignment = DataGridViewContentAlignment.MiddleLeft
            End With

            .ColumnHeadersHeight = 35
            .RowTemplate.Height = 35
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
            .MultiSelect = False
            .RowHeadersVisible = False
        End With
    End Sub

    Private Sub RefreshData()
        Dim activeStatus As String = ""
        Dim statusLabels As Label() = {lblScreened, lblHRAvatar, lblFinalInterview, lblJobOffer, lblHired, lblOngoingRequirements, lblForOrientation, lblDeployed, lblPooling, lblBackout, lblRejected, lblInactive}

        For Each lbl As Label In statusLabels
            If lbl IsNot Nothing AndAlso lbl.Font.Style = FontStyle.Bold AndAlso lbl.Tag IsNot Nothing Then
                activeStatus = lbl.Tag.ToString()
                Exit For
            End If
        Next

        UpdateStatusCounts(dtpFrom.Value, dtpTo.Value)
        LoadApplicants(activeStatus, txtSearch.Text.Trim(), dtpFrom.Value, dtpTo.Value)
    End Sub

    Private Sub UpdateStatusCounts(fromDate As DateTime, toDate As DateTime)
        connection()
        If cn.State <> ConnectionState.Open Then Exit Sub

        Try
            Dim sqlCounts = "SELECT CURRENT_STATUS, COUNT(*) as TotalCount FROM applicant_masterlist WHERE DATE(`DATE`) BETWEEN @fromDate AND @toDate GROUP BY CURRENT_STATUS"
            cmd = New MySqlCommand(sqlCounts, cn)
            cmd.Parameters.AddWithValue("@fromDate", fromDate.ToString("yyyy-MM-dd"))
            cmd.Parameters.AddWithValue("@toDate", toDate.ToString("yyyy-MM-dd"))

            Dim dtCounts As New DataTable()
            Dim daCounts As New MySqlDataAdapter(cmd)
            daCounts.Fill(dtCounts)

            Dim countsDict As New Dictionary(Of String, Integer)(StringComparer.OrdinalIgnoreCase)
            For Each row As DataRow In dtCounts.Rows
                Dim st As String = row("CURRENT_STATUS").ToString()
                countsDict(st) = Convert.ToInt32(row("TotalCount"))
            Next

            Dim statusLabels As Label() = {lblScreened, lblHRAvatar, lblFinalInterview, lblJobOffer, lblHired, lblOngoingRequirements, lblForOrientation, lblDeployed, lblPooling, lblBackout, lblRejected, lblInactive}

            For Each lbl As Label In statusLabels
                If lbl IsNot Nothing AndAlso lbl.Tag IsNot Nothing Then
                    Dim statusName As String = lbl.Tag.ToString()
                    Dim count As Integer = If(countsDict.ContainsKey(statusName), countsDict(statusName), 0)
                    lbl.Text = statusName & " (" & count & ")"
                End If
            Next
        Catch ex As Exception
        Finally
            CloseConnection()
        End Try
    End Sub

    Public Sub LoadApplicants(Optional filterStatus As String = "", Optional searchQuery As String = "", Optional fromDate As DateTime? = Nothing, Optional toDate As DateTime? = Nothing)
        connection()
        If cn.State <> ConnectionState.Open Then Exit Sub

        Try
            sql = "SELECT ApplicantID, NAME, POSITION, CONTACT_NO, EMAIL_ADDRESS, CURRENT_STATUS, SITE, `DATE`, " &
                  "BARANGAY_CLEARANCE, POLICE_CLEARANCE, NBI, SSS, PHILHEALTH, PAGIBIG, TIN, MEDICAL, DIPLOMA, TOR " &
                  "FROM applicant_masterlist WHERE 1=1"

            If Not String.IsNullOrEmpty(filterStatus) Then
                sql &= " AND CURRENT_STATUS = @status"
            End If

            If Not String.IsNullOrEmpty(searchQuery) Then
                sql &= " AND (NAME LIKE @search OR POSITION LIKE @search OR EMAIL_ADDRESS LIKE @search)"
            End If

            If fromDate.HasValue AndAlso toDate.HasValue Then
                sql &= " AND DATE(`DATE`) BETWEEN @fromDate AND @toDate"
            End If

            sql &= " ORDER BY ApplicantID DESC"

            cmd = New MySqlCommand(sql, cn)

            If Not String.IsNullOrEmpty(filterStatus) Then
                cmd.Parameters.AddWithValue("@status", filterStatus)
            End If

            If Not String.IsNullOrEmpty(searchQuery) Then
                cmd.Parameters.AddWithValue("@search", "%" & searchQuery.Trim() & "%")
            End If

            If fromDate.HasValue AndAlso toDate.HasValue Then
                cmd.Parameters.AddWithValue("@fromDate", fromDate.Value.ToString("yyyy-MM-dd"))
                cmd.Parameters.AddWithValue("@toDate", toDate.Value.ToString("yyyy-MM-dd"))
            End If

            Dim da As New MySqlDataAdapter(cmd)
            Dim dtOriginal As New DataTable()
            da.Fill(dtOriginal)

            Dim dtDisplay As New DataTable()
            dtDisplay.Columns.Add("ApplicantID", GetType(Integer))
            dtDisplay.Columns.Add("NO", GetType(Integer))
            dtDisplay.Columns.Add("NAME", GetType(String))
            dtDisplay.Columns.Add("POSITION", GetType(String))
            dtDisplay.Columns.Add("CONTACT_NO", GetType(String))
            dtDisplay.Columns.Add("EMAIL_ADDRESS", GetType(String))
            dtDisplay.Columns.Add("Requirements", GetType(String))
            dtDisplay.Columns.Add("CURRENT_STATUS", GetType(String))
            dtDisplay.Columns.Add("SITE", GetType(String))
            dtDisplay.Columns.Add("DATE", GetType(String))

            Dim rowNumber As Integer = 1
            For Each row As DataRow In dtOriginal.Rows
                Dim submittedCount As Integer = 0
                Dim reqFields As String() = {"BARANGAY_CLEARANCE", "POLICE_CLEARANCE", "NBI", "SSS", "PHILHEALTH", "PAGIBIG", "TIN", "MEDICAL", "DIPLOMA", "TOR"}
                For Each field As String In reqFields
                    If row(field).ToString() = "Submitted" Then submittedCount += 1
                Next
                Dim percentage As Integer = submittedCount * 10

                dtDisplay.Rows.Add(
                    row("ApplicantID"),
                    rowNumber,
                    row("NAME"),
                    row("POSITION"),
                    row("CONTACT_NO"),
                    row("EMAIL_ADDRESS"),
                    percentage.ToString() & "%",
                    row("CURRENT_STATUS"),
                    row("SITE"),
                    row("DATE")
                )
                rowNumber += 1
            Next

            dgvApplicants.DataSource = dtDisplay

            If lblTotalApplicants IsNot Nothing Then
                lblTotalApplicants.Text = "Total Applicants: " & dtOriginal.Rows.Count.ToString()
            End If

            If dgvApplicants.Columns.Count > 0 Then
                dgvApplicants.Columns("ApplicantID").Visible = False
                dgvApplicants.Columns("NO").HeaderText = "No."
                dgvApplicants.Columns("NAME").HeaderText = "Applicant Name"
                dgvApplicants.Columns("POSITION").HeaderText = "Position Applied"
                dgvApplicants.Columns("CONTACT_NO").HeaderText = "Contact No."
                dgvApplicants.Columns("EMAIL_ADDRESS").HeaderText = "Email Address"
                dgvApplicants.Columns("Requirements").HeaderText = "Requirements %"
                dgvApplicants.Columns("CURRENT_STATUS").HeaderText = "Current Status"
                dgvApplicants.Columns("SITE").HeaderText = "Site"
                dgvApplicants.Columns("DATE").HeaderText = "Date Applied"
                dgvApplicants.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
            End If

            If Not dgvApplicants.Columns.Contains("btnEditColumn") Then
                Dim btnEdit As New DataGridViewButtonColumn()
                btnEdit.Name = "btnEditColumn"
                btnEdit.HeaderText = "Action"
                btnEdit.Text = "EDIT"
                btnEdit.UseColumnTextForButtonValue = True
                btnEdit.FlatStyle = FlatStyle.Flat
                dgvApplicants.Columns.Add(btnEdit)
            End If

            If Not dgvApplicants.Columns.Contains("btnRejectColumn") Then
                Dim btnReject As New DataGridViewButtonColumn()
                btnReject.Name = "btnRejectColumn"
                btnReject.HeaderText = ""
                btnReject.Text = "REJECT"
                btnReject.UseColumnTextForButtonValue = True
                btnReject.FlatStyle = FlatStyle.Flat
                dgvApplicants.Columns.Add(btnReject)
            End If

        Catch ex As Exception
            MsgBox("Error loading applicants: " & ex.Message, MsgBoxStyle.Critical)
        Finally
            CloseConnection()
        End Try
    End Sub

    ' --- EXPORT ALL DATABASE COLUMNS WITH UPDATED COLOR CODING TO EXCEL WORKBOOK ---
    Private Sub btnExportExcel_Click(sender As Object, e As EventArgs) Handles btnExportExcel.Click
        connection()
        If cn.State <> ConnectionState.Open Then Exit Sub

        Dim xlApp As Excel.Application = Nothing
        Dim xlWorkBook As Excel.Workbook = Nothing
        Dim xlWorkSheet As Excel.Worksheet = Nothing

        Try
            Dim exportSql = "SELECT * FROM applicant_masterlist WHERE 1=1"
            exportSql &= " AND DATE(`DATE`) BETWEEN @fromDate AND @toDate"

            Dim activeStatus As String = ""
            Dim statusLabels As Label() = {lblScreened, lblHRAvatar, lblFinalInterview, lblJobOffer, lblHired, lblOngoingRequirements, lblForOrientation, lblDeployed, lblPooling, lblBackout, lblRejected, lblInactive}
            For Each lbl As Label In statusLabels
                If lbl IsNot Nothing AndAlso lbl.Font.Style = FontStyle.Bold AndAlso lbl.Tag IsNot Nothing Then
                    activeStatus = lbl.Tag.ToString()
                    Exit For
                End If
            Next

            If Not String.IsNullOrEmpty(activeStatus) Then
                exportSql &= " AND CURRENT_STATUS = @status"
            End If

            If Not String.IsNullOrEmpty(txtSearch.Text.Trim()) Then
                exportSql &= " AND (NAME LIKE @search OR POSITION LIKE @search OR EMAIL_ADDRESS LIKE @search)"
            End If

            exportSql &= " ORDER BY ApplicantID DESC"

            cmd = New MySqlCommand(exportSql, cn)
            cmd.Parameters.AddWithValue("@fromDate", dtpFrom.Value.ToString("yyyy-MM-dd"))
            cmd.Parameters.AddWithValue("@toDate", dtpTo.Value.ToString("yyyy-MM-dd"))
            If Not String.IsNullOrEmpty(activeStatus) Then
                cmd.Parameters.AddWithValue("@status", activeStatus)
            End If
            If Not String.IsNullOrEmpty(txtSearch.Text.Trim()) Then
                cmd.Parameters.AddWithValue("@search", "%" & txtSearch.Text.Trim() & "%")
            End If

            Dim da As New MySqlDataAdapter(cmd)
            Dim dtExport As New DataTable()
            da.Fill(dtExport)

            If dtExport.Rows.Count = 0 Then
                MsgBox("No data available to export.", MsgBoxStyle.Exclamation, "Export Warning")
                Exit Sub
            End If

            xlApp = New Excel.Application()
            xlWorkBook = xlApp.Workbooks.Add(System.Reflection.Missing.Value)
            xlWorkSheet = CType(xlWorkBook.Sheets(1), Excel.Worksheet)
            xlWorkSheet.Name = "Applicant Masterlist"

            ' 1. SUMMARY BLOCK ON TOP
            xlWorkSheet.Cells(1, 1) = dtpFrom.Value.ToString("MMMM yyyy").ToUpper() & " ONWARDS"
            xlWorkSheet.Cells(1, 1).Font.Bold = True

            xlWorkSheet.Range("C1:D1").Merge()
            xlWorkSheet.Cells(1, 3) = "TOTAL ACQUIRED"
            With xlWorkSheet.Range("C1:D1")
                .Interior.Color = ColorTranslator.ToOle(Color.FromArgb(176, 42, 42))
                .Font.Color = ColorTranslator.ToOle(Color.White)
                .Font.Bold = True
                .HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
            End With

            xlWorkSheet.Cells(1, 5) = dtExport.Rows.Count
            xlWorkSheet.Cells(1, 5).Font.Bold = True
            xlWorkSheet.Cells(1, 5).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter

            Dim statusesLeft As String() = {"Screened", "HR Avatar", "Final Interview", "Hired", "Ongoing Requirements", "Deployed"}
            Dim statusesRight As String() = {"Job Offer", "For Orientation", "Rejected", "Pooling", "Backout", "Inactive"}

            For i = 0 To statusesLeft.Length - 1
                Dim rowIdx As Integer = i + 2
                xlWorkSheet.Cells(rowIdx, 1) = statusesLeft(i)
                xlWorkSheet.Cells(rowIdx, 2) = GetStatusCountFromLabel(statusesLeft(i))

                xlWorkSheet.Cells(rowIdx, 3) = statusesRight(i)
                xlWorkSheet.Cells(rowIdx, 4) = GetStatusCountFromLabel(statusesRight(i))
            Next

            ' 2. MAIN DATA TABLE STARTING AT ROW 10
            Dim startRow As Integer = 10

            Dim excelColumns As New List(Of String) From {
                "NO", "DATE", "POSITION", "NAME", "CONTACT_NO", "EMAIL_ADDRESS", "ADDRESS", "SITE",
                "CURRENT_STATUS", "SOURCE", "BARANGAY_CLEARANCE", "POLICE_CLEARANCE", "NBI", "SSS",
                "PHILHEALTH", "PAGIBIG", "TIN", "MEDICAL", "DIPLOMA", "TOR", "REQUIREMENTS_PERCENTAGE",
                "DATE_SCREENED", "FINAL_INTERVIEW_DATE", "JOB_OFFER_DATE", "DATE_HIRED", "DATE_DEPLOYED",
                "REJECTED_DATE", "BACKOUT_DATE", "REMARKS", "REQUIREMENTS_COMPLETION_DATE", "RESUME"
            }

            For i = 0 To excelColumns.Count - 1
                xlWorkSheet.Cells(startRow, i + 1) = excelColumns(i)
            Next

            Dim headerRange As Excel.Range = xlWorkSheet.Range(xlWorkSheet.Cells(startRow, 1), xlWorkSheet.Cells(startRow, excelColumns.Count))
            headerRange.Interior.Color = ColorTranslator.ToOle(Color.FromArgb(243, 229, 213))
            headerRange.Font.Bold = True
            headerRange.Borders.LineStyle = Excel.XlLineStyle.xlContinuous

            Dim rIdx As Integer = startRow + 1
            Dim exportRowNumber As Integer = 1
            For Each row As DataRow In dtExport.Rows
                Dim submittedCount As Integer = 0
                Dim reqFieldNames As String() = {"BARANGAY_CLEARANCE", "POLICE_CLEARANCE", "NBI", "SSS", "PHILHEALTH", "PAGIBIG", "TIN", "MEDICAL", "DIPLOMA", "TOR"}
                For Each field As String In reqFieldNames
                    If row(field).ToString() = "Submitted" Then submittedCount += 1
                Next
                Dim pctString As String = (submittedCount * 10).ToString() & "%"

                xlWorkSheet.Cells(rIdx, 1) = exportRowNumber
                xlWorkSheet.Cells(rIdx, 2) = If(row("DATE") Is DBNull.Value, "", Convert.ToDateTime(row("DATE")).ToString("yyyy-MM-dd HH:mm"))
                xlWorkSheet.Cells(rIdx, 3) = If(row("POSITION") Is DBNull.Value, "", row("POSITION").ToString())
                xlWorkSheet.Cells(rIdx, 4) = If(row("NAME") Is DBNull.Value, "", row("NAME").ToString())
                xlWorkSheet.Cells(rIdx, 5) = If(row("CONTACT_NO") Is DBNull.Value, "", row("CONTACT_NO").ToString())
                xlWorkSheet.Cells(rIdx, 6) = If(row("EMAIL_ADDRESS") Is DBNull.Value, "", row("EMAIL_ADDRESS").ToString())
                xlWorkSheet.Cells(rIdx, 7) = If(row("ADDRESS") Is DBNull.Value, "", row("ADDRESS").ToString())
                xlWorkSheet.Cells(rIdx, 8) = If(row("SITE") Is DBNull.Value, "", row("SITE").ToString())
                xlWorkSheet.Cells(rIdx, 9) = If(row("CURRENT_STATUS") Is DBNull.Value, "", row("CURRENT_STATUS").ToString())
                xlWorkSheet.Cells(rIdx, 10) = If(row("SOURCE") Is DBNull.Value, "", row("SOURCE").ToString())
                xlWorkSheet.Cells(rIdx, 11) = If(row("BARANGAY_CLEARANCE") Is DBNull.Value, "", row("BARANGAY_CLEARANCE").ToString())
                xlWorkSheet.Cells(rIdx, 12) = If(row("POLICE_CLEARANCE") Is DBNull.Value, "", row("POLICE_CLEARANCE").ToString())
                xlWorkSheet.Cells(rIdx, 13) = If(row("NBI") Is DBNull.Value, "", row("NBI").ToString())
                xlWorkSheet.Cells(rIdx, 14) = If(row("SSS") Is DBNull.Value, "", row("SSS").ToString())
                xlWorkSheet.Cells(rIdx, 15) = If(row("PHILHEALTH") Is DBNull.Value, "", row("PHILHEALTH").ToString())
                xlWorkSheet.Cells(rIdx, 16) = If(row("PAGIBIG") Is DBNull.Value, "", row("PAGIBIG").ToString())
                xlWorkSheet.Cells(rIdx, 17) = If(row("TIN") Is DBNull.Value, "", row("TIN").ToString())
                xlWorkSheet.Cells(rIdx, 18) = If(row("MEDICAL") Is DBNull.Value, "", row("MEDICAL").ToString())
                xlWorkSheet.Cells(rIdx, 19) = If(row("DIPLOMA") Is DBNull.Value, "", row("DIPLOMA").ToString())
                xlWorkSheet.Cells(rIdx, 20) = If(row("TOR") Is DBNull.Value, "", row("TOR").ToString())
                xlWorkSheet.Cells(rIdx, 21) = pctString
                xlWorkSheet.Cells(rIdx, 22) = If(row("DATE_SCREENED") Is DBNull.Value, "", row("DATE_SCREENED").ToString())
                xlWorkSheet.Cells(rIdx, 23) = If(row("FINAL_INTERVIEW_DATE") Is DBNull.Value, "", row("FINAL_INTERVIEW_DATE").ToString())
                xlWorkSheet.Cells(rIdx, 24) = If(row("JOB_OFFER_DATE") Is DBNull.Value, "", row("JOB_OFFER_DATE").ToString())
                xlWorkSheet.Cells(rIdx, 25) = If(row("DATE_HIRED") Is DBNull.Value, "", row("DATE_HIRED").ToString())
                xlWorkSheet.Cells(rIdx, 26) = If(row("DATE_DEPLOYED") Is DBNull.Value, "", row("DATE_DEPLOYED").ToString())
                xlWorkSheet.Cells(rIdx, 27) = If(row("REJECTED_DATE") Is DBNull.Value, "", row("REJECTED_DATE").ToString())
                xlWorkSheet.Cells(rIdx, 28) = If(row("BACKOUT_DATE") Is DBNull.Value, "", row("BACKOUT_DATE").ToString())
                xlWorkSheet.Cells(rIdx, 29) = If(row("REMARKS") Is DBNull.Value, "", row("REMARKS").ToString())
                xlWorkSheet.Cells(rIdx, 30) = If(row("REQUIREMENTS_COMPLETION_DATE") Is DBNull.Value, "", row("REQUIREMENTS_COMPLETION_DATE").ToString())
                xlWorkSheet.Cells(rIdx, 31) = If(row("RESUME") Is DBNull.Value, "", row("RESUME").ToString())

                ' --- UPDATED COLOR CODING LOGIC ---
                Dim currentStatus As String = If(row("CURRENT_STATUS") Is DBNull.Value, "", row("CURRENT_STATUS").ToString().Trim())
                Dim targetColor As Integer = -1

                If currentStatus.Equals("Deployed", StringComparison.OrdinalIgnoreCase) Then
                    targetColor = ColorTranslator.ToOle(Color.FromArgb(198, 239, 206)) ' Soft Green
                ElseIf currentStatus.Equals("Hired", StringComparison.OrdinalIgnoreCase) Then
                    targetColor = ColorTranslator.ToOle(Color.FromArgb(221, 235, 247)) ' Soft Light Blue
                ElseIf currentStatus.Equals("Inactive", StringComparison.OrdinalIgnoreCase) Then
                    targetColor = ColorTranslator.ToOle(Color.FromArgb(255, 235, 156)) ' Soft Orange
                ElseIf currentStatus.Equals("Rejected", StringComparison.OrdinalIgnoreCase) OrElse currentStatus.Equals("Backout", StringComparison.OrdinalIgnoreCase) Then
                    targetColor = ColorTranslator.ToOle(Color.FromArgb(255, 199, 206)) ' Soft Red
                End If

                If targetColor <> -1 Then
                    Dim rowRange As Excel.Range = xlWorkSheet.Range(xlWorkSheet.Cells(rIdx, 1), xlWorkSheet.Cells(rIdx, excelColumns.Count))
                    rowRange.Interior.Color = targetColor
                End If

                rIdx += 1
                exportRowNumber += 1
            Next

            xlWorkSheet.Columns.AutoFit()

            Dim sfd As New SaveFileDialog()
            sfd.Filter = "Excel Workbook (*.xlsx)|*.xlsx"
            sfd.FileName = "Applicant_Masterlist_Complete_" & DateTime.Now.ToString("yyyyMMdd_HHmmss") & ".xlsx"

            If sfd.ShowDialog() = DialogResult.OK Then
                xlWorkBook.SaveAs(sfd.FileName)
                MsgBox("Complete Masterlist Excel report exported successfully!", MsgBoxStyle.Information, "Success")
            End If

        Catch ex As Exception
            MsgBox("Error exporting to Excel: " & ex.Message, MsgBoxStyle.Critical, "Export Error")
        Finally
            CloseConnection()
            If xlWorkBook IsNot Nothing Then xlWorkBook.Close(False)
            If xlApp IsNot Nothing Then xlApp.Quit()
            ReleaseObject(xlApp)
            ReleaseObject(xlWorkBook)
            ReleaseObject(xlWorkSheet)
        End Try
    End Sub

    Private Function GetStatusCountFromLabel(statusName As String) As Integer
        Dim statusLabels As Label() = {lblScreened, lblHRAvatar, lblFinalInterview, lblJobOffer, lblHired, lblOngoingRequirements, lblForOrientation, lblDeployed, lblPooling, lblBackout, lblRejected, lblInactive}
        For Each lbl As Label In statusLabels
            If lbl IsNot Nothing AndAlso lbl.Tag IsNot Nothing AndAlso lbl.Tag.ToString().Equals(statusName, StringComparison.OrdinalIgnoreCase) Then
                Dim text As String = lbl.Text
                If text.Contains("(") AndAlso text.Contains(")") Then
                    Dim startIdx As Integer = text.IndexOf("(") + 1
                    Dim length As Integer = text.IndexOf(")") - startIdx
                    Dim countStr As String = text.Substring(startIdx, length)
                    Dim cnt As Integer = 0
                    If Integer.TryParse(countStr, cnt) Then Return cnt
                End If
            End If
        Next
        Return 0
    End Function

    Private Sub ReleaseObject(ByVal obj As Object)
        Try
            If obj IsNot Nothing Then System.Runtime.InteropServices.Marshal.ReleaseComObject(obj)
        Catch ex As Exception
        Finally
            obj = Nothing
        End Try
    End Sub

    Private Sub dtpFrom_ValueChanged(sender As Object, e As EventArgs) Handles dtpFrom.ValueChanged
        RefreshData()
    End Sub

    Private Sub dtpTo_ValueChanged(sender As Object, e As EventArgs) Handles dtpTo.ValueChanged
        RefreshData()
    End Sub

    Private Sub dgvApplicants_CellPainting(sender As Object, e As DataGridViewCellPaintingEventArgs) Handles dgvApplicants.CellPainting
        If e.RowIndex >= 0 AndAlso (dgvApplicants.Columns(e.ColumnIndex).Name = "btnEditColumn" OrElse dgvApplicants.Columns(e.ColumnIndex).Name = "btnRejectColumn") Then
            e.Paint(e.CellBounds, DataGridViewPaintParts.Background Or DataGridViewPaintParts.SelectionBackground)

            Dim isEdit As Boolean = (dgvApplicants.Columns(e.ColumnIndex).Name = "btnEditColumn")
            Dim buttonText As String = If(isEdit, "EDIT", "REJECT")
            Dim buttonColor As Color = If(isEdit, Color.FromArgb(16, 37, 66), Color.FromArgb(176, 42, 42))

            Dim rect As Rectangle = e.CellBounds
            rect.Inflate(-6, -6)

            Using path As GraphicsPath = GetRoundedRect(rect, 6)
                Using brush As New SolidBrush(buttonColor)
                    e.Graphics.SmoothingMode = SmoothingMode.AntiAlias
                    e.Graphics.FillPath(brush, path)
                End Using
            End Using

            Using sf As New StringFormat()
                sf.Alignment = StringAlignment.Center
                sf.LineAlignment = StringAlignment.Center
                Using brush As New SolidBrush(Color.White)
                    e.Graphics.DrawString(buttonText, New Font(dgvApplicants.Font.FontFamily, 9, FontStyle.Bold), brush, rect, sf)
                End Using
            End Using

            e.Handled = True
        End If
    End Sub

    Private Function GetRoundedRect(rect As Rectangle, radius As Integer) As GraphicsPath
        Dim path As New GraphicsPath()
        Dim diameter As Integer = radius * 2
        path.AddArc(rect.X, rect.Y, diameter, diameter, 180, 90)
        path.AddArc(rect.Right - diameter, rect.Y, diameter, diameter, 270, 90)
        path.AddArc(rect.Right - diameter, rect.Bottom - diameter, diameter, diameter, 0, 90)
        path.AddArc(rect.X, rect.Bottom - diameter, diameter, diameter, 90, 90)
        path.CloseFigure()
        Return path
    End Function

    Private Sub dgvApplicants_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvApplicants.CellContentClick
        If e.RowIndex >= 0 Then
            Dim applicantID As Integer = Convert.ToInt32(dgvApplicants.Rows(e.RowIndex).Cells("ApplicantID").Value)

            If dgvApplicants.Columns(e.ColumnIndex).Name = "btnEditColumn" Then
                Dim editForm As New frmAddApplicant()
                editForm.IsEditMode = True
                editForm.ApplicantIDToEdit = applicantID
                editForm.ShowDialog()
                RefreshData()
            ElseIf dgvApplicants.Columns(e.ColumnIndex).Name = "btnRejectColumn" Then
                Dim result As DialogResult = MessageBox.Show("Are you sure you want to reject this applicant?", "Confirm Rejection", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                If result = DialogResult.Yes Then
                    connection()
                    If cn.State <> ConnectionState.Open Then Exit Sub
                    Try
                        sql = "UPDATE applicant_masterlist SET CURRENT_STATUS = 'Rejected' WHERE ApplicantID = @id"
                        cmd = New MySqlCommand(sql, cn)
                        cmd.Parameters.AddWithValue("@id", applicantID)
                        cmd.ExecuteNonQuery()
                        MsgBox("Applicant has been rejected.", MsgBoxStyle.Information, "Success")
                        RefreshData()
                    Catch ex As Exception
                        MsgBox("Error updating status: " & ex.Message, MsgBoxStyle.Critical)
                    Finally
                        CloseConnection()
                    End Try
                End If
            End If
        End If
    End Sub

    Private Sub txtSearch_TextChanged(sender As Object, e As EventArgs) Handles txtSearch.TextChanged
        RefreshData()
    End Sub

    Private Sub btnRefresh_Click(sender As Object, e As EventArgs) Handles btnRefresh.Click
        txtSearch.Clear()
        ResetLabelStyles()
        RefreshData()
    End Sub

    Private Sub StatusLabel_Click(sender As Object, e As EventArgs) Handles _
        lblScreened.Click, lblHRAvatar.Click, lblFinalInterview.Click,
        lblJobOffer.Click, lblHired.Click, lblOngoingRequirements.Click,
        lblForOrientation.Click, lblDeployed.Click, lblPooling.Click,
        lblBackout.Click, lblRejected.Click, lblInactive.Click

        Dim selectedLabel As Label = CType(sender, Label)
        If selectedLabel.Tag Is Nothing Then Exit Sub

        ResetLabelStyles()
        selectedLabel.ForeColor = Color.FromArgb(0, 103, 184)
        selectedLabel.Font = New Font(selectedLabel.Font, FontStyle.Bold)

        LoadApplicants(selectedLabel.Tag.ToString(), txtSearch.Text.Trim(), dtpFrom.Value, dtpTo.Value)
    End Sub

    Private Sub ResetLabelStyles()
        Dim statusLabels As Label() = {lblScreened, lblHRAvatar, lblFinalInterview, lblJobOffer, lblHired, lblOngoingRequirements, lblForOrientation, lblDeployed, lblPooling, lblBackout, lblRejected, lblInactive}

        For Each lbl As Label In statusLabels
            If lbl IsNot Nothing AndAlso lbl.Tag IsNot Nothing Then
                Dim countText = lbl.Text.Substring(lbl.Text.LastIndexOf("("))
                lbl.Text = lbl.Tag.ToString() & " " & countText
                lbl.ForeColor = Color.Black
                lbl.Font = New Font(lbl.Font, FontStyle.Regular)
            End If
        Next
    End Sub

    Private Sub StatusLabel_MouseEnter(sender As Object, e As EventArgs) Handles _
        lblScreened.MouseEnter, lblHRAvatar.MouseEnter, lblFinalInterview.MouseEnter,
        lblJobOffer.MouseEnter, lblHired.MouseEnter, lblOngoingRequirements.MouseEnter,
        lblForOrientation.MouseEnter, lblDeployed.MouseEnter, lblPooling.MouseEnter,
        lblBackout.MouseEnter, lblRejected.MouseEnter, lblInactive.MouseEnter

        Dim lbl As Label = CType(sender, Label)
        If lbl.Font.Style <> FontStyle.Bold Then
            lbl.ForeColor = Color.FromArgb(0, 103, 184)
        End If
    End Sub

    Private Sub StatusLabel_MouseLeave(sender As Object, e As EventArgs) Handles _
        lblScreened.MouseLeave, lblHRAvatar.MouseLeave, lblFinalInterview.MouseLeave,
        lblJobOffer.MouseLeave, lblHired.MouseLeave, lblOngoingRequirements.MouseLeave,
        lblForOrientation.MouseLeave, lblDeployed.MouseLeave, lblPooling.MouseLeave,
        lblBackout.MouseLeave, lblRejected.MouseLeave, lblInactive.MouseLeave

        Dim lbl As Label = CType(sender, Label)
        If lbl.Font.Style <> FontStyle.Bold Then
            lbl.ForeColor = Color.Black
        End If
    End Sub

    Private Sub btnReset_Click(sender As Object, e As EventArgs) Handles btnReset.Click
        frmAddApplicant.Show()
    End Sub

End Class