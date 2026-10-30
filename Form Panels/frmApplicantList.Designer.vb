<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmApplicantList
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmApplicantList))
        Me.lblScreened = New System.Windows.Forms.Label()
        Me.lblHRAvatar = New System.Windows.Forms.Label()
        Me.lblJobOffer = New System.Windows.Forms.Label()
        Me.lblDeployed = New System.Windows.Forms.Label()
        Me.lblForOrientation = New System.Windows.Forms.Label()
        Me.lblOngoingRequirements = New System.Windows.Forms.Label()
        Me.lblHired = New System.Windows.Forms.Label()
        Me.btnRefresh = New System.Windows.Forms.Button()
        Me.btnReset = New System.Windows.Forms.Button()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.dtpTo = New System.Windows.Forms.DateTimePicker()
        Me.txtSearch = New System.Windows.Forms.TextBox()
        Me.lblFinalInterview = New System.Windows.Forms.Label()
        Me.lblPooling = New System.Windows.Forms.Label()
        Me.lblRejected = New System.Windows.Forms.Label()
        Me.lblBackout = New System.Windows.Forms.Label()
        Me.lblInactive = New System.Windows.Forms.Label()
        Me.dgvApplicants = New System.Windows.Forms.DataGridView()
        Me.dtpFrom = New System.Windows.Forms.DateTimePicker()
        Me.lblTotalApplicants = New System.Windows.Forms.Label()
        Me.btnExportExcel = New System.Windows.Forms.Button()
        Me.Panel2.SuspendLayout()
        CType(Me.dgvApplicants, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblScreened
        '
        Me.lblScreened.AutoSize = True
        Me.lblScreened.Font = New System.Drawing.Font("Microsoft YaHei UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblScreened.Location = New System.Drawing.Point(25, 20)
        Me.lblScreened.Name = "lblScreened"
        Me.lblScreened.Size = New System.Drawing.Size(80, 21)
        Me.lblScreened.TabIndex = 161
        Me.lblScreened.Text = "Screened"
        '
        'lblHRAvatar
        '
        Me.lblHRAvatar.AutoSize = True
        Me.lblHRAvatar.Font = New System.Drawing.Font("Microsoft YaHei UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblHRAvatar.Location = New System.Drawing.Point(25, 61)
        Me.lblHRAvatar.Name = "lblHRAvatar"
        Me.lblHRAvatar.Size = New System.Drawing.Size(86, 21)
        Me.lblHRAvatar.TabIndex = 162
        Me.lblHRAvatar.Text = "HR Avatar"
        '
        'lblJobOffer
        '
        Me.lblJobOffer.AutoSize = True
        Me.lblJobOffer.Font = New System.Drawing.Font("Microsoft YaHei UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblJobOffer.Location = New System.Drawing.Point(532, 20)
        Me.lblJobOffer.Name = "lblJobOffer"
        Me.lblJobOffer.Size = New System.Drawing.Size(81, 21)
        Me.lblJobOffer.TabIndex = 164
        Me.lblJobOffer.Text = "Job Offer"
        '
        'lblDeployed
        '
        Me.lblDeployed.AutoSize = True
        Me.lblDeployed.Font = New System.Drawing.Font("Microsoft YaHei UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDeployed.Location = New System.Drawing.Point(229, 102)
        Me.lblDeployed.Name = "lblDeployed"
        Me.lblDeployed.Size = New System.Drawing.Size(82, 21)
        Me.lblDeployed.TabIndex = 168
        Me.lblDeployed.Text = "Deployed"
        '
        'lblForOrientation
        '
        Me.lblForOrientation.AutoSize = True
        Me.lblForOrientation.Font = New System.Drawing.Font("Microsoft YaHei UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblForOrientation.Location = New System.Drawing.Point(532, 61)
        Me.lblForOrientation.Name = "lblForOrientation"
        Me.lblForOrientation.Size = New System.Drawing.Size(121, 21)
        Me.lblForOrientation.TabIndex = 167
        Me.lblForOrientation.Text = "For Orientaion"
        '
        'lblOngoingRequirements
        '
        Me.lblOngoingRequirements.AutoSize = True
        Me.lblOngoingRequirements.Font = New System.Drawing.Font("Microsoft YaHei UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblOngoingRequirements.Location = New System.Drawing.Point(238, 61)
        Me.lblOngoingRequirements.Name = "lblOngoingRequirements"
        Me.lblOngoingRequirements.Size = New System.Drawing.Size(177, 21)
        Me.lblOngoingRequirements.TabIndex = 166
        Me.lblOngoingRequirements.Text = "Ongoing Reuirements"
        '
        'lblHired
        '
        Me.lblHired.AutoSize = True
        Me.lblHired.Font = New System.Drawing.Font("Microsoft YaHei UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblHired.Location = New System.Drawing.Point(238, 20)
        Me.lblHired.Name = "lblHired"
        Me.lblHired.Size = New System.Drawing.Size(51, 21)
        Me.lblHired.TabIndex = 165
        Me.lblHired.Text = "Hired"
        '
        'btnRefresh
        '
        Me.btnRefresh.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnRefresh.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.btnRefresh.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnRefresh.Font = New System.Drawing.Font("Microsoft YaHei UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnRefresh.ForeColor = System.Drawing.Color.DarkBlue
        Me.btnRefresh.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnRefresh.Location = New System.Drawing.Point(1220, 183)
        Me.btnRefresh.Name = "btnRefresh"
        Me.btnRefresh.Size = New System.Drawing.Size(134, 37)
        Me.btnRefresh.TabIndex = 170
        Me.btnRefresh.Text = "Refresh"
        Me.btnRefresh.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnRefresh.UseVisualStyleBackColor = False
        '
        'btnReset
        '
        Me.btnReset.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnReset.BackColor = System.Drawing.Color.DarkBlue
        Me.btnReset.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnReset.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnReset.Font = New System.Drawing.Font("Microsoft YaHei UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnReset.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.btnReset.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnReset.Location = New System.Drawing.Point(1220, 140)
        Me.btnReset.Name = "btnReset"
        Me.btnReset.Size = New System.Drawing.Size(134, 37)
        Me.btnReset.TabIndex = 169
        Me.btnReset.Text = "Create New"
        Me.btnReset.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnReset.UseVisualStyleBackColor = False
        '
        'Panel2
        '
        Me.Panel2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel2.BackColor = System.Drawing.SystemColors.ControlLight
        Me.Panel2.Controls.Add(Me.txtSearch)
        Me.Panel2.Controls.Add(Me.dtpFrom)
        Me.Panel2.Controls.Add(Me.dtpTo)
        Me.Panel2.Location = New System.Drawing.Point(12, 237)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1342, 44)
        Me.Panel2.TabIndex = 1
        '
        'dtpTo
        '
        Me.dtpTo.Font = New System.Drawing.Font("Microsoft YaHei UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpTo.Location = New System.Drawing.Point(631, 9)
        Me.dtpTo.Name = "dtpTo"
        Me.dtpTo.Size = New System.Drawing.Size(287, 28)
        Me.dtpTo.TabIndex = 172
        '
        'txtSearch
        '
        Me.txtSearch.BackColor = System.Drawing.SystemColors.Control
        Me.txtSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtSearch.Font = New System.Drawing.Font("Microsoft YaHei UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSearch.Location = New System.Drawing.Point(16, 9)
        Me.txtSearch.Name = "txtSearch"
        Me.txtSearch.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal
        Me.txtSearch.Size = New System.Drawing.Size(316, 28)
        Me.txtSearch.TabIndex = 165
        '
        'lblFinalInterview
        '
        Me.lblFinalInterview.AutoSize = True
        Me.lblFinalInterview.Font = New System.Drawing.Font("Microsoft YaHei UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFinalInterview.Location = New System.Drawing.Point(25, 102)
        Me.lblFinalInterview.Name = "lblFinalInterview"
        Me.lblFinalInterview.Size = New System.Drawing.Size(121, 21)
        Me.lblFinalInterview.TabIndex = 163
        Me.lblFinalInterview.Text = "Final Interview"
        '
        'lblPooling
        '
        Me.lblPooling.AutoSize = True
        Me.lblPooling.Font = New System.Drawing.Font("Microsoft YaHei UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPooling.Location = New System.Drawing.Point(755, 20)
        Me.lblPooling.Name = "lblPooling"
        Me.lblPooling.Size = New System.Drawing.Size(68, 21)
        Me.lblPooling.TabIndex = 173
        Me.lblPooling.Text = "Pooling"
        '
        'lblRejected
        '
        Me.lblRejected.AutoSize = True
        Me.lblRejected.Font = New System.Drawing.Font("Microsoft YaHei UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRejected.Location = New System.Drawing.Point(532, 102)
        Me.lblRejected.Name = "lblRejected"
        Me.lblRejected.Size = New System.Drawing.Size(75, 21)
        Me.lblRejected.TabIndex = 172
        Me.lblRejected.Text = "Rejected"
        '
        'lblBackout
        '
        Me.lblBackout.AutoSize = True
        Me.lblBackout.Font = New System.Drawing.Font("Microsoft YaHei UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBackout.Location = New System.Drawing.Point(755, 61)
        Me.lblBackout.Name = "lblBackout"
        Me.lblBackout.Size = New System.Drawing.Size(72, 21)
        Me.lblBackout.TabIndex = 174
        Me.lblBackout.Text = "Backout"
        '
        'lblInactive
        '
        Me.lblInactive.AutoSize = True
        Me.lblInactive.Font = New System.Drawing.Font("Microsoft YaHei UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblInactive.Location = New System.Drawing.Point(754, 102)
        Me.lblInactive.Name = "lblInactive"
        Me.lblInactive.Size = New System.Drawing.Size(69, 21)
        Me.lblInactive.TabIndex = 175
        Me.lblInactive.Text = "Inactive"
        '
        'dgvApplicants
        '
        Me.dgvApplicants.AllowUserToAddRows = False
        Me.dgvApplicants.AllowUserToDeleteRows = False
        Me.dgvApplicants.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvApplicants.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvApplicants.Location = New System.Drawing.Point(12, 287)
        Me.dgvApplicants.Name = "dgvApplicants"
        Me.dgvApplicants.ReadOnly = True
        Me.dgvApplicants.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvApplicants.Size = New System.Drawing.Size(1342, 469)
        Me.dgvApplicants.TabIndex = 0
        '
        'dtpFrom
        '
        Me.dtpFrom.Font = New System.Drawing.Font("Microsoft YaHei UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpFrom.Location = New System.Drawing.Point(338, 9)
        Me.dtpFrom.Name = "dtpFrom"
        Me.dtpFrom.Size = New System.Drawing.Size(287, 28)
        Me.dtpFrom.TabIndex = 173
        '
        'lblTotalApplicants
        '
        Me.lblTotalApplicants.AutoSize = True
        Me.lblTotalApplicants.Font = New System.Drawing.Font("Microsoft YaHei UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotalApplicants.Location = New System.Drawing.Point(950, 20)
        Me.lblTotalApplicants.Name = "lblTotalApplicants"
        Me.lblTotalApplicants.Size = New System.Drawing.Size(148, 21)
        Me.lblTotalApplicants.TabIndex = 176
        Me.lblTotalApplicants.Text = "TOTAL ACQUIRED"
        '
        'btnExportExcel
        '
        Me.btnExportExcel.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnExportExcel.BackColor = System.Drawing.Color.DarkBlue
        Me.btnExportExcel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnExportExcel.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnExportExcel.Font = New System.Drawing.Font("Microsoft YaHei UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnExportExcel.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.btnExportExcel.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnExportExcel.Location = New System.Drawing.Point(1220, 97)
        Me.btnExportExcel.Name = "btnExportExcel"
        Me.btnExportExcel.Size = New System.Drawing.Size(134, 37)
        Me.btnExportExcel.TabIndex = 177
        Me.btnExportExcel.Text = "Export"
        Me.btnExportExcel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnExportExcel.UseVisualStyleBackColor = False
        '
        'frmApplicantList
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1366, 768)
        Me.Controls.Add(Me.btnExportExcel)
        Me.Controls.Add(Me.lblTotalApplicants)
        Me.Controls.Add(Me.dgvApplicants)
        Me.Controls.Add(Me.btnRefresh)
        Me.Controls.Add(Me.btnReset)
        Me.Controls.Add(Me.lblInactive)
        Me.Controls.Add(Me.lblBackout)
        Me.Controls.Add(Me.lblPooling)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.lblRejected)
        Me.Controls.Add(Me.lblScreened)
        Me.Controls.Add(Me.lblHRAvatar)
        Me.Controls.Add(Me.lblFinalInterview)
        Me.Controls.Add(Me.lblHired)
        Me.Controls.Add(Me.lblForOrientation)
        Me.Controls.Add(Me.lblDeployed)
        Me.Controls.Add(Me.lblOngoingRequirements)
        Me.Controls.Add(Me.lblJobOffer)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmApplicantList"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "frmApplicantList"
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        CType(Me.dgvApplicants, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblScreened As Label
    Friend WithEvents lblHRAvatar As Label
    Friend WithEvents lblJobOffer As Label
    Friend WithEvents lblDeployed As Label
    Friend WithEvents lblForOrientation As Label
    Friend WithEvents lblOngoingRequirements As Label
    Friend WithEvents lblHired As Label
    Friend WithEvents btnRefresh As Button
    Friend WithEvents btnReset As Button
    Friend WithEvents Panel2 As Panel
    Friend WithEvents txtSearch As TextBox
    Friend WithEvents lblFinalInterview As Label
    Friend WithEvents dtpTo As DateTimePicker
    Friend WithEvents lblPooling As Label
    Friend WithEvents lblRejected As Label
    Friend WithEvents lblBackout As Label
    Friend WithEvents lblInactive As Label
    Friend WithEvents dgvApplicants As DataGridView
    Friend WithEvents dtpFrom As DateTimePicker
    Friend WithEvents lblTotalApplicants As Label
    Friend WithEvents btnExportExcel As Button
End Class
