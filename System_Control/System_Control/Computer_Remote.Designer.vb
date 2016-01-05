<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Computer_Remote
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
        Me.Computer_Remote_Panel = New System.Windows.Forms.Panel
        Me.Button2 = New System.Windows.Forms.Button
        Me.IP_MAC = New System.Windows.Forms.Button
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.BT_Start = New System.Windows.Forms.Button
        Me.BT_Close = New System.Windows.Forms.Button
        Me.BT_Restart = New System.Windows.Forms.Button
        Me.BT_Logoff = New System.Windows.Forms.Button
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.CheckBox1 = New System.Windows.Forms.CheckBox
        Me.CheckBox2 = New System.Windows.Forms.CheckBox
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.Outter = New System.Windows.Forms.GroupBox
        Me.CB_Standard1 = New System.Windows.Forms.CheckBox
        Me.PB_Standard1 = New System.Windows.Forms.PictureBox
        Me.Inner = New System.Windows.Forms.GroupBox
        Me.CB_Standard2 = New System.Windows.Forms.CheckBox
        Me.PB_Standard2 = New System.Windows.Forms.PictureBox
        Me.Computer_Remote_Panel.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.Outter.SuspendLayout()
        CType(Me.PB_Standard1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Inner.SuspendLayout()
        CType(Me.PB_Standard2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Computer_Remote_Panel
        '
        Me.Computer_Remote_Panel.Controls.Add(Me.Button2)
        Me.Computer_Remote_Panel.Controls.Add(Me.IP_MAC)
        Me.Computer_Remote_Panel.Controls.Add(Me.GroupBox2)
        Me.Computer_Remote_Panel.Controls.Add(Me.GroupBox1)
        Me.Computer_Remote_Panel.Controls.Add(Me.Panel1)
        Me.Computer_Remote_Panel.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Computer_Remote_Panel.Location = New System.Drawing.Point(0, 0)
        Me.Computer_Remote_Panel.Margin = New System.Windows.Forms.Padding(0)
        Me.Computer_Remote_Panel.Name = "Computer_Remote_Panel"
        Me.Computer_Remote_Panel.Size = New System.Drawing.Size(728, 560)
        Me.Computer_Remote_Panel.TabIndex = 0
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(619, 346)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(87, 23)
        Me.Button2.TabIndex = 13
        Me.Button2.Text = "刷新"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'IP_MAC
        '
        Me.IP_MAC.Location = New System.Drawing.Point(619, 292)
        Me.IP_MAC.Name = "IP_MAC"
        Me.IP_MAC.Size = New System.Drawing.Size(87, 23)
        Me.IP_MAC.TabIndex = 12
        Me.IP_MAC.Text = "IP、MAC修改"
        Me.IP_MAC.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.BT_Start)
        Me.GroupBox2.Controls.Add(Me.BT_Close)
        Me.GroupBox2.Controls.Add(Me.BT_Restart)
        Me.GroupBox2.Controls.Add(Me.BT_Logoff)
        Me.GroupBox2.Location = New System.Drawing.Point(604, 98)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(117, 159)
        Me.GroupBox2.TabIndex = 11
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "远程控制"
        '
        'BT_Start
        '
        Me.BT_Start.Location = New System.Drawing.Point(15, 20)
        Me.BT_Start.Name = "BT_Start"
        Me.BT_Start.Size = New System.Drawing.Size(87, 23)
        Me.BT_Start.TabIndex = 9
        Me.BT_Start.Text = "选中电脑开机"
        Me.BT_Start.UseVisualStyleBackColor = True
        '
        'BT_Close
        '
        Me.BT_Close.Location = New System.Drawing.Point(15, 55)
        Me.BT_Close.Name = "BT_Close"
        Me.BT_Close.Size = New System.Drawing.Size(87, 23)
        Me.BT_Close.TabIndex = 6
        Me.BT_Close.Text = "选中电脑关机"
        Me.BT_Close.UseVisualStyleBackColor = True
        '
        'BT_Restart
        '
        Me.BT_Restart.Location = New System.Drawing.Point(15, 90)
        Me.BT_Restart.Name = "BT_Restart"
        Me.BT_Restart.Size = New System.Drawing.Size(87, 23)
        Me.BT_Restart.TabIndex = 7
        Me.BT_Restart.Text = "选中电脑重启"
        Me.BT_Restart.UseVisualStyleBackColor = True
        '
        'BT_Logoff
        '
        Me.BT_Logoff.Location = New System.Drawing.Point(15, 125)
        Me.BT_Logoff.Name = "BT_Logoff"
        Me.BT_Logoff.Size = New System.Drawing.Size(87, 23)
        Me.BT_Logoff.TabIndex = 8
        Me.BT_Logoff.Text = "选中电脑注销"
        Me.BT_Logoff.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.CheckBox1)
        Me.GroupBox1.Controls.Add(Me.CheckBox2)
        Me.GroupBox1.Location = New System.Drawing.Point(604, 15)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(117, 69)
        Me.GroupBox1.TabIndex = 10
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "快捷选择"
        '
        'CheckBox1
        '
        Me.CheckBox1.AutoSize = True
        Me.CheckBox1.Location = New System.Drawing.Point(12, 20)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(96, 16)
        Me.CheckBox1.TabIndex = 4
        Me.CheckBox1.Text = "外屋机器全选"
        Me.CheckBox1.UseVisualStyleBackColor = True
        '
        'CheckBox2
        '
        Me.CheckBox2.AutoSize = True
        Me.CheckBox2.Location = New System.Drawing.Point(12, 42)
        Me.CheckBox2.Name = "CheckBox2"
        Me.CheckBox2.Size = New System.Drawing.Size(96, 16)
        Me.CheckBox2.TabIndex = 5
        Me.CheckBox2.Text = "里屋机器全选"
        Me.CheckBox2.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Panel1.AutoScroll = True
        Me.Panel1.Controls.Add(Me.Outter)
        Me.Panel1.Controls.Add(Me.Inner)
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(596, 560)
        Me.Panel1.TabIndex = 3
        '
        'Outter
        '
        Me.Outter.Controls.Add(Me.CB_Standard1)
        Me.Outter.Controls.Add(Me.PB_Standard1)
        Me.Outter.Location = New System.Drawing.Point(14, 15)
        Me.Outter.Name = "Outter"
        Me.Outter.Size = New System.Drawing.Size(556, 555)
        Me.Outter.TabIndex = 1
        Me.Outter.TabStop = False
        Me.Outter.Text = "外屋"
        '
        'CB_Standard1
        '
        Me.CB_Standard1.AutoSize = True
        Me.CB_Standard1.Location = New System.Drawing.Point(28, 83)
        Me.CB_Standard1.Name = "CB_Standard1"
        Me.CB_Standard1.Size = New System.Drawing.Size(78, 16)
        Me.CB_Standard1.TabIndex = 2
        Me.CB_Standard1.Text = "CheckBox1"
        Me.CB_Standard1.UseVisualStyleBackColor = True
        '
        'PB_Standard1
        '
        Me.PB_Standard1.BackgroundImage = Global.System_Control.My.Resources.Resources.close
        Me.PB_Standard1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PB_Standard1.Location = New System.Drawing.Point(18, 20)
        Me.PB_Standard1.Name = "PB_Standard1"
        Me.PB_Standard1.Size = New System.Drawing.Size(58, 57)
        Me.PB_Standard1.TabIndex = 0
        Me.PB_Standard1.TabStop = False
        '
        'Inner
        '
        Me.Inner.Controls.Add(Me.CB_Standard2)
        Me.Inner.Controls.Add(Me.PB_Standard2)
        Me.Inner.Location = New System.Drawing.Point(14, 590)
        Me.Inner.Name = "Inner"
        Me.Inner.Size = New System.Drawing.Size(556, 466)
        Me.Inner.TabIndex = 2
        Me.Inner.TabStop = False
        Me.Inner.Text = "里屋"
        '
        'CB_Standard2
        '
        Me.CB_Standard2.AutoSize = True
        Me.CB_Standard2.Location = New System.Drawing.Point(27, 89)
        Me.CB_Standard2.Name = "CB_Standard2"
        Me.CB_Standard2.Size = New System.Drawing.Size(78, 16)
        Me.CB_Standard2.TabIndex = 2
        Me.CB_Standard2.Text = "CheckBox1"
        Me.CB_Standard2.UseVisualStyleBackColor = True
        '
        'PB_Standard2
        '
        Me.PB_Standard2.BackgroundImage = Global.System_Control.My.Resources.Resources.close
        Me.PB_Standard2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PB_Standard2.Location = New System.Drawing.Point(18, 23)
        Me.PB_Standard2.Name = "PB_Standard2"
        Me.PB_Standard2.Size = New System.Drawing.Size(58, 57)
        Me.PB_Standard2.TabIndex = 1
        Me.PB_Standard2.TabStop = False
        '
        'Computer_Remote
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(739, 573)
        Me.Controls.Add(Me.Computer_Remote_Panel)
        Me.DoubleBuffered = True
        Me.Name = "Computer_Remote"
        Me.Text = "Computer_Remote"
        Me.Computer_Remote_Panel.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Outter.ResumeLayout(False)
        Me.Outter.PerformLayout()
        CType(Me.PB_Standard1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Inner.ResumeLayout(False)
        Me.Inner.PerformLayout()
        CType(Me.PB_Standard2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Computer_Remote_Panel As System.Windows.Forms.Panel
    Friend WithEvents PB_Standard1 As System.Windows.Forms.PictureBox
    Friend WithEvents Outter As System.Windows.Forms.GroupBox
    Friend WithEvents Inner As System.Windows.Forms.GroupBox
    Friend WithEvents PB_Standard2 As System.Windows.Forms.PictureBox
    Friend WithEvents CB_Standard1 As System.Windows.Forms.CheckBox
    Friend WithEvents CB_Standard2 As System.Windows.Forms.CheckBox
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents CheckBox2 As System.Windows.Forms.CheckBox
    Friend WithEvents CheckBox1 As System.Windows.Forms.CheckBox
    Friend WithEvents BT_Start As System.Windows.Forms.Button
    Friend WithEvents BT_Logoff As System.Windows.Forms.Button
    Friend WithEvents BT_Restart As System.Windows.Forms.Button
    Friend WithEvents BT_Close As System.Windows.Forms.Button
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents IP_MAC As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
End Class
