<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SetupPack
    Inherits System.Windows.Forms.Form

    'Form 重写 Dispose，以清理组件列表。
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Windows 窗体设计器所必需的
    Private components As System.ComponentModel.IContainer

    '注意: 以下过程是 Windows 窗体设计器所必需的
    '可以使用 Windows 窗体设计器修改它。
    '不要使用代码编辑器修改它。
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(SetupPack))
        Me.ButSetup = New System.Windows.Forms.Button
        Me.ButExit = New System.Windows.Forms.Button
        Me.CheckDeskTop_Elab = New System.Windows.Forms.CheckBox
        Me.LabState = New System.Windows.Forms.Label
        Me.Timer = New System.Windows.Forms.Timer(Me.components)
        Me.CheckDeskTop_Sign = New System.Windows.Forms.CheckBox
        Me.CheckStart = New System.Windows.Forms.CheckBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.But_Fin = New System.Windows.Forms.Button
        Me.Panel = New System.Windows.Forms.Panel
        Me.Panel.SuspendLayout()
        Me.SuspendLayout()
        '
        'ButSetup
        '
        Me.ButSetup.Location = New System.Drawing.Point(68, 141)
        Me.ButSetup.Name = "ButSetup"
        Me.ButSetup.Size = New System.Drawing.Size(67, 33)
        Me.ButSetup.TabIndex = 0
        Me.ButSetup.Text = "安装程序"
        Me.ButSetup.UseVisualStyleBackColor = True
        '
        'ButExit
        '
        Me.ButExit.Location = New System.Drawing.Point(179, 141)
        Me.ButExit.Name = "ButExit"
        Me.ButExit.Size = New System.Drawing.Size(67, 33)
        Me.ButExit.TabIndex = 1
        Me.ButExit.Text = "退出安装"
        Me.ButExit.UseVisualStyleBackColor = True
        '
        'CheckDeskTop_Elab
        '
        Me.CheckDeskTop_Elab.AutoSize = True
        Me.CheckDeskTop_Elab.Checked = True
        Me.CheckDeskTop_Elab.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CheckDeskTop_Elab.Location = New System.Drawing.Point(78, 90)
        Me.CheckDeskTop_Elab.Name = "CheckDeskTop_Elab"
        Me.CheckDeskTop_Elab.Size = New System.Drawing.Size(240, 16)
        Me.CheckDeskTop_Elab.TabIndex = 4
        Me.CheckDeskTop_Elab.Text = "添加科中管理系统到桌面快捷方式(推荐)"
        Me.CheckDeskTop_Elab.UseVisualStyleBackColor = True
        '
        'LabState
        '
        Me.LabState.AutoSize = True
        Me.LabState.BackColor = System.Drawing.SystemColors.Control
        Me.LabState.Font = New System.Drawing.Font("幼圆", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.LabState.ForeColor = System.Drawing.SystemColors.ControlText
        Me.LabState.Location = New System.Drawing.Point(45, 22)
        Me.LabState.Name = "LabState"
        Me.LabState.Size = New System.Drawing.Size(80, 16)
        Me.LabState.TabIndex = 6
        Me.LabState.Text = "LabState"
        Me.LabState.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Timer
        '
        Me.Timer.Interval = 1000
        '
        'CheckDeskTop_Sign
        '
        Me.CheckDeskTop_Sign.AutoSize = True
        Me.CheckDeskTop_Sign.Checked = True
        Me.CheckDeskTop_Sign.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CheckDeskTop_Sign.Location = New System.Drawing.Point(78, 112)
        Me.CheckDeskTop_Sign.Name = "CheckDeskTop_Sign"
        Me.CheckDeskTop_Sign.Size = New System.Drawing.Size(216, 16)
        Me.CheckDeskTop_Sign.TabIndex = 9
        Me.CheckDeskTop_Sign.Text = "添加签到功能到桌面快捷方式(推荐)"
        Me.CheckDeskTop_Sign.UseVisualStyleBackColor = True
        '
        'CheckStart
        '
        Me.CheckStart.AutoSize = True
        Me.CheckStart.Location = New System.Drawing.Point(78, 68)
        Me.CheckStart.Name = "CheckStart"
        Me.CheckStart.Size = New System.Drawing.Size(156, 16)
        Me.CheckStart.TabIndex = 5
        Me.CheckStart.Text = "安装完成后自动运行程序"
        Me.CheckStart.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(15, 203)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(341, 12)
        Me.Label1.TabIndex = 8
        Me.Label1.Text = "程序将默认安装在""D:\Program Files\科中管理系统\""文件夹下"
        '
        'But_Fin
        '
        Me.But_Fin.Enabled = False
        Me.But_Fin.Location = New System.Drawing.Point(264, 21)
        Me.But_Fin.Name = "But_Fin"
        Me.But_Fin.Size = New System.Drawing.Size(47, 23)
        Me.But_Fin.TabIndex = 10
        Me.But_Fin.Text = "完成"
        Me.But_Fin.UseVisualStyleBackColor = True
        '
        'Panel
        '
        Me.Panel.Controls.Add(Me.But_Fin)
        Me.Panel.Controls.Add(Me.CheckDeskTop_Sign)
        Me.Panel.Controls.Add(Me.LabState)
        Me.Panel.Controls.Add(Me.CheckStart)
        Me.Panel.Controls.Add(Me.CheckDeskTop_Elab)
        Me.Panel.Controls.Add(Me.ButExit)
        Me.Panel.Controls.Add(Me.ButSetup)
        Me.Panel.Enabled = False
        Me.Panel.Location = New System.Drawing.Point(26, 12)
        Me.Panel.Name = "Panel"
        Me.Panel.Size = New System.Drawing.Size(344, 181)
        Me.Panel.TabIndex = 7
        '
        'SetupPack
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(385, 230)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Panel)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "SetupPack"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "SetupPack"
        Me.Panel.ResumeLayout(False)
        Me.Panel.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ButSetup As System.Windows.Forms.Button
    Friend WithEvents ButExit As System.Windows.Forms.Button
    Friend WithEvents CheckDeskTop_Elab As System.Windows.Forms.CheckBox
    Friend WithEvents LabState As System.Windows.Forms.Label
    Friend WithEvents Timer As System.Windows.Forms.Timer
    Friend WithEvents CheckStart As System.Windows.Forms.CheckBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents CheckDeskTop_Sign As System.Windows.Forms.CheckBox
    Friend WithEvents But_Fin As System.Windows.Forms.Button
    Friend WithEvents Panel As System.Windows.Forms.Panel

End Class
