<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_Login
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_Login))
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.btn_LoginCancel = New System.Windows.Forms.Button()
        Me.btn_LoginOk = New System.Windows.Forms.Button()
        Me.txt_Password = New System.Windows.Forms.TextBox()
        Me.LogoPictureBox = New System.Windows.Forms.PictureBox()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LogoPictureBox, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(237, 85)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(76, 45)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox1.TabIndex = 25
        Me.PictureBox1.TabStop = False
        '
        'btn_LoginCancel
        '
        Me.btn_LoginCancel.BackgroundImage = CType(resources.GetObject("btn_LoginCancel.BackgroundImage"), System.Drawing.Image)
        Me.btn_LoginCancel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btn_LoginCancel.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btn_LoginCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btn_LoginCancel.FlatAppearance.BorderSize = 0
        Me.btn_LoginCancel.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.btn_LoginCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_LoginCancel.Location = New System.Drawing.Point(528, 175)
        Me.btn_LoginCancel.Name = "btn_LoginCancel"
        Me.btn_LoginCancel.Size = New System.Drawing.Size(50, 50)
        Me.btn_LoginCancel.TabIndex = 23
        '
        'btn_LoginOk
        '
        Me.btn_LoginOk.BackgroundImage = CType(resources.GetObject("btn_LoginOk.BackgroundImage"), System.Drawing.Image)
        Me.btn_LoginOk.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btn_LoginOk.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btn_LoginOk.FlatAppearance.BorderSize = 0
        Me.btn_LoginOk.FlatAppearance.MouseOverBackColor = System.Drawing.Color.PaleGreen
        Me.btn_LoginOk.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_LoginOk.Location = New System.Drawing.Point(460, 175)
        Me.btn_LoginOk.Name = "btn_LoginOk"
        Me.btn_LoginOk.Size = New System.Drawing.Size(50, 50)
        Me.btn_LoginOk.TabIndex = 22
        '
        'txt_Password
        '
        Me.txt_Password.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.txt_Password.Font = New System.Drawing.Font("Microsoft Sans Serif", 26.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(162, Byte))
        Me.txt_Password.Location = New System.Drawing.Point(319, 85)
        Me.txt_Password.MaxLength = 10
        Me.txt_Password.Name = "txt_Password"
        Me.txt_Password.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txt_Password.Size = New System.Drawing.Size(257, 47)
        Me.txt_Password.TabIndex = 21
        '
        'LogoPictureBox
        '
        Me.LogoPictureBox.Image = CType(resources.GetObject("LogoPictureBox.Image"), System.Drawing.Image)
        Me.LogoPictureBox.Location = New System.Drawing.Point(10, 11)
        Me.LogoPictureBox.Name = "LogoPictureBox"
        Me.LogoPictureBox.Size = New System.Drawing.Size(210, 171)
        Me.LogoPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.LogoPictureBox.TabIndex = 24
        Me.LogoPictureBox.TabStop = False
        '
        'frm_Login
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.ClientSize = New System.Drawing.Size(598, 245)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.btn_LoginCancel)
        Me.Controls.Add(Me.btn_LoginOk)
        Me.Controls.Add(Me.txt_Password)
        Me.Controls.Add(Me.LogoPictureBox)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(2)
        Me.MaximizeBox = False
        Me.Name = "frm_Login"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Elopar Torque Station - User Login"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LogoPictureBox, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents btn_LoginCancel As Button
    Friend WithEvents btn_LoginOk As Button
    Friend WithEvents txt_Password As TextBox
    Friend WithEvents LogoPictureBox As PictureBox
End Class
