<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ChangeInfo
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
        Me.Change_Info_Panel = New System.Windows.Forms.Panel
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.Label10 = New System.Windows.Forms.Label
        Me.TextBox7 = New System.Windows.Forms.TextBox
        Me.ReWP = New System.Windows.Forms.Button
        Me.Label9 = New System.Windows.Forms.Label
        Me.UpdateInfo = New System.Windows.Forms.Button
        Me.quit = New System.Windows.Forms.Button
        Me.reset = New System.Windows.Forms.Button
        Me.AddInfo = New System.Windows.Forms.Button
        Me.lady = New System.Windows.Forms.RadioButton
        Me.gentleman = New System.Windows.Forms.RadioButton
        Me.ComboBox1 = New System.Windows.Forms.ComboBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.TextBox6 = New System.Windows.Forms.TextBox
        Me.TextBox5 = New System.Windows.Forms.TextBox
        Me.TextBox4 = New System.Windows.Forms.TextBox
        Me.TextBox3 = New System.Windows.Forms.TextBox
        Me.TextBox2 = New System.Windows.Forms.TextBox
        Me.TextBox1 = New System.Windows.Forms.TextBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.Change_Info_Panel.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Change_Info_Panel
        '
        Me.Change_Info_Panel.Controls.Add(Me.GroupBox1)
        Me.Change_Info_Panel.Location = New System.Drawing.Point(0, 0)
        Me.Change_Info_Panel.Margin = New System.Windows.Forms.Padding(0)
        Me.Change_Info_Panel.Name = "Change_Info_Panel"
        Me.Change_Info_Panel.Size = New System.Drawing.Size(728, 560)
        Me.Change_Info_Panel.TabIndex = 2
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label10)
        Me.GroupBox1.Controls.Add(Me.TextBox7)
        Me.GroupBox1.Controls.Add(Me.ReWP)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.UpdateInfo)
        Me.GroupBox1.Controls.Add(Me.quit)
        Me.GroupBox1.Controls.Add(Me.reset)
        Me.GroupBox1.Controls.Add(Me.AddInfo)
        Me.GroupBox1.Controls.Add(Me.lady)
        Me.GroupBox1.Controls.Add(Me.gentleman)
        Me.GroupBox1.Controls.Add(Me.ComboBox1)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.TextBox6)
        Me.GroupBox1.Controls.Add(Me.TextBox5)
        Me.GroupBox1.Controls.Add(Me.TextBox4)
        Me.GroupBox1.Controls.Add(Me.TextBox3)
        Me.GroupBox1.Controls.Add(Me.TextBox2)
        Me.GroupBox1.Controls.Add(Me.TextBox1)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Font = New System.Drawing.Font("宋体", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(697, 532)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "添加成员信息"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(171, 74)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(104, 19)
        Me.Label10.TabIndex = 24
        Me.Label10.Text = "登录用户名"
        '
        'TextBox7
        '
        Me.TextBox7.Location = New System.Drawing.Point(279, 71)
        Me.TextBox7.Name = "TextBox7"
        Me.TextBox7.Size = New System.Drawing.Size(184, 29)
        Me.TextBox7.TabIndex = 0
        '
        'ReWP
        '
        Me.ReWP.Location = New System.Drawing.Point(547, 481)
        Me.ReWP.Name = "ReWP"
        Me.ReWP.Size = New System.Drawing.Size(100, 30)
        Me.ReWP.TabIndex = 22
        Me.ReWP.Text = "密码重置"
        Me.ReWP.UseVisualStyleBackColor = True
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("宋体", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label9.Location = New System.Drawing.Point(469, 386)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(218, 19)
        Me.Label9.TabIndex = 17
        Me.Label9.Text = "在此修改密码（非必填）"
        '
        'UpdateInfo
        '
        Me.UpdateInfo.Location = New System.Drawing.Point(81, 481)
        Me.UpdateInfo.Name = "UpdateInfo"
        Me.UpdateInfo.Size = New System.Drawing.Size(100, 30)
        Me.UpdateInfo.TabIndex = 19
        Me.UpdateInfo.Text = "更新"
        Me.UpdateInfo.UseVisualStyleBackColor = True
        '
        'quit
        '
        Me.quit.Location = New System.Drawing.Point(431, 481)
        Me.quit.Name = "quit"
        Me.quit.Size = New System.Drawing.Size(100, 30)
        Me.quit.TabIndex = 21
        Me.quit.Text = "关闭"
        Me.quit.UseVisualStyleBackColor = True
        '
        'reset
        '
        Me.reset.Location = New System.Drawing.Point(316, 481)
        Me.reset.Name = "reset"
        Me.reset.Size = New System.Drawing.Size(100, 30)
        Me.reset.TabIndex = 20
        Me.reset.Text = "重置"
        Me.reset.UseVisualStyleBackColor = True
        '
        'AddInfo
        '
        Me.AddInfo.Location = New System.Drawing.Point(198, 481)
        Me.AddInfo.Name = "AddInfo"
        Me.AddInfo.Size = New System.Drawing.Size(100, 30)
        Me.AddInfo.TabIndex = 18
        Me.AddInfo.Text = "添加"
        Me.AddInfo.UseVisualStyleBackColor = True
        '
        'lady
        '
        Me.lady.AutoSize = True
        Me.lady.Font = New System.Drawing.Font("宋体", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.lady.Location = New System.Drawing.Point(381, 207)
        Me.lady.Name = "lady"
        Me.lady.Size = New System.Drawing.Size(46, 23)
        Me.lady.TabIndex = 4
        Me.lady.TabStop = True
        Me.lady.Text = "女"
        Me.lady.UseVisualStyleBackColor = True
        '
        'gentleman
        '
        Me.gentleman.AutoSize = True
        Me.gentleman.Font = New System.Drawing.Font("宋体", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.gentleman.Location = New System.Drawing.Point(309, 207)
        Me.gentleman.Name = "gentleman"
        Me.gentleman.Size = New System.Drawing.Size(46, 23)
        Me.gentleman.TabIndex = 3
        Me.gentleman.TabStop = True
        Me.gentleman.Text = "男"
        Me.gentleman.UseVisualStyleBackColor = True
        '
        'ComboBox1
        '
        Me.ComboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox1.Font = New System.Drawing.Font("宋体", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.ComboBox1.FormattingEnabled = True
        Me.ComboBox1.Items.AddRange(New Object() {"电子组", "软件组", "助课组"})
        Me.ComboBox1.Location = New System.Drawing.Point(279, 296)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(184, 27)
        Me.ComboBox1.TabIndex = 6
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("宋体", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label8.Location = New System.Drawing.Point(171, 434)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(85, 19)
        Me.Label8.TabIndex = 16
        Me.Label8.Text = "确认密码"
        '
        'TextBox6
        '
        Me.TextBox6.Font = New System.Drawing.Font("宋体", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.TextBox6.Location = New System.Drawing.Point(279, 431)
        Me.TextBox6.Name = "TextBox6"
        Me.TextBox6.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.TextBox6.Size = New System.Drawing.Size(184, 29)
        Me.TextBox6.TabIndex = 9
        '
        'TextBox5
        '
        Me.TextBox5.Font = New System.Drawing.Font("宋体", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.TextBox5.Location = New System.Drawing.Point(279, 386)
        Me.TextBox5.Name = "TextBox5"
        Me.TextBox5.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.TextBox5.Size = New System.Drawing.Size(184, 29)
        Me.TextBox5.TabIndex = 8
        '
        'TextBox4
        '
        Me.TextBox4.Font = New System.Drawing.Font("宋体", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.TextBox4.Location = New System.Drawing.Point(279, 341)
        Me.TextBox4.MaxLength = 11
        Me.TextBox4.Name = "TextBox4"
        Me.TextBox4.Size = New System.Drawing.Size(184, 29)
        Me.TextBox4.TabIndex = 7
        '
        'TextBox3
        '
        Me.TextBox3.Font = New System.Drawing.Font("宋体", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.TextBox3.Location = New System.Drawing.Point(279, 251)
        Me.TextBox3.Name = "TextBox3"
        Me.TextBox3.Size = New System.Drawing.Size(184, 29)
        Me.TextBox3.TabIndex = 5
        '
        'TextBox2
        '
        Me.TextBox2.Font = New System.Drawing.Font("宋体", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.TextBox2.Location = New System.Drawing.Point(279, 161)
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Size = New System.Drawing.Size(184, 29)
        Me.TextBox2.TabIndex = 2
        '
        'TextBox1
        '
        Me.TextBox1.Font = New System.Drawing.Font("宋体", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.TextBox1.Location = New System.Drawing.Point(279, 116)
        Me.TextBox1.MaxLength = 9
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(184, 29)
        Me.TextBox1.TabIndex = 1
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("宋体", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label7.Location = New System.Drawing.Point(171, 389)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(87, 19)
        Me.Label7.TabIndex = 12
        Me.Label7.Text = "密    码"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("宋体", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label6.Location = New System.Drawing.Point(171, 344)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(87, 19)
        Me.Label6.TabIndex = 15
        Me.Label6.Text = "电    话"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("宋体", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label5.Location = New System.Drawing.Point(171, 299)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(87, 19)
        Me.Label5.TabIndex = 14
        Me.Label5.Text = "组    别"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("宋体", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label4.Location = New System.Drawing.Point(171, 254)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(87, 19)
        Me.Label4.TabIndex = 13
        Me.Label4.Text = "院    系"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("宋体", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label3.Location = New System.Drawing.Point(171, 209)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(87, 19)
        Me.Label3.TabIndex = 11
        Me.Label3.Text = "性    别"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("宋体", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label2.Location = New System.Drawing.Point(171, 164)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(87, 19)
        Me.Label2.TabIndex = 10
        Me.Label2.Text = "姓    名"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("宋体", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label1.Location = New System.Drawing.Point(171, 119)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(87, 19)
        Me.Label1.TabIndex = 9
        Me.Label1.Text = "学    号"
        '
        'ChangeInfo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(729, 563)
        Me.Controls.Add(Me.Change_Info_Panel)
        Me.DoubleBuffered = True
        Me.MaximumSize = New System.Drawing.Size(745, 602)
        Me.MinimumSize = New System.Drawing.Size(745, 602)
        Me.Name = "ChangeInfo"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "成员信息"
        Me.Change_Info_Panel.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Change_Info_Panel As System.Windows.Forms.Panel
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents ReWP As System.Windows.Forms.Button
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents UpdateInfo As System.Windows.Forms.Button
    Friend WithEvents quit As System.Windows.Forms.Button
    Friend WithEvents reset As System.Windows.Forms.Button
    Friend WithEvents AddInfo As System.Windows.Forms.Button
    Friend WithEvents lady As System.Windows.Forms.RadioButton
    Friend WithEvents gentleman As System.Windows.Forms.RadioButton
    Friend WithEvents ComboBox1 As System.Windows.Forms.ComboBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents TextBox6 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox5 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox4 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox3 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox2 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TextBox7 As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
End Class
