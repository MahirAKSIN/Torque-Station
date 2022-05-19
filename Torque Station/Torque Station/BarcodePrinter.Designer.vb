<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class BarcodePrinter
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(BarcodePrinter))
        Me.txt_order = New System.Windows.Forms.TextBox()
        Me.txt_date = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.txt_sta = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txt_op = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.btn_Exit = New System.Windows.Forms.Button()
        Me.SuspendLayout
        '
        'txt_order
        '
        Me.txt_order.Font = New System.Drawing.Font("Microsoft Sans Serif", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(162,Byte))
        Me.txt_order.Location = New System.Drawing.Point(141, 52)
        Me.txt_order.Name = "txt_order"
        Me.txt_order.Size = New System.Drawing.Size(153, 26)
        Me.txt_order.TabIndex = 1
        Me.txt_order.Tag = "txt"
        '
        'txt_date
        '
        Me.txt_date.Font = New System.Drawing.Font("Microsoft Sans Serif", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(162,Byte))
        Me.txt_date.Location = New System.Drawing.Point(141, 180)
        Me.txt_date.Name = "txt_date"
        Me.txt_date.Size = New System.Drawing.Size(153, 26)
        Me.txt_date.TabIndex = 4
        Me.txt_date.Tag = "txt"
        '
        'Label3
        '
        Me.Label3.AutoSize = true
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(162,Byte))
        Me.Label3.Location = New System.Drawing.Point(44, 180)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(82, 20)
        Me.Label3.TabIndex = 13
        Me.Label3.Text = "Date Time"
        '
        'Label2
        '
        Me.Label2.AutoSize = true
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(162,Byte))
        Me.Label2.Location = New System.Drawing.Point(44, 55)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(95, 20)
        Me.Label2.TabIndex = 11
        Me.Label2.Text = "Order Name"
        '
        'Button1
        '
        Me.Button1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(162,Byte))
        Me.Button1.Location = New System.Drawing.Point(141, 228)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(94, 36)
        Me.Button1.TabIndex = 5
        Me.Button1.Tag = "btn"
        Me.Button1.Text = "Printer"
        Me.Button1.UseVisualStyleBackColor = true
        '
        'txt_sta
        '
        Me.txt_sta.Font = New System.Drawing.Font("Microsoft Sans Serif", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(162,Byte))
        Me.txt_sta.Location = New System.Drawing.Point(141, 97)
        Me.txt_sta.Name = "txt_sta"
        Me.txt_sta.Size = New System.Drawing.Size(153, 26)
        Me.txt_sta.TabIndex = 2
        Me.txt_sta.Tag = "txt"
        '
        'Label1
        '
        Me.Label1.AutoSize = true
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(162,Byte))
        Me.Label1.Location = New System.Drawing.Point(44, 100)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(78, 20)
        Me.Label1.TabIndex = 16
        Me.Label1.Text = "Station Id"
        '
        'txt_op
        '
        Me.txt_op.Font = New System.Drawing.Font("Microsoft Sans Serif", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(162,Byte))
        Me.txt_op.Location = New System.Drawing.Point(141, 142)
        Me.txt_op.Name = "txt_op"
        Me.txt_op.Size = New System.Drawing.Size(153, 26)
        Me.txt_op.TabIndex = 3
        Me.txt_op.Tag = "txt"
        '
        'Label4
        '
        Me.Label4.AutoSize = true
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(162,Byte))
        Me.Label4.Location = New System.Drawing.Point(44, 145)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(90, 20)
        Me.Label4.TabIndex = 18
        Me.Label4.Text = "Operator Id"
        '
        'btn_Exit
        '
        Me.btn_Exit.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
        Me.btn_Exit.BackgroundImage = CType(resources.GetObject("btn_Exit.BackgroundImage"),System.Drawing.Image)
        Me.btn_Exit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btn_Exit.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btn_Exit.FlatAppearance.BorderSize = 0
        Me.btn_Exit.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(192,Byte),Integer), CType(CType(0,Byte),Integer), CType(CType(0,Byte),Integer))
        Me.btn_Exit.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_Exit.Font = New System.Drawing.Font("Microsoft Sans Serif", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(162,Byte))
        Me.btn_Exit.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btn_Exit.Location = New System.Drawing.Point(257, 228)
        Me.btn_Exit.Name = "btn_Exit"
        Me.btn_Exit.Size = New System.Drawing.Size(37, 36)
        Me.btn_Exit.TabIndex = 6
        Me.btn_Exit.UseVisualStyleBackColor = true
        '
        'BarcodePrinter
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6!, 13!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(326, 285)
        Me.Controls.Add(Me.btn_Exit)
        Me.Controls.Add(Me.txt_op)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txt_sta)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txt_order)
        Me.Controls.Add(Me.txt_date)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Button1)
        Me.Name = "BarcodePrinter"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "BarcodePrinter"
        Me.ResumeLayout(false)
        Me.PerformLayout

End Sub
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Button1 As Button
    Public WithEvents txt_order As TextBox
    Public WithEvents txt_date As TextBox
    Public WithEvents txt_sta As TextBox
    Friend WithEvents Label1 As Label
    Public WithEvents txt_op As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents btn_Exit As Button
End Class
