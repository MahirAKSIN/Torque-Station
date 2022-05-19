<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frm_Main
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_Main))
        Me.btn_About = New System.Windows.Forms.Button()
        Me.btn_Exit = New System.Windows.Forms.Button()
        Me.btn_Statistics = New System.Windows.Forms.Button()
        Me.btn_Process = New System.Windows.Forms.Button()
        Me.btn_User_Setup = New System.Windows.Forms.Button()
        Me.btn_ProcessSetup = New System.Windows.Forms.Button()
        Me.pb = New System.Windows.Forms.PictureBox()
        Me.btn_Settings = New System.Windows.Forms.Button()
        Me.btn_Print = New System.Windows.Forms.Button()
        Me.btn_deneme = New System.Windows.Forms.Button()
        CType(Me.pb,System.ComponentModel.ISupportInitialize).BeginInit
        Me.SuspendLayout
        '
        'btn_About
        '
        Me.btn_About.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
        Me.btn_About.BackgroundImage = CType(resources.GetObject("btn_About.BackgroundImage"),System.Drawing.Image)
        Me.btn_About.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btn_About.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btn_About.FlatAppearance.BorderSize = 0
        Me.btn_About.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_About.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btn_About.Location = New System.Drawing.Point(591, 452)
        Me.btn_About.Name = "btn_About"
        Me.btn_About.Size = New System.Drawing.Size(75, 76)
        Me.btn_About.TabIndex = 50
        Me.btn_About.UseVisualStyleBackColor = true
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
        Me.btn_Exit.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btn_Exit.Location = New System.Drawing.Point(687, 452)
        Me.btn_Exit.Name = "btn_Exit"
        Me.btn_Exit.Size = New System.Drawing.Size(75, 76)
        Me.btn_Exit.TabIndex = 49
        Me.btn_Exit.UseVisualStyleBackColor = true
        '
        'btn_Statistics
        '
        Me.btn_Statistics.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.btn_Statistics.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btn_Statistics.FlatAppearance.BorderSize = 2
        Me.btn_Statistics.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_Statistics.Font = New System.Drawing.Font("Microsoft Sans Serif", 12!)
        Me.btn_Statistics.ForeColor = System.Drawing.Color.RoyalBlue
        Me.btn_Statistics.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btn_Statistics.Location = New System.Drawing.Point(42, 219)
        Me.btn_Statistics.Name = "btn_Statistics"
        Me.btn_Statistics.Size = New System.Drawing.Size(182, 73)
        Me.btn_Statistics.TabIndex = 51
        Me.btn_Statistics.Tag = "btn"
        Me.btn_Statistics.Text = "Statistics"
        Me.btn_Statistics.UseVisualStyleBackColor = false
        '
        'btn_Process
        '
        Me.btn_Process.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.btn_Process.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btn_Process.FlatAppearance.BorderSize = 2
        Me.btn_Process.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_Process.Font = New System.Drawing.Font("Microsoft Sans Serif", 12!)
        Me.btn_Process.ForeColor = System.Drawing.Color.RoyalBlue
        Me.btn_Process.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btn_Process.Location = New System.Drawing.Point(42, 397)
        Me.btn_Process.Name = "btn_Process"
        Me.btn_Process.Size = New System.Drawing.Size(182, 73)
        Me.btn_Process.TabIndex = 52
        Me.btn_Process.Tag = "btn"
        Me.btn_Process.Text = "Process"
        Me.btn_Process.UseVisualStyleBackColor = false
        '
        'btn_User_Setup
        '
        Me.btn_User_Setup.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.btn_User_Setup.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btn_User_Setup.FlatAppearance.BorderSize = 2
        Me.btn_User_Setup.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_User_Setup.Font = New System.Drawing.Font("Microsoft Sans Serif", 12!)
        Me.btn_User_Setup.ForeColor = System.Drawing.Color.RoyalBlue
        Me.btn_User_Setup.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btn_User_Setup.Location = New System.Drawing.Point(42, 133)
        Me.btn_User_Setup.Name = "btn_User_Setup"
        Me.btn_User_Setup.Size = New System.Drawing.Size(182, 73)
        Me.btn_User_Setup.TabIndex = 42
        Me.btn_User_Setup.Tag = "btn"
        Me.btn_User_Setup.Text = "User Setup"
        Me.btn_User_Setup.UseVisualStyleBackColor = false
        '
        'btn_ProcessSetup
        '
        Me.btn_ProcessSetup.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.btn_ProcessSetup.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btn_ProcessSetup.FlatAppearance.BorderSize = 2
        Me.btn_ProcessSetup.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_ProcessSetup.Font = New System.Drawing.Font("Microsoft Sans Serif", 12!)
        Me.btn_ProcessSetup.ForeColor = System.Drawing.Color.RoyalBlue
        Me.btn_ProcessSetup.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btn_ProcessSetup.Location = New System.Drawing.Point(42, 41)
        Me.btn_ProcessSetup.Name = "btn_ProcessSetup"
        Me.btn_ProcessSetup.Size = New System.Drawing.Size(182, 73)
        Me.btn_ProcessSetup.TabIndex = 53
        Me.btn_ProcessSetup.Tag = "btn"
        Me.btn_ProcessSetup.Text = "Process Setup"
        Me.btn_ProcessSetup.UseVisualStyleBackColor = false
        '
        'pb
        '
        Me.pb.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom)  _
            Or System.Windows.Forms.AnchorStyles.Left)  _
            Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
        Me.pb.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.pb.Image = CType(resources.GetObject("pb.Image"),System.Drawing.Image)
        Me.pb.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.pb.Location = New System.Drawing.Point(248, 41)
        Me.pb.Name = "pb"
        Me.pb.Size = New System.Drawing.Size(472, 375)
        Me.pb.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pb.TabIndex = 54
        Me.pb.TabStop = false
        '
        'btn_Settings
        '
        Me.btn_Settings.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.btn_Settings.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btn_Settings.FlatAppearance.BorderSize = 2
        Me.btn_Settings.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_Settings.Font = New System.Drawing.Font("Microsoft Sans Serif", 12!)
        Me.btn_Settings.ForeColor = System.Drawing.Color.RoyalBlue
        Me.btn_Settings.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btn_Settings.Location = New System.Drawing.Point(42, 310)
        Me.btn_Settings.Name = "btn_Settings"
        Me.btn_Settings.Size = New System.Drawing.Size(182, 73)
        Me.btn_Settings.TabIndex = 56
        Me.btn_Settings.Tag = "btn"
        Me.btn_Settings.Text = "Settings"
        Me.btn_Settings.UseVisualStyleBackColor = false
        '
        'btn_Print
        '
        Me.btn_Print.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.btn_Print.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btn_Print.FlatAppearance.BorderSize = 2
        Me.btn_Print.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_Print.Font = New System.Drawing.Font("Microsoft Sans Serif", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(162,Byte))
        Me.btn_Print.ForeColor = System.Drawing.Color.RoyalBlue
        Me.btn_Print.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btn_Print.Location = New System.Drawing.Point(42, 481)
        Me.btn_Print.Name = "btn_Print"
        Me.btn_Print.Size = New System.Drawing.Size(182, 32)
        Me.btn_Print.TabIndex = 57
        Me.btn_Print.Tag = "btn"
        Me.btn_Print.Text = "Print Barcode"
        Me.btn_Print.UseVisualStyleBackColor = false
        Me.btn_Print.Visible = false
        '
        'btn_deneme
        '
        Me.btn_deneme.Location = New System.Drawing.Point(361, 440)
        Me.btn_deneme.Name = "btn_deneme"
        Me.btn_deneme.Size = New System.Drawing.Size(75, 23)
        Me.btn_deneme.TabIndex = 58
        Me.btn_deneme.Text = "deneme"
        Me.btn_deneme.UseVisualStyleBackColor = true
        Me.btn_deneme.Visible = false
        '
        'frm_Main
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6!, 13!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(784, 554)
        Me.Controls.Add(Me.btn_deneme)
        Me.Controls.Add(Me.btn_Print)
        Me.Controls.Add(Me.btn_Settings)
        Me.Controls.Add(Me.pb)
        Me.Controls.Add(Me.btn_ProcessSetup)
        Me.Controls.Add(Me.btn_Process)
        Me.Controls.Add(Me.btn_Statistics)
        Me.Controls.Add(Me.btn_About)
        Me.Controls.Add(Me.btn_Exit)
        Me.Controls.Add(Me.btn_User_Setup)
        Me.Icon = CType(resources.GetObject("$this.Icon"),System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(2)
        Me.MaximizeBox = false
        Me.Name = "frm_Main"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Elopar Torque Station"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.pb,System.ComponentModel.ISupportInitialize).EndInit
        Me.ResumeLayout(false)

End Sub
    Friend WithEvents btn_About As Button
    Friend WithEvents btn_Exit As Button
    Friend WithEvents btn_Statistics As Button
    Friend WithEvents btn_Process As Button
    Friend WithEvents btn_User_Setup As Button
    Friend WithEvents btn_ProcessSetup As Button
    Friend WithEvents pb As PictureBox
    Friend WithEvents btn_Settings As Button
    Friend WithEvents btn_Print As Button
    Friend WithEvents btn_deneme As Button
End Class
