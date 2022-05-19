<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frm_ProcessSetup
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_ProcessSetup))
        Me.pb_Socket = New System.Windows.Forms.PictureBox()
        Me.NumericUpDown1 = New System.Windows.Forms.NumericUpDown()
        Me.tab_Main = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.grp_IODefinitions = New System.Windows.Forms.GroupBox()
        Me.cmb_Type = New System.Windows.Forms.ComboBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.txt_Device = New System.Windows.Forms.TextBox()
        Me.grd_PLCIO = New System.Windows.Forms.DataGridView()
        Me.btn_SaveIO = New System.Windows.Forms.Button()
        Me.txt_Address = New System.Windows.Forms.TextBox()
        Me.btn_DeleteIO = New System.Windows.Forms.Button()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.btn_EditIO = New System.Windows.Forms.Button()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.btn_NewIO = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.btn_SaveJob = New System.Windows.Forms.Button()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.btn_DeleteJob = New System.Windows.Forms.Button()
        Me.txt_MaxAngle = New System.Windows.Forms.TextBox()
        Me.btn_EditJob = New System.Windows.Forms.Button()
        Me.txt_JobDesc = New System.Windows.Forms.TextBox()
        Me.btn_NewJob = New System.Windows.Forms.Button()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.grd_JobDescription = New System.Windows.Forms.DataGridView()
        Me.txt_MinAngle = New System.Windows.Forms.TextBox()
        Me.txt_JobNo = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txt_MaxTorque = New System.Windows.Forms.TextBox()
        Me.txt_MinTorque = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.txt_issue = New System.Windows.Forms.TextBox()
        Me.Label28 = New System.Windows.Forms.Label()
        Me.cmb_Variant = New System.Windows.Forms.ComboBox()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.btn_DeleteMaster = New System.Windows.Forms.Button()
        Me.btn_AddMaster = New System.Windows.Forms.Button()
        Me.cmb_Master = New System.Windows.Forms.ComboBox()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.btn_DeleteVariant = New System.Windows.Forms.Button()
        Me.btn_AddVariant = New System.Windows.Forms.Button()
        Me.txt_MasterName = New System.Windows.Forms.TextBox()
        Me.txt_VariantName = New System.Windows.Forms.TextBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.btn_SelectPicture = New System.Windows.Forms.Button()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.pb_Layout = New System.Windows.Forms.PictureBox()
        Me.TabPage3 = New System.Windows.Forms.TabPage()
        Me.Label29 = New System.Windows.Forms.Label()
        Me.txt_issueP = New System.Windows.Forms.TextBox()
        Me.cmb_SelectVariant = New System.Windows.Forms.ComboBox()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.txt_NutPos = New System.Windows.Forms.TextBox()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.btn_SaveNut = New System.Windows.Forms.Button()
        Me.btn_DeleteNut = New System.Windows.Forms.Button()
        Me.btn_AddNut = New System.Windows.Forms.Button()
        Me.cmb_JobNo = New System.Windows.Forms.ComboBox()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.cmb_ScrewOrder = New System.Windows.Forms.ComboBox()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.cmb_NutType = New System.Windows.Forms.ComboBox()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.txt_ScrewPos = New System.Windows.Forms.TextBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.grd_ProcessDesc = New System.Windows.Forms.DataGridView()
        Me.tmr_Indicator = New System.Windows.Forms.Timer(Me.components)
        Me.openFileDialog = New System.Windows.Forms.OpenFileDialog()
        CType(Me.pb_Socket,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.NumericUpDown1,System.ComponentModel.ISupportInitialize).BeginInit
        Me.tab_Main.SuspendLayout
        Me.TabPage1.SuspendLayout
        Me.grp_IODefinitions.SuspendLayout
        CType(Me.grd_PLCIO,System.ComponentModel.ISupportInitialize).BeginInit
        Me.GroupBox1.SuspendLayout
        CType(Me.grd_JobDescription,System.ComponentModel.ISupportInitialize).BeginInit
        Me.TabPage2.SuspendLayout
        CType(Me.pb_Layout,System.ComponentModel.ISupportInitialize).BeginInit
        Me.TabPage3.SuspendLayout
        CType(Me.grd_ProcessDesc,System.ComponentModel.ISupportInitialize).BeginInit
        Me.SuspendLayout
        '
        'pb_Socket
        '
        Me.pb_Socket.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom)  _
            Or System.Windows.Forms.AnchorStyles.Left)  _
            Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
        Me.pb_Socket.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pb_Socket.Location = New System.Drawing.Point(194, 5)
        Me.pb_Socket.Margin = New System.Windows.Forms.Padding(2)
        Me.pb_Socket.Name = "pb_Socket"
        Me.pb_Socket.Size = New System.Drawing.Size(588, 382)
        Me.pb_Socket.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pb_Socket.TabIndex = 0
        Me.pb_Socket.TabStop = false
        '
        'NumericUpDown1
        '
        Me.NumericUpDown1.Location = New System.Drawing.Point(14, 41)
        Me.NumericUpDown1.Margin = New System.Windows.Forms.Padding(2)
        Me.NumericUpDown1.Minimum = New Decimal(New Integer() {10, 0, 0, 0})
        Me.NumericUpDown1.Name = "NumericUpDown1"
        Me.NumericUpDown1.Size = New System.Drawing.Size(151, 26)
        Me.NumericUpDown1.TabIndex = 3
        Me.NumericUpDown1.Value = New Decimal(New Integer() {15, 0, 0, 0})
        '
        'tab_Main
        '
        Me.tab_Main.Controls.Add(Me.TabPage1)
        Me.tab_Main.Controls.Add(Me.TabPage2)
        Me.tab_Main.Controls.Add(Me.TabPage3)
        Me.tab_Main.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tab_Main.Font = New System.Drawing.Font("Microsoft Sans Serif", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(162,Byte))
        Me.tab_Main.Location = New System.Drawing.Point(0, 0)
        Me.tab_Main.Margin = New System.Windows.Forms.Padding(2)
        Me.tab_Main.Name = "tab_Main"
        Me.tab_Main.SelectedIndex = 0
        Me.tab_Main.Size = New System.Drawing.Size(793, 610)
        Me.tab_Main.TabIndex = 11
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.grp_IODefinitions)
        Me.TabPage1.Controls.Add(Me.GroupBox1)
        Me.TabPage1.Location = New System.Drawing.Point(4, 29)
        Me.TabPage1.Margin = New System.Windows.Forms.Padding(2)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(2)
        Me.TabPage1.Size = New System.Drawing.Size(785, 577)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "IOs & Job Description"
        Me.TabPage1.UseVisualStyleBackColor = true
        '
        'grp_IODefinitions
        '
        Me.grp_IODefinitions.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left)  _
            Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
        Me.grp_IODefinitions.Controls.Add(Me.cmb_Type)
        Me.grp_IODefinitions.Controls.Add(Me.Label13)
        Me.grp_IODefinitions.Controls.Add(Me.txt_Device)
        Me.grp_IODefinitions.Controls.Add(Me.grd_PLCIO)
        Me.grp_IODefinitions.Controls.Add(Me.btn_SaveIO)
        Me.grp_IODefinitions.Controls.Add(Me.txt_Address)
        Me.grp_IODefinitions.Controls.Add(Me.btn_DeleteIO)
        Me.grp_IODefinitions.Controls.Add(Me.Label14)
        Me.grp_IODefinitions.Controls.Add(Me.btn_EditIO)
        Me.grp_IODefinitions.Controls.Add(Me.Label15)
        Me.grp_IODefinitions.Controls.Add(Me.btn_NewIO)
        Me.grp_IODefinitions.Font = New System.Drawing.Font("Microsoft Sans Serif", 12!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(162,Byte))
        Me.grp_IODefinitions.Location = New System.Drawing.Point(14, 5)
        Me.grp_IODefinitions.Margin = New System.Windows.Forms.Padding(2)
        Me.grp_IODefinitions.Name = "grp_IODefinitions"
        Me.grp_IODefinitions.Padding = New System.Windows.Forms.Padding(2)
        Me.grp_IODefinitions.Size = New System.Drawing.Size(764, 189)
        Me.grp_IODefinitions.TabIndex = 35
        Me.grp_IODefinitions.TabStop = false
        Me.grp_IODefinitions.Text = "IO Definitions"
        '
        'cmb_Type
        '
        Me.cmb_Type.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmb_Type.FormattingEnabled = true
        Me.cmb_Type.Location = New System.Drawing.Point(8, 93)
        Me.cmb_Type.Margin = New System.Windows.Forms.Padding(2)
        Me.cmb_Type.Name = "cmb_Type"
        Me.cmb_Type.Size = New System.Drawing.Size(161, 28)
        Me.cmb_Type.TabIndex = 45
        '
        'Label13
        '
        Me.Label13.AutoSize = true
        Me.Label13.Location = New System.Drawing.Point(4, 21)
        Me.Label13.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(63, 20)
        Me.Label13.TabIndex = 39
        Me.Label13.Text = "Device"
        '
        'txt_Device
        '
        Me.txt_Device.Location = New System.Drawing.Point(8, 44)
        Me.txt_Device.Margin = New System.Windows.Forms.Padding(2)
        Me.txt_Device.MaxLength = 14
        Me.txt_Device.Name = "txt_Device"
        Me.txt_Device.Size = New System.Drawing.Size(161, 26)
        Me.txt_Device.TabIndex = 40
        '
        'grd_PLCIO
        '
        Me.grd_PLCIO.AllowUserToAddRows = false
        Me.grd_PLCIO.AllowUserToDeleteRows = false
        Me.grd_PLCIO.AllowUserToResizeColumns = false
        Me.grd_PLCIO.AllowUserToResizeRows = false
        Me.grd_PLCIO.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left)  _
            Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
        Me.grd_PLCIO.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.grd_PLCIO.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grd_PLCIO.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.grd_PLCIO.Location = New System.Drawing.Point(186, 14)
        Me.grd_PLCIO.Margin = New System.Windows.Forms.Padding(2)
        Me.grd_PLCIO.MultiSelect = false
        Me.grd_PLCIO.Name = "grd_PLCIO"
        Me.grd_PLCIO.RowTemplate.Height = 24
        Me.grd_PLCIO.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.grd_PLCIO.Size = New System.Drawing.Size(574, 117)
        Me.grd_PLCIO.TabIndex = 0
        '
        'btn_SaveIO
        '
        Me.btn_SaveIO.Location = New System.Drawing.Point(440, 137)
        Me.btn_SaveIO.Margin = New System.Windows.Forms.Padding(2)
        Me.btn_SaveIO.Name = "btn_SaveIO"
        Me.btn_SaveIO.Size = New System.Drawing.Size(78, 36)
        Me.btn_SaveIO.TabIndex = 4
        Me.btn_SaveIO.Text = "Save"
        Me.btn_SaveIO.UseVisualStyleBackColor = true
        '
        'txt_Address
        '
        Me.txt_Address.Location = New System.Drawing.Point(8, 143)
        Me.txt_Address.Margin = New System.Windows.Forms.Padding(2)
        Me.txt_Address.MaxLength = 9
        Me.txt_Address.Name = "txt_Address"
        Me.txt_Address.Size = New System.Drawing.Size(161, 26)
        Me.txt_Address.TabIndex = 44
        '
        'btn_DeleteIO
        '
        Me.btn_DeleteIO.Location = New System.Drawing.Point(326, 137)
        Me.btn_DeleteIO.Margin = New System.Windows.Forms.Padding(2)
        Me.btn_DeleteIO.Name = "btn_DeleteIO"
        Me.btn_DeleteIO.Size = New System.Drawing.Size(90, 36)
        Me.btn_DeleteIO.TabIndex = 3
        Me.btn_DeleteIO.Text = "Delete"
        Me.btn_DeleteIO.UseVisualStyleBackColor = true
        '
        'Label14
        '
        Me.Label14.AutoSize = true
        Me.Label14.Location = New System.Drawing.Point(4, 71)
        Me.Label14.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(47, 20)
        Me.Label14.TabIndex = 41
        Me.Label14.Text = "Type"
        '
        'btn_EditIO
        '
        Me.btn_EditIO.Location = New System.Drawing.Point(247, 137)
        Me.btn_EditIO.Margin = New System.Windows.Forms.Padding(2)
        Me.btn_EditIO.Name = "btn_EditIO"
        Me.btn_EditIO.Size = New System.Drawing.Size(56, 36)
        Me.btn_EditIO.TabIndex = 2
        Me.btn_EditIO.Text = "Edit"
        Me.btn_EditIO.UseVisualStyleBackColor = true
        '
        'Label15
        '
        Me.Label15.AutoSize = true
        Me.Label15.Location = New System.Drawing.Point(4, 120)
        Me.Label15.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(75, 20)
        Me.Label15.TabIndex = 43
        Me.Label15.Text = "Address"
        '
        'btn_NewIO
        '
        Me.btn_NewIO.Location = New System.Drawing.Point(186, 137)
        Me.btn_NewIO.Margin = New System.Windows.Forms.Padding(2)
        Me.btn_NewIO.Name = "btn_NewIO"
        Me.btn_NewIO.Size = New System.Drawing.Size(56, 36)
        Me.btn_NewIO.TabIndex = 1
        Me.btn_NewIO.Text = "New"
        Me.btn_NewIO.UseVisualStyleBackColor = true
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom)  _
            Or System.Windows.Forms.AnchorStyles.Left)  _
            Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.btn_SaveJob)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.btn_DeleteJob)
        Me.GroupBox1.Controls.Add(Me.txt_MaxAngle)
        Me.GroupBox1.Controls.Add(Me.btn_EditJob)
        Me.GroupBox1.Controls.Add(Me.txt_JobDesc)
        Me.GroupBox1.Controls.Add(Me.btn_NewJob)
        Me.GroupBox1.Controls.Add(Me.Label11)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.grd_JobDescription)
        Me.GroupBox1.Controls.Add(Me.txt_MinAngle)
        Me.GroupBox1.Controls.Add(Me.txt_JobNo)
        Me.GroupBox1.Controls.Add(Me.Label12)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.txt_MaxTorque)
        Me.GroupBox1.Controls.Add(Me.txt_MinTorque)
        Me.GroupBox1.Controls.Add(Me.Label10)
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(162,Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(14, 199)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(2)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(2)
        Me.GroupBox1.Size = New System.Drawing.Size(769, 366)
        Me.GroupBox1.TabIndex = 34
        Me.GroupBox1.TabStop = false
        Me.GroupBox1.Text = "Job Description"
        '
        'btn_SaveJob
        '
        Me.btn_SaveJob.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left),System.Windows.Forms.AnchorStyles)
        Me.btn_SaveJob.Location = New System.Drawing.Point(440, 308)
        Me.btn_SaveJob.Margin = New System.Windows.Forms.Padding(2)
        Me.btn_SaveJob.Name = "btn_SaveJob"
        Me.btn_SaveJob.Size = New System.Drawing.Size(78, 40)
        Me.btn_SaveJob.TabIndex = 38
        Me.btn_SaveJob.Text = "Save"
        Me.btn_SaveJob.UseVisualStyleBackColor = true
        '
        'Label7
        '
        Me.Label7.AutoSize = true
        Me.Label7.Location = New System.Drawing.Point(4, 29)
        Me.Label7.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(134, 20)
        Me.Label7.TabIndex = 22
        Me.Label7.Text = "Job Description"
        '
        'btn_DeleteJob
        '
        Me.btn_DeleteJob.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left),System.Windows.Forms.AnchorStyles)
        Me.btn_DeleteJob.Location = New System.Drawing.Point(326, 308)
        Me.btn_DeleteJob.Margin = New System.Windows.Forms.Padding(2)
        Me.btn_DeleteJob.Name = "btn_DeleteJob"
        Me.btn_DeleteJob.Size = New System.Drawing.Size(90, 40)
        Me.btn_DeleteJob.TabIndex = 37
        Me.btn_DeleteJob.Text = "Delete"
        Me.btn_DeleteJob.UseVisualStyleBackColor = true
        '
        'txt_MaxAngle
        '
        Me.txt_MaxAngle.Location = New System.Drawing.Point(8, 308)
        Me.txt_MaxAngle.Margin = New System.Windows.Forms.Padding(2)
        Me.txt_MaxAngle.MaxLength = 14
        Me.txt_MaxAngle.Name = "txt_MaxAngle"
        Me.txt_MaxAngle.Size = New System.Drawing.Size(161, 26)
        Me.txt_MaxAngle.TabIndex = 33
        '
        'btn_EditJob
        '
        Me.btn_EditJob.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left),System.Windows.Forms.AnchorStyles)
        Me.btn_EditJob.Location = New System.Drawing.Point(247, 308)
        Me.btn_EditJob.Margin = New System.Windows.Forms.Padding(2)
        Me.btn_EditJob.Name = "btn_EditJob"
        Me.btn_EditJob.Size = New System.Drawing.Size(56, 40)
        Me.btn_EditJob.TabIndex = 36
        Me.btn_EditJob.Text = "Edit"
        Me.btn_EditJob.UseVisualStyleBackColor = true
        '
        'txt_JobDesc
        '
        Me.txt_JobDesc.Location = New System.Drawing.Point(8, 52)
        Me.txt_JobDesc.Margin = New System.Windows.Forms.Padding(2)
        Me.txt_JobDesc.MaxLength = 14
        Me.txt_JobDesc.Name = "txt_JobDesc"
        Me.txt_JobDesc.Size = New System.Drawing.Size(161, 26)
        Me.txt_JobDesc.TabIndex = 23
        '
        'btn_NewJob
        '
        Me.btn_NewJob.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left),System.Windows.Forms.AnchorStyles)
        Me.btn_NewJob.Location = New System.Drawing.Point(186, 308)
        Me.btn_NewJob.Margin = New System.Windows.Forms.Padding(2)
        Me.btn_NewJob.Name = "btn_NewJob"
        Me.btn_NewJob.Size = New System.Drawing.Size(56, 40)
        Me.btn_NewJob.TabIndex = 35
        Me.btn_NewJob.Text = "New"
        Me.btn_NewJob.UseVisualStyleBackColor = true
        '
        'Label11
        '
        Me.Label11.AutoSize = true
        Me.Label11.Location = New System.Drawing.Point(4, 285)
        Me.Label11.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(92, 20)
        Me.Label11.TabIndex = 32
        Me.Label11.Text = "Max Angle"
        '
        'Label8
        '
        Me.Label8.AutoSize = true
        Me.Label8.Location = New System.Drawing.Point(4, 79)
        Me.Label8.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(65, 20)
        Me.Label8.TabIndex = 24
        Me.Label8.Text = "Job No"
        '
        'grd_JobDescription
        '
        Me.grd_JobDescription.AllowUserToAddRows = false
        Me.grd_JobDescription.AllowUserToDeleteRows = false
        Me.grd_JobDescription.AllowUserToResizeColumns = false
        Me.grd_JobDescription.AllowUserToResizeRows = false
        Me.grd_JobDescription.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom)  _
            Or System.Windows.Forms.AnchorStyles.Left)  _
            Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
        Me.grd_JobDescription.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.grd_JobDescription.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grd_JobDescription.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnF2
        Me.grd_JobDescription.Location = New System.Drawing.Point(186, 29)
        Me.grd_JobDescription.Margin = New System.Windows.Forms.Padding(2)
        Me.grd_JobDescription.Name = "grd_JobDescription"
        Me.grd_JobDescription.RowTemplate.Height = 24
        Me.grd_JobDescription.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.grd_JobDescription.Size = New System.Drawing.Size(578, 254)
        Me.grd_JobDescription.TabIndex = 17
        '
        'txt_MinAngle
        '
        Me.txt_MinAngle.Location = New System.Drawing.Point(8, 258)
        Me.txt_MinAngle.Margin = New System.Windows.Forms.Padding(2)
        Me.txt_MinAngle.MaxLength = 14
        Me.txt_MinAngle.Name = "txt_MinAngle"
        Me.txt_MinAngle.Size = New System.Drawing.Size(161, 26)
        Me.txt_MinAngle.TabIndex = 31
        '
        'txt_JobNo
        '
        Me.txt_JobNo.Location = New System.Drawing.Point(8, 102)
        Me.txt_JobNo.Margin = New System.Windows.Forms.Padding(2)
        Me.txt_JobNo.MaxLength = 14
        Me.txt_JobNo.Name = "txt_JobNo"
        Me.txt_JobNo.Size = New System.Drawing.Size(161, 26)
        Me.txt_JobNo.TabIndex = 25
        '
        'Label12
        '
        Me.Label12.AutoSize = true
        Me.Label12.Location = New System.Drawing.Point(4, 236)
        Me.Label12.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(88, 20)
        Me.Label12.TabIndex = 30
        Me.Label12.Text = "Min Angle"
        '
        'Label9
        '
        Me.Label9.AutoSize = true
        Me.Label9.Location = New System.Drawing.Point(4, 128)
        Me.Label9.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(98, 20)
        Me.Label9.TabIndex = 26
        Me.Label9.Text = "Min Torque"
        '
        'txt_MaxTorque
        '
        Me.txt_MaxTorque.Location = New System.Drawing.Point(8, 206)
        Me.txt_MaxTorque.Margin = New System.Windows.Forms.Padding(2)
        Me.txt_MaxTorque.MaxLength = 14
        Me.txt_MaxTorque.Name = "txt_MaxTorque"
        Me.txt_MaxTorque.Size = New System.Drawing.Size(161, 26)
        Me.txt_MaxTorque.TabIndex = 29
        '
        'txt_MinTorque
        '
        Me.txt_MinTorque.Location = New System.Drawing.Point(8, 151)
        Me.txt_MinTorque.Margin = New System.Windows.Forms.Padding(2)
        Me.txt_MinTorque.MaxLength = 14
        Me.txt_MinTorque.Name = "txt_MinTorque"
        Me.txt_MinTorque.Size = New System.Drawing.Size(161, 26)
        Me.txt_MinTorque.TabIndex = 27
        '
        'Label10
        '
        Me.Label10.AutoSize = true
        Me.Label10.Location = New System.Drawing.Point(4, 178)
        Me.Label10.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(102, 20)
        Me.Label10.TabIndex = 28
        Me.Label10.Text = "Max Torque"
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.txt_issue)
        Me.TabPage2.Controls.Add(Me.Label28)
        Me.TabPage2.Controls.Add(Me.cmb_Variant)
        Me.TabPage2.Controls.Add(Me.Label27)
        Me.TabPage2.Controls.Add(Me.btn_DeleteMaster)
        Me.TabPage2.Controls.Add(Me.btn_AddMaster)
        Me.TabPage2.Controls.Add(Me.cmb_Master)
        Me.TabPage2.Controls.Add(Me.Label26)
        Me.TabPage2.Controls.Add(Me.btn_DeleteVariant)
        Me.TabPage2.Controls.Add(Me.btn_AddVariant)
        Me.TabPage2.Controls.Add(Me.txt_MasterName)
        Me.TabPage2.Controls.Add(Me.txt_VariantName)
        Me.TabPage2.Controls.Add(Me.Label17)
        Me.TabPage2.Controls.Add(Me.Label25)
        Me.TabPage2.Controls.Add(Me.btn_SelectPicture)
        Me.TabPage2.Controls.Add(Me.Label23)
        Me.TabPage2.Controls.Add(Me.pb_Layout)
        Me.TabPage2.Location = New System.Drawing.Point(4, 29)
        Me.TabPage2.Margin = New System.Windows.Forms.Padding(2)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Size = New System.Drawing.Size(785, 577)
        Me.TabPage2.TabIndex = 2
        Me.TabPage2.Text = "Variant & Layout Description"
        Me.TabPage2.UseVisualStyleBackColor = true
        '
        'txt_issue
        '
        Me.txt_issue.Location = New System.Drawing.Point(8, 392)
        Me.txt_issue.Margin = New System.Windows.Forms.Padding(2)
        Me.txt_issue.MaxLength = 15
        Me.txt_issue.Name = "txt_issue"
        Me.txt_issue.Size = New System.Drawing.Size(152, 26)
        Me.txt_issue.TabIndex = 55
        '
        'Label28
        '
        Me.Label28.AutoSize = true
        Me.Label28.Font = New System.Drawing.Font("Microsoft Sans Serif", 12!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(162,Byte))
        Me.Label28.Location = New System.Drawing.Point(8, 370)
        Me.Label28.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(53, 20)
        Me.Label28.TabIndex = 65
        Me.Label28.Text = "Issue"
        '
        'cmb_Variant
        '
        Me.cmb_Variant.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmb_Variant.FormattingEnabled = true
        Me.cmb_Variant.Location = New System.Drawing.Point(12, 453)
        Me.cmb_Variant.Margin = New System.Windows.Forms.Padding(2)
        Me.cmb_Variant.Name = "cmb_Variant"
        Me.cmb_Variant.Size = New System.Drawing.Size(149, 28)
        Me.cmb_Variant.TabIndex = 64
        '
        'Label27
        '
        Me.Label27.AutoSize = true
        Me.Label27.Font = New System.Drawing.Font("Microsoft Sans Serif", 12!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(162,Byte))
        Me.Label27.Location = New System.Drawing.Point(9, 424)
        Me.Label27.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(123, 20)
        Me.Label27.TabIndex = 63
        Me.Label27.Text = "Select Variant"
        '
        'btn_DeleteMaster
        '
        Me.btn_DeleteMaster.Location = New System.Drawing.Point(8, 256)
        Me.btn_DeleteMaster.Margin = New System.Windows.Forms.Padding(2)
        Me.btn_DeleteMaster.Name = "btn_DeleteMaster"
        Me.btn_DeleteMaster.Size = New System.Drawing.Size(151, 29)
        Me.btn_DeleteMaster.TabIndex = 62
        Me.btn_DeleteMaster.Text = "Delete Master"
        Me.btn_DeleteMaster.UseVisualStyleBackColor = true
        '
        'btn_AddMaster
        '
        Me.btn_AddMaster.Location = New System.Drawing.Point(8, 222)
        Me.btn_AddMaster.Margin = New System.Windows.Forms.Padding(2)
        Me.btn_AddMaster.Name = "btn_AddMaster"
        Me.btn_AddMaster.Size = New System.Drawing.Size(151, 29)
        Me.btn_AddMaster.TabIndex = 61
        Me.btn_AddMaster.Text = "Add Master"
        Me.btn_AddMaster.UseVisualStyleBackColor = true
        '
        'cmb_Master
        '
        Me.cmb_Master.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmb_Master.FormattingEnabled = true
        Me.cmb_Master.Location = New System.Drawing.Point(11, 38)
        Me.cmb_Master.Margin = New System.Windows.Forms.Padding(2)
        Me.cmb_Master.Name = "cmb_Master"
        Me.cmb_Master.Size = New System.Drawing.Size(149, 28)
        Me.cmb_Master.TabIndex = 60
        '
        'Label26
        '
        Me.Label26.AutoSize = true
        Me.Label26.Font = New System.Drawing.Font("Microsoft Sans Serif", 12!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(162,Byte))
        Me.Label26.Location = New System.Drawing.Point(8, 9)
        Me.Label26.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(120, 20)
        Me.Label26.TabIndex = 59
        Me.Label26.Text = "Select Master"
        '
        'btn_DeleteVariant
        '
        Me.btn_DeleteVariant.Location = New System.Drawing.Point(12, 531)
        Me.btn_DeleteVariant.Margin = New System.Windows.Forms.Padding(2)
        Me.btn_DeleteVariant.Name = "btn_DeleteVariant"
        Me.btn_DeleteVariant.Size = New System.Drawing.Size(151, 29)
        Me.btn_DeleteVariant.TabIndex = 57
        Me.btn_DeleteVariant.Text = "Delete Variant"
        Me.btn_DeleteVariant.UseVisualStyleBackColor = true
        '
        'btn_AddVariant
        '
        Me.btn_AddVariant.Location = New System.Drawing.Point(12, 497)
        Me.btn_AddVariant.Margin = New System.Windows.Forms.Padding(2)
        Me.btn_AddVariant.Name = "btn_AddVariant"
        Me.btn_AddVariant.Size = New System.Drawing.Size(151, 29)
        Me.btn_AddVariant.TabIndex = 56
        Me.btn_AddVariant.Text = "Add Variant"
        Me.btn_AddVariant.UseVisualStyleBackColor = true
        '
        'txt_MasterName
        '
        Me.txt_MasterName.Location = New System.Drawing.Point(8, 109)
        Me.txt_MasterName.Margin = New System.Windows.Forms.Padding(2)
        Me.txt_MasterName.MaxLength = 15
        Me.txt_MasterName.Name = "txt_MasterName"
        Me.txt_MasterName.Size = New System.Drawing.Size(152, 26)
        Me.txt_MasterName.TabIndex = 53
        '
        'txt_VariantName
        '
        Me.txt_VariantName.Location = New System.Drawing.Point(8, 342)
        Me.txt_VariantName.Margin = New System.Windows.Forms.Padding(2)
        Me.txt_VariantName.MaxLength = 15
        Me.txt_VariantName.Name = "txt_VariantName"
        Me.txt_VariantName.Size = New System.Drawing.Size(152, 26)
        Me.txt_VariantName.TabIndex = 54
        '
        'Label17
        '
        Me.Label17.AutoSize = true
        Me.Label17.Font = New System.Drawing.Font("Microsoft Sans Serif", 12!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(162,Byte))
        Me.Label17.Location = New System.Drawing.Point(8, 320)
        Me.Label17.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(118, 20)
        Me.Label17.TabIndex = 53
        Me.Label17.Text = "Variant Name"
        '
        'Label25
        '
        Me.Label25.AutoSize = true
        Me.Label25.Font = New System.Drawing.Font("Microsoft Sans Serif", 12!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(162,Byte))
        Me.Label25.Location = New System.Drawing.Point(4, 86)
        Me.Label25.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(115, 20)
        Me.Label25.TabIndex = 52
        Me.Label25.Text = "Master Name"
        '
        'btn_SelectPicture
        '
        Me.btn_SelectPicture.Location = New System.Drawing.Point(8, 178)
        Me.btn_SelectPicture.Margin = New System.Windows.Forms.Padding(2)
        Me.btn_SelectPicture.Name = "btn_SelectPicture"
        Me.btn_SelectPicture.Size = New System.Drawing.Size(151, 29)
        Me.btn_SelectPicture.TabIndex = 51
        Me.btn_SelectPicture.Text = "Select Picture"
        Me.btn_SelectPicture.UseVisualStyleBackColor = true
        '
        'Label23
        '
        Me.Label23.AutoSize = true
        Me.Label23.Font = New System.Drawing.Font("Microsoft Sans Serif", 12!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(162,Byte))
        Me.Label23.Location = New System.Drawing.Point(4, 146)
        Me.Label23.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(181, 20)
        Me.Label23.TabIndex = 43
        Me.Label23.Text = "Select master Picture"
        '
        'pb_Layout
        '
        Me.pb_Layout.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom)  _
            Or System.Windows.Forms.AnchorStyles.Left)  _
            Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
        Me.pb_Layout.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pb_Layout.Location = New System.Drawing.Point(189, 34)
        Me.pb_Layout.Margin = New System.Windows.Forms.Padding(2)
        Me.pb_Layout.Name = "pb_Layout"
        Me.pb_Layout.Size = New System.Drawing.Size(589, 384)
        Me.pb_Layout.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pb_Layout.TabIndex = 1
        Me.pb_Layout.TabStop = false
        '
        'TabPage3
        '
        Me.TabPage3.Controls.Add(Me.Label29)
        Me.TabPage3.Controls.Add(Me.txt_issueP)
        Me.TabPage3.Controls.Add(Me.cmb_SelectVariant)
        Me.TabPage3.Controls.Add(Me.Label24)
        Me.TabPage3.Controls.Add(Me.Label22)
        Me.TabPage3.Controls.Add(Me.txt_NutPos)
        Me.TabPage3.Controls.Add(Me.Label21)
        Me.TabPage3.Controls.Add(Me.btn_SaveNut)
        Me.TabPage3.Controls.Add(Me.btn_DeleteNut)
        Me.TabPage3.Controls.Add(Me.btn_AddNut)
        Me.TabPage3.Controls.Add(Me.cmb_JobNo)
        Me.TabPage3.Controls.Add(Me.Label20)
        Me.TabPage3.Controls.Add(Me.cmb_ScrewOrder)
        Me.TabPage3.Controls.Add(Me.Label19)
        Me.TabPage3.Controls.Add(Me.cmb_NutType)
        Me.TabPage3.Controls.Add(Me.Label18)
        Me.TabPage3.Controls.Add(Me.txt_ScrewPos)
        Me.TabPage3.Controls.Add(Me.Label16)
        Me.TabPage3.Controls.Add(Me.grd_ProcessDesc)
        Me.TabPage3.Controls.Add(Me.NumericUpDown1)
        Me.TabPage3.Controls.Add(Me.pb_Socket)
        Me.TabPage3.Location = New System.Drawing.Point(4, 29)
        Me.TabPage3.Margin = New System.Windows.Forms.Padding(2)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Padding = New System.Windows.Forms.Padding(2)
        Me.TabPage3.Size = New System.Drawing.Size(785, 577)
        Me.TabPage3.TabIndex = 1
        Me.TabPage3.Text = "Process Description"
        Me.TabPage3.UseVisualStyleBackColor = true
        '
        'Label29
        '
        Me.Label29.AutoSize = true
        Me.Label29.Location = New System.Drawing.Point(10, 132)
        Me.Label29.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(48, 20)
        Me.Label29.TabIndex = 59
        Me.Label29.Text = "Issue"
        '
        'txt_issueP
        '
        Me.txt_issueP.Enabled = false
        Me.txt_issueP.Location = New System.Drawing.Point(14, 153)
        Me.txt_issueP.Margin = New System.Windows.Forms.Padding(2)
        Me.txt_issueP.Name = "txt_issueP"
        Me.txt_issueP.Size = New System.Drawing.Size(161, 26)
        Me.txt_issueP.TabIndex = 58
        '
        'cmb_SelectVariant
        '
        Me.cmb_SelectVariant.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmb_SelectVariant.FormattingEnabled = true
        Me.cmb_SelectVariant.Location = New System.Drawing.Point(14, 102)
        Me.cmb_SelectVariant.Margin = New System.Windows.Forms.Padding(2)
        Me.cmb_SelectVariant.Name = "cmb_SelectVariant"
        Me.cmb_SelectVariant.Size = New System.Drawing.Size(149, 28)
        Me.cmb_SelectVariant.TabIndex = 57
        '
        'Label24
        '
        Me.Label24.AutoSize = true
        Me.Label24.Font = New System.Drawing.Font("Microsoft Sans Serif", 12!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(162,Byte))
        Me.Label24.Location = New System.Drawing.Point(10, 80)
        Me.Label24.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(123, 20)
        Me.Label24.TabIndex = 56
        Me.Label24.Text = "Select Variant"
        '
        'Label22
        '
        Me.Label22.AutoSize = true
        Me.Label22.Location = New System.Drawing.Point(10, 403)
        Me.Label22.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(94, 20)
        Me.Label22.TabIndex = 55
        Me.Label22.Text = "Nut Position"
        '
        'txt_NutPos
        '
        Me.txt_NutPos.Enabled = false
        Me.txt_NutPos.Location = New System.Drawing.Point(10, 426)
        Me.txt_NutPos.Margin = New System.Windows.Forms.Padding(2)
        Me.txt_NutPos.Name = "txt_NutPos"
        Me.txt_NutPos.Size = New System.Drawing.Size(161, 26)
        Me.txt_NutPos.TabIndex = 42
        '
        'Label21
        '
        Me.Label21.AutoSize = true
        Me.Label21.Location = New System.Drawing.Point(10, 353)
        Me.Label21.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(113, 20)
        Me.Label21.TabIndex = 53
        Me.Label21.Text = "Screw Position"
        '
        'btn_SaveNut
        '
        Me.btn_SaveNut.Location = New System.Drawing.Point(14, 532)
        Me.btn_SaveNut.Margin = New System.Windows.Forms.Padding(2)
        Me.btn_SaveNut.Name = "btn_SaveNut"
        Me.btn_SaveNut.Size = New System.Drawing.Size(151, 29)
        Me.btn_SaveNut.TabIndex = 52
        Me.btn_SaveNut.Text = "Save Nut"
        Me.btn_SaveNut.UseVisualStyleBackColor = true
        '
        'btn_DeleteNut
        '
        Me.btn_DeleteNut.Location = New System.Drawing.Point(14, 498)
        Me.btn_DeleteNut.Margin = New System.Windows.Forms.Padding(2)
        Me.btn_DeleteNut.Name = "btn_DeleteNut"
        Me.btn_DeleteNut.Size = New System.Drawing.Size(151, 29)
        Me.btn_DeleteNut.TabIndex = 51
        Me.btn_DeleteNut.Text = "Delete Nut"
        Me.btn_DeleteNut.UseVisualStyleBackColor = true
        '
        'btn_AddNut
        '
        Me.btn_AddNut.Location = New System.Drawing.Point(14, 464)
        Me.btn_AddNut.Margin = New System.Windows.Forms.Padding(2)
        Me.btn_AddNut.Name = "btn_AddNut"
        Me.btn_AddNut.Size = New System.Drawing.Size(151, 29)
        Me.btn_AddNut.TabIndex = 50
        Me.btn_AddNut.Text = "Add Nut"
        Me.btn_AddNut.UseVisualStyleBackColor = true
        '
        'cmb_JobNo
        '
        Me.cmb_JobNo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmb_JobNo.FormattingEnabled = true
        Me.cmb_JobNo.Location = New System.Drawing.Point(10, 323)
        Me.cmb_JobNo.Margin = New System.Windows.Forms.Padding(2)
        Me.cmb_JobNo.Name = "cmb_JobNo"
        Me.cmb_JobNo.Size = New System.Drawing.Size(152, 28)
        Me.cmb_JobNo.TabIndex = 49
        '
        'Label20
        '
        Me.Label20.AutoSize = true
        Me.Label20.Font = New System.Drawing.Font("Microsoft Sans Serif", 12!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(162,Byte))
        Me.Label20.Location = New System.Drawing.Point(10, 301)
        Me.Label20.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(70, 20)
        Me.Label20.TabIndex = 48
        Me.Label20.Text = "Job No."
        '
        'cmb_ScrewOrder
        '
        Me.cmb_ScrewOrder.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmb_ScrewOrder.FormattingEnabled = true
        Me.cmb_ScrewOrder.Location = New System.Drawing.Point(10, 266)
        Me.cmb_ScrewOrder.Margin = New System.Windows.Forms.Padding(2)
        Me.cmb_ScrewOrder.Name = "cmb_ScrewOrder"
        Me.cmb_ScrewOrder.Size = New System.Drawing.Size(152, 28)
        Me.cmb_ScrewOrder.TabIndex = 47
        '
        'Label19
        '
        Me.Label19.AutoSize = true
        Me.Label19.Font = New System.Drawing.Font("Microsoft Sans Serif", 12!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(162,Byte))
        Me.Label19.Location = New System.Drawing.Point(10, 243)
        Me.Label19.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(108, 20)
        Me.Label19.TabIndex = 46
        Me.Label19.Text = "Screw Order"
        '
        'cmb_NutType
        '
        Me.cmb_NutType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmb_NutType.FormattingEnabled = true
        Me.cmb_NutType.Location = New System.Drawing.Point(10, 214)
        Me.cmb_NutType.Margin = New System.Windows.Forms.Padding(2)
        Me.cmb_NutType.Name = "cmb_NutType"
        Me.cmb_NutType.Size = New System.Drawing.Size(152, 28)
        Me.cmb_NutType.TabIndex = 45
        '
        'Label18
        '
        Me.Label18.AutoSize = true
        Me.Label18.Font = New System.Drawing.Font("Microsoft Sans Serif", 12!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(162,Byte))
        Me.Label18.Location = New System.Drawing.Point(10, 191)
        Me.Label18.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(80, 20)
        Me.Label18.TabIndex = 44
        Me.Label18.Text = "Nut Type"
        '
        'txt_ScrewPos
        '
        Me.txt_ScrewPos.Enabled = false
        Me.txt_ScrewPos.Location = New System.Drawing.Point(10, 376)
        Me.txt_ScrewPos.Margin = New System.Windows.Forms.Padding(2)
        Me.txt_ScrewPos.Name = "txt_ScrewPos"
        Me.txt_ScrewPos.Size = New System.Drawing.Size(161, 26)
        Me.txt_ScrewPos.TabIndex = 41
        '
        'Label16
        '
        Me.Label16.AutoSize = true
        Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 12!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(162,Byte))
        Me.Label16.Location = New System.Drawing.Point(10, 19)
        Me.Label16.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(98, 20)
        Me.Label16.TabIndex = 40
        Me.Label16.Text = "Nut Radius"
        '
        'grd_ProcessDesc
        '
        Me.grd_ProcessDesc.AllowUserToAddRows = false
        Me.grd_ProcessDesc.AllowUserToDeleteRows = false
        Me.grd_ProcessDesc.AllowUserToResizeColumns = false
        Me.grd_ProcessDesc.AllowUserToResizeRows = false
        Me.grd_ProcessDesc.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left)  _
            Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
        Me.grd_ProcessDesc.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.grd_ProcessDesc.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grd_ProcessDesc.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.grd_ProcessDesc.Location = New System.Drawing.Point(194, 399)
        Me.grd_ProcessDesc.Margin = New System.Windows.Forms.Padding(2)
        Me.grd_ProcessDesc.MultiSelect = false
        Me.grd_ProcessDesc.Name = "grd_ProcessDesc"
        Me.grd_ProcessDesc.RowTemplate.Height = 24
        Me.grd_ProcessDesc.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.grd_ProcessDesc.Size = New System.Drawing.Size(587, 166)
        Me.grd_ProcessDesc.TabIndex = 15
        '
        'tmr_Indicator
        '
        Me.tmr_Indicator.Interval = 50
        '
        'openFileDialog
        '
        Me.openFileDialog.Title = "Select a picture"
        '
        'frm_ProcessSetup
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6!, 13!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(793, 610)
        Me.Controls.Add(Me.tab_Main)
        Me.Icon = CType(resources.GetObject("$this.Icon"),System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(2)
        Me.Name = "frm_ProcessSetup"
        Me.Text = "Elopar Torque Station - Process Setup"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.pb_Socket,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.NumericUpDown1,System.ComponentModel.ISupportInitialize).EndInit
        Me.tab_Main.ResumeLayout(false)
        Me.TabPage1.ResumeLayout(false)
        Me.grp_IODefinitions.ResumeLayout(false)
        Me.grp_IODefinitions.PerformLayout
        CType(Me.grd_PLCIO,System.ComponentModel.ISupportInitialize).EndInit
        Me.GroupBox1.ResumeLayout(false)
        Me.GroupBox1.PerformLayout
        CType(Me.grd_JobDescription,System.ComponentModel.ISupportInitialize).EndInit
        Me.TabPage2.ResumeLayout(false)
        Me.TabPage2.PerformLayout
        CType(Me.pb_Layout,System.ComponentModel.ISupportInitialize).EndInit
        Me.TabPage3.ResumeLayout(false)
        Me.TabPage3.PerformLayout
        CType(Me.grd_ProcessDesc,System.ComponentModel.ISupportInitialize).EndInit
        Me.ResumeLayout(false)

End Sub

    Friend WithEvents pb_Socket As PictureBox
    Friend WithEvents NumericUpDown1 As NumericUpDown
    Friend WithEvents tab_Main As TabControl
    Friend WithEvents TabPage1 As TabPage
    Friend WithEvents TabPage3 As TabPage
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents TextBox6 As TextBox
    Friend WithEvents TextBox5 As TextBox
    Friend WithEvents TextBox4 As TextBox
    Friend WithEvents TextBox3 As TextBox
    Friend WithEvents TextBox2 As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents grd_PLCIO As DataGridView
    Friend WithEvents btn_DeleteIO As Button
    Friend WithEvents btn_EditIO As Button
    Friend WithEvents btn_NewIO As Button
    Friend WithEvents btn_SaveIO As Button
    Friend WithEvents grd_JobDescription As DataGridView
    Friend WithEvents grd_ProcessDesc As DataGridView
    Friend WithEvents txt_JobNo As TextBox
    Friend WithEvents Label8 As Label
    Friend WithEvents txt_JobDesc As TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents txt_MaxAngle As TextBox
    Friend WithEvents Label11 As Label
    Friend WithEvents txt_MinAngle As TextBox
    Friend WithEvents Label12 As Label
    Friend WithEvents txt_MaxTorque As TextBox
    Friend WithEvents Label10 As Label
    Friend WithEvents txt_MinTorque As TextBox
    Friend WithEvents Label9 As Label
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents btn_SaveJob As Button
    Friend WithEvents btn_DeleteJob As Button
    Friend WithEvents btn_EditJob As Button
    Friend WithEvents btn_NewJob As Button
    Friend WithEvents grp_IODefinitions As GroupBox
    Friend WithEvents Label13 As Label
    Friend WithEvents txt_Device As TextBox
    Friend WithEvents txt_Address As TextBox
    Friend WithEvents Label14 As Label
    Friend WithEvents Label15 As Label
    Friend WithEvents cmb_Type As ComboBox
    Friend WithEvents Label16 As Label
    Friend WithEvents tmr_Indicator As Timer
    Friend WithEvents txt_ScrewPos As TextBox
    Friend WithEvents cmb_NutType As ComboBox
    Friend WithEvents Label18 As Label
    Friend WithEvents cmb_ScrewOrder As ComboBox
    Friend WithEvents Label19 As Label
    Friend WithEvents cmb_JobNo As ComboBox
    Friend WithEvents Label20 As Label
    Friend WithEvents btn_AddNut As Button
    Friend WithEvents btn_DeleteNut As Button
    Friend WithEvents btn_SaveNut As Button
    Friend WithEvents Label21 As Label
    Friend WithEvents Label22 As Label
    Friend WithEvents txt_NutPos As TextBox
    Friend WithEvents TabPage2 As TabPage
    Friend WithEvents pb_Layout As PictureBox
    Friend WithEvents openFileDialog As OpenFileDialog
    Friend WithEvents Label23 As Label
    Friend WithEvents btn_SelectPicture As Button
    Friend WithEvents Label24 As Label
    Friend WithEvents cmb_SelectVariant As ComboBox
    Friend WithEvents Label25 As Label
    Friend WithEvents txt_MasterName As TextBox
    Friend WithEvents txt_VariantName As TextBox
    Friend WithEvents Label17 As Label
    Friend WithEvents btn_DeleteVariant As Button
    Friend WithEvents btn_AddVariant As Button
    Friend WithEvents Label26 As Label
    Friend WithEvents cmb_Master As ComboBox
    Friend WithEvents btn_DeleteMaster As Button
    Friend WithEvents btn_AddMaster As Button
    Friend WithEvents cmb_Variant As ComboBox
    Friend WithEvents Label27 As Label
    Friend WithEvents txt_issue As TextBox
    Friend WithEvents Label28 As Label
    Friend WithEvents Label29 As Label
    Friend WithEvents txt_issueP As TextBox
End Class
