Imports MySql.Data.MySqlClient
Imports System.Windows.Forms.DataVisualization.Charting
Imports LiveCharts
Imports LiveCharts.Wpf
Imports System.Drawing

Public Class frmHome

    Private Sub frmHome_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        dtpMonthFilter.Value = DateTime.Now
        RefreshDashboardCharts()
    End Sub

    ' Refresh counts automatically whenever switching tabs or activating the dashboard
    Private Sub frmHome_Activated(sender As Object, e As EventArgs) Handles MyBase.Activated
        RefreshDashboardCharts()
    End Sub

    Private Sub dtpMonthFilter_ValueChanged(sender As Object, e As EventArgs) Handles dtpMonthFilter.ValueChanged
        RefreshDashboardCharts()
    End Sub

    Public Sub RefreshDashboardCharts()
        Dim selectedDate As DateTime = dtpMonthFilter.Value
        LoadDashboardCounts(selectedDate)
        LoadMonthlyApplicantsChart(selectedDate)
        LoadRecentMonthStatusPieChart(selectedDate)
    End Sub

    ' ====================================================================
    ' DYNAMIC DASHBOARD STAT CARDS (EXACT 1-TO-1 STATUS MATCHING)
    ' ====================================================================
    Private Sub LoadDashboardCounts(filterDate As DateTime)
        Try
            connection()

            ResetCountLabels()

            ' 1. Total Applicants, Walk-in, and Online counts
            Dim sqlSummary As String = "SELECT " &
                "COUNT(*) AS TotalCount, " &
                "SUM(CASE WHEN LOWER(IFNULL(SOURCE, '')) LIKE '%walk%' THEN 1 ELSE 0 END) AS WalkInCount, " &
                "SUM(CASE WHEN LOWER(IFNULL(SOURCE, '')) LIKE '%walk%' THEN 0 ELSE 1 END) AS OnlineCount " &
                "FROM applicant_masterlist " &
                "WHERE MONTH(`DATE`) = @selectedMonth AND YEAR(`DATE`) = @selectedYear"

            cmd = New MySqlCommand(sqlSummary, cn)
            cmd.Parameters.AddWithValue("@selectedMonth", filterDate.Month)
            cmd.Parameters.AddWithValue("@selectedYear", filterDate.Year)
            dr = cmd.ExecuteReader()

            If dr.Read() Then
                SetLabelText(lblTotalApplicants, dr("TotalCount"))
                SetLabelText(lblOnline, dr("OnlineCount"))
                SetLabelText(lblWalkIn, dr("WalkInCount"))
            End If
            dr.Close()

            ' 2. Fetch status counts grouped by CURRENT_STATUS
            Dim sqlStatus As String = "SELECT CURRENT_STATUS, COUNT(*) AS StatusCount " &
                "FROM applicant_masterlist " &
                "WHERE MONTH(`DATE`) = @selectedMonth AND YEAR(`DATE`) = @selectedYear " &
                "GROUP BY CURRENT_STATUS"

            cmd = New MySqlCommand(sqlStatus, cn)
            cmd.Parameters.AddWithValue("@selectedMonth", filterDate.Month)
            cmd.Parameters.AddWithValue("@selectedYear", filterDate.Year)
            dr = cmd.ExecuteReader()

            Dim statusDict As New Dictionary(Of String, Integer)(StringComparer.OrdinalIgnoreCase)
            While dr.Read()
                Dim statusName As String = dr("CURRENT_STATUS").ToString().Trim()
                Dim count As Integer = Convert.ToInt32(dr("StatusCount"))
                statusDict(statusName) = count
            End While
            dr.Close()

            ' 3. Exact Status Mappings aligned with Applicant Masterlist
            SetLabelText(lblScreened, GetCount(statusDict, "Screened"))
            SetLabelText(lblHRAvatar, GetCount(statusDict, "HR Avatar"))
            SetLabelText(lblFinalInterview, GetCount(statusDict, "Final Interview"))
            SetLabelText(lblOngoingRequirements, GetCount(statusDict, "Ongoing Requirements"))
            SetLabelText(lblHired, GetCount(statusDict, "Hired"))
            SetLabelText(lblDeployed, GetCount(statusDict, "Deployed"))
            SetLabelText(lblJobOffer, GetCount(statusDict, "Job Offer", "For Job Offer"))
            SetLabelText(lblOrientation, GetCount(statusDict, "For Orientation", "Orientation"))
            SetLabelText(lblRejected, GetCount(statusDict, "Rejected"))
            SetLabelText(lblPooling, GetCount(statusDict, "Pooling", "For Pooling"))
            SetLabelText(lblBackout, GetCount(statusDict, "Backout"))
            SetLabelText(lblInactive, GetCount(statusDict, "Inactive"))

            ' Secondary/Optional Card Mappings
            SetLabelText(lblPhoneInterview, GetCount(statusDict, "Phone Interview"))
            SetLabelText(lblNoShow, GetCount(statusDict, "No Show"))
            SetLabelText(lblForExam, GetCount(statusDict, "For Exam", "Exam"))
            SetLabelText(lblNoAnswer, GetCount(statusDict, "No Answer"))

        Catch ex As Exception
            MsgBox("Error loading dashboard counts: " & ex.Message, MsgBoxStyle.Critical)
        Finally
            CloseConnection()
        End Try
    End Sub

    Private Function GetCount(dict As Dictionary(Of String, Integer), ParamArray statusKeys() As String) As Integer
        For Each key In statusKeys
            If dict.ContainsKey(key) Then Return dict(key)
        Next
        Return 0
    End Function

    Private Sub SetLabelText(lbl As System.Windows.Forms.Label, value As Object)
        If lbl IsNot Nothing Then
            lbl.Text = If(value Is DBNull.Value OrElse value Is Nothing, "0", value.ToString())
        End If
    End Sub

    Private Sub ResetCountLabels()
        Dim countLabels As System.Windows.Forms.Label() = {
            lblOnline, lblWalkIn, lblTotalApplicants, lblScreened, lblHRAvatar,
            lblFinalInterview, lblOngoingRequirements, lblHired, lblDeployed,
            lblJobOffer, lblOrientation, lblRejected, lblPooling, lblBackout,
            lblInactive, lblPhoneInterview, lblNoShow, lblForExam, lblNoAnswer
        }
        For Each lbl In countLabels
            If lbl IsNot Nothing Then lbl.Text = "0"
        Next
    End Sub

    ' ====================================================================
    ' CHART 1: Standard MS Bar Chart - Number of Applicants Every Month
    ' ====================================================================
    Private Sub LoadMonthlyApplicantsChart(filterDate As DateTime)
        Try
            connection()

            sql = "SELECT DATE_FORMAT(`DATE`, '%M') AS MonthName, COUNT(*) AS TotalApplicants " &
                  "FROM applicant_masterlist " &
                  "WHERE YEAR(`DATE`) = @selectedYear " &
                  "GROUP BY MONTH(`DATE`), DATE_FORMAT(`DATE`, '%M') " &
                  "ORDER BY MONTH(`DATE`)"

            cmd = New MySqlCommand(sql, cn)
            cmd.Parameters.AddWithValue("@selectedYear", filterDate.Year)
            dr = cmd.ExecuteReader()

            Chart1.Series.Clear()
            Chart1.Titles.Clear()

            Chart1.Titles.Add($"Applicants Per Month ({filterDate.Year})")
            Chart1.Titles(0).Font = New System.Drawing.Font("Arial", 12, System.Drawing.FontStyle.Bold)

            Dim seriesName As String = "Applicants per Month"
            Chart1.Series.Add(seriesName)
            Chart1.Series(seriesName).ChartType = SeriesChartType.Column

            Chart1.Series(seriesName).IsValueShownAsLabel = True
            Chart1.Series(seriesName).Font = New System.Drawing.Font("Arial", 10, System.Drawing.FontStyle.Bold)

            If Chart1.ChartAreas.Count > 0 Then
                Chart1.ChartAreas(0).AxisX.Title = "Month"
                Chart1.ChartAreas(0).AxisX.TitleFont = New System.Drawing.Font("Arial", 10, System.Drawing.FontStyle.Bold)
                Chart1.ChartAreas(0).AxisY.Title = "Number of Applicants"
                Chart1.ChartAreas(0).AxisY.TitleFont = New System.Drawing.Font("Arial", 10, System.Drawing.FontStyle.Bold)
            End If

            While dr.Read()
                Dim month As String = dr("MonthName").ToString()
                Dim total As Integer = Convert.ToInt32(dr("TotalApplicants"))
                Chart1.Series(seriesName).Points.AddXY(month, total)
            End While

            dr.Close()
        Catch ex As Exception
            MsgBox("Error loading Monthly Chart: " & ex.Message, MsgBoxStyle.Critical)
        Finally
            CloseConnection()
        End Try
    End Sub

    ' ====================================================================
    ' CHART 2: LiveCharts Pie Chart - Status Breakdown
    ' ====================================================================
    Private Sub LoadRecentMonthStatusPieChart(filterDate As DateTime)
        Try
            connection()

            sql = "SELECT CURRENT_STATUS, COUNT(*) AS StatusCount " &
                  "FROM applicant_masterlist " &
                  "WHERE MONTH(`DATE`) = @selectedMonth AND YEAR(`DATE`) = @selectedYear " &
                  "GROUP BY CURRENT_STATUS"

            cmd = New MySqlCommand(sql, cn)
            cmd.Parameters.AddWithValue("@selectedMonth", filterDate.Month)
            cmd.Parameters.AddWithValue("@selectedYear", filterDate.Year)
            dr = cmd.ExecuteReader()

            Dim pieSeriesCollection As New LiveCharts.SeriesCollection()

            While dr.Read()
                Dim status As String = dr("CURRENT_STATUS").ToString()
                Dim total As Integer = Convert.ToInt32(dr("StatusCount"))

                If String.IsNullOrWhiteSpace(status) Then status = "Pending"

                Dim currentStatusLabel As String = status

                pieSeriesCollection.Add(New PieSeries With {
                    .Title = currentStatusLabel,
                    .Values = New ChartValues(Of Integer)({total}),
                    .DataLabels = True,
                    .LabelPoint = Function(chartPoint) $"{currentStatusLabel}: {chartPoint.Y}"
                })
            End While

            Chart2.Series = pieSeriesCollection

            dr.Close()
        Catch ex As Exception
            MsgBox("Error loading Status Pie Chart: " & ex.Message, MsgBoxStyle.Critical)
        Finally
            CloseConnection()
        End Try
    End Sub

End Class