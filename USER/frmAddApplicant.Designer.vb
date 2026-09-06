<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAddApplicant
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmAddApplicant))
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.chkMedical = New System.Windows.Forms.CheckBox()
        Me.chkDiploma = New System.Windows.Forms.CheckBox()
        Me.chkTOR = New System.Windows.Forms.CheckBox()
        Me.chkTIN = New System.Windows.Forms.CheckBox()
        Me.chkPagibig = New System.Windows.Forms.CheckBox()
        Me.chkPhilhealth = New System.Windows.Forms.CheckBox()
        Me.chkSSS = New System.Windows.Forms.CheckBox()
        Me.chkBarangay = New System.Windows.Forms.CheckBox()
        Me.chkPolice = New System.Windows.Forms.CheckBox()
        Me.chkNBI = New System.Windows.Forms.CheckBox()
        Me.chkCompleteRequirements = New System.Windows.Forms.CheckBox()
        Me.cboPosition = New System.Windows.Forms.ComboBox()
        Me.txtContactNo = New System.Windows.Forms.TextBox()
        Me.txtEmail = New System.Windows.Forms.TextBox()
        Me.rchAddress = New System.Windows.Forms.RichTextBox()
        Me.cboSite = New System.Windows.Forms.ComboBox()
        Me.cboCurrentStatus = New System.Windows.Forms.ComboBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.cboSource = New System.Windows.Forms.ComboBox()
        Me.txtRemarks = New System.Windows.Forms.TextBox()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.txtname = New System.Windows.Forms.TextBox()
        Me.lblErrName = New System.Windows.Forms.Label()
        Me.lblErrPosition = New System.Windows.Forms.Label()
        Me.lblErrEmail = New System.Windows.Forms.Label()
        Me.lblErrContact = New System.Windows.Forms.Label()
        Me.lblErrAddress = New System.Windows.Forms.Label()
        Me.lblErrSite = New System.Windows.Forms.Label()
        Me.lblErrSource = New System.Windows.Forms.Label()
        Me.lblErrStatus = New System.Windows.Forms.Label()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft YaHei UI", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.MidnightBlue
        Me.Label9.Location = New System.Drawing.Point(12, 37)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(200, 26)
        Me.Label9.TabIndex = 173
        Me.Label9.Text = "ADD new Applicant"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft YaHei UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(313, 119)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(58, 19)
        Me.Label7.TabIndex = 177
        Me.Label7.Text = "Position"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft YaHei UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(8, 120)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(108, 19)
        Me.Label3.TabIndex = 175
        Me.Label3.Text = "Applicant Name"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft YaHei UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(8, 211)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(113, 19)
        Me.Label1.TabIndex = 179
        Me.Label1.Text = "Contact Number"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft YaHei UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(313, 211)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(41, 19)
        Me.Label2.TabIndex = 181
        Me.Label2.Text = "Email"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft YaHei UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(14, 298)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(109, 19)
        Me.Label4.TabIndex = 183
        Me.Label4.Text = "Current Address"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft YaHei UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(10, 417)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(32, 19)
        Me.Label5.TabIndex = 185
        Me.Label5.Text = "Site"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft YaHei UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(8, 499)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(52, 19)
        Me.Label6.TabIndex = 189
        Me.Label6.Text = "Source"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft YaHei UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(8, 709)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(61, 19)
        Me.Label10.TabIndex = 194
        Me.Label10.Text = "Remarks"
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.chkMedical)
        Me.Panel1.Controls.Add(Me.chkDiploma)
        Me.Panel1.Controls.Add(Me.chkTOR)
        Me.Panel1.Controls.Add(Me.chkTIN)
        Me.Panel1.Controls.Add(Me.chkPagibig)
        Me.Panel1.Controls.Add(Me.chkCompleteRequirements)
        Me.Panel1.Controls.Add(Me.chkPhilhealth)
        Me.Panel1.Controls.Add(Me.chkSSS)
        Me.Panel1.Controls.Add(Me.chkBarangay)
        Me.Panel1.Controls.Add(Me.chkPolice)
        Me.Panel1.Controls.Add(Me.chkNBI)
        Me.Panel1.Location = New System.Drawing.Point(12, 581)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(606, 114)
        Me.Panel1.TabIndex = 195
        '
        'chkMedical
        '
        Me.chkMedical.AutoSize = True
        Me.chkMedical.Location = New System.Drawing.Point(418, 9)
        Me.chkMedical.Name = "chkMedical"
        Me.chkMedical.Size = New System.Drawing.Size(73, 17)
        Me.chkMedical.TabIndex = 202
        Me.chkMedical.Text = "MEDICAL"
        Me.chkMedical.UseVisualStyleBackColor = True
        '
        'chkDiploma
        '
        Me.chkDiploma.AutoSize = True
        Me.chkDiploma.Location = New System.Drawing.Point(418, 37)
        Me.chkDiploma.Name = "chkDiploma"
        Me.chkDiploma.Size = New System.Drawing.Size(74, 17)
        Me.chkDiploma.TabIndex = 203
        Me.chkDiploma.Text = "DIPLOMA"
        Me.chkDiploma.UseVisualStyleBackColor = True
        '
        'chkTOR
        '
        Me.chkTOR.AutoSize = True
        Me.chkTOR.Location = New System.Drawing.Point(418, 63)
        Me.chkTOR.Name = "chkTOR"
        Me.chkTOR.Size = New System.Drawing.Size(49, 17)
        Me.chkTOR.TabIndex = 205
        Me.chkTOR.Text = "TOR"
        Me.chkTOR.UseVisualStyleBackColor = True
        '
        'chkTIN
        '
        Me.chkTIN.AutoSize = True
        Me.chkTIN.Location = New System.Drawing.Point(248, 63)
        Me.chkTIN.Name = "chkTIN"
        Me.chkTIN.Size = New System.Drawing.Size(44, 17)
        Me.chkTIN.TabIndex = 201
        Me.chkTIN.Text = "TIN"
        Me.chkTIN.UseVisualStyleBackColor = True
        '
        'chkPagibig
        '
        Me.chkPagibig.AutoSize = True
        Me.chkPagibig.Location = New System.Drawing.Point(248, 37)
        Me.chkPagibig.Name = "chkPagibig"
        Me.chkPagibig.Size = New System.Drawing.Size(72, 17)
        Me.chkPagibig.TabIndex = 199
        Me.chkPagibig.Text = "PAG IBIG"
        Me.chkPagibig.UseVisualStyleBackColor = True
        '
        'chkPhilhealth
        '
        Me.chkPhilhealth.AutoSize = True
        Me.chkPhilhealth.Location = New System.Drawing.Point(248, 9)
        Me.chkPhilhealth.Name = "chkPhilhealth"
        Me.chkPhilhealth.Size = New System.Drawing.Size(93, 17)
        Me.chkPhilhealth.TabIndex = 200
        Me.chkPhilhealth.Text = "PHILHEALTH"
        Me.chkPhilhealth.UseVisualStyleBackColor = True
        '
        'chkSSS
        '
        Me.chkSSS.AutoSize = True
        Me.chkSSS.Location = New System.Drawing.Point(36, 87)
        Me.chkSSS.Name = "chkSSS"
        Me.chkSSS.Size = New System.Drawing.Size(47, 17)
        Me.chkSSS.TabIndex = 198
        Me.chkSSS.Text = "SSS"
        Me.chkSSS.UseVisualStyleBackColor = True
        '
        'chkBarangay
        '
        Me.chkBarangay.AutoSize = True
        Me.chkBarangay.Location = New System.Drawing.Point(36, 9)
        Me.chkBarangay.Name = "chkBarangay"
        Me.chkBarangay.Size = New System.Drawing.Size(152, 17)
        Me.chkBarangay.TabIndex = 206
        Me.chkBarangay.Text = "BARANGAY CLEARANCE"
        Me.chkBarangay.UseVisualStyleBackColor = True
        '
        'chkPolice
        '
        Me.chkPolice.AutoSize = True
        Me.chkPolice.Location = New System.Drawing.Point(36, 37)
        Me.chkPolice.Name = "chkPolice"
        Me.chkPolice.Size = New System.Drawing.Size(64, 17)
        Me.chkPolice.TabIndex = 197
        Me.chkPolice.Text = "POLICE"
        Me.chkPolice.UseVisualStyleBackColor = True
        '
        'chkNBI
        '
        Me.chkNBI.AutoSize = True
        Me.chkNBI.Location = New System.Drawing.Point(36, 63)
        Me.chkNBI.Name = "chkNBI"
        Me.chkNBI.Size = New System.Drawing.Size(44, 17)
        Me.chkNBI.TabIndex = 196
        Me.chkNBI.Text = "NBI"
        Me.chkNBI.UseVisualStyleBackColor = True
        '
        'chkCompleteRequirements
        '
        Me.chkCompleteRequirements.AutoSize = True
        Me.chkCompleteRequirements.Location = New System.Drawing.Point(418, 87)
        Me.chkCompleteRequirements.Name = "chkCompleteRequirements"
        Me.chkCompleteRequirements.Size = New System.Drawing.Size(138, 17)
        Me.chkCompleteRequirements.TabIndex = 204
        Me.chkCompleteRequirements.Text = "Complete Requirements"
        Me.chkCompleteRequirements.UseVisualStyleBackColor = True
        '
        'cboPosition
        '
        Me.cboPosition.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboPosition.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cboPosition.Font = New System.Drawing.Font("Microsoft YaHei UI", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboPosition.FormattingEnabled = True
        Me.cboPosition.Location = New System.Drawing.Point(317, 141)
        Me.cboPosition.Name = "cboPosition"
        Me.cboPosition.Size = New System.Drawing.Size(299, 28)
        Me.cboPosition.TabIndex = 217
        '
        'txtContactNo
        '
        Me.txtContactNo.BackColor = System.Drawing.SystemColors.Control
        Me.txtContactNo.Font = New System.Drawing.Font("Microsoft YaHei UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtContactNo.Location = New System.Drawing.Point(12, 233)
        Me.txtContactNo.Name = "txtContactNo"
        Me.txtContactNo.Size = New System.Drawing.Size(299, 28)
        Me.txtContactNo.TabIndex = 218
        '
        'txtEmail
        '
        Me.txtEmail.BackColor = System.Drawing.SystemColors.Control
        Me.txtEmail.Font = New System.Drawing.Font("Microsoft YaHei UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtEmail.Location = New System.Drawing.Point(317, 233)
        Me.txtEmail.Name = "txtEmail"
        Me.txtEmail.Size = New System.Drawing.Size(299, 28)
        Me.txtEmail.TabIndex = 219
        '
        'rchAddress
        '
        Me.rchAddress.Font = New System.Drawing.Font("Microsoft YaHei UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rchAddress.Location = New System.Drawing.Point(12, 320)
        Me.rchAddress.Name = "rchAddress"
        Me.rchAddress.Size = New System.Drawing.Size(606, 71)
        Me.rchAddress.TabIndex = 222
        Me.rchAddress.Text = ""
        '
        'cboSite
        '
        Me.cboSite.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboSite.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cboSite.Font = New System.Drawing.Font("Microsoft YaHei UI", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboSite.FormattingEnabled = True
        Me.cboSite.Location = New System.Drawing.Point(12, 439)
        Me.cboSite.Name = "cboSite"
        Me.cboSite.Size = New System.Drawing.Size(604, 28)
        Me.cboSite.TabIndex = 223
        '
        'cboCurrentStatus
        '
        Me.cboCurrentStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboCurrentStatus.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cboCurrentStatus.Font = New System.Drawing.Font("Microsoft YaHei UI", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboCurrentStatus.FormattingEnabled = True
        Me.cboCurrentStatus.Location = New System.Drawing.Point(316, 521)
        Me.cboCurrentStatus.Name = "cboCurrentStatus"
        Me.cboCurrentStatus.Size = New System.Drawing.Size(302, 28)
        Me.cboCurrentStatus.TabIndex = 225
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Microsoft YaHei UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(321, 499)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(48, 19)
        Me.Label15.TabIndex = 224
        Me.Label15.Text = "Status"
        '
        'cboSource
        '
        Me.cboSource.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboSource.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cboSource.Font = New System.Drawing.Font("Microsoft YaHei UI", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboSource.FormattingEnabled = True
        Me.cboSource.Location = New System.Drawing.Point(12, 521)
        Me.cboSource.Name = "cboSource"
        Me.cboSource.Size = New System.Drawing.Size(299, 28)
        Me.cboSource.TabIndex = 226
        '
        'txtRemarks
        '
        Me.txtRemarks.BackColor = System.Drawing.SystemColors.Control
        Me.txtRemarks.Font = New System.Drawing.Font("Microsoft YaHei UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRemarks.Location = New System.Drawing.Point(12, 731)
        Me.txtRemarks.Name = "txtRemarks"
        Me.txtRemarks.Size = New System.Drawing.Size(606, 28)
        Me.txtRemarks.TabIndex = 227
        '
        'btnCancel
        '
        Me.btnCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCancel.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.btnCancel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCancel.Font = New System.Drawing.Font("Microsoft YaHei UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancel.ForeColor = System.Drawing.Color.DarkBlue
        Me.btnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnCancel.Location = New System.Drawing.Point(12, 821)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(606, 37)
        Me.btnCancel.TabIndex = 229
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnCancel.UseVisualStyleBackColor = False
        '
        'btnSave
        '
        Me.btnSave.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSave.BackColor = System.Drawing.Color.DarkBlue
        Me.btnSave.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSave.Font = New System.Drawing.Font("Microsoft YaHei UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSave.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnSave.Location = New System.Drawing.Point(12, 778)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(606, 37)
        Me.btnSave.TabIndex = 228
        Me.btnSave.Text = "Save"
        Me.btnSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnSave.UseVisualStyleBackColor = False
        '
        'txtname
        '
        Me.txtname.BackColor = System.Drawing.SystemColors.Control
        Me.txtname.Font = New System.Drawing.Font("Microsoft YaHei UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtname.Location = New System.Drawing.Point(12, 142)
        Me.txtname.Name = "txtname"
        Me.txtname.Size = New System.Drawing.Size(299, 28)
        Me.txtname.TabIndex = 214
        '
        'lblErrName
        '
        Me.lblErrName.AutoSize = True
        Me.lblErrName.Font = New System.Drawing.Font("Microsoft YaHei UI Light", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblErrName.Location = New System.Drawing.Point(12, 173)
        Me.lblErrName.Name = "lblErrName"
        Me.lblErrName.Size = New System.Drawing.Size(12, 16)
        Me.lblErrName.TabIndex = 230
        Me.lblErrName.Text = "-"
        '
        'lblErrPosition
        '
        Me.lblErrPosition.AutoSize = True
        Me.lblErrPosition.Font = New System.Drawing.Font("Microsoft YaHei UI Light", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblErrPosition.Location = New System.Drawing.Point(313, 172)
        Me.lblErrPosition.Name = "lblErrPosition"
        Me.lblErrPosition.Size = New System.Drawing.Size(12, 16)
        Me.lblErrPosition.TabIndex = 231
        Me.lblErrPosition.Text = "-"
        '
        'lblErrEmail
        '
        Me.lblErrEmail.AutoSize = True
        Me.lblErrEmail.Font = New System.Drawing.Font("Microsoft YaHei UI Light", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblErrEmail.Location = New System.Drawing.Point(314, 264)
        Me.lblErrEmail.Name = "lblErrEmail"
        Me.lblErrEmail.Size = New System.Drawing.Size(12, 16)
        Me.lblErrEmail.TabIndex = 233
        Me.lblErrEmail.Text = "-"
        '
        'lblErrContact
        '
        Me.lblErrContact.AutoSize = True
        Me.lblErrContact.Font = New System.Drawing.Font("Microsoft YaHei UI Light", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblErrContact.Location = New System.Drawing.Point(12, 264)
        Me.lblErrContact.Name = "lblErrContact"
        Me.lblErrContact.Size = New System.Drawing.Size(12, 16)
        Me.lblErrContact.TabIndex = 232
        Me.lblErrContact.Text = "-"
        '
        'lblErrAddress
        '
        Me.lblErrAddress.AutoSize = True
        Me.lblErrAddress.Font = New System.Drawing.Font("Microsoft YaHei UI Light", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblErrAddress.Location = New System.Drawing.Point(9, 394)
        Me.lblErrAddress.Name = "lblErrAddress"
        Me.lblErrAddress.Size = New System.Drawing.Size(12, 16)
        Me.lblErrAddress.TabIndex = 234
        Me.lblErrAddress.Text = "-"
        '
        'lblErrSite
        '
        Me.lblErrSite.AutoSize = True
        Me.lblErrSite.Font = New System.Drawing.Font("Microsoft YaHei UI Light", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblErrSite.Location = New System.Drawing.Point(9, 470)
        Me.lblErrSite.Name = "lblErrSite"
        Me.lblErrSite.Size = New System.Drawing.Size(12, 16)
        Me.lblErrSite.TabIndex = 235
        Me.lblErrSite.Text = "-"
        '
        'lblErrSource
        '
        Me.lblErrSource.AutoSize = True
        Me.lblErrSource.Font = New System.Drawing.Font("Microsoft YaHei UI Light", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblErrSource.Location = New System.Drawing.Point(9, 552)
        Me.lblErrSource.Name = "lblErrSource"
        Me.lblErrSource.Size = New System.Drawing.Size(12, 16)
        Me.lblErrSource.TabIndex = 236
        Me.lblErrSource.Text = "-"
        '
        'lblErrStatus
        '
        Me.lblErrStatus.AutoSize = True
        Me.lblErrStatus.Font = New System.Drawing.Font("Microsoft YaHei UI Light", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblErrStatus.Location = New System.Drawing.Point(322, 552)
        Me.lblErrStatus.Name = "lblErrStatus"
        Me.lblErrStatus.Size = New System.Drawing.Size(12, 16)
        Me.lblErrStatus.TabIndex = 237
        Me.lblErrStatus.Text = "-"
        '
        'frmAddApplicant
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(630, 872)
        Me.Controls.Add(Me.lblErrStatus)
        Me.Controls.Add(Me.lblErrSource)
        Me.Controls.Add(Me.lblErrSite)
        Me.Controls.Add(Me.lblErrAddress)
        Me.Controls.Add(Me.lblErrEmail)
        Me.Controls.Add(Me.lblErrContact)
        Me.Controls.Add(Me.lblErrPosition)
        Me.Controls.Add(Me.lblErrName)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.txtRemarks)
        Me.Controls.Add(Me.cboSource)
        Me.Controls.Add(Me.cboCurrentStatus)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.cboSite)
        Me.Controls.Add(Me.rchAddress)
        Me.Controls.Add(Me.txtEmail)
        Me.Controls.Add(Me.txtContactNo)
        Me.Controls.Add(Me.cboPosition)
        Me.Controls.Add(Me.txtname)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label9)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmAddApplicant"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "frmAddApplicant"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label9 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents Panel1 As Panel
    Friend WithEvents chkNBI As CheckBox
    Friend WithEvents chkPolice As CheckBox
    Friend WithEvents chkPagibig As CheckBox
    Friend WithEvents chkSSS As CheckBox
    Friend WithEvents chkPhilhealth As CheckBox
    Friend WithEvents chkTOR As CheckBox
    Friend WithEvents chkCompleteRequirements As CheckBox
    Friend WithEvents chkDiploma As CheckBox
    Friend WithEvents chkMedical As CheckBox
    Friend WithEvents chkTIN As CheckBox
    Friend WithEvents chkBarangay As CheckBox
    Friend WithEvents cboPosition As ComboBox
    Friend WithEvents txtContactNo As TextBox
    Friend WithEvents txtEmail As TextBox
    Friend WithEvents rchAddress As RichTextBox
    Friend WithEvents cboSite As ComboBox
    Friend WithEvents cboCurrentStatus As ComboBox
    Friend WithEvents Label15 As Label
    Friend WithEvents cboSource As ComboBox
    Friend WithEvents txtRemarks As TextBox
    Friend WithEvents btnCancel As Button
    Friend WithEvents btnSave As Button
    Friend WithEvents txtname As TextBox
    Friend WithEvents lblErrName As Label
    Friend WithEvents lblErrEmail As Label
    Friend WithEvents lblErrContact As Label
    Friend WithEvents lblErrAddress As Label
    Friend WithEvents lblErrSite As Label
    Friend WithEvents lblErrSource As Label
    Friend WithEvents lblErrStatus As Label
    Friend WithEvents lblErrPosition As Label
End Class
