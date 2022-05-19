<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frm_Process
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_Process))
        Me.pb_Process = New System.Windows.Forms.PictureBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.txt_VariantBarcode = New System.Windows.Forms.TextBox()
        Me.grd_Process = New System.Windows.Forms.DataGridView()
        Me.tmr_Indicator = New System.Windows.Forms.Timer(Me.components)
        Me.tmr_Process = New System.Windows.Forms.Timer(Me.components)
        Me.txt_SerialPort = New System.Windows.Forms.TextBox()
        Me.txt_PLCError = New System.Windows.Forms.TextBox()
        Me.txt_LinearRuler = New System.Windows.Forms.TextBox()
        Me.txt_RotaryEncoder = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.led_InCycle = New LBSoft.IndustrialCtrls.Leds.LBLed()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.led_ResultOK = New LBSoft.IndustrialCtrls.Leds.LBLed()
        Me.led_ResultNOK = New LBSoft.IndustrialCtrls.Leds.LBLed()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txt_Info = New System.Windows.Forms.TextBox()
        Me.lbl_BitWarning = New System.Windows.Forms.Label()
        CType(Me.pb_Process, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grd_Process, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pb_Process
        '
        Me.pb_Process.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pb_Process.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pb_Process.Location = New System.Drawing.Point(196, 42)
        Me.pb_Process.Margin = New System.Windows.Forms.Padding(2)
        Me.pb_Process.Name = "pb_Process"
        Me.pb_Process.Size = New System.Drawing.Size(588, 382)
        Me.pb_Process.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pb_Process.TabIndex = 1
        Me.pb_Process.TabStop = False
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(162, Byte))
        Me.Label16.Location = New System.Drawing.Point(193, 15)
        Me.Label16.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(185, 20)
        Me.Label16.TabIndex = 41
        Me.Label16.Text = "Scan Variant Barcode"
        '
        'txt_VariantBarcode
        '
        Me.txt_VariantBarcode.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(162, Byte))
        Me.txt_VariantBarcode.Location = New System.Drawing.Point(406, 11)
        Me.txt_VariantBarcode.Margin = New System.Windows.Forms.Padding(2)
        Me.txt_VariantBarcode.Name = "txt_VariantBarcode"
        Me.txt_VariantBarcode.Size = New System.Drawing.Size(182, 28)
        Me.txt_VariantBarcode.TabIndex = 42
        '
        'grd_Process
        '
        Me.grd_Process.AllowUserToAddRows = False
        Me.grd_Process.AllowUserToDeleteRows = False
        Me.grd_Process.AllowUserToResizeColumns = False
        Me.grd_Process.AllowUserToResizeRows = False
        Me.grd_Process.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grd_Process.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.grd_Process.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grd_Process.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.grd_Process.Location = New System.Drawing.Point(196, 435)
        Me.grd_Process.Margin = New System.Windows.Forms.Padding(2)
        Me.grd_Process.MultiSelect = False
        Me.grd_Process.Name = "grd_Process"
        Me.grd_Process.RowTemplate.Height = 24
        Me.grd_Process.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.grd_Process.Size = New System.Drawing.Size(587, 114)
        Me.grd_Process.TabIndex = 43
        '
        'tmr_Indicator
        '
        '
        'tmr_Process
        '
        '
        'txt_SerialPort
        '
        Me.txt_SerialPort.Location = New System.Drawing.Point(10, 11)
        Me.txt_SerialPort.Margin = New System.Windows.Forms.Padding(2)
        Me.txt_SerialPort.Name = "txt_SerialPort"
        Me.txt_SerialPort.Size = New System.Drawing.Size(76, 20)
        Me.txt_SerialPort.TabIndex = 46
        '
        'txt_PLCError
        '
        Me.txt_PLCError.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txt_PLCError.Location = New System.Drawing.Point(12, 531)
        Me.txt_PLCError.Margin = New System.Windows.Forms.Padding(2)
        Me.txt_PLCError.Name = "txt_PLCError"
        Me.txt_PLCError.Size = New System.Drawing.Size(167, 20)
        Me.txt_PLCError.TabIndex = 47
        '
        'txt_LinearRuler
        '
        Me.txt_LinearRuler.Enabled = False
        Me.txt_LinearRuler.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(162, Byte))
        Me.txt_LinearRuler.Location = New System.Drawing.Point(47, 317)
        Me.txt_LinearRuler.Margin = New System.Windows.Forms.Padding(2)
        Me.txt_LinearRuler.Name = "txt_LinearRuler"
        Me.txt_LinearRuler.Size = New System.Drawing.Size(70, 28)
        Me.txt_LinearRuler.TabIndex = 53
        '
        'txt_RotaryEncoder
        '
        Me.txt_RotaryEncoder.Enabled = False
        Me.txt_RotaryEncoder.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(162, Byte))
        Me.txt_RotaryEncoder.Location = New System.Drawing.Point(47, 348)
        Me.txt_RotaryEncoder.Margin = New System.Windows.Forms.Padding(2)
        Me.txt_RotaryEncoder.Name = "txt_RotaryEncoder"
        Me.txt_RotaryEncoder.Size = New System.Drawing.Size(71, 28)
        Me.txt_RotaryEncoder.TabIndex = 54
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(162, Byte))
        Me.Label1.Location = New System.Drawing.Point(8, 321)
        Me.Label1.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(31, 24)
        Me.Label1.TabIndex = 55
        Me.Label1.Text = "X:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(162, Byte))
        Me.Label2.Location = New System.Drawing.Point(8, 352)
        Me.Label2.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(29, 24)
        Me.Label2.TabIndex = 56
        Me.Label2.Text = "Y:"
        '
        'led_InCycle
        '
        Me.led_InCycle.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.led_InCycle.BackColor = System.Drawing.Color.Transparent
        Me.led_InCycle.BlinkInterval = 500
        Me.led_InCycle.Label = ""
        Me.led_InCycle.LabelPosition = LBSoft.IndustrialCtrls.Leds.LBLed.LedLabelPosition.Top
        Me.led_InCycle.LedColor = System.Drawing.Color.Yellow
        Me.led_InCycle.LedSize = New System.Drawing.SizeF(30.0!, 30.0!)
        Me.led_InCycle.Location = New System.Drawing.Point(12, 416)
        Me.led_InCycle.Name = "led_InCycle"
        Me.led_InCycle.Renderer = Nothing
        Me.led_InCycle.Size = New System.Drawing.Size(34, 33)
        Me.led_InCycle.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.Off
        Me.led_InCycle.Style = LBSoft.IndustrialCtrls.Leds.LBLed.LedStyle.Circular
        Me.led_InCycle.TabIndex = 183
        '
        'Label3
        '
        Me.Label3.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(162, Byte))
        Me.Label3.Location = New System.Drawing.Point(44, 426)
        Me.Label3.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(85, 24)
        Me.Label3.TabIndex = 184
        Me.Label3.Text = "In Cycle"
        '
        'led_ResultOK
        '
        Me.led_ResultOK.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.led_ResultOK.BackColor = System.Drawing.Color.Transparent
        Me.led_ResultOK.BlinkInterval = 500
        Me.led_ResultOK.Label = ""
        Me.led_ResultOK.LabelPosition = LBSoft.IndustrialCtrls.Leds.LBLed.LedLabelPosition.Top
        Me.led_ResultOK.LedColor = System.Drawing.Color.LimeGreen
        Me.led_ResultOK.LedSize = New System.Drawing.SizeF(30.0!, 30.0!)
        Me.led_ResultOK.Location = New System.Drawing.Point(12, 453)
        Me.led_ResultOK.Name = "led_ResultOK"
        Me.led_ResultOK.Renderer = Nothing
        Me.led_ResultOK.Size = New System.Drawing.Size(34, 33)
        Me.led_ResultOK.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.Off
        Me.led_ResultOK.Style = LBSoft.IndustrialCtrls.Leds.LBLed.LedStyle.Circular
        Me.led_ResultOK.TabIndex = 185
        '
        'led_ResultNOK
        '
        Me.led_ResultNOK.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.led_ResultNOK.BackColor = System.Drawing.Color.Transparent
        Me.led_ResultNOK.BlinkInterval = 500
        Me.led_ResultNOK.Label = ""
        Me.led_ResultNOK.LabelPosition = LBSoft.IndustrialCtrls.Leds.LBLed.LedLabelPosition.Top
        Me.led_ResultNOK.LedColor = System.Drawing.Color.Crimson
        Me.led_ResultNOK.LedSize = New System.Drawing.SizeF(30.0!, 30.0!)
        Me.led_ResultNOK.Location = New System.Drawing.Point(12, 489)
        Me.led_ResultNOK.Name = "led_ResultNOK"
        Me.led_ResultNOK.Renderer = Nothing
        Me.led_ResultNOK.Size = New System.Drawing.Size(34, 33)
        Me.led_ResultNOK.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.Off
        Me.led_ResultNOK.Style = LBSoft.IndustrialCtrls.Leds.LBLed.LedStyle.Circular
        Me.led_ResultNOK.TabIndex = 186
        '
        'Label4
        '
        Me.Label4.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(162, Byte))
        Me.Label4.Location = New System.Drawing.Point(44, 462)
        Me.Label4.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(103, 24)
        Me.Label4.TabIndex = 187
        Me.Label4.Text = "Result OK"
        '
        'Label5
        '
        Me.Label5.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(162, Byte))
        Me.Label5.Location = New System.Drawing.Point(44, 499)
        Me.Label5.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(118, 24)
        Me.Label5.TabIndex = 188
        Me.Label5.Text = "Result NOK"
        '
        'txt_Info
        '
        Me.txt_Info.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.txt_Info.Enabled = False
        Me.txt_Info.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(162, Byte))
        Me.txt_Info.Location = New System.Drawing.Point(0, 582)
        Me.txt_Info.Margin = New System.Windows.Forms.Padding(2)
        Me.txt_Info.Name = "txt_Info"
        Me.txt_Info.Size = New System.Drawing.Size(793, 28)
        Me.txt_Info.TabIndex = 189
        '
        'lbl_BitWarning
        '
        Me.lbl_BitWarning.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lbl_BitWarning.AutoSize = True
        Me.lbl_BitWarning.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(162, Byte))
        Me.lbl_BitWarning.Location = New System.Drawing.Point(9, 560)
        Me.lbl_BitWarning.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lbl_BitWarning.Name = "lbl_BitWarning"
        Me.lbl_BitWarning.Size = New System.Drawing.Size(63, 20)
        Me.lbl_BitWarning.TabIndex = 191
        Me.lbl_BitWarning.Text = "Label6"
        '
        'frm_Process
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(793, 610)
        Me.Controls.Add(Me.lbl_BitWarning)
        Me.Controls.Add(Me.txt_Info)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.led_ResultNOK)
        Me.Controls.Add(Me.led_ResultOK)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.led_InCycle)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txt_RotaryEncoder)
        Me.Controls.Add(Me.txt_LinearRuler)
        Me.Controls.Add(Me.txt_PLCError)
        Me.Controls.Add(Me.txt_SerialPort)
        Me.Controls.Add(Me.grd_Process)
        Me.Controls.Add(Me.txt_VariantBarcode)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.pb_Process)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(2)
        Me.Name = "frm_Process"
        Me.Text = "Elopar Torque Station"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.pb_Process, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grd_Process, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents pb_Process As PictureBox
    Friend WithEvents Label16 As Label
    Friend WithEvents txt_VariantBarcode As TextBox
    Friend WithEvents grd_Process As DataGridView
    Friend WithEvents tmr_Indicator As Timer
    Friend WithEvents tmr_Process As Timer
    Friend WithEvents txt_SerialPort As TextBox
    Friend WithEvents txt_PLCError As TextBox
    Friend WithEvents txt_LinearRuler As TextBox
    Friend WithEvents txt_RotaryEncoder As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents led_InCycle As LBSoft.IndustrialCtrls.Leds.LBLed
    Friend WithEvents Label3 As Label
    Friend WithEvents led_ResultOK As LBSoft.IndustrialCtrls.Leds.LBLed
    Friend WithEvents led_ResultNOK As LBSoft.IndustrialCtrls.Leds.LBLed
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents txt_Info As TextBox
    Friend WithEvents lbl_BitWarning As Label
End Class
