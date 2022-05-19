<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_Settings
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_Settings))
        Me.Label13 = New System.Windows.Forms.Label()
        Me.txt_StationId = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cmb_SerialPort = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cmb_LabelPrinter = New System.Windows.Forms.ComboBox()
        Me.btn_Exit = New System.Windows.Forms.Button()
        Me.btn_Save = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.nmrc_XTolerance = New System.Windows.Forms.NumericUpDown()
        Me.nmrc_YTolerance = New System.Windows.Forms.NumericUpDown()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.nmrc_SerialTimeout = New System.Windows.Forms.NumericUpDown()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.txt_SQLDatabase = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.btn_ConnectionTest = New System.Windows.Forms.Button()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txt_SQLPassword = New System.Windows.Forms.TextBox()
        Me.txt_SQLUsername = New System.Windows.Forms.TextBox()
        Me.txt_SQLServerName = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        CType(Me.nmrc_XTolerance,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.nmrc_YTolerance,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.nmrc_SerialTimeout,System.ComponentModel.ISupportInitialize).BeginInit
        Me.GroupBox1.SuspendLayout
        Me.SuspendLayout
        '
        'Label13
        '
        Me.Label13.AutoSize = true
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 12!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(162,Byte))
        Me.Label13.Location = New System.Drawing.Point(18, 29)
        Me.Label13.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(93, 20)
        Me.Label13.TabIndex = 40
        Me.Label13.Text = "Station Id:"
        '
        'txt_StationId
        '
        Me.txt_StationId.Font = New System.Drawing.Font("Microsoft Sans Serif", 12!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(162,Byte))
        Me.txt_StationId.Location = New System.Drawing.Point(181, 25)
        Me.txt_StationId.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.txt_StationId.MaxLength = 19
        Me.txt_StationId.Name = "txt_StationId"
        Me.txt_StationId.Size = New System.Drawing.Size(248, 26)
        Me.txt_StationId.TabIndex = 41
        '
        'Label1
        '
        Me.Label1.AutoSize = true
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(162,Byte))
        Me.Label1.Location = New System.Drawing.Point(18, 63)
        Me.Label1.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(98, 20)
        Me.Label1.TabIndex = 42
        Me.Label1.Text = "Serial Port:"
        '
        'cmb_SerialPort
        '
        Me.cmb_SerialPort.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmb_SerialPort.Font = New System.Drawing.Font("Microsoft Sans Serif", 12!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(162,Byte))
        Me.cmb_SerialPort.FormattingEnabled = true
        Me.cmb_SerialPort.Location = New System.Drawing.Point(180, 63)
        Me.cmb_SerialPort.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.cmb_SerialPort.Name = "cmb_SerialPort"
        Me.cmb_SerialPort.Size = New System.Drawing.Size(248, 28)
        Me.cmb_SerialPort.TabIndex = 43
        '
        'Label2
        '
        Me.Label2.AutoSize = true
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(162,Byte))
        Me.Label2.Location = New System.Drawing.Point(18, 101)
        Me.Label2.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(116, 20)
        Me.Label2.TabIndex = 44
        Me.Label2.Text = "Label Printer:"
        '
        'cmb_LabelPrinter
        '
        Me.cmb_LabelPrinter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmb_LabelPrinter.Font = New System.Drawing.Font("Microsoft Sans Serif", 12!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(162,Byte))
        Me.cmb_LabelPrinter.FormattingEnabled = true
        Me.cmb_LabelPrinter.Location = New System.Drawing.Point(181, 101)
        Me.cmb_LabelPrinter.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.cmb_LabelPrinter.Name = "cmb_LabelPrinter"
        Me.cmb_LabelPrinter.Size = New System.Drawing.Size(248, 28)
        Me.cmb_LabelPrinter.TabIndex = 45
        '
        'btn_Exit
        '
        Me.btn_Exit.BackgroundImage = CType(resources.GetObject("btn_Exit.BackgroundImage"),System.Drawing.Image)
        Me.btn_Exit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btn_Exit.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btn_Exit.FlatAppearance.BorderSize = 0
        Me.btn_Exit.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Red
        Me.btn_Exit.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_Exit.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btn_Exit.Location = New System.Drawing.Point(400, 482)
        Me.btn_Exit.Name = "btn_Exit"
        Me.btn_Exit.Size = New System.Drawing.Size(59, 55)
        Me.btn_Exit.TabIndex = 70
        Me.btn_Exit.UseVisualStyleBackColor = true
        '
        'btn_Save
        '
        Me.btn_Save.BackgroundImage = CType(resources.GetObject("btn_Save.BackgroundImage"),System.Drawing.Image)
        Me.btn_Save.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btn_Save.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btn_Save.FlatAppearance.BorderSize = 0
        Me.btn_Save.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DeepSkyBlue
        Me.btn_Save.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_Save.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btn_Save.Location = New System.Drawing.Point(322, 482)
        Me.btn_Save.Name = "btn_Save"
        Me.btn_Save.Size = New System.Drawing.Size(55, 55)
        Me.btn_Save.TabIndex = 71
        Me.btn_Save.UseVisualStyleBackColor = true
        '
        'Label3
        '
        Me.Label3.AutoSize = true
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 12!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(162,Byte))
        Me.Label3.Location = New System.Drawing.Point(18, 143)
        Me.Label3.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(162, 20)
        Me.Label3.TabIndex = 72
        Me.Label3.Text = "Position Tolerance:"
        '
        'Label4
        '
        Me.Label4.AutoSize = true
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 12!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(162,Byte))
        Me.Label4.Location = New System.Drawing.Point(177, 143)
        Me.Label4.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(26, 20)
        Me.Label4.TabIndex = 73
        Me.Label4.Text = "X:"
        '
        'Label5
        '
        Me.Label5.AutoSize = true
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 12!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(162,Byte))
        Me.Label5.Location = New System.Drawing.Point(308, 143)
        Me.Label5.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(26, 20)
        Me.Label5.TabIndex = 75
        Me.Label5.Text = "Y:"
        '
        'nmrc_XTolerance
        '
        Me.nmrc_XTolerance.Font = New System.Drawing.Font("Microsoft Sans Serif", 12!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(162,Byte))
        Me.nmrc_XTolerance.Location = New System.Drawing.Point(208, 141)
        Me.nmrc_XTolerance.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.nmrc_XTolerance.Maximum = New Decimal(New Integer() {500, 0, 0, 0})
        Me.nmrc_XTolerance.Name = "nmrc_XTolerance"
        Me.nmrc_XTolerance.Size = New System.Drawing.Size(90, 26)
        Me.nmrc_XTolerance.TabIndex = 77
        '
        'nmrc_YTolerance
        '
        Me.nmrc_YTolerance.Font = New System.Drawing.Font("Microsoft Sans Serif", 12!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(162,Byte))
        Me.nmrc_YTolerance.Location = New System.Drawing.Point(338, 141)
        Me.nmrc_YTolerance.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.nmrc_YTolerance.Maximum = New Decimal(New Integer() {500, 0, 0, 0})
        Me.nmrc_YTolerance.Name = "nmrc_YTolerance"
        Me.nmrc_YTolerance.Size = New System.Drawing.Size(90, 26)
        Me.nmrc_YTolerance.TabIndex = 78
        '
        'Label6
        '
        Me.Label6.AutoSize = true
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 12!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(162,Byte))
        Me.Label6.Location = New System.Drawing.Point(18, 183)
        Me.Label6.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(167, 20)
        Me.Label6.TabIndex = 79
        Me.Label6.Text = "Serial Port Timeout:"
        '
        'nmrc_SerialTimeout
        '
        Me.nmrc_SerialTimeout.Font = New System.Drawing.Font("Microsoft Sans Serif", 12!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(162,Byte))
        Me.nmrc_SerialTimeout.Location = New System.Drawing.Point(181, 180)
        Me.nmrc_SerialTimeout.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.nmrc_SerialTimeout.Maximum = New Decimal(New Integer() {500, 0, 0, 0})
        Me.nmrc_SerialTimeout.Name = "nmrc_SerialTimeout"
        Me.nmrc_SerialTimeout.Size = New System.Drawing.Size(247, 26)
        Me.nmrc_SerialTimeout.TabIndex = 80
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.txt_SQLDatabase)
        Me.GroupBox1.Controls.Add(Me.Label11)
        Me.GroupBox1.Controls.Add(Me.btn_ConnectionTest)
        Me.GroupBox1.Controls.Add(Me.Label10)
        Me.GroupBox1.Controls.Add(Me.txt_SQLPassword)
        Me.GroupBox1.Controls.Add(Me.txt_SQLUsername)
        Me.GroupBox1.Controls.Add(Me.txt_SQLServerName)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(162,Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(9, 223)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.GroupBox1.Size = New System.Drawing.Size(451, 233)
        Me.GroupBox1.TabIndex = 81
        Me.GroupBox1.TabStop = false
        Me.GroupBox1.Text = "SQL Connection"
        '
        'txt_SQLDatabase
        '
        Me.txt_SQLDatabase.Font = New System.Drawing.Font("Microsoft Sans Serif", 12!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(162,Byte))
        Me.txt_SQLDatabase.Location = New System.Drawing.Point(172, 68)
        Me.txt_SQLDatabase.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.txt_SQLDatabase.MaxLength = 32700
        Me.txt_SQLDatabase.Name = "txt_SQLDatabase"
        Me.txt_SQLDatabase.Size = New System.Drawing.Size(248, 26)
        Me.txt_SQLDatabase.TabIndex = 90
        '
        'Label11
        '
        Me.Label11.AutoSize = true
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 12!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(162,Byte))
        Me.Label11.Location = New System.Drawing.Point(18, 68)
        Me.Label11.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(92, 20)
        Me.Label11.TabIndex = 89
        Me.Label11.Text = "Database:"
        '
        'btn_ConnectionTest
        '
        Me.btn_ConnectionTest.Location = New System.Drawing.Point(171, 183)
        Me.btn_ConnectionTest.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.btn_ConnectionTest.Name = "btn_ConnectionTest"
        Me.btn_ConnectionTest.Size = New System.Drawing.Size(247, 28)
        Me.btn_ConnectionTest.TabIndex = 88
        Me.btn_ConnectionTest.Text = "Connection Test"
        Me.btn_ConnectionTest.UseVisualStyleBackColor = true
        '
        'Label10
        '
        Me.Label10.AutoSize = true
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 12!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(162,Byte))
        Me.Label10.Location = New System.Drawing.Point(18, 187)
        Me.Label10.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(145, 20)
        Me.Label10.TabIndex = 87
        Me.Label10.Text = "Connection Test:"
        '
        'txt_SQLPassword
        '
        Me.txt_SQLPassword.Font = New System.Drawing.Font("Microsoft Sans Serif", 12!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(162,Byte))
        Me.txt_SQLPassword.Location = New System.Drawing.Point(172, 144)
        Me.txt_SQLPassword.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.txt_SQLPassword.MaxLength = 32700
        Me.txt_SQLPassword.Name = "txt_SQLPassword"
        Me.txt_SQLPassword.Size = New System.Drawing.Size(248, 26)
        Me.txt_SQLPassword.TabIndex = 86
        '
        'txt_SQLUsername
        '
        Me.txt_SQLUsername.Font = New System.Drawing.Font("Microsoft Sans Serif", 12!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(162,Byte))
        Me.txt_SQLUsername.Location = New System.Drawing.Point(171, 106)
        Me.txt_SQLUsername.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.txt_SQLUsername.MaxLength = 32700
        Me.txt_SQLUsername.Name = "txt_SQLUsername"
        Me.txt_SQLUsername.Size = New System.Drawing.Size(248, 26)
        Me.txt_SQLUsername.TabIndex = 85
        '
        'txt_SQLServerName
        '
        Me.txt_SQLServerName.Font = New System.Drawing.Font("Microsoft Sans Serif", 12!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(162,Byte))
        Me.txt_SQLServerName.Location = New System.Drawing.Point(171, 30)
        Me.txt_SQLServerName.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.txt_SQLServerName.MaxLength = 32700
        Me.txt_SQLServerName.Name = "txt_SQLServerName"
        Me.txt_SQLServerName.Size = New System.Drawing.Size(248, 26)
        Me.txt_SQLServerName.TabIndex = 82
        '
        'Label9
        '
        Me.Label9.AutoSize = true
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 12!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(162,Byte))
        Me.Label9.Location = New System.Drawing.Point(18, 146)
        Me.Label9.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(91, 20)
        Me.Label9.TabIndex = 84
        Me.Label9.Text = "Password:"
        '
        'Label8
        '
        Me.Label8.AutoSize = true
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 12!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(162,Byte))
        Me.Label8.Location = New System.Drawing.Point(18, 108)
        Me.Label8.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(96, 20)
        Me.Label8.TabIndex = 83
        Me.Label8.Text = "Username:"
        '
        'Label7
        '
        Me.Label7.AutoSize = true
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 12!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(162,Byte))
        Me.Label7.Location = New System.Drawing.Point(18, 32)
        Me.Label7.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(117, 20)
        Me.Label7.TabIndex = 82
        Me.Label7.Text = "Server Name:"
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(138, 508)
        Me.Button1.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(56, 19)
        Me.Button1.TabIndex = 82
        Me.Button1.Text = "Button1"
        Me.Button1.UseVisualStyleBackColor = true
        '
        'frm_Settings
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6!, 13!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.ClientSize = New System.Drawing.Size(477, 622)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.nmrc_SerialTimeout)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.nmrc_YTolerance)
        Me.Controls.Add(Me.nmrc_XTolerance)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.btn_Save)
        Me.Controls.Add(Me.btn_Exit)
        Me.Controls.Add(Me.cmb_LabelPrinter)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.cmb_SerialPort)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txt_StationId)
        Me.Controls.Add(Me.Label13)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"),System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.MaximizeBox = false
        Me.Name = "frm_Settings"
        Me.Text = "Elopar Torque Station - Settings"
        CType(Me.nmrc_XTolerance,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.nmrc_YTolerance,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.nmrc_SerialTimeout,System.ComponentModel.ISupportInitialize).EndInit
        Me.GroupBox1.ResumeLayout(false)
        Me.GroupBox1.PerformLayout
        Me.ResumeLayout(false)
        Me.PerformLayout

End Sub

    Friend WithEvents Label13 As Label
    Friend WithEvents txt_StationId As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents cmb_SerialPort As ComboBox
    Friend WithEvents Label2 As Label
    Friend WithEvents cmb_LabelPrinter As ComboBox
    Friend WithEvents btn_Exit As Button
    Friend WithEvents btn_Save As Button
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents nmrc_XTolerance As NumericUpDown
    Friend WithEvents nmrc_YTolerance As NumericUpDown
    Friend WithEvents Label6 As Label
    Friend WithEvents nmrc_SerialTimeout As NumericUpDown
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents Label9 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents txt_SQLPassword As TextBox
    Friend WithEvents txt_SQLUsername As TextBox
    Friend WithEvents txt_SQLServerName As TextBox
    Friend WithEvents btn_ConnectionTest As Button
    Friend WithEvents Label10 As Label
    Friend WithEvents txt_SQLDatabase As TextBox
    Friend WithEvents Label11 As Label
    Friend WithEvents Button1 As Button
End Class
