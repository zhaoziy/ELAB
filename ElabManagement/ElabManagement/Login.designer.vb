<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Login
    Inherits System.Windows.Forms.Form

    'Form 重写 Dispose，以清理组件列表。
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

    'Windows 窗体设计器所必需的
    Private components As System.ComponentModel.IContainer

    '注意: 以下过程是 Windows 窗体设计器所必需的
    '可以使用 Windows 窗体设计器修改它。
    '不要使用代码编辑器修改它。
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Login))
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.Txtinvisible = New System.Windows.Forms.TextBox
        Me.txtphone = New System.Windows.Forms.TextBox
        Me.txtmail = New System.Windows.Forms.TextBox
        Me.txtpwdqr = New System.Windows.Forms.TextBox
        Me.txtpwd = New System.Windows.Forms.TextBox
        Me.txtnum = New System.Windows.Forms.TextBox
        Me.Label12 = New System.Windows.Forms.Label
        Me.Label11 = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.PictureUser = New System.Windows.Forms.PictureBox
        Me.txtdepart = New System.Windows.Forms.Label
        Me.txtname = New System.Windows.Forms.Label
        Me.Groupinfo = New System.Windows.Forms.GroupBox
        Me.Label13 = New System.Windows.Forms.Label
        Me.PictureBox2 = New System.Windows.Forms.PictureBox
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.LoginEnter = New System.Windows.Forms.Button
        Me.reset = New System.Windows.Forms.Button
        Me.quit = New System.Windows.Forms.Button
        Me.Label4 = New System.Windows.Forms.Label
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.Label5 = New System.Windows.Forms.Label
        CType(Me.PictureUser, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Groupinfo.SuspendLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("宋体", 17.0!)
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(32, 35)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(104, 23)
        Me.Label1.TabIndex = 8
        Me.Label1.Text = "学    号"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("宋体", 17.0!)
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(32, 75)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(104, 23)
        Me.Label2.TabIndex = 9
        Me.Label2.Text = "密    码"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("宋体", 17.0!)
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(32, 115)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(102, 23)
        Me.Label3.TabIndex = 10
        Me.Label3.Text = "确认密码"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("宋体", 17.0!)
        Me.Label6.ForeColor = System.Drawing.Color.White
        Me.Label6.Location = New System.Drawing.Point(32, 155)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(104, 23)
        Me.Label6.TabIndex = 13
        Me.Label6.Text = "邮    箱"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("宋体", 17.0!)
        Me.Label7.ForeColor = System.Drawing.Color.White
        Me.Label7.Location = New System.Drawing.Point(32, 195)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(104, 23)
        Me.Label7.TabIndex = 14
        Me.Label7.Text = "电    话"
        '
        'Txtinvisible
        '
        Me.Txtinvisible.BackColor = System.Drawing.Color.White
        Me.Txtinvisible.ForeColor = System.Drawing.Color.Black
        Me.Txtinvisible.Location = New System.Drawing.Point(225, 234)
        Me.Txtinvisible.Name = "Txtinvisible"
        Me.Txtinvisible.Size = New System.Drawing.Size(61, 21)
        Me.Txtinvisible.TabIndex = 15
        Me.Txtinvisible.TabStop = False
        Me.Txtinvisible.Visible = False
        '
        'txtphone
        '
        Me.txtphone.BackColor = System.Drawing.Color.White
        Me.txtphone.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtphone.Font = New System.Drawing.Font("宋体", 15.0!)
        Me.txtphone.ForeColor = System.Drawing.Color.Black
        Me.txtphone.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.txtphone.Location = New System.Drawing.Point(142, 195)
        Me.txtphone.MaxLength = 11
        Me.txtphone.Name = "txtphone"
        Me.txtphone.ReadOnly = True
        Me.txtphone.Size = New System.Drawing.Size(162, 23)
        Me.txtphone.TabIndex = 4
        '
        'txtmail
        '
        Me.txtmail.BackColor = System.Drawing.Color.White
        Me.txtmail.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtmail.Font = New System.Drawing.Font("宋体", 15.0!)
        Me.txtmail.ForeColor = System.Drawing.Color.Black
        Me.txtmail.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.txtmail.Location = New System.Drawing.Point(142, 155)
        Me.txtmail.Name = "txtmail"
        Me.txtmail.ReadOnly = True
        Me.txtmail.Size = New System.Drawing.Size(162, 23)
        Me.txtmail.TabIndex = 3
        '
        'txtpwdqr
        '
        Me.txtpwdqr.BackColor = System.Drawing.Color.White
        Me.txtpwdqr.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtpwdqr.Font = New System.Drawing.Font("宋体", 15.0!)
        Me.txtpwdqr.ForeColor = System.Drawing.Color.Black
        Me.txtpwdqr.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.txtpwdqr.Location = New System.Drawing.Point(142, 115)
        Me.txtpwdqr.Name = "txtpwdqr"
        Me.txtpwdqr.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtpwdqr.ReadOnly = True
        Me.txtpwdqr.Size = New System.Drawing.Size(162, 23)
        Me.txtpwdqr.TabIndex = 2
        '
        'txtpwd
        '
        Me.txtpwd.BackColor = System.Drawing.Color.White
        Me.txtpwd.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtpwd.Font = New System.Drawing.Font("宋体", 15.0!)
        Me.txtpwd.ForeColor = System.Drawing.Color.Black
        Me.txtpwd.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.txtpwd.Location = New System.Drawing.Point(142, 75)
        Me.txtpwd.Name = "txtpwd"
        Me.txtpwd.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtpwd.Size = New System.Drawing.Size(162, 23)
        Me.txtpwd.TabIndex = 1
        '
        'txtnum
        '
        Me.txtnum.BackColor = System.Drawing.Color.White
        Me.txtnum.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtnum.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtnum.Font = New System.Drawing.Font("宋体", 15.0!)
        Me.txtnum.ForeColor = System.Drawing.Color.Black
        Me.txtnum.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.txtnum.Location = New System.Drawing.Point(142, 35)
        Me.txtnum.MaxLength = 9
        Me.txtnum.Name = "txtnum"
        Me.txtnum.Size = New System.Drawing.Size(162, 23)
        Me.txtnum.TabIndex = 0
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.ForeColor = System.Drawing.Color.Red
        Me.Label12.Location = New System.Drawing.Point(23, 200)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(11, 12)
        Me.Label12.TabIndex = 20
        Me.Label12.Text = "*"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.ForeColor = System.Drawing.Color.Red
        Me.Label11.Location = New System.Drawing.Point(23, 160)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(11, 12)
        Me.Label11.TabIndex = 19
        Me.Label11.Text = "*"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.ForeColor = System.Drawing.Color.Red
        Me.Label10.Location = New System.Drawing.Point(23, 120)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(11, 12)
        Me.Label10.TabIndex = 18
        Me.Label10.Text = "*"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.ForeColor = System.Drawing.Color.Red
        Me.Label9.Location = New System.Drawing.Point(23, 80)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(11, 12)
        Me.Label9.TabIndex = 17
        Me.Label9.Text = "*"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.ForeColor = System.Drawing.Color.Red
        Me.Label8.Location = New System.Drawing.Point(23, 40)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(11, 12)
        Me.Label8.TabIndex = 16
        Me.Label8.Text = "*"
        '
        'PictureUser
        '
        Me.PictureUser.BackColor = System.Drawing.Color.Transparent
        Me.PictureUser.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.PictureUser.ErrorImage = Global.ElabManagement.My.Resources.Resources.person
        Me.PictureUser.Image = Global.ElabManagement.My.Resources.Resources.person
        Me.PictureUser.Location = New System.Drawing.Point(811, 196)
        Me.PictureUser.Name = "PictureUser"
        Me.PictureUser.Size = New System.Drawing.Size(107, 164)
        Me.PictureUser.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureUser.TabIndex = 27
        Me.PictureUser.TabStop = False
        '
        'txtdepart
        '
        Me.txtdepart.BackColor = System.Drawing.Color.Transparent
        Me.txtdepart.Font = New System.Drawing.Font("宋体", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.txtdepart.ForeColor = System.Drawing.Color.Black
        Me.txtdepart.Location = New System.Drawing.Point(613, 334)
        Me.txtdepart.Name = "txtdepart"
        Me.txtdepart.Size = New System.Drawing.Size(192, 18)
        Me.txtdepart.TabIndex = 28
        Me.txtdepart.Text = "Label4"
        Me.txtdepart.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtname
        '
        Me.txtname.BackColor = System.Drawing.Color.Transparent
        Me.txtname.Font = New System.Drawing.Font("宋体", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.txtname.ForeColor = System.Drawing.Color.Black
        Me.txtname.Location = New System.Drawing.Point(613, 299)
        Me.txtname.Name = "txtname"
        Me.txtname.Size = New System.Drawing.Size(192, 18)
        Me.txtname.TabIndex = 29
        Me.txtname.Text = "Label5"
        Me.txtname.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Groupinfo
        '
        Me.Groupinfo.BackColor = System.Drawing.Color.Transparent
        Me.Groupinfo.Controls.Add(Me.Label13)
        Me.Groupinfo.Controls.Add(Me.PictureBox2)
        Me.Groupinfo.Controls.Add(Me.PictureBox1)
        Me.Groupinfo.Controls.Add(Me.Txtinvisible)
        Me.Groupinfo.Controls.Add(Me.txtmail)
        Me.Groupinfo.Controls.Add(Me.Label9)
        Me.Groupinfo.Controls.Add(Me.txtphone)
        Me.Groupinfo.Controls.Add(Me.Label8)
        Me.Groupinfo.Controls.Add(Me.Label10)
        Me.Groupinfo.Controls.Add(Me.Label7)
        Me.Groupinfo.Controls.Add(Me.Label11)
        Me.Groupinfo.Controls.Add(Me.txtpwdqr)
        Me.Groupinfo.Controls.Add(Me.Label6)
        Me.Groupinfo.Controls.Add(Me.Label1)
        Me.Groupinfo.Controls.Add(Me.Label12)
        Me.Groupinfo.Controls.Add(Me.txtpwd)
        Me.Groupinfo.Controls.Add(Me.Label3)
        Me.Groupinfo.Controls.Add(Me.Label2)
        Me.Groupinfo.Controls.Add(Me.txtnum)
        Me.Groupinfo.ForeColor = System.Drawing.Color.White
        Me.Groupinfo.Location = New System.Drawing.Point(600, 399)
        Me.Groupinfo.Name = "Groupinfo"
        Me.Groupinfo.Size = New System.Drawing.Size(338, 260)
        Me.Groupinfo.TabIndex = 21
        Me.Groupinfo.TabStop = False
        Me.Groupinfo.Text = "基本信息"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("宋体", 15.0!)
        Me.Label13.ForeColor = System.Drawing.Color.Black
        Me.Label13.Location = New System.Drawing.Point(48, 230)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(189, 20)
        Me.Label13.TabIndex = 23
        Me.Label13.Text = "注意：请先输入学号"
        '
        'PictureBox2
        '
        Me.PictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PictureBox2.Location = New System.Drawing.Point(308, 195)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(22, 22)
        Me.PictureBox2.TabIndex = 22
        Me.PictureBox2.TabStop = False
        '
        'PictureBox1
        '
        Me.PictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.PictureBox1.Location = New System.Drawing.Point(308, 155)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(22, 22)
        Me.PictureBox1.TabIndex = 21
        Me.PictureBox1.TabStop = False
        '
        'LoginEnter
        '
        Me.LoginEnter.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.LoginEnter.Image = Global.ElabManagement.My.Resources.Resources.enter
        Me.LoginEnter.Location = New System.Drawing.Point(637, 693)
        Me.LoginEnter.Name = "LoginEnter"
        Me.LoginEnter.Size = New System.Drawing.Size(113, 45)
        Me.LoginEnter.TabIndex = 30
        Me.LoginEnter.UseVisualStyleBackColor = True
        '
        'reset
        '
        Me.reset.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.reset.Image = Global.ElabManagement.My.Resources.Resources.reset
        Me.reset.Location = New System.Drawing.Point(791, 693)
        Me.reset.Name = "reset"
        Me.reset.Size = New System.Drawing.Size(113, 45)
        Me.reset.TabIndex = 31
        Me.reset.UseVisualStyleBackColor = True
        '
        'quit
        '
        Me.quit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.quit.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.quit.Location = New System.Drawing.Point(825, 679)
        Me.quit.Name = "quit"
        Me.quit.Size = New System.Drawing.Size(0, 0)
        Me.quit.TabIndex = 32
        Me.quit.UseVisualStyleBackColor = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("黑体", 12.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label4.Location = New System.Drawing.Point(668, 760)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(215, 17)
        Me.Label4.TabIndex = 33
        Me.Label4.Text = "Elab-Zhao　版本号：1.00"
        '
        'Timer1
        '
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("宋体", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label5.Location = New System.Drawing.Point(578, 709)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(69, 20)
        Me.Label5.TabIndex = 34
        Me.Label5.Text = "Label5"
        '
        'Login
        '
        Me.AcceptButton = Me.LoginEnter
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.LightSkyBlue
        Me.BackgroundImage = Global.ElabManagement.My.Resources.Resources.固定背景
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.CancelButton = Me.quit
        Me.ClientSize = New System.Drawing.Size(992, 780)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.quit)
        Me.Controls.Add(Me.reset)
        Me.Controls.Add(Me.LoginEnter)
        Me.Controls.Add(Me.txtname)
        Me.Controls.Add(Me.Groupinfo)
        Me.Controls.Add(Me.txtdepart)
        Me.Controls.Add(Me.PictureUser)
        Me.DoubleBuffered = True
        Me.ForeColor = System.Drawing.Color.Black
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Login"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "登录"
        Me.TransparencyKey = System.Drawing.Color.Yellow
        CType(Me.PictureUser, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Groupinfo.ResumeLayout(False)
        Me.Groupinfo.PerformLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtphone As System.Windows.Forms.TextBox
    Friend WithEvents txtmail As System.Windows.Forms.TextBox
    Friend WithEvents txtpwdqr As System.Windows.Forms.TextBox
    Friend WithEvents txtpwd As System.Windows.Forms.TextBox
    Friend WithEvents txtnum As System.Windows.Forms.TextBox
    Friend WithEvents Txtinvisible As System.Windows.Forms.TextBox
    Friend WithEvents PictureUser As System.Windows.Forms.PictureBox
    Friend WithEvents txtname As System.Windows.Forms.Label
    Friend WithEvents txtdepart As System.Windows.Forms.Label
    Friend WithEvents Groupinfo As System.Windows.Forms.GroupBox
    Friend WithEvents LoginEnter As System.Windows.Forms.Button
    Friend WithEvents reset As System.Windows.Forms.Button
    Friend WithEvents quit As System.Windows.Forms.Button
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents Label5 As System.Windows.Forms.Label

End Class
