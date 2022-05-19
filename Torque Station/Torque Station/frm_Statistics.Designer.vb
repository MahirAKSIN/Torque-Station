<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_Statistics
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_Statistics))
        Me.cmb_processResult = New System.Windows.Forms.ComboBox()
        Me.lbl_process = New System.Windows.Forms.Label()
        Me.lbl_date1 = New System.Windows.Forms.Label()
        Me.dtp_StartDate = New System.Windows.Forms.DateTimePicker()
        Me.grd_Statistics = New System.Windows.Forms.DataGridView()
        Me.save_Fd = New System.Windows.Forms.SaveFileDialog()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btn_Exit = New System.Windows.Forms.Button()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.btn_Reset = New System.Windows.Forms.Button()
        Me.btn_ExportStatistics = New System.Windows.Forms.Button()
        Me.btn_Filter = New System.Windows.Forms.Button()
        Me.cmb_OperatorId = New System.Windows.Forms.ComboBox()
        Me.lbl_OperatorID = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.dtp_EndDate = New System.Windows.Forms.DateTimePicker()
        CType(Me.grd_Statistics, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cmb_processResult
        '
        Me.cmb_processResult.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmb_processResult.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(162, Byte))
        Me.cmb_processResult.FormattingEnabled = True
        Me.cmb_processResult.Location = New System.Drawing.Point(214, 97)
        Me.cmb_processResult.Margin = New System.Windows.Forms.Padding(4)
        Me.cmb_processResult.Name = "cmb_processResult"
        Me.cmb_processResult.Size = New System.Drawing.Size(210, 33)
        Me.cmb_processResult.TabIndex = 44
        '
        'lbl_process
        '
        Me.lbl_process.AutoSize = True
        Me.lbl_process.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(162, Byte))
        Me.lbl_process.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lbl_process.Location = New System.Drawing.Point(29, 102)
        Me.lbl_process.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lbl_process.Name = "lbl_process"
        Me.lbl_process.Size = New System.Drawing.Size(123, 20)
        Me.lbl_process.TabIndex = 43
        Me.lbl_process.Tag = "lbl"
        Me.lbl_process.Text = "Filter results:"
        '
        'lbl_date1
        '
        Me.lbl_date1.AutoSize = True
        Me.lbl_date1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(162, Byte))
        Me.lbl_date1.ForeColor = System.Drawing.Color.Black
        Me.lbl_date1.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lbl_date1.Location = New System.Drawing.Point(29, 20)
        Me.lbl_date1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lbl_date1.Name = "lbl_date1"
        Me.lbl_date1.Size = New System.Drawing.Size(102, 20)
        Me.lbl_date1.TabIndex = 46
        Me.lbl_date1.Tag = "lbl"
        Me.lbl_date1.Text = "Start Date:"
        '
        'dtp_StartDate
        '
        Me.dtp_StartDate.CustomFormat = "dd/MM/yy"
        Me.dtp_StartDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(162, Byte))
        Me.dtp_StartDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtp_StartDate.Location = New System.Drawing.Point(214, 8)
        Me.dtp_StartDate.Margin = New System.Windows.Forms.Padding(4)
        Me.dtp_StartDate.Name = "dtp_StartDate"
        Me.dtp_StartDate.Size = New System.Drawing.Size(210, 34)
        Me.dtp_StartDate.TabIndex = 45
        '
        'grd_Statistics
        '
        Me.grd_Statistics.AllowUserToAddRows = False
        Me.grd_Statistics.AllowUserToDeleteRows = False
        Me.grd_Statistics.AllowUserToResizeColumns = False
        Me.grd_Statistics.AllowUserToResizeRows = False
        Me.grd_Statistics.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grd_Statistics.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.grd_Statistics.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight
        Me.grd_Statistics.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grd_Statistics.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.grd_Statistics.Location = New System.Drawing.Point(33, 225)
        Me.grd_Statistics.MultiSelect = False
        Me.grd_Statistics.Name = "grd_Statistics"
        Me.grd_Statistics.RowTemplate.Height = 24
        Me.grd_Statistics.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.grd_Statistics.Size = New System.Drawing.Size(958, 326)
        Me.grd_Statistics.TabIndex = 80
        '
        'Label1
        '
        Me.Label1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(162, Byte))
        Me.Label1.Location = New System.Drawing.Point(917, 84)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(41, 20)
        Me.Label1.TabIndex = 88
        Me.Label1.Tag = "lbl"
        Me.Label1.Text = "Exit"
        '
        'btn_Exit
        '
        Me.btn_Exit.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn_Exit.BackgroundImage = CType(resources.GetObject("btn_Exit.BackgroundImage"), System.Drawing.Image)
        Me.btn_Exit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btn_Exit.FlatAppearance.BorderSize = 0
        Me.btn_Exit.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_Exit.Location = New System.Drawing.Point(913, 20)
        Me.btn_Exit.Margin = New System.Windows.Forms.Padding(4)
        Me.btn_Exit.Name = "btn_Exit"
        Me.btn_Exit.Size = New System.Drawing.Size(60, 60)
        Me.btn_Exit.TabIndex = 87
        Me.btn_Exit.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(162, Byte))
        Me.Label6.Location = New System.Drawing.Point(769, 84)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(103, 20)
        Me.Label6.TabIndex = 86
        Me.Label6.Tag = "lbl"
        Me.Label6.Text = "Reset filter"
        '
        'Label5
        '
        Me.Label5.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(162, Byte))
        Me.Label5.Location = New System.Drawing.Point(671, 84)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(63, 20)
        Me.Label5.TabIndex = 84
        Me.Label5.Tag = "lbl"
        Me.Label5.Text = "Export"
        '
        'Label4
        '
        Me.Label4.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(162, Byte))
        Me.Label4.Location = New System.Drawing.Point(590, 84)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(53, 20)
        Me.Label4.TabIndex = 83
        Me.Label4.Tag = "lbl"
        Me.Label4.Text = "Filter"
        '
        'btn_Reset
        '
        Me.btn_Reset.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn_Reset.BackgroundImage = CType(resources.GetObject("btn_Reset.BackgroundImage"), System.Drawing.Image)
        Me.btn_Reset.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btn_Reset.FlatAppearance.BorderSize = 0
        Me.btn_Reset.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_Reset.Location = New System.Drawing.Point(791, 20)
        Me.btn_Reset.Margin = New System.Windows.Forms.Padding(4)
        Me.btn_Reset.Name = "btn_Reset"
        Me.btn_Reset.Size = New System.Drawing.Size(60, 60)
        Me.btn_Reset.TabIndex = 82
        Me.btn_Reset.UseVisualStyleBackColor = True
        '
        'btn_ExportStatistics
        '
        Me.btn_ExportStatistics.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn_ExportStatistics.BackgroundImage = CType(resources.GetObject("btn_ExportStatistics.BackgroundImage"), System.Drawing.Image)
        Me.btn_ExportStatistics.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btn_ExportStatistics.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btn_ExportStatistics.FlatAppearance.BorderSize = 0
        Me.btn_ExportStatistics.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.btn_ExportStatistics.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_ExportStatistics.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btn_ExportStatistics.Location = New System.Drawing.Point(674, 20)
        Me.btn_ExportStatistics.Margin = New System.Windows.Forms.Padding(4)
        Me.btn_ExportStatistics.Name = "btn_ExportStatistics"
        Me.btn_ExportStatistics.Size = New System.Drawing.Size(60, 60)
        Me.btn_ExportStatistics.TabIndex = 85
        Me.btn_ExportStatistics.UseVisualStyleBackColor = True
        '
        'btn_Filter
        '
        Me.btn_Filter.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn_Filter.BackgroundImage = CType(resources.GetObject("btn_Filter.BackgroundImage"), System.Drawing.Image)
        Me.btn_Filter.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btn_Filter.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btn_Filter.FlatAppearance.BorderSize = 0
        Me.btn_Filter.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.btn_Filter.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_Filter.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.btn_Filter.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btn_Filter.Location = New System.Drawing.Point(590, 20)
        Me.btn_Filter.Margin = New System.Windows.Forms.Padding(4)
        Me.btn_Filter.Name = "btn_Filter"
        Me.btn_Filter.Size = New System.Drawing.Size(60, 60)
        Me.btn_Filter.TabIndex = 81
        Me.btn_Filter.UseVisualStyleBackColor = True
        '
        'cmb_OperatorId
        '
        Me.cmb_OperatorId.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmb_OperatorId.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(162, Byte))
        Me.cmb_OperatorId.FormattingEnabled = True
        Me.cmb_OperatorId.Location = New System.Drawing.Point(214, 134)
        Me.cmb_OperatorId.Margin = New System.Windows.Forms.Padding(4)
        Me.cmb_OperatorId.Name = "cmb_OperatorId"
        Me.cmb_OperatorId.Size = New System.Drawing.Size(210, 33)
        Me.cmb_OperatorId.TabIndex = 90
        '
        'lbl_OperatorID
        '
        Me.lbl_OperatorID.AutoSize = True
        Me.lbl_OperatorID.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(162, Byte))
        Me.lbl_OperatorID.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lbl_OperatorID.Location = New System.Drawing.Point(29, 149)
        Me.lbl_OperatorID.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lbl_OperatorID.Name = "lbl_OperatorID"
        Me.lbl_OperatorID.Size = New System.Drawing.Size(120, 20)
        Me.lbl_OperatorID.TabIndex = 89
        Me.lbl_OperatorID.Tag = "lbl"
        Me.lbl_OperatorID.Text = "Operator ID :"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(162, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label2.Location = New System.Drawing.Point(29, 62)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(93, 20)
        Me.Label2.TabIndex = 92
        Me.Label2.Tag = "lbl"
        Me.Label2.Text = "End Date:"
        '
        'dtp_EndDate
        '
        Me.dtp_EndDate.CustomFormat = "dd/MM/yy"
        Me.dtp_EndDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(162, Byte))
        Me.dtp_EndDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtp_EndDate.Location = New System.Drawing.Point(214, 50)
        Me.dtp_EndDate.Margin = New System.Windows.Forms.Padding(4)
        Me.dtp_EndDate.Name = "dtp_EndDate"
        Me.dtp_EndDate.Size = New System.Drawing.Size(210, 34)
        Me.dtp_EndDate.TabIndex = 91
        '
        'frm_Statistics
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1037, 563)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.dtp_EndDate)
        Me.Controls.Add(Me.cmb_OperatorId)
        Me.Controls.Add(Me.lbl_OperatorID)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btn_Exit)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.btn_Reset)
        Me.Controls.Add(Me.btn_ExportStatistics)
        Me.Controls.Add(Me.btn_Filter)
        Me.Controls.Add(Me.grd_Statistics)
        Me.Controls.Add(Me.lbl_date1)
        Me.Controls.Add(Me.dtp_StartDate)
        Me.Controls.Add(Me.cmb_processResult)
        Me.Controls.Add(Me.lbl_process)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "frm_Statistics"
        Me.Text = "Elopar Torque Station - Statistics"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.grd_Statistics, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cmb_processResult As ComboBox
    Friend WithEvents lbl_process As Label
    Friend WithEvents lbl_date1 As Label
    Friend WithEvents dtp_StartDate As DateTimePicker
    Friend WithEvents grd_Statistics As DataGridView
    Friend WithEvents save_Fd As SaveFileDialog
    Friend WithEvents Label1 As Label
    Friend WithEvents btn_Exit As Button
    Friend WithEvents Label6 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents btn_Reset As Button
    Friend WithEvents btn_ExportStatistics As Button
    Friend WithEvents btn_Filter As Button
    Friend WithEvents cmb_OperatorId As ComboBox
    Friend WithEvents lbl_OperatorID As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents dtp_EndDate As DateTimePicker
End Class
