<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmHome
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmHome))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Panel19 = New System.Windows.Forms.Panel()
        Me.lblTotalLocationHired = New System.Windows.Forms.Label()
        Me.Button15 = New System.Windows.Forms.Button()
        Me.Panel12 = New System.Windows.Forms.Panel()
        Me.lblTotalLocationSlots = New System.Windows.Forms.Label()
        Me.Button14 = New System.Windows.Forms.Button()
        Me.Panel20 = New System.Windows.Forms.Panel()
        Me.lblTotalPositionHired = New System.Windows.Forms.Label()
        Me.Button16 = New System.Windows.Forms.Button()
        Me.Panel11 = New System.Windows.Forms.Panel()
        Me.lblTotalPositionSlots = New System.Windows.Forms.Label()
        Me.Button12 = New System.Windows.Forms.Button()
        Me.Panel7 = New System.Windows.Forms.Panel()
        Me.dgvApplicants = New System.Windows.Forms.DataGridView()
        Me.btnRefresh = New System.Windows.Forms.Button()
        Me.Button13 = New System.Windows.Forms.Button()
        Me.Panel10 = New System.Windows.Forms.Panel()
        Me.txtSearchApplicant = New System.Windows.Forms.TextBox()
        Me.lvPositions = New System.Windows.Forms.ListView()
        Me.Panel6 = New System.Windows.Forms.Panel()
        Me.lblCountPooling = New System.Windows.Forms.Label()
        Me.Button10 = New System.Windows.Forms.Button()
        Me.Panel17 = New System.Windows.Forms.Panel()
        Me.lblCountOngoing = New System.Windows.Forms.Label()
        Me.Button6 = New System.Windows.Forms.Button()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.lblCountInactive = New System.Windows.Forms.Label()
        Me.Button8 = New System.Windows.Forms.Button()
        Me.Panel8 = New System.Windows.Forms.Panel()
        Me.lblCountRejected = New System.Windows.Forms.Label()
        Me.Button11 = New System.Windows.Forms.Button()
        Me.Panel18 = New System.Windows.Forms.Panel()
        Me.lblCountHired = New System.Windows.Forms.Label()
        Me.Button7 = New System.Windows.Forms.Button()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.lblCountBackout = New System.Windows.Forms.Label()
        Me.Button9 = New System.Windows.Forms.Button()
        Me.lvLocations = New System.Windows.Forms.ListView()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.lblCountScreened = New System.Windows.Forms.Label()
        Me.btnReset = New System.Windows.Forms.Button()
        Me.Panel15 = New System.Windows.Forms.Panel()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Panel13 = New System.Windows.Forms.Panel()
        Me.lblCountHRAvatar = New System.Windows.Forms.Label()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Panel9 = New System.Windows.Forms.Panel()
        Me.lblCountOrientation = New System.Windows.Forms.Label()
        Me.Button5 = New System.Windows.Forms.Button()
        Me.Panel16 = New System.Windows.Forms.Panel()
        Me.lblCountJobOffer = New System.Windows.Forms.Label()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.lblCountDeployed = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Panel14 = New System.Windows.Forms.Panel()
        Me.lblCountFinalInterview = New System.Windows.Forms.Label()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.Panel1.SuspendLayout()
        Me.Panel19.SuspendLayout()
        Me.Panel12.SuspendLayout()
        Me.Panel20.SuspendLayout()
        Me.Panel11.SuspendLayout()
        Me.Panel7.SuspendLayout()
        CType(Me.dgvApplicants, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel10.SuspendLayout()
        Me.Panel6.SuspendLayout()
        Me.Panel17.SuspendLayout()
        Me.Panel4.SuspendLayout()
        Me.Panel8.SuspendLayout()
        Me.Panel18.SuspendLayout()
        Me.Panel5.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel15.SuspendLayout()
        Me.Panel13.SuspendLayout()
        Me.Panel9.SuspendLayout()
        Me.Panel16.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.Panel14.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.AutoScroll = True
        Me.Panel1.Controls.Add(Me.Panel19)
        Me.Panel1.Controls.Add(Me.Panel12)
        Me.Panel1.Controls.Add(Me.Panel20)
        Me.Panel1.Controls.Add(Me.Panel11)
        Me.Panel1.Controls.Add(Me.Panel7)
        Me.Panel1.Controls.Add(Me.lvPositions)
        Me.Panel1.Controls.Add(Me.Panel6)
        Me.Panel1.Controls.Add(Me.Panel17)
        Me.Panel1.Controls.Add(Me.Panel4)
        Me.Panel1.Controls.Add(Me.Panel8)
        Me.Panel1.Controls.Add(Me.Panel18)
        Me.Panel1.Controls.Add(Me.Panel5)
        Me.Panel1.Controls.Add(Me.lvLocations)
        Me.Panel1.Controls.Add(Me.Panel2)
        Me.Panel1.Controls.Add(Me.Panel15)
        Me.Panel1.Controls.Add(Me.Panel13)
        Me.Panel1.Controls.Add(Me.Panel9)
        Me.Panel1.Controls.Add(Me.Panel16)
        Me.Panel1.Controls.Add(Me.Panel3)
        Me.Panel1.Controls.Add(Me.Panel14)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1366, 768)
        Me.Panel1.TabIndex = 0
        '
        'Panel19
        '
        Me.Panel19.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel19.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel19.Controls.Add(Me.lblTotalLocationHired)
        Me.Panel19.Controls.Add(Me.Button15)
        Me.Panel19.Location = New System.Drawing.Point(797, 328)
        Me.Panel19.Name = "Panel19"
        Me.Panel19.Size = New System.Drawing.Size(181, 99)
        Me.Panel19.TabIndex = 206
        '
        'lblTotalLocationHired
        '
        Me.lblTotalLocationHired.AutoSize = True
        Me.lblTotalLocationHired.Font = New System.Drawing.Font("Microsoft YaHei UI", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotalLocationHired.ForeColor = System.Drawing.Color.Navy
        Me.lblTotalLocationHired.Location = New System.Drawing.Point(72, 40)
        Me.lblTotalLocationHired.Name = "lblTotalLocationHired"
        Me.lblTotalLocationHired.Size = New System.Drawing.Size(32, 36)
        Me.lblTotalLocationHired.TabIndex = 163
        Me.lblTotalLocationHired.Text = "0"
        '
        'Button15
        '
        Me.Button15.BackColor = System.Drawing.Color.DarkBlue
        Me.Button15.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.Button15.Dock = System.Windows.Forms.DockStyle.Top
        Me.Button15.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button15.Font = New System.Drawing.Font("Microsoft YaHei UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button15.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.Button15.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button15.Location = New System.Drawing.Point(0, 0)
        Me.Button15.Name = "Button15"
        Me.Button15.Size = New System.Drawing.Size(179, 37)
        Me.Button15.TabIndex = 179
        Me.Button15.Text = "Location Hired"
        Me.Button15.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.Button15.UseVisualStyleBackColor = False
        '
        'Panel12
        '
        Me.Panel12.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel12.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel12.Controls.Add(Me.lblTotalLocationSlots)
        Me.Panel12.Controls.Add(Me.Button14)
        Me.Panel12.Location = New System.Drawing.Point(610, 328)
        Me.Panel12.Name = "Panel12"
        Me.Panel12.Size = New System.Drawing.Size(183, 99)
        Me.Panel12.TabIndex = 208
        '
        'lblTotalLocationSlots
        '
        Me.lblTotalLocationSlots.AutoSize = True
        Me.lblTotalLocationSlots.Font = New System.Drawing.Font("Microsoft YaHei UI", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotalLocationSlots.ForeColor = System.Drawing.Color.Navy
        Me.lblTotalLocationSlots.Location = New System.Drawing.Point(72, 40)
        Me.lblTotalLocationSlots.Name = "lblTotalLocationSlots"
        Me.lblTotalLocationSlots.Size = New System.Drawing.Size(32, 36)
        Me.lblTotalLocationSlots.TabIndex = 163
        Me.lblTotalLocationSlots.Text = "0"
        '
        'Button14
        '
        Me.Button14.BackColor = System.Drawing.Color.DarkBlue
        Me.Button14.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.Button14.Dock = System.Windows.Forms.DockStyle.Top
        Me.Button14.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button14.Font = New System.Drawing.Font("Microsoft YaHei UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button14.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.Button14.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button14.Location = New System.Drawing.Point(0, 0)
        Me.Button14.Name = "Button14"
        Me.Button14.Size = New System.Drawing.Size(181, 37)
        Me.Button14.TabIndex = 179
        Me.Button14.Text = "Location Slots"
        Me.Button14.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.Button14.UseVisualStyleBackColor = False
        '
        'Panel20
        '
        Me.Panel20.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel20.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel20.Controls.Add(Me.lblTotalPositionHired)
        Me.Panel20.Controls.Add(Me.Button16)
        Me.Panel20.Location = New System.Drawing.Point(1175, 327)
        Me.Panel20.Name = "Panel20"
        Me.Panel20.Size = New System.Drawing.Size(181, 99)
        Me.Panel20.TabIndex = 207
        '
        'lblTotalPositionHired
        '
        Me.lblTotalPositionHired.AutoSize = True
        Me.lblTotalPositionHired.Font = New System.Drawing.Font("Microsoft YaHei UI", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotalPositionHired.ForeColor = System.Drawing.Color.Navy
        Me.lblTotalPositionHired.Location = New System.Drawing.Point(73, 43)
        Me.lblTotalPositionHired.Name = "lblTotalPositionHired"
        Me.lblTotalPositionHired.Size = New System.Drawing.Size(32, 36)
        Me.lblTotalPositionHired.TabIndex = 163
        Me.lblTotalPositionHired.Text = "0"
        '
        'Button16
        '
        Me.Button16.BackColor = System.Drawing.Color.DarkBlue
        Me.Button16.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.Button16.Dock = System.Windows.Forms.DockStyle.Top
        Me.Button16.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button16.Font = New System.Drawing.Font("Microsoft YaHei UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button16.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.Button16.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button16.Location = New System.Drawing.Point(0, 0)
        Me.Button16.Name = "Button16"
        Me.Button16.Size = New System.Drawing.Size(179, 37)
        Me.Button16.TabIndex = 179
        Me.Button16.Text = "Position Hired"
        Me.Button16.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.Button16.UseVisualStyleBackColor = False
        '
        'Panel11
        '
        Me.Panel11.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel11.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel11.Controls.Add(Me.lblTotalPositionSlots)
        Me.Panel11.Controls.Add(Me.Button12)
        Me.Panel11.Location = New System.Drawing.Point(985, 327)
        Me.Panel11.Name = "Panel11"
        Me.Panel11.Size = New System.Drawing.Size(182, 99)
        Me.Panel11.TabIndex = 207
        '
        'lblTotalPositionSlots
        '
        Me.lblTotalPositionSlots.AutoSize = True
        Me.lblTotalPositionSlots.Font = New System.Drawing.Font("Microsoft YaHei UI", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotalPositionSlots.ForeColor = System.Drawing.Color.Navy
        Me.lblTotalPositionSlots.Location = New System.Drawing.Point(73, 43)
        Me.lblTotalPositionSlots.Name = "lblTotalPositionSlots"
        Me.lblTotalPositionSlots.Size = New System.Drawing.Size(32, 36)
        Me.lblTotalPositionSlots.TabIndex = 163
        Me.lblTotalPositionSlots.Text = "0"
        '
        'Button12
        '
        Me.Button12.BackColor = System.Drawing.Color.DarkBlue
        Me.Button12.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.Button12.Dock = System.Windows.Forms.DockStyle.Top
        Me.Button12.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button12.Font = New System.Drawing.Font("Microsoft YaHei UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button12.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.Button12.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button12.Location = New System.Drawing.Point(0, 0)
        Me.Button12.Name = "Button12"
        Me.Button12.Size = New System.Drawing.Size(180, 37)
        Me.Button12.TabIndex = 179
        Me.Button12.Text = "Position Slots"
        Me.Button12.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.Button12.UseVisualStyleBackColor = False
        '
        'Panel7
        '
        Me.Panel7.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel7.Controls.Add(Me.dgvApplicants)
        Me.Panel7.Controls.Add(Me.btnRefresh)
        Me.Panel7.Controls.Add(Me.Button13)
        Me.Panel7.Controls.Add(Me.Panel10)
        Me.Panel7.Location = New System.Drawing.Point(11, 117)
        Me.Panel7.Name = "Panel7"
        Me.Panel7.Size = New System.Drawing.Size(593, 639)
        Me.Panel7.TabIndex = 212
        '
        'dgvApplicants
        '
        Me.dgvApplicants.AllowUserToAddRows = False
        Me.dgvApplicants.AllowUserToDeleteRows = False
        Me.dgvApplicants.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvApplicants.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dgvApplicants.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvApplicants.Location = New System.Drawing.Point(16, 106)
        Me.dgvApplicants.Name = "dgvApplicants"
        Me.dgvApplicants.ReadOnly = True
        Me.dgvApplicants.Size = New System.Drawing.Size(561, 513)
        Me.dgvApplicants.TabIndex = 171
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
        Me.btnRefresh.Location = New System.Drawing.Point(443, 9)
        Me.btnRefresh.Name = "btnRefresh"
        Me.btnRefresh.Size = New System.Drawing.Size(134, 37)
        Me.btnRefresh.TabIndex = 170
        Me.btnRefresh.Text = "Refresh"
        Me.btnRefresh.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnRefresh.UseVisualStyleBackColor = False
        '
        'Button13
        '
        Me.Button13.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button13.BackColor = System.Drawing.Color.DarkBlue
        Me.Button13.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.Button13.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button13.Font = New System.Drawing.Font("Microsoft YaHei UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button13.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.Button13.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button13.Location = New System.Drawing.Point(303, 7)
        Me.Button13.Name = "Button13"
        Me.Button13.Size = New System.Drawing.Size(134, 37)
        Me.Button13.TabIndex = 169
        Me.Button13.Text = "Create New"
        Me.Button13.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.Button13.UseVisualStyleBackColor = False
        '
        'Panel10
        '
        Me.Panel10.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel10.BackColor = System.Drawing.SystemColors.ControlLight
        Me.Panel10.Controls.Add(Me.txtSearchApplicant)
        Me.Panel10.Location = New System.Drawing.Point(0, 52)
        Me.Panel10.Name = "Panel10"
        Me.Panel10.Size = New System.Drawing.Size(593, 44)
        Me.Panel10.TabIndex = 1
        '
        'txtSearchApplicant
        '
        Me.txtSearchApplicant.BackColor = System.Drawing.SystemColors.Control
        Me.txtSearchApplicant.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtSearchApplicant.Font = New System.Drawing.Font("Microsoft YaHei UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSearchApplicant.Location = New System.Drawing.Point(16, 9)
        Me.txtSearchApplicant.Name = "txtSearchApplicant"
        Me.txtSearchApplicant.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal
        Me.txtSearchApplicant.Size = New System.Drawing.Size(316, 28)
        Me.txtSearchApplicant.TabIndex = 165
        '
        'lvPositions
        '
        Me.lvPositions.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lvPositions.HideSelection = False
        Me.lvPositions.Location = New System.Drawing.Point(985, 432)
        Me.lvPositions.Name = "lvPositions"
        Me.lvPositions.Size = New System.Drawing.Size(371, 324)
        Me.lvPositions.TabIndex = 207
        Me.lvPositions.UseCompatibleStateImageBehavior = False
        '
        'Panel6
        '
        Me.Panel6.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel6.Controls.Add(Me.lblCountPooling)
        Me.Panel6.Controls.Add(Me.Button10)
        Me.Panel6.Location = New System.Drawing.Point(798, 223)
        Me.Panel6.Name = "Panel6"
        Me.Panel6.Size = New System.Drawing.Size(181, 99)
        Me.Panel6.TabIndex = 204
        '
        'lblCountPooling
        '
        Me.lblCountPooling.AutoSize = True
        Me.lblCountPooling.Font = New System.Drawing.Font("Microsoft YaHei UI", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCountPooling.ForeColor = System.Drawing.Color.Navy
        Me.lblCountPooling.Location = New System.Drawing.Point(72, 40)
        Me.lblCountPooling.Name = "lblCountPooling"
        Me.lblCountPooling.Size = New System.Drawing.Size(32, 36)
        Me.lblCountPooling.TabIndex = 163
        Me.lblCountPooling.Text = "0"
        '
        'Button10
        '
        Me.Button10.BackColor = System.Drawing.Color.DarkBlue
        Me.Button10.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.Button10.Dock = System.Windows.Forms.DockStyle.Top
        Me.Button10.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button10.Font = New System.Drawing.Font("Microsoft YaHei UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button10.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.Button10.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button10.Location = New System.Drawing.Point(0, 0)
        Me.Button10.Name = "Button10"
        Me.Button10.Size = New System.Drawing.Size(179, 37)
        Me.Button10.TabIndex = 179
        Me.Button10.Text = "Pooling"
        Me.Button10.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.Button10.UseVisualStyleBackColor = False
        '
        'Panel17
        '
        Me.Panel17.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel17.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel17.Controls.Add(Me.lblCountOngoing)
        Me.Panel17.Controls.Add(Me.Button6)
        Me.Panel17.Location = New System.Drawing.Point(799, 118)
        Me.Panel17.Name = "Panel17"
        Me.Panel17.Size = New System.Drawing.Size(181, 99)
        Me.Panel17.TabIndex = 200
        '
        'lblCountOngoing
        '
        Me.lblCountOngoing.AutoSize = True
        Me.lblCountOngoing.Font = New System.Drawing.Font("Microsoft YaHei UI", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCountOngoing.ForeColor = System.Drawing.Color.Navy
        Me.lblCountOngoing.Location = New System.Drawing.Point(71, 41)
        Me.lblCountOngoing.Name = "lblCountOngoing"
        Me.lblCountOngoing.Size = New System.Drawing.Size(32, 36)
        Me.lblCountOngoing.TabIndex = 163
        Me.lblCountOngoing.Text = "0"
        '
        'Button6
        '
        Me.Button6.BackColor = System.Drawing.Color.DarkBlue
        Me.Button6.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.Button6.Dock = System.Windows.Forms.DockStyle.Top
        Me.Button6.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button6.Font = New System.Drawing.Font("Microsoft YaHei UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button6.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.Button6.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button6.Location = New System.Drawing.Point(0, 0)
        Me.Button6.Name = "Button6"
        Me.Button6.Size = New System.Drawing.Size(179, 37)
        Me.Button6.TabIndex = 179
        Me.Button6.Text = "Ongoing"
        Me.Button6.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.Button6.UseVisualStyleBackColor = False
        '
        'Panel4
        '
        Me.Panel4.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel4.Controls.Add(Me.lblCountInactive)
        Me.Panel4.Controls.Add(Me.Button8)
        Me.Panel4.Location = New System.Drawing.Point(1172, 222)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(181, 99)
        Me.Panel4.TabIndex = 206
        '
        'lblCountInactive
        '
        Me.lblCountInactive.AutoSize = True
        Me.lblCountInactive.Font = New System.Drawing.Font("Microsoft YaHei UI", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCountInactive.ForeColor = System.Drawing.Color.Navy
        Me.lblCountInactive.Location = New System.Drawing.Point(70, 43)
        Me.lblCountInactive.Name = "lblCountInactive"
        Me.lblCountInactive.Size = New System.Drawing.Size(32, 36)
        Me.lblCountInactive.TabIndex = 163
        Me.lblCountInactive.Text = "0"
        '
        'Button8
        '
        Me.Button8.BackColor = System.Drawing.Color.DarkBlue
        Me.Button8.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.Button8.Dock = System.Windows.Forms.DockStyle.Top
        Me.Button8.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button8.Font = New System.Drawing.Font("Microsoft YaHei UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button8.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.Button8.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button8.Location = New System.Drawing.Point(0, 0)
        Me.Button8.Name = "Button8"
        Me.Button8.Size = New System.Drawing.Size(179, 37)
        Me.Button8.TabIndex = 179
        Me.Button8.Text = "Inactive"
        Me.Button8.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.Button8.UseVisualStyleBackColor = False
        '
        'Panel8
        '
        Me.Panel8.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel8.Controls.Add(Me.lblCountRejected)
        Me.Panel8.Controls.Add(Me.Button11)
        Me.Panel8.Location = New System.Drawing.Point(611, 222)
        Me.Panel8.Name = "Panel8"
        Me.Panel8.Size = New System.Drawing.Size(181, 99)
        Me.Panel8.TabIndex = 203
        '
        'lblCountRejected
        '
        Me.lblCountRejected.AutoSize = True
        Me.lblCountRejected.Font = New System.Drawing.Font("Microsoft YaHei UI", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCountRejected.ForeColor = System.Drawing.Color.Navy
        Me.lblCountRejected.Location = New System.Drawing.Point(71, 43)
        Me.lblCountRejected.Name = "lblCountRejected"
        Me.lblCountRejected.Size = New System.Drawing.Size(32, 36)
        Me.lblCountRejected.TabIndex = 163
        Me.lblCountRejected.Text = "0"
        '
        'Button11
        '
        Me.Button11.BackColor = System.Drawing.Color.DarkBlue
        Me.Button11.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.Button11.Dock = System.Windows.Forms.DockStyle.Top
        Me.Button11.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button11.Font = New System.Drawing.Font("Microsoft YaHei UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button11.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.Button11.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button11.Location = New System.Drawing.Point(0, 0)
        Me.Button11.Name = "Button11"
        Me.Button11.Size = New System.Drawing.Size(179, 37)
        Me.Button11.TabIndex = 179
        Me.Button11.Text = "Rejected"
        Me.Button11.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.Button11.UseVisualStyleBackColor = False
        '
        'Panel18
        '
        Me.Panel18.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel18.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel18.Controls.Add(Me.lblCountHired)
        Me.Panel18.Controls.Add(Me.Button7)
        Me.Panel18.Location = New System.Drawing.Point(612, 117)
        Me.Panel18.Name = "Panel18"
        Me.Panel18.Size = New System.Drawing.Size(181, 99)
        Me.Panel18.TabIndex = 199
        '
        'lblCountHired
        '
        Me.lblCountHired.AutoSize = True
        Me.lblCountHired.Font = New System.Drawing.Font("Microsoft YaHei UI", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCountHired.ForeColor = System.Drawing.Color.Navy
        Me.lblCountHired.Location = New System.Drawing.Point(70, 40)
        Me.lblCountHired.Name = "lblCountHired"
        Me.lblCountHired.Size = New System.Drawing.Size(32, 36)
        Me.lblCountHired.TabIndex = 163
        Me.lblCountHired.Text = "0"
        '
        'Button7
        '
        Me.Button7.BackColor = System.Drawing.Color.DarkBlue
        Me.Button7.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.Button7.Dock = System.Windows.Forms.DockStyle.Top
        Me.Button7.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button7.Font = New System.Drawing.Font("Microsoft YaHei UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button7.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.Button7.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button7.Location = New System.Drawing.Point(0, 0)
        Me.Button7.Name = "Button7"
        Me.Button7.Size = New System.Drawing.Size(179, 37)
        Me.Button7.TabIndex = 179
        Me.Button7.Text = "Hired"
        Me.Button7.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.Button7.UseVisualStyleBackColor = False
        '
        'Panel5
        '
        Me.Panel5.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel5.Controls.Add(Me.lblCountBackout)
        Me.Panel5.Controls.Add(Me.Button9)
        Me.Panel5.Location = New System.Drawing.Point(985, 222)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(181, 99)
        Me.Panel5.TabIndex = 205
        '
        'lblCountBackout
        '
        Me.lblCountBackout.AutoSize = True
        Me.lblCountBackout.Font = New System.Drawing.Font("Microsoft YaHei UI", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCountBackout.ForeColor = System.Drawing.Color.Navy
        Me.lblCountBackout.Location = New System.Drawing.Point(73, 43)
        Me.lblCountBackout.Name = "lblCountBackout"
        Me.lblCountBackout.Size = New System.Drawing.Size(32, 36)
        Me.lblCountBackout.TabIndex = 163
        Me.lblCountBackout.Text = "0"
        '
        'Button9
        '
        Me.Button9.BackColor = System.Drawing.Color.DarkBlue
        Me.Button9.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.Button9.Dock = System.Windows.Forms.DockStyle.Top
        Me.Button9.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button9.Font = New System.Drawing.Font("Microsoft YaHei UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button9.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.Button9.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button9.Location = New System.Drawing.Point(0, 0)
        Me.Button9.Name = "Button9"
        Me.Button9.Size = New System.Drawing.Size(179, 37)
        Me.Button9.TabIndex = 179
        Me.Button9.Text = "Backout"
        Me.Button9.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.Button9.UseVisualStyleBackColor = False
        '
        'lvLocations
        '
        Me.lvLocations.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lvLocations.HideSelection = False
        Me.lvLocations.Location = New System.Drawing.Point(611, 433)
        Me.lvLocations.Name = "lvLocations"
        Me.lvLocations.Size = New System.Drawing.Size(369, 323)
        Me.lvLocations.TabIndex = 208
        Me.lvLocations.UseCompatibleStateImageBehavior = False
        '
        'Panel2
        '
        Me.Panel2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel2.Controls.Add(Me.lblCountScreened)
        Me.Panel2.Controls.Add(Me.btnReset)
        Me.Panel2.Location = New System.Drawing.Point(611, 12)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(181, 99)
        Me.Panel2.TabIndex = 195
        '
        'lblCountScreened
        '
        Me.lblCountScreened.AutoSize = True
        Me.lblCountScreened.Font = New System.Drawing.Font("Microsoft YaHei UI", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCountScreened.ForeColor = System.Drawing.Color.Navy
        Me.lblCountScreened.Location = New System.Drawing.Point(71, 42)
        Me.lblCountScreened.Name = "lblCountScreened"
        Me.lblCountScreened.Size = New System.Drawing.Size(32, 36)
        Me.lblCountScreened.TabIndex = 163
        Me.lblCountScreened.Text = "0"
        '
        'btnReset
        '
        Me.btnReset.BackColor = System.Drawing.Color.DarkBlue
        Me.btnReset.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnReset.Dock = System.Windows.Forms.DockStyle.Top
        Me.btnReset.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnReset.Font = New System.Drawing.Font("Microsoft YaHei UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnReset.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.btnReset.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnReset.Location = New System.Drawing.Point(0, 0)
        Me.btnReset.Name = "btnReset"
        Me.btnReset.Size = New System.Drawing.Size(179, 37)
        Me.btnReset.TabIndex = 179
        Me.btnReset.Text = "Screened"
        Me.btnReset.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnReset.UseVisualStyleBackColor = False
        '
        'Panel15
        '
        Me.Panel15.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel15.Controls.Add(Me.Label8)
        Me.Panel15.Location = New System.Drawing.Point(11, 12)
        Me.Panel15.Name = "Panel15"
        Me.Panel15.Size = New System.Drawing.Size(594, 99)
        Me.Panel15.TabIndex = 194
        '
        'Label8
        '
        Me.Label8.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft YaHei UI", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.MidnightBlue
        Me.Label8.Location = New System.Drawing.Point(35, 24)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(498, 42)
        Me.Label8.TabIndex = 173
        Me.Label8.Text = "Applicant tracking Dashboard"
        '
        'Panel13
        '
        Me.Panel13.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel13.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel13.Controls.Add(Me.lblCountHRAvatar)
        Me.Panel13.Controls.Add(Me.Button2)
        Me.Panel13.Location = New System.Drawing.Point(798, 13)
        Me.Panel13.Name = "Panel13"
        Me.Panel13.Size = New System.Drawing.Size(181, 99)
        Me.Panel13.TabIndex = 196
        '
        'lblCountHRAvatar
        '
        Me.lblCountHRAvatar.AutoSize = True
        Me.lblCountHRAvatar.Font = New System.Drawing.Font("Microsoft YaHei UI", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCountHRAvatar.ForeColor = System.Drawing.Color.Navy
        Me.lblCountHRAvatar.Location = New System.Drawing.Point(72, 41)
        Me.lblCountHRAvatar.Name = "lblCountHRAvatar"
        Me.lblCountHRAvatar.Size = New System.Drawing.Size(32, 36)
        Me.lblCountHRAvatar.TabIndex = 163
        Me.lblCountHRAvatar.Text = "0"
        '
        'Button2
        '
        Me.Button2.BackColor = System.Drawing.Color.DarkBlue
        Me.Button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.Button2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button2.Font = New System.Drawing.Font("Microsoft YaHei UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button2.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.Button2.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button2.Location = New System.Drawing.Point(0, 0)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(179, 37)
        Me.Button2.TabIndex = 179
        Me.Button2.Text = "HR Avatar"
        Me.Button2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.Button2.UseVisualStyleBackColor = False
        '
        'Panel9
        '
        Me.Panel9.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel9.Controls.Add(Me.lblCountOrientation)
        Me.Panel9.Controls.Add(Me.Button5)
        Me.Panel9.Location = New System.Drawing.Point(986, 117)
        Me.Panel9.Name = "Panel9"
        Me.Panel9.Size = New System.Drawing.Size(181, 99)
        Me.Panel9.TabIndex = 201
        '
        'lblCountOrientation
        '
        Me.lblCountOrientation.AutoSize = True
        Me.lblCountOrientation.Font = New System.Drawing.Font("Microsoft YaHei UI", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCountOrientation.ForeColor = System.Drawing.Color.Navy
        Me.lblCountOrientation.Location = New System.Drawing.Point(72, 42)
        Me.lblCountOrientation.Name = "lblCountOrientation"
        Me.lblCountOrientation.Size = New System.Drawing.Size(32, 36)
        Me.lblCountOrientation.TabIndex = 163
        Me.lblCountOrientation.Text = "0"
        '
        'Button5
        '
        Me.Button5.BackColor = System.Drawing.Color.DarkBlue
        Me.Button5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.Button5.Dock = System.Windows.Forms.DockStyle.Top
        Me.Button5.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button5.Font = New System.Drawing.Font("Microsoft YaHei UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button5.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.Button5.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button5.Location = New System.Drawing.Point(0, 0)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(179, 37)
        Me.Button5.TabIndex = 179
        Me.Button5.Text = "For Orientation"
        Me.Button5.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.Button5.UseVisualStyleBackColor = False
        '
        'Panel16
        '
        Me.Panel16.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel16.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel16.Controls.Add(Me.lblCountJobOffer)
        Me.Panel16.Controls.Add(Me.Button4)
        Me.Panel16.Location = New System.Drawing.Point(1172, 12)
        Me.Panel16.Name = "Panel16"
        Me.Panel16.Size = New System.Drawing.Size(181, 99)
        Me.Panel16.TabIndex = 198
        '
        'lblCountJobOffer
        '
        Me.lblCountJobOffer.AutoSize = True
        Me.lblCountJobOffer.Font = New System.Drawing.Font("Microsoft YaHei UI", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCountJobOffer.ForeColor = System.Drawing.Color.Navy
        Me.lblCountJobOffer.Location = New System.Drawing.Point(70, 40)
        Me.lblCountJobOffer.Name = "lblCountJobOffer"
        Me.lblCountJobOffer.Size = New System.Drawing.Size(32, 36)
        Me.lblCountJobOffer.TabIndex = 163
        Me.lblCountJobOffer.Text = "0"
        '
        'Button4
        '
        Me.Button4.BackColor = System.Drawing.Color.DarkBlue
        Me.Button4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.Button4.Dock = System.Windows.Forms.DockStyle.Top
        Me.Button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button4.Font = New System.Drawing.Font("Microsoft YaHei UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button4.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.Button4.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button4.Location = New System.Drawing.Point(0, 0)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(179, 37)
        Me.Button4.TabIndex = 179
        Me.Button4.Text = "Job offer"
        Me.Button4.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.Button4.UseVisualStyleBackColor = False
        '
        'Panel3
        '
        Me.Panel3.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel3.Controls.Add(Me.lblCountDeployed)
        Me.Panel3.Controls.Add(Me.Button1)
        Me.Panel3.Location = New System.Drawing.Point(1173, 117)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(181, 99)
        Me.Panel3.TabIndex = 202
        '
        'lblCountDeployed
        '
        Me.lblCountDeployed.AutoSize = True
        Me.lblCountDeployed.Font = New System.Drawing.Font("Microsoft YaHei UI", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCountDeployed.ForeColor = System.Drawing.Color.Navy
        Me.lblCountDeployed.Location = New System.Drawing.Point(69, 42)
        Me.lblCountDeployed.Name = "lblCountDeployed"
        Me.lblCountDeployed.Size = New System.Drawing.Size(32, 36)
        Me.lblCountDeployed.TabIndex = 163
        Me.lblCountDeployed.Text = "0"
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.DarkBlue
        Me.Button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.Button1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.Font = New System.Drawing.Font("Microsoft YaHei UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.Button1.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button1.Location = New System.Drawing.Point(0, 0)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(179, 37)
        Me.Button1.TabIndex = 179
        Me.Button1.Text = "Deployed"
        Me.Button1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.Button1.UseVisualStyleBackColor = False
        '
        'Panel14
        '
        Me.Panel14.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel14.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel14.Controls.Add(Me.lblCountFinalInterview)
        Me.Panel14.Controls.Add(Me.Button3)
        Me.Panel14.Location = New System.Drawing.Point(985, 12)
        Me.Panel14.Name = "Panel14"
        Me.Panel14.Size = New System.Drawing.Size(181, 99)
        Me.Panel14.TabIndex = 197
        '
        'lblCountFinalInterview
        '
        Me.lblCountFinalInterview.AutoSize = True
        Me.lblCountFinalInterview.Font = New System.Drawing.Font("Microsoft YaHei UI", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCountFinalInterview.ForeColor = System.Drawing.Color.Navy
        Me.lblCountFinalInterview.Location = New System.Drawing.Point(73, 42)
        Me.lblCountFinalInterview.Name = "lblCountFinalInterview"
        Me.lblCountFinalInterview.Size = New System.Drawing.Size(32, 36)
        Me.lblCountFinalInterview.TabIndex = 163
        Me.lblCountFinalInterview.Text = "0"
        '
        'Button3
        '
        Me.Button3.BackColor = System.Drawing.Color.DarkBlue
        Me.Button3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.Button3.Dock = System.Windows.Forms.DockStyle.Top
        Me.Button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button3.Font = New System.Drawing.Font("Microsoft YaHei UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button3.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.Button3.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button3.Location = New System.Drawing.Point(0, 0)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(179, 37)
        Me.Button3.TabIndex = 179
        Me.Button3.Text = "Final Interview"
        Me.Button3.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.Button3.UseVisualStyleBackColor = False
        '
        'Timer1
        '
        Me.Timer1.Enabled = True
        Me.Timer1.Interval = 1000
        '
        'frmHome
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.ClientSize = New System.Drawing.Size(1366, 768)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmHome"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "frmHome"
        Me.Panel1.ResumeLayout(False)
        Me.Panel19.ResumeLayout(False)
        Me.Panel19.PerformLayout()
        Me.Panel12.ResumeLayout(False)
        Me.Panel12.PerformLayout()
        Me.Panel20.ResumeLayout(False)
        Me.Panel20.PerformLayout()
        Me.Panel11.ResumeLayout(False)
        Me.Panel11.PerformLayout()
        Me.Panel7.ResumeLayout(False)
        CType(Me.dgvApplicants, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel10.ResumeLayout(False)
        Me.Panel10.PerformLayout()
        Me.Panel6.ResumeLayout(False)
        Me.Panel6.PerformLayout()
        Me.Panel17.ResumeLayout(False)
        Me.Panel17.PerformLayout()
        Me.Panel4.ResumeLayout(False)
        Me.Panel4.PerformLayout()
        Me.Panel8.ResumeLayout(False)
        Me.Panel8.PerformLayout()
        Me.Panel18.ResumeLayout(False)
        Me.Panel18.PerformLayout()
        Me.Panel5.ResumeLayout(False)
        Me.Panel5.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.Panel15.ResumeLayout(False)
        Me.Panel15.PerformLayout()
        Me.Panel13.ResumeLayout(False)
        Me.Panel13.PerformLayout()
        Me.Panel9.ResumeLayout(False)
        Me.Panel9.PerformLayout()
        Me.Panel16.ResumeLayout(False)
        Me.Panel16.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.Panel14.ResumeLayout(False)
        Me.Panel14.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents lvPositions As ListView
    Friend WithEvents Panel6 As Panel
    Friend WithEvents lblCountPooling As Label
    Friend WithEvents Button10 As Button
    Friend WithEvents Panel17 As Panel
    Friend WithEvents lblCountOngoing As Label
    Friend WithEvents Button6 As Button
    Friend WithEvents Panel4 As Panel
    Friend WithEvents lblCountInactive As Label
    Friend WithEvents Button8 As Button
    Friend WithEvents Panel8 As Panel
    Friend WithEvents lblCountRejected As Label
    Friend WithEvents Button11 As Button
    Friend WithEvents Panel18 As Panel
    Friend WithEvents lblCountHired As Label
    Friend WithEvents Button7 As Button
    Friend WithEvents Panel5 As Panel
    Friend WithEvents lblCountBackout As Label
    Friend WithEvents Button9 As Button
    Friend WithEvents lvLocations As ListView
    Friend WithEvents Panel2 As Panel
    Friend WithEvents lblCountScreened As Label
    Friend WithEvents btnReset As Button
    Friend WithEvents Panel15 As Panel
    Friend WithEvents Label8 As Label
    Friend WithEvents Panel13 As Panel
    Friend WithEvents lblCountHRAvatar As Label
    Friend WithEvents Button2 As Button
    Friend WithEvents Panel9 As Panel
    Friend WithEvents lblCountOrientation As Label
    Friend WithEvents Button5 As Button
    Friend WithEvents Panel16 As Panel
    Friend WithEvents lblCountJobOffer As Label
    Friend WithEvents Button4 As Button
    Friend WithEvents Panel3 As Panel
    Friend WithEvents lblCountDeployed As Label
    Friend WithEvents Button1 As Button
    Friend WithEvents Panel14 As Panel
    Friend WithEvents lblCountFinalInterview As Label
    Friend WithEvents Button3 As Button
    Friend WithEvents Timer1 As Timer
    Friend WithEvents Panel7 As Panel
    Friend WithEvents btnRefresh As Button
    Friend WithEvents Button13 As Button
    Friend WithEvents Panel10 As Panel
    Friend WithEvents txtSearchApplicant As TextBox
    Friend WithEvents Panel12 As Panel
    Friend WithEvents lblTotalLocationSlots As Label
    Friend WithEvents Button14 As Button
    Friend WithEvents Panel11 As Panel
    Friend WithEvents lblTotalPositionSlots As Label
    Friend WithEvents Button12 As Button
    Friend WithEvents Panel19 As Panel
    Friend WithEvents lblTotalLocationHired As Label
    Friend WithEvents Button15 As Button
    Friend WithEvents Panel20 As Panel
    Friend WithEvents lblTotalPositionHired As Label
    Friend WithEvents Button16 As Button
    Friend WithEvents dgvApplicants As DataGridView
End Class
