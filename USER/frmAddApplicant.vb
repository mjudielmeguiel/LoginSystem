Imports System.Drawing
Imports System.Text.RegularExpressions
Imports MySql.Data.MySqlClient

Public Class frmAddApplicant

    Private isUpdatingCheckboxes As Boolean = False

    Private Sub frmAddApplicant_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Clear and hide error labels on form load
        ClearErrorLabels()

        ' Populate Status Dropdown Options
        cboCurrentStatus.Items.Clear()
        cboCurrentStatus.Items.Add("-- Select Status --")
        cboCurrentStatus.Items.AddRange(New String() {
            "Screened", "HR Avatar", "Final Interview", "Job Offer",
            "Hired", "Ongoing Requirements", "For Orientation", "Deployed",
            "Pooling", "Backout", "Rejected", "Inactive"
        })
        cboCurrentStatus.SelectedIndex = 0

        ' Load Database-backed Dropdowns
        LoadPositions()
        LoadSites()
        LoadSources()
    End Sub

    ' -------------------------------------------------------------
    ' DROPDOWN DATA LOADERS (WITH ID BINDING & PLACEHOLDERS)
    ' -------------------------------------------------------------

    Private Sub LoadPositions()
        Call connection()
        If cn.State <> ConnectionState.Open Then Exit Sub

        Try
            sql = "SELECT position_id, position_title FROM positions ORDER BY position_title ASC"
            Dim adapter As New MySqlDataAdapter(sql, cn)
            Dim dt As New DataTable()
            adapter.Fill(dt)

            ' Insert placeholder row at top
            Dim dr As DataRow = dt.NewRow()
            dr("position_id") = 0
            dr("position_title") = "-- Select Position --"
            dt.Rows.InsertAt(dr, 0)

            cboPosition.DataSource = dt
            cboPosition.DisplayMember = "position_title"
            cboPosition.ValueMember = "position_id"
            cboPosition.SelectedIndex = 0
        Catch ex As Exception
            ' Silent catch
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

            ' Insert placeholder row at top
            Dim dr As DataRow = dt.NewRow()
            dr("LocationID") = 0
            dr("Site") = "-- Select Site --"
            dt.Rows.InsertAt(dr, 0)

            cboSite.DataSource = dt
            cboSite.DisplayMember = "Site"
            cboSite.ValueMember = "LocationID"
            cboSite.SelectedIndex = 0
        Catch ex As Exception
            ' Silent catch
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

            ' Insert placeholder row at top
            Dim dr As DataRow = dt.NewRow()
            dr("SourceID") = 0
            dr("SourceName") = "-- Select Source --"
            dt.Rows.InsertAt(dr, 0)

            cboSource.DataSource = dt
            cboSource.DisplayMember = "SourceName"
            cboSource.ValueMember = "SourceID"
            cboSource.SelectedIndex = 0
        Catch ex As Exception
            ' Silent catch
        Finally
            Call DBconnection.CloseConnection()
        End Try
    End Sub

    Private Sub ClearErrorLabels()
        HideError(lblErrName)
        HideError(lblErrPosition)
        HideError(lblErrContact)
        HideError(lblErrEmail)
        HideError(lblErrAddress)
        HideError(lblErrSite)
        HideError(lblErrSource)
        HideError(lblErrStatus)
    End Sub

    ' -------------------------------------------------------------
    ' FORM VALIDATION (ON SAVE CLICK ONLY)
    ' -------------------------------------------------------------

    Private Function ValidateInputs() As Boolean
        Dim isValid As Boolean = True
        Dim emailPattern As String = "^[a-zA-Z0-9._%+-]+@(gmail|yahoo|outlook|hotmail|icloud)\.com$"

        ' Clear previous validation states
        ClearErrorLabels()

        ' 1. Name
        If String.IsNullOrWhiteSpace(txtname.Text) Then
            ShowError(lblErrName, "Name is required")
            isValid = False
        ElseIf Not Regex.IsMatch(txtname.Text.Trim(), "^[a-zA-Z\s\.\-]+$") Then
            ShowError(lblErrName, "Invalid Name format")
            isValid = False
        End If

        ' 2. Position
        If cboPosition.SelectedIndex <= 0 OrElse String.IsNullOrWhiteSpace(cboPosition.Text) Then
            ShowError(lblErrPosition, "Position is required")
            isValid = False
        End If

        ' 3. Contact Number
        If String.IsNullOrWhiteSpace(txtContactNo.Text) Then
            ShowError(lblErrContact, "Contact number is required")
            isValid = False
        ElseIf Not Regex.IsMatch(txtContactNo.Text.Trim(), "^(09|\+639)\d{9}$") AndAlso Not Regex.IsMatch(txtContactNo.Text.Trim(), "^\d{7,12}$") Then
            ShowError(lblErrContact, "Invalid contact number")
            isValid = False
        End If

        ' 4. Email Address
        If String.IsNullOrWhiteSpace(txtEmail.Text) Then
            ShowError(lblErrEmail, "Email address is required")
            isValid = False
        ElseIf Not Regex.IsMatch(txtEmail.Text.Trim(), emailPattern, RegexOptions.IgnoreCase) Then
            ShowError(lblErrEmail, "Must end in valid domain (e.g. @gmail.com)")
            isValid = False
        End If

        ' 5. Current Address
        If String.IsNullOrWhiteSpace(rchAddress.Text) OrElse rchAddress.Text.Trim().Length < 5 Then
            ShowError(lblErrAddress, "Address is required")
            isValid = False
        End If

        ' 6. Site
        If cboSite.SelectedIndex <= 0 OrElse String.IsNullOrWhiteSpace(cboSite.Text) Then
            ShowError(lblErrSite, "Site is required")
            isValid = False
        End If

        ' 7. Source
        If cboSource.SelectedIndex <= 0 OrElse String.IsNullOrWhiteSpace(cboSource.Text) Then
            ShowError(lblErrSource, "Source is required")
            isValid = False
        End If

        ' 8. Status
        If cboCurrentStatus.SelectedIndex <= 0 OrElse String.IsNullOrWhiteSpace(cboCurrentStatus.Text) Then
            ShowError(lblErrStatus, "Status is required")
            isValid = False
        End If

        Return isValid
    End Function

    Private Sub ShowError(lbl As Label, msg As String)
        lbl.Text = msg
        lbl.ForeColor = Color.Red
        lbl.Visible = True
    End Sub

    Private Sub HideError(lbl As Label)
        lbl.Text = ""
        lbl.Visible = False
    End Sub

    ' -------------------------------------------------------------
    ' CHECKBOX LOGIC
    ' -------------------------------------------------------------

    Private Sub chkCompleteRequirements_CheckedChanged(sender As Object, e As EventArgs) Handles chkCompleteRequirements.CheckedChanged
        If isUpdatingCheckboxes Then Exit Sub

        isUpdatingCheckboxes = True
        Dim state As Boolean = chkCompleteRequirements.Checked

        chkBarangay.Checked = state
        chkPolice.Checked = state
        chkNBI.Checked = state
        chkSSS.Checked = state
        chkPhilhealth.Checked = state
        chkPagibig.Checked = state
        chkTIN.Checked = state
        chkMedical.Checked = state
        chkDiploma.Checked = state
        chkTOR.Checked = state

        isUpdatingCheckboxes = False
    End Sub

    Private Sub IndividualRequirement_CheckedChanged(sender As Object, e As EventArgs) Handles _
        chkBarangay.CheckedChanged, chkPolice.CheckedChanged, chkNBI.CheckedChanged,
        chkSSS.CheckedChanged, chkPhilhealth.CheckedChanged, chkPagibig.CheckedChanged,
        chkTIN.CheckedChanged, chkMedical.CheckedChanged, chkDiploma.CheckedChanged, chkTOR.CheckedChanged

        If isUpdatingCheckboxes Then Exit Sub

        isUpdatingCheckboxes = True

        Dim allChecked As Boolean = chkBarangay.Checked AndAlso chkPolice.Checked AndAlso chkNBI.Checked AndAlso
                                   chkSSS.Checked AndAlso chkPhilhealth.Checked AndAlso chkPagibig.Checked AndAlso
                                   chkTIN.Checked AndAlso chkMedical.Checked AndAlso chkDiploma.Checked AndAlso chkTOR.Checked

        chkCompleteRequirements.Checked = allChecked
        isUpdatingCheckboxes = False
    End Sub

    Private Function GetReqStatus(chk As CheckBox) As String
        Return If(chk.Checked, "Submitted", "Pending")
    End Function

    ' -------------------------------------------------------------
    ' SAVE BUTTON
    ' -------------------------------------------------------------

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click

        ' Validates form only when Save is clicked
        If Not ValidateInputs() Then
            Exit Sub
        End If

        Call connection()
        If cn.State <> ConnectionState.Open Then
            MsgBox("Database Connection Error", MsgBoxStyle.Critical)
            Exit Sub
        End If

        Try
            sql = "INSERT INTO applicant_masterlist (" &
                  "NAME, POSITION, CONTACT_NO, EMAIL_ADDRESS, ADDRESS, SITE, SOURCE, CURRENT_STATUS, " &
                  "BARANGAY_CLEARANCE, POLICE_CLEARANCE, NBI, SSS, PHILHEALTH, PAGIBIG, TIN, MEDICAL, DIPLOMA, TOR, REMARKS) " &
                  "VALUES (" &
                  "@name, @position, @contact, @email, @address, @site, @source, @status, " &
                  "@brgy, @police, @nbi, @sss, @philhealth, @pagibig, @tin, @medical, @diploma, @tor, @remarks)"

            cmd = New MySqlCommand(sql, cn)

            With cmd.Parameters
                .AddWithValue("@name", txtname.Text.Trim())
                .AddWithValue("@position", cboPosition.Text.Trim())
                .AddWithValue("@contact", txtContactNo.Text.Trim())
                .AddWithValue("@email", txtEmail.Text.Trim().ToLower())
                .AddWithValue("@address", rchAddress.Text.Trim())
                .AddWithValue("@site", cboSite.Text.Trim())
                .AddWithValue("@source", cboSource.Text.Trim())
                .AddWithValue("@status", cboCurrentStatus.Text.Trim())

                .AddWithValue("@brgy", GetReqStatus(chkBarangay))
                .AddWithValue("@police", GetReqStatus(chkPolice))
                .AddWithValue("@nbi", GetReqStatus(chkNBI))
                .AddWithValue("@sss", GetReqStatus(chkSSS))
                .AddWithValue("@philhealth", GetReqStatus(chkPhilhealth))
                .AddWithValue("@pagibig", GetReqStatus(chkPagibig))
                .AddWithValue("@tin", GetReqStatus(chkTIN))
                .AddWithValue("@medical", GetReqStatus(chkMedical))
                .AddWithValue("@diploma", GetReqStatus(chkDiploma))
                .AddWithValue("@tor", GetReqStatus(chkTOR))

                .AddWithValue("@remarks", txtRemarks.Text.Trim())
            End With

            cmd.ExecuteNonQuery()

            MsgBox("Applicant added successfully!", MsgBoxStyle.Information, "Success")

            If Application.OpenForms.OfType(Of frmApplicantList)().Any() Then
                frmApplicantList.LoadApplicants()
            End If

            Me.Close()

        Catch ex As Exception
            MsgBox("Error adding applicant: " & ex.Message, MsgBoxStyle.Critical, "Database Error")
        Finally
            Call DBconnection.CloseConnection()
        End Try
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

End Class