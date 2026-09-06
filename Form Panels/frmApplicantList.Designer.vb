<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmApplicantList
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmApplicantList))
        Me.dgvApplicants = New System.Windows.Forms.DataGridView()
        Me.lblScreened = New System.Windows.Forms.Label()
        Me.lblHRAvatar = New System.Windows.Forms.Label()
        Me.lblJobOffer = New System.Windows.Forms.Label()
        Me.lblDeployed = New System.Windows.Forms.Label()
        Me.lblForOrientation = New System.Windows.Forms.Label()
        Me.lblOngoingRequirements = New System.Windows.Forms.Label()
        Me.lblHired = New System.Windows.Forms.Label()
        Me.btnRefresh = New System.Windows.Forms.Button()
        Me.btnReset = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.txtSearch = New System.Windows.Forms.TextBox()
        Me.lblFinalInterview = New System.Windows.Forms.Label()
        CType(Me.dgvApplicants, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'dgvApplicants
        '
        Me.dgvApplicants.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvApplicants.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvApplicants.Location = New System.Drawing.Point(0, 96)
        Me.dgvApplicants.Name = "dgvApplicants"
        Me.dgvApplicants.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvApplicants.Size = New System.Drawing.Size(1342, 448)
        Me.dgvApplicants.TabIndex = 0
        '
        'lblScreened
        '
        Me.lblScreened.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblScreened.AutoSize = True
        Me.lblScreened.Font = New System.Drawing.Font("Microsoft YaHei UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblScreened.Location = New System.Drawing.Point(8, 703)
        Me.lblScreened.Name = "lblScreened"
        Me.lblScreened.Size = New System.Drawing.Size(66, 19)
        Me.lblScreened.TabIndex = 161
        Me.lblScreened.Text = "Screened"
        '
        'lblHRAvatar
        '
        Me.lblHRAvatar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblHRAvatar.AutoSize = True
        Me.lblHRAvatar.Font = New System.Drawing.Font("Microsoft YaHei UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblHRAvatar.Location = New System.Drawing.Point(129, 703)
        Me.lblHRAvatar.Name = "lblHRAvatar"
        Me.lblHRAvatar.Size = New System.Drawing.Size(71, 19)
        Me.lblHRAvatar.TabIndex = 162
        Me.lblHRAvatar.Text = "HR Avatar"
        '
        'lblJobOffer
        '
        Me.lblJobOffer.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblJobOffer.AutoSize = True
        Me.lblJobOffer.Font = New System.Drawing.Font("Microsoft YaHei UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblJobOffer.Location = New System.Drawing.Point(397, 703)
        Me.lblJobOffer.Name = "lblJobOffer"
        Me.lblJobOffer.Size = New System.Drawing.Size(67, 19)
        Me.lblJobOffer.TabIndex = 164
        Me.lblJobOffer.Text = "Job Offer"
        '
        'lblDeployed
        '
        Me.lblDeployed.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblDeployed.AutoSize = True
        Me.lblDeployed.Font = New System.Drawing.Font("Microsoft YaHei UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDeployed.Location = New System.Drawing.Point(980, 703)
        Me.lblDeployed.Name = "lblDeployed"
        Me.lblDeployed.Size = New System.Drawing.Size(67, 19)
        Me.lblDeployed.TabIndex = 168
        Me.lblDeployed.Text = "Deployed"
        '
        'lblForOrientation
        '
        Me.lblForOrientation.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblForOrientation.AutoSize = True
        Me.lblForOrientation.Font = New System.Drawing.Font("Microsoft YaHei UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblForOrientation.Location = New System.Drawing.Point(823, 703)
        Me.lblForOrientation.Name = "lblForOrientation"
        Me.lblForOrientation.Size = New System.Drawing.Size(98, 19)
        Me.lblForOrientation.TabIndex = 167
        Me.lblForOrientation.Text = "For Orientaion"
        '
        'lblOngoingRequirements
        '
        Me.lblOngoingRequirements.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblOngoingRequirements.AutoSize = True
        Me.lblOngoingRequirements.Font = New System.Drawing.Font("Microsoft YaHei UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblOngoingRequirements.Location = New System.Drawing.Point(624, 703)
        Me.lblOngoingRequirements.Name = "lblOngoingRequirements"
        Me.lblOngoingRequirements.Size = New System.Drawing.Size(143, 19)
        Me.lblOngoingRequirements.TabIndex = 166
        Me.lblOngoingRequirements.Text = "Ongoing Reuirements"
        '
        'lblHired
        '
        Me.lblHired.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblHired.AutoSize = True
        Me.lblHired.Font = New System.Drawing.Font("Microsoft YaHei UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblHired.Location = New System.Drawing.Point(516, 703)
        Me.lblHired.Name = "lblHired"
        Me.lblHired.Size = New System.Drawing.Size(42, 19)
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
        Me.btnRefresh.Location = New System.Drawing.Point(1192, 9)
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
        Me.btnReset.Location = New System.Drawing.Point(1052, 7)
        Me.btnReset.Name = "btnReset"
        Me.btnReset.Size = New System.Drawing.Size(134, 37)
        Me.btnReset.TabIndex = 169
        Me.btnReset.Text = "Create New"
        Me.btnReset.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnReset.UseVisualStyleBackColor = False
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.Label9)
        Me.Panel1.Controls.Add(Me.btnRefresh)
        Me.Panel1.Controls.Add(Me.btnReset)
        Me.Panel1.Controls.Add(Me.Panel2)
        Me.Panel1.Controls.Add(Me.dgvApplicants)
        Me.Panel1.Location = New System.Drawing.Point(12, 156)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1342, 544)
        Me.Panel1.TabIndex = 171
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft YaHei UI", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.MidnightBlue
        Me.Label9.Location = New System.Drawing.Point(11, 13)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(190, 26)
        Me.Label9.TabIndex = 172
        Me.Label9.Text = "Applicant tracking"
        '
        'Panel2
        '
        Me.Panel2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel2.BackColor = System.Drawing.SystemColors.ControlLight
        Me.Panel2.Controls.Add(Me.txtSearch)
        Me.Panel2.Location = New System.Drawing.Point(0, 52)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1342, 44)
        Me.Panel2.TabIndex = 1
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
        Me.lblFinalInterview.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblFinalInterview.AutoSize = True
        Me.lblFinalInterview.Font = New System.Drawing.Font("Microsoft YaHei UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFinalInterview.Location = New System.Drawing.Point(247, 703)
        Me.lblFinalInterview.Name = "lblFinalInterview"
        Me.lblFinalInterview.Size = New System.Drawing.Size(97, 19)
        Me.lblFinalInterview.TabIndex = 163
        Me.lblFinalInterview.Text = "Final Interview"
        '
        'frmApplicantList
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1366, 768)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.lblDeployed)
        Me.Controls.Add(Me.lblForOrientation)
        Me.Controls.Add(Me.lblOngoingRequirements)
        Me.Controls.Add(Me.lblHired)
        Me.Controls.Add(Me.lblJobOffer)
        Me.Controls.Add(Me.lblFinalInterview)
        Me.Controls.Add(Me.lblHRAvatar)
        Me.Controls.Add(Me.lblScreened)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmApplicantList"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "frmApplicantList"
        CType(Me.dgvApplicants, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents dgvApplicants As DataGridView
    Friend WithEvents lblScreened As Label
    Friend WithEvents lblHRAvatar As Label
    Friend WithEvents lblJobOffer As Label
    Friend WithEvents lblDeployed As Label
    Friend WithEvents lblForOrientation As Label
    Friend WithEvents lblOngoingRequirements As Label
    Friend WithEvents lblHired As Label
    Friend WithEvents btnRefresh As Button
    Friend WithEvents btnReset As Button
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Panel2 As Panel
    Friend WithEvents txtSearch As TextBox
    Friend WithEvents Label9 As Label
    Friend WithEvents lblFinalInterview As Label
End Class
