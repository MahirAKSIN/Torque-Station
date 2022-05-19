<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frm_UserSetup
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_UserSetup))
        Me.lbl_level = New System.Windows.Forms.Label()
        Me.lbl_Pass2 = New System.Windows.Forms.Label()
        Me.lbl_Pass1 = New System.Windows.Forms.Label()
        Me.lbl_SaveUser = New System.Windows.Forms.Label()
        Me.lbl_UpdatePass = New System.Windows.Forms.Label()
        Me.lbl_editPass = New System.Windows.Forms.Label()
        Me.lbl_deleteUser = New System.Windows.Forms.Label()
        Me.lbl_addUser = New System.Windows.Forms.Label()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.cmb_UserLevel = New System.Windows.Forms.ComboBox()
        Me.btn_NewUser = New System.Windows.Forms.Button()
        Me.btn_Edit_User = New System.Windows.Forms.Button()
        Me.txt_Password = New System.Windows.Forms.TextBox()
        Me.txt_Username = New System.Windows.Forms.TextBox()
        Me.btn_Update_User = New System.Windows.Forms.Button()
        Me.btn_DeleteUser = New System.Windows.Forms.Button()
        Me.btn_SaveUser = New System.Windows.Forms.Button()
        Me.btn_Exit = New System.Windows.Forms.Button()
        Me.grd_Users = New System.Windows.Forms.DataGridView()
        CType(Me.PictureBox2,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.PictureBox1,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.grd_Users,System.ComponentModel.ISupportInitialize).BeginInit
        Me.SuspendLayout
        '
        'lbl_level
        '
        Me.lbl_level.AutoSize = true
        Me.lbl_level.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.lbl_level.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lbl_level.Location = New System.Drawing.Point(262, 184)
        Me.lbl_level.Name = "lbl_level"
        Me.lbl_level.Size = New System.Drawing.Size(45, 13)
        Me.lbl_level.TabIndex = 79
        Me.lbl_level.Tag = "lbl"
        Me.lbl_level.Text = "LEVEL"
        '
        'lbl_Pass2
        '
        Me.lbl_Pass2.AutoSize = true
        Me.lbl_Pass2.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lbl_Pass2.Location = New System.Drawing.Point(490, 83)
        Me.lbl_Pass2.Name = "lbl_Pass2"
        Me.lbl_Pass2.Size = New System.Drawing.Size(53, 13)
        Me.lbl_Pass2.TabIndex = 78
        Me.lbl_Pass2.Tag = "lbl"
        Me.lbl_Pass2.Text = "Password"
        '
        'lbl_Pass1
        '
        Me.lbl_Pass1.AutoSize = true
        Me.lbl_Pass1.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lbl_Pass1.Location = New System.Drawing.Point(387, 81)
        Me.lbl_Pass1.Name = "lbl_Pass1"
        Me.lbl_Pass1.Size = New System.Drawing.Size(53, 13)
        Me.lbl_Pass1.TabIndex = 77
        Me.lbl_Pass1.Tag = "lbl"
        Me.lbl_Pass1.Text = "Password"
        '
        'lbl_SaveUser
        '
        Me.lbl_SaveUser.AutoSize = true
        Me.lbl_SaveUser.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(162,Byte))
        Me.lbl_SaveUser.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lbl_SaveUser.Location = New System.Drawing.Point(254, 68)
        Me.lbl_SaveUser.Name = "lbl_SaveUser"
        Me.lbl_SaveUser.Size = New System.Drawing.Size(66, 13)
        Me.lbl_SaveUser.TabIndex = 76
        Me.lbl_SaveUser.Tag = "lbl"
        Me.lbl_SaveUser.Text = "Save User"
        '
        'lbl_UpdatePass
        '
        Me.lbl_UpdatePass.AutoSize = true
        Me.lbl_UpdatePass.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lbl_UpdatePass.Location = New System.Drawing.Point(490, 69)
        Me.lbl_UpdatePass.Name = "lbl_UpdatePass"
        Me.lbl_UpdatePass.Size = New System.Drawing.Size(67, 13)
        Me.lbl_UpdatePass.TabIndex = 75
        Me.lbl_UpdatePass.Tag = "lbl"
        Me.lbl_UpdatePass.Text = "Update User"
        '
        'lbl_editPass
        '
        Me.lbl_editPass.AutoSize = true
        Me.lbl_editPass.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lbl_editPass.Location = New System.Drawing.Point(387, 68)
        Me.lbl_editPass.Name = "lbl_editPass"
        Me.lbl_editPass.Size = New System.Drawing.Size(50, 13)
        Me.lbl_editPass.TabIndex = 74
        Me.lbl_editPass.Tag = "lbl"
        Me.lbl_editPass.Text = "Edit User"
        '
        'lbl_deleteUser
        '
        Me.lbl_deleteUser.AutoSize = true
        Me.lbl_deleteUser.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(162,Byte))
        Me.lbl_deleteUser.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lbl_deleteUser.Location = New System.Drawing.Point(131, 68)
        Me.lbl_deleteUser.Name = "lbl_deleteUser"
        Me.lbl_deleteUser.Size = New System.Drawing.Size(74, 13)
        Me.lbl_deleteUser.TabIndex = 73
        Me.lbl_deleteUser.Tag = "lbl"
        Me.lbl_deleteUser.Text = "Delete User"
        '
        'lbl_addUser
        '
        Me.lbl_addUser.AutoSize = true
        Me.lbl_addUser.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(162,Byte))
        Me.lbl_addUser.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lbl_addUser.Location = New System.Drawing.Point(41, 68)
        Me.lbl_addUser.Name = "lbl_addUser"
        Me.lbl_addUser.Size = New System.Drawing.Size(62, 13)
        Me.lbl_addUser.TabIndex = 72
        Me.lbl_addUser.Tag = "lbl"
        Me.lbl_addUser.Text = "New User"
        '
        'PictureBox2
        '
        Me.PictureBox2.Image = CType(resources.GetObject("PictureBox2.Image"),System.Drawing.Image)
        Me.PictureBox2.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.PictureBox2.Location = New System.Drawing.Point(271, 143)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(32, 26)
        Me.PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox2.TabIndex = 71
        Me.PictureBox2.TabStop = false
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"),System.Drawing.Image)
        Me.PictureBox1.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.PictureBox1.Location = New System.Drawing.Point(271, 111)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(32, 26)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox1.TabIndex = 70
        Me.PictureBox1.TabStop = false
        '
        'cmb_UserLevel
        '
        Me.cmb_UserLevel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmb_UserLevel.Enabled = false
        Me.cmb_UserLevel.Font = New System.Drawing.Font("Microsoft Sans Serif", 12!)
        Me.cmb_UserLevel.FormattingEnabled = true
        Me.cmb_UserLevel.Location = New System.Drawing.Point(323, 176)
        Me.cmb_UserLevel.Name = "cmb_UserLevel"
        Me.cmb_UserLevel.Size = New System.Drawing.Size(273, 28)
        Me.cmb_UserLevel.TabIndex = 62
        '
        'btn_NewUser
        '
        Me.btn_NewUser.BackgroundImage = CType(resources.GetObject("btn_NewUser.BackgroundImage"),System.Drawing.Image)
        Me.btn_NewUser.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btn_NewUser.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btn_NewUser.FlatAppearance.BorderSize = 0
        Me.btn_NewUser.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Chartreuse
        Me.btn_NewUser.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_NewUser.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btn_NewUser.Location = New System.Drawing.Point(38, 11)
        Me.btn_NewUser.Name = "btn_NewUser"
        Me.btn_NewUser.Size = New System.Drawing.Size(55, 55)
        Me.btn_NewUser.TabIndex = 63
        Me.btn_NewUser.UseVisualStyleBackColor = true
        '
        'btn_Edit_User
        '
        Me.btn_Edit_User.BackgroundImage = CType(resources.GetObject("btn_Edit_User.BackgroundImage"),System.Drawing.Image)
        Me.btn_Edit_User.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btn_Edit_User.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btn_Edit_User.FlatAppearance.BorderSize = 0
        Me.btn_Edit_User.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Black
        Me.btn_Edit_User.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_Edit_User.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btn_Edit_User.Location = New System.Drawing.Point(390, 11)
        Me.btn_Edit_User.Name = "btn_Edit_User"
        Me.btn_Edit_User.Size = New System.Drawing.Size(55, 55)
        Me.btn_Edit_User.TabIndex = 64
        Me.btn_Edit_User.UseVisualStyleBackColor = true
        '
        'txt_Password
        '
        Me.txt_Password.Enabled = false
        Me.txt_Password.Font = New System.Drawing.Font("Microsoft Sans Serif", 12!)
        Me.txt_Password.Location = New System.Drawing.Point(323, 143)
        Me.txt_Password.MaxLength = 10
        Me.txt_Password.Name = "txt_Password"
        Me.txt_Password.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txt_Password.Size = New System.Drawing.Size(273, 26)
        Me.txt_Password.TabIndex = 61
        '
        'txt_Username
        '
        Me.txt_Username.Enabled = false
        Me.txt_Username.Font = New System.Drawing.Font("Microsoft Sans Serif", 12!)
        Me.txt_Username.Location = New System.Drawing.Point(323, 111)
        Me.txt_Username.MaxLength = 20
        Me.txt_Username.Name = "txt_Username"
        Me.txt_Username.Size = New System.Drawing.Size(273, 26)
        Me.txt_Username.TabIndex = 60
        '
        'btn_Update_User
        '
        Me.btn_Update_User.BackgroundImage = CType(resources.GetObject("btn_Update_User.BackgroundImage"),System.Drawing.Image)
        Me.btn_Update_User.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btn_Update_User.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btn_Update_User.FlatAppearance.BorderSize = 0
        Me.btn_Update_User.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Black
        Me.btn_Update_User.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_Update_User.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btn_Update_User.Location = New System.Drawing.Point(492, 11)
        Me.btn_Update_User.Name = "btn_Update_User"
        Me.btn_Update_User.Size = New System.Drawing.Size(55, 55)
        Me.btn_Update_User.TabIndex = 65
        Me.btn_Update_User.UseVisualStyleBackColor = true
        '
        'btn_DeleteUser
        '
        Me.btn_DeleteUser.BackgroundImage = CType(resources.GetObject("btn_DeleteUser.BackgroundImage"),System.Drawing.Image)
        Me.btn_DeleteUser.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btn_DeleteUser.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btn_DeleteUser.FlatAppearance.BorderSize = 0
        Me.btn_DeleteUser.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkRed
        Me.btn_DeleteUser.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_DeleteUser.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btn_DeleteUser.Location = New System.Drawing.Point(134, 11)
        Me.btn_DeleteUser.Name = "btn_DeleteUser"
        Me.btn_DeleteUser.Size = New System.Drawing.Size(55, 55)
        Me.btn_DeleteUser.TabIndex = 66
        Me.btn_DeleteUser.UseVisualStyleBackColor = true
        '
        'btn_SaveUser
        '
        Me.btn_SaveUser.BackgroundImage = CType(resources.GetObject("btn_SaveUser.BackgroundImage"),System.Drawing.Image)
        Me.btn_SaveUser.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btn_SaveUser.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btn_SaveUser.FlatAppearance.BorderSize = 0
        Me.btn_SaveUser.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DeepSkyBlue
        Me.btn_SaveUser.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_SaveUser.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btn_SaveUser.Location = New System.Drawing.Point(256, 11)
        Me.btn_SaveUser.Name = "btn_SaveUser"
        Me.btn_SaveUser.Size = New System.Drawing.Size(55, 55)
        Me.btn_SaveUser.TabIndex = 68
        Me.btn_SaveUser.UseVisualStyleBackColor = true
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
        Me.btn_Exit.Location = New System.Drawing.Point(527, 298)
        Me.btn_Exit.Name = "btn_Exit"
        Me.btn_Exit.Size = New System.Drawing.Size(69, 72)
        Me.btn_Exit.TabIndex = 69
        Me.btn_Exit.UseVisualStyleBackColor = true
        '
        'grd_Users
        '
        Me.grd_Users.AllowUserToAddRows = false
        Me.grd_Users.AllowUserToDeleteRows = false
        Me.grd_Users.AllowUserToResizeColumns = false
        Me.grd_Users.AllowUserToResizeRows = false
        Me.grd_Users.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.grd_Users.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grd_Users.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.grd_Users.Location = New System.Drawing.Point(20, 111)
        Me.grd_Users.MultiSelect = false
        Me.grd_Users.Name = "grd_Users"
        Me.grd_Users.RowHeadersVisible = false
        Me.grd_Users.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.grd_Users.Size = New System.Drawing.Size(215, 259)
        Me.grd_Users.TabIndex = 67
        '
        'frm_UserSetup
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6!, 13!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.ClientSize = New System.Drawing.Size(634, 396)
        Me.Controls.Add(Me.lbl_level)
        Me.Controls.Add(Me.lbl_Pass2)
        Me.Controls.Add(Me.lbl_Pass1)
        Me.Controls.Add(Me.lbl_SaveUser)
        Me.Controls.Add(Me.lbl_UpdatePass)
        Me.Controls.Add(Me.lbl_editPass)
        Me.Controls.Add(Me.lbl_deleteUser)
        Me.Controls.Add(Me.lbl_addUser)
        Me.Controls.Add(Me.PictureBox2)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.cmb_UserLevel)
        Me.Controls.Add(Me.btn_NewUser)
        Me.Controls.Add(Me.btn_Edit_User)
        Me.Controls.Add(Me.txt_Password)
        Me.Controls.Add(Me.txt_Username)
        Me.Controls.Add(Me.btn_Update_User)
        Me.Controls.Add(Me.btn_DeleteUser)
        Me.Controls.Add(Me.btn_SaveUser)
        Me.Controls.Add(Me.btn_Exit)
        Me.Controls.Add(Me.grd_Users)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"),System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.MaximizeBox = false
        Me.Name = "frm_UserSetup"
        Me.Text = "Elopar Torque Station - User Setup"
        CType(Me.PictureBox2,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.PictureBox1,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.grd_Users,System.ComponentModel.ISupportInitialize).EndInit
        Me.ResumeLayout(false)
        Me.PerformLayout

End Sub

    Friend WithEvents lbl_level As Label
    Friend WithEvents lbl_Pass2 As Label
    Friend WithEvents lbl_Pass1 As Label
    Friend WithEvents lbl_SaveUser As Label
    Friend WithEvents lbl_UpdatePass As Label
    Friend WithEvents lbl_editPass As Label
    Friend WithEvents lbl_deleteUser As Label
    Friend WithEvents lbl_addUser As Label
    Friend WithEvents PictureBox2 As PictureBox
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents cmb_UserLevel As ComboBox
    Friend WithEvents btn_NewUser As Button
    Friend WithEvents btn_Edit_User As Button
    Friend WithEvents txt_Password As TextBox
    Friend WithEvents txt_Username As TextBox
    Friend WithEvents btn_Update_User As Button
    Friend WithEvents btn_DeleteUser As Button
    Friend WithEvents btn_SaveUser As Button
    Friend WithEvents btn_Exit As Button
    Friend WithEvents grd_Users As DataGridView
End Class
