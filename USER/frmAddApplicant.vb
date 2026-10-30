Imports System.Drawing
Imports System.Text.RegularExpressions
Imports MySql.Data.MySqlClient

Public Class frmAddApplicant

    ' Properties to determine if the form is in Add or Edit mode
    Public Property IsEditMode As Boolean = False
    Public Property ApplicantIDToEdit As Integer = 0

    Private isUpdatingCheckboxes As Boolean = False

    Private Sub frmAddApplicant_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cboCurrentStatus.Items.Clear()
        cboCurrentStatus.Items.Add("-- Select Status --")
        cboCurrentStatus.Items.AddRange(New String() {
            "Screened", "HR Avatar", "Final Interview", "Job Offer",
            "Hired", "Ongoing Requirements", "For Orientation", "Deployed",
            "Pooling", "Backout", "Rejected", "Inactive"
        })
        cboCurrentStatus.SelectedIndex = 0

        InitializeRequirementsCheckedListBox()
        InitializeStatusHistoryListView()

        LoadPositions()
        LoadSites()
        LoadSources()

        ' Adjust UI labels based on whether we are adding or updating
        If IsEditMode Then
            If Me.Controls.ContainsKey("lblTitle") Then
                DirectCast(Me.Controls("lblTitle"), Label).Text = "Update Applicant Information"
            End If
            Me.Text = "Update Applicant"
            btnSave.Text = "Update"
            LoadApplicantDataForEditing()
        Else
            If Me.Controls.ContainsKey("lblTitle") Then
                DirectCast(Me.Controls("lblTitle"), Label).Text = "Add New Applicant"
            End If
            Me.Text = "Add Applicant"
            btnSave.Text = "Save"
            If lvStatusHistory IsNot Nothing Then lvStatusHistory.Visible = False ' Hide history for new entries
        End If
    End Sub

    Private Sub InitializeRequirementsCheckedListBox()
        If clbRequirements IsNot Nothing Then
            clbRequirements.Items.Clear()
            clbRequirements.Items.Add("Barangay Clearance")
            clbRequirements.Items.Add("Police Clearance")
            clbRequirements.Items.Add("NBI Clearance")
            clbRequirements.Items.Add("SSS")
            clbRequirements.Items.Add("PhilHealth")
            clbRequirements.Items.Add("Pag-IBIG")
            clbRequirements.Items.Add("TIN")
            clbRequirements.Items.Add("Medical")
            clbRequirements.Items.Add("Diploma")
            clbRequirements.Items.Add("TOR")
        End If
    End Sub

    Private Sub InitializeStatusHistoryListView()
        If lvStatusHistory IsNot Nothing Then
            lvStatusHistory.View = View.Details
            lvStatusHistory.FullRowSelect = True
            lvStatusHistory.GridLines = True
            lvStatusHistory.Columns.Clear()
            lvStatusHistory.Columns.Add("Process / Milestone", 180, HorizontalAlignment.Left)
            lvStatusHistory.Columns.Add("Date Updated", 140, HorizontalAlignment.Left)
        End If
    End Sub

    Private Sub LoadApplicantDataForEditing()
        Call connection()
        If cn.State <> ConnectionState.Open Then Exit Sub

        Try
            sql = "SELECT * FROM applicant_masterlist WHERE ApplicantID = @id"
            cmd = New MySqlCommand(sql, cn)
            cmd.Parameters.AddWithValue("@id", ApplicantIDToEdit)
            Dim adapter As New MySqlDataAdapter(cmd)
            Dim dt As New DataTable()
            adapter.Fill(dt)

            If dt.Rows.Count > 0 Then
                Dim row As DataRow = dt.Rows(0)

                txtname.Text = If(row("NAME") Is DBNull.Value, "", row("NAME").ToString())
                cboPosition.Text = If(row("POSITION") Is DBNull.Value, "", row("POSITION").ToString())
                txtContactNo.Text = If(row("CONTACT_NO") Is DBNull.Value, "", row("CONTACT_NO").ToString())
                txtEmail.Text = If(row("EMAIL_ADDRESS") Is DBNull.Value, "", row("EMAIL_ADDRESS").ToString())
                rchAddress.Text = If(row("ADDRESS") Is DBNull.Value, "", row("ADDRESS").ToString())
                cboSite.Text = If(row("SITE") Is DBNull.Value, "", row("SITE").ToString())
                cboSource.Text = If(row("SOURCE") Is DBNull.Value, "", row("SOURCE").ToString())
                cboCurrentStatus.Text = If(row("CURRENT_STATUS") Is DBNull.Value, "-- Select Status --", row("CURRENT_STATUS").ToString())
                txtRemarks.Text = If(row("REMARKS") Is DBNull.Value, "", row("REMARKS").ToString())

                ' CheckedListBox state mapping
                SetItemCheckedStatus("Barangay Clearance", row("BARANGAY_CLEARANCE").ToString() = "Submitted")
                SetItemCheckedStatus("Police Clearance", row("POLICE_CLEARANCE").ToString() = "Submitted")
                SetItemCheckedStatus("NBI Clearance", row("NBI").ToString() = "Submitted")
                SetItemCheckedStatus("SSS", row("SSS").ToString() = "Submitted")
                SetItemCheckedStatus("PhilHealth", row("PHILHEALTH").ToString() = "Submitted")
                SetItemCheckedStatus("Pag-IBIG", row("PAGIBIG").ToString() = "Submitted")
                SetItemCheckedStatus("TIN", row("TIN").ToString() = "Submitted")
                SetItemCheckedStatus("Medical", row("MEDICAL").ToString() = "Submitted")
                SetItemCheckedStatus("Diploma", row("DIPLOMA").ToString() = "Submitted")
                SetItemCheckedStatus("TOR", row("TOR").ToString() = "Submitted")

                CheckMasterRequirementsState()

                ' Populate Status History ListView showing both filled dates and Pending steps
                If lvStatusHistory IsNot Nothing Then
                    lvStatusHistory.Items.Clear()
                    lvStatusHistory.Visible = True

                    AddDateToHistory("Date Applied", row("DATE"))
                    AddDateToHistory("Screened", row("DATE_SCREENED"))
                    AddDateToHistory("Final Interview", row("FINAL_INTERVIEW_DATE"))
                    AddDateToHistory("Job Offer", row("JOB_OFFER_DATE"))
                    AddDateToHistory("Hired", row("DATE_HIRED"))
                    AddDateToHistory("Deployed", row("DATE_DEPLOYED"))
                    AddDateToHistory("Rejected", row("REJECTED_DATE"))
                    AddDateToHistory("Backout", row("BACKOUT_DATE"))
                    AddDateToHistory("Requirements Complete", row("REQUIREMENTS_COMPLETION_DATE"))
                End If
            End If
        Catch ex As Exception
            MsgBox("Error loading applicant details: " & ex.Message, MsgBoxStyle.Critical)
        Finally
            Call DBconnection.CloseConnection()
        End Try
    End Sub

    Private Sub SetItemCheckedStatus(itemName As String, isChecked As Boolean)
        If clbRequirements IsNot Nothing Then
            Dim index As Integer = clbRequirements.Items.IndexOf(itemName)
            If index <> -1 Then
                clbRequirements.SetItemChecked(index, isChecked)
            End If
        End If
    End Sub

    Private Function IsRequirementChecked(itemName As String) As Boolean
        If clbRequirements IsNot Nothing Then
            Dim index As Integer = clbRequirements.Items.IndexOf(itemName)
            If index <> -1 Then
                Return clbRequirements.GetItemChecked(index)
            End If
        End If
        Return False
    End Function

    Private Sub AddDateToHistory(statusName As String, dbValue As Object)
        Dim dateDisplay As String = "Pending"

        If dbValue IsNot Nothing AndAlso dbValue IsNot DBNull.Value AndAlso Not String.IsNullOrWhiteSpace(dbValue.ToString()) Then
            Dim parsedDate As DateTime
            If DateTime.TryParse(dbValue.ToString(), parsedDate) Then
                dateDisplay = parsedDate.ToString("yyyy-MM-dd")
            End If
        End If

        Dim lvi As New ListViewItem(statusName)
        lvi.SubItems.Add(dateDisplay)
        lvStatusHistory.Items.Add(lvi)
    End Sub

    Private Sub LoadPositions()
        Call connection()
        If cn.State <> ConnectionState.Open Then Exit Sub

        Try
            sql = "SELECT position_id, position_title FROM positions ORDER BY position_title ASC"
            Dim adapter As New MySqlDataAdapter(sql, cn)
            Dim dt As New DataTable()
            adapter.Fill(dt)

            Dim dr As DataRow = dt.NewRow()
            dr("position_id") = 0
            dr("position_title") = "-- Select Position --"
            dt.Rows.InsertAt(dr, 0)

            cboPosition.DataSource = dt
            cboPosition.DisplayMember = "position_title"
            cboPosition.ValueMember = "position_id"
            cboPosition.SelectedIndex = 0
        Catch ex As Exception
        Finally
            Call DBconnection.CloseConnection()
        End Try
    End Sub

    Private Sub LoadSites()
        Call connection()
        If cn.State <> ConnectionState.Open Then Exit Sub

        Try
            sql = "SELECT LocationID, Site FROM Location ORDER BY Site ASC"
            Dim adapter As New MySqlDataAdapter(sql, cn)
            Dim dt As New DataTable()
            adapter.Fill(dt)

            Dim dr As DataRow = dt.NewRow()
            dr("LocationID") = 0
            dr("Site") = "-- Select Site --"
            dt.Rows.InsertAt(dr, 0)

            cboSite.DataSource = dt
            cboSite.DisplayMember = "Site"
            cboSite.ValueMember = "LocationID"
            cboSite.SelectedIndex = 0
        Catch ex As Exception
        Finally
            Call DBconnection.CloseConnection()
        End Try
    End Sub

    Private Sub LoadSources()
        Call connection()
        If cn.State <> ConnectionState.Open Then Exit Sub

        Try
            sql = "SELECT SourceID, SourceName FROM Sources ORDER BY SourceName ASC"
            Dim adapter As New MySqlDataAdapter(sql, cn)
            Dim dt As New DataTable()
            adapter.Fill(dt)

            Dim dr As DataRow = dt.NewRow()
            dr("SourceID") = 0
            dr("SourceName") = "-- Select Source --"
            dt.Rows.InsertAt(dr, 0)

            cboSource.DataSource = dt
            cboSource.DisplayMember = "SourceName"
            cboSource.ValueMember = "SourceID"
            cboSource.SelectedIndex = 0
        Catch ex As Exception
        Finally
            Call DBconnection.CloseConnection()
        End Try
    End Sub

    Private Sub chkCompleteRequirements_CheckedChanged(sender As Object, e As EventArgs) Handles chkCompleteRequirements.CheckedChanged
        If isUpdatingCheckboxes Then Exit Sub

        isUpdatingCheckboxes = True
        Dim state As Boolean = chkCompleteRequirements.Checked

        If clbRequirements IsNot Nothing Then
            For i As Integer = 0 To clbRequirements.Items.Count - 1
                clbRequirements.SetItemChecked(i, state)
            Next
        End If

        isUpdatingCheckboxes = False
    End Sub

    Private Sub clbRequirements_ItemCheck(sender As Object, e As ItemCheckEventArgs) Handles clbRequirements.ItemCheck
        If isUpdatingCheckboxes Then Exit Sub

        Me.BeginInvoke(New Action(AddressOf CheckMasterRequirementsState))
    End Sub

    Private Sub CheckMasterRequirementsState()
        If clbRequirements Is Nothing OrElse chkCompleteRequirements Is Nothing Then Exit Sub

        isUpdatingCheckboxes = True
        Dim allChecked As Boolean = True

        For i As Integer = 0 To clbRequirements.Items.Count - 1
            If Not clbRequirements.GetItemChecked(i) Then
                allChecked = False
                Exit For
            End If
        Next

        chkCompleteRequirements.Checked = allChecked
        isUpdatingCheckboxes = False
    End Sub

    Private Function GetReqStatus(itemName As String) As String
        Return If(IsRequirementChecked(itemName), "Submitted", "Pending")
    End Function

    Private Function FormatInput(value As String) As String
        If String.IsNullOrWhiteSpace(value) Then
            Return "N/A"
        End If
        Return value.Trim()
    End Function

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        ' --- VALIDATIONS ---
        If cboPosition.SelectedIndex <= 0 Then
            MsgBox("Please select a valid position.", MsgBoxStyle.Exclamation, "Validation Error")
            cboPosition.Focus()
            Exit Sub
        End If

        If cboSource.SelectedIndex <= 0 Then
            MsgBox("Please select a valid source.", MsgBoxStyle.Exclamation, "Validation Error")
            cboSource.Focus()
            Exit Sub
        End If

        ' Calculate requirements submitted count from CheckedListBox
        Dim submittedCount As Integer = 0
        Dim missingRequirements As New List(Of String)()

        For i As Integer = 0 To clbRequirements.Items.Count - 1
            Dim reqName As String = clbRequirements.Items(i).ToString()
            If clbRequirements.GetItemChecked(i) Then
                submittedCount += 1
            Else
                missingRequirements.Add(reqName)
            End If
        Next
        Dim isAllRequirementsChecked As Boolean = (submittedCount = clbRequirements.Items.Count)

        ' Check if requirements are complete when status is Hired or Deployed
        Dim selectedStatus As String = cboCurrentStatus.Text.Trim()
        If selectedStatus.Equals("Hired", StringComparison.OrdinalIgnoreCase) OrElse selectedStatus.Equals("Deployed", StringComparison.OrdinalIgnoreCase) Then
            If Not isAllRequirementsChecked Then
                MsgBox("Cannot set status to '" & selectedStatus & "' because applicant requirements are not complete (100%).", MsgBoxStyle.Critical, "Requirements Incomplete")
                Exit Sub
            End If
        End If

        ' --- AUTOMATED REMARKS GENERATION ---
        Dim currentRemarksUserTyped As String = txtRemarks.Text.Trim()
        Dim autoRemarkTag As String = ""

        ' 1. Check for Missing Requirements
        If Not isAllRequirementsChecked Then
            autoRemarkTag &= "[Pending Requirements: " & String.Join(", ", missingRequirements) & "]"
        Else
            autoRemarkTag &= "[Requirements Complete: 100%]"
        End If

        ' 2. Check for Backout or Rejected Status Notes
        If selectedStatus.Equals("Rejected", StringComparison.OrdinalIgnoreCase) Then
            autoRemarkTag &= " [Applicant Rejected on " & DateTime.Now.ToString("yyyy-MM-dd") & "]"
        ElseIf selectedStatus.Equals("Backout", StringComparison.OrdinalIgnoreCase) Then
            autoRemarkTag &= " [Applicant Backed Out on " & DateTime.Now.ToString("yyyy-MM-dd") & "]"
        End If

        ' Combine user remarks responsively without duplicates
        Dim finalRemarksToSave As String = currentRemarksUserTyped
        If Not finalRemarksToSave.Contains(autoRemarkTag) Then
            If String.IsNullOrEmpty(finalRemarksToSave) OrElse finalRemarksToSave = "N/A" Then
                finalRemarksToSave = autoRemarkTag
            Else
                finalRemarksToSave &= " | " & autoRemarkTag
            End If
        End If

        Call connection()
        If cn.State <> ConnectionState.Open Then
            MsgBox("Database Connection Error", MsgBoxStyle.Critical)
            Exit Sub
        End If

        Try
            Dim reqPercentage As String = (submittedCount * 10).ToString() & "%"

            If IsEditMode Then
                ' Execute UPDATE if editing an existing applicant
                sql = "UPDATE applicant_masterlist SET " &
                      "NAME = @name, POSITION = @position, CONTACT_NO = @contact, EMAIL_ADDRESS = @email, " &
                      "ADDRESS = @address, SITE = @site, SOURCE = @source, CURRENT_STATUS = @status, " &
                      "BARANGAY_CLEARANCE = @brgy, POLICE_CLEARANCE = @police, NBI = @nbi, SSS = @sss, " &
                      "PHILHEALTH = @philhealth, PAGIBIG = @pagibig, TIN = @tin, MEDICAL = @medical, " &
                      "DIPLOMA = @diploma, TOR = @tor, REQUIREMENTS_PERCENTAGE = @reqPct, REMARKS = @remarks"

                If selectedStatus.Equals("Screened", StringComparison.OrdinalIgnoreCase) Then sql &= ", DATE_SCREENED = IF(DATE_SCREENED IS NULL, CURDATE(), DATE_SCREENED)"
                If selectedStatus.Equals("Final Interview", StringComparison.OrdinalIgnoreCase) Then sql &= ", FINAL_INTERVIEW_DATE = IF(FINAL_INTERVIEW_DATE IS NULL, CURDATE(), FINAL_INTERVIEW_DATE)"
                If selectedStatus.Equals("Job Offer", StringComparison.OrdinalIgnoreCase) Then sql &= ", JOB_OFFER_DATE = IF(JOB_OFFER_DATE IS NULL, CURDATE(), JOB_OFFER_DATE)"
                If selectedStatus.Equals("Hired", StringComparison.OrdinalIgnoreCase) Then sql &= ", DATE_HIRED = IF(DATE_HIRED IS NULL, CURDATE(), DATE_HIRED)"
                If selectedStatus.Equals("Deployed", StringComparison.OrdinalIgnoreCase) Then sql &= ", DATE_DEPLOYED = IF(DATE_DEPLOYED IS NULL, CURDATE(), DATE_DEPLOYED)"
                If selectedStatus.Equals("Rejected", StringComparison.OrdinalIgnoreCase) Then sql &= ", REJECTED_DATE = IF(REJECTED_DATE IS NULL, CURDATE(), REJECTED_DATE)"
                If selectedStatus.Equals("Backout", StringComparison.OrdinalIgnoreCase) Then sql &= ", BACKOUT_DATE = IF(BACKOUT_DATE IS NULL, CURDATE(), BACKOUT_DATE)"
                If submittedCount = clbRequirements.Items.Count Then sql &= ", REQUIREMENTS_COMPLETION_DATE = IF(REQUIREMENTS_COMPLETION_DATE IS NULL, CURDATE(), REQUIREMENTS_COMPLETION_DATE)"

                sql &= " WHERE ApplicantID = @id"
            Else
                ' Execute INSERT if adding a new applicant
                sql = "INSERT INTO applicant_masterlist (" &
                      "NAME, POSITION, CONTACT_NO, EMAIL_ADDRESS, ADDRESS, SITE, SOURCE, CURRENT_STATUS, " &
                      "BARANGAY_CLEARANCE, POLICE_CLEARANCE, NBI, SSS, PHILHEALTH, PAGIBIG, TIN, MEDICAL, DIPLOMA, TOR, REQUIREMENTS_PERCENTAGE, REMARKS, " &
                      "DATE_SCREENED, FINAL_INTERVIEW_DATE, JOB_OFFER_DATE, DATE_HIRED, DATE_DEPLOYED, REJECTED_DATE, BACKOUT_DATE, REQUIREMENTS_COMPLETION_DATE) " &
                      "VALUES (" &
                      "@name, @position, @contact, @email, @address, @site, @source, @status, " &
                      "@brgy, @police, @nbi, @sss, @philhealth, @pagibig, @tin, @medical, @diploma, @tor, @reqPct, @remarks, " &
                      "IF(@status = 'Screened', CURDATE(), NULL), " &
                      "IF(@status = 'Final Interview', CURDATE(), NULL), " &
                      "IF(@status = 'Job Offer', CURDATE(), NULL), " &
                      "IF(@status = 'Hired', CURDATE(), NULL), " &
                      "IF(@status = 'Deployed', CURDATE(), NULL), " &
                      "IF(@status = 'Rejected', CURDATE(), NULL), " &
                      "IF(@status = 'Backout', CURDATE(), NULL), " &
                      "IF(@reqPct = '100%', CURDATE(), NULL))"
            End If

            cmd = New MySqlCommand(sql, cn)

            With cmd.Parameters
                If IsEditMode Then
                    .AddWithValue("@id", ApplicantIDToEdit)
                End If
                .AddWithValue("@name", FormatInput(txtname.Text))
                .AddWithValue("@position", cboPosition.Text.Trim())
                .AddWithValue("@contact", FormatInput(txtContactNo.Text))
                .AddWithValue("@email", FormatInput(txtEmail.Text).ToLower())
                .AddWithValue("@address", FormatInput(rchAddress.Text))
                .AddWithValue("@site", cboSite.Text.Trim())
                .AddWithValue("@source", cboSource.Text.Trim())
                .AddWithValue("@status", selectedStatus)

                .AddWithValue("@brgy", GetReqStatus("Barangay Clearance"))
                .AddWithValue("@police", GetReqStatus("Police Clearance"))
                .AddWithValue("@nbi", GetReqStatus("NBI Clearance"))
                .AddWithValue("@sss", GetReqStatus("SSS"))
                .AddWithValue("@philhealth", GetReqStatus("PhilHealth"))
                .AddWithValue("@pagibig", GetReqStatus("Pag-IBIG"))
                .AddWithValue("@tin", GetReqStatus("TIN"))
                .AddWithValue("@medical", GetReqStatus("Medical"))
                .AddWithValue("@diploma", GetReqStatus("Diploma"))
                .AddWithValue("@tor", GetReqStatus("TOR"))
                .AddWithValue("@reqPct", reqPercentage)

                .AddWithValue("@remarks", finalRemarksToSave)
            End With

            cmd.ExecuteNonQuery()

            Dim successMsg As String = If(IsEditMode, "Applicant updated successfully!", "Applicant added successfully!")
            MsgBox(successMsg, MsgBoxStyle.Information, "Success")

            Me.Close()

        Catch ex As Exception
            MsgBox("Error saving applicant: " & ex.Message, MsgBoxStyle.Critical, "Database Error")
        Finally
            Call DBconnection.CloseConnection()
        End Try
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

End Class