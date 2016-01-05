<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class scorecaculate
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
        Me.chongzhi = New System.Windows.Forms.Button
        Me.daochuwj = New System.Windows.Forms.Button
        Me.lilun = New System.Windows.Forms.Label
        Me.yingjian = New System.Windows.Forms.Label
        Me.ruanjian = New System.Windows.Forms.Label
        Me.shijuan = New System.Windows.Forms.Label
        Me.TextBox1 = New System.Windows.Forms.TextBox
        Me.TextBox2 = New System.Windows.Forms.TextBox
        Me.TextBox3 = New System.Windows.Forms.TextBox
        Me.TextBox4 = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Quit = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'chongzhi
        '
        Me.chongzhi.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.chongzhi.Location = New System.Drawing.Point(36, 156)
        Me.chongzhi.Name = "chongzhi"
        Me.chongzhi.Size = New System.Drawing.Size(65, 25)
        Me.chongzhi.TabIndex = 5
        Me.chongzhi.Text = "重置"
        Me.chongzhi.UseVisualStyleBackColor = True
        '
        'daochuwj
        '
        Me.daochuwj.Location = New System.Drawing.Point(136, 156)
        Me.daochuwj.Name = "daochuwj"
        Me.daochuwj.Size = New System.Drawing.Size(65, 25)
        Me.daochuwj.TabIndex = 4
        Me.daochuwj.Text = "导出"
        Me.daochuwj.UseVisualStyleBackColor = True
        '
        'lilun
        '
        Me.lilun.AutoSize = True
        Me.lilun.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.lilun.Location = New System.Drawing.Point(33, 24)
        Me.lilun.Name = "lilun"
        Me.lilun.Size = New System.Drawing.Size(56, 16)
        Me.lilun.TabIndex = 6
        Me.lilun.Text = "理论课"
        '
        'yingjian
        '
        Me.yingjian.AutoSize = True
        Me.yingjian.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.yingjian.Location = New System.Drawing.Point(33, 54)
        Me.yingjian.Name = "yingjian"
        Me.yingjian.Size = New System.Drawing.Size(56, 16)
        Me.yingjian.TabIndex = 7
        Me.yingjian.Text = "硬件课"
        '
        'ruanjian
        '
        Me.ruanjian.AutoSize = True
        Me.ruanjian.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.ruanjian.Location = New System.Drawing.Point(33, 84)
        Me.ruanjian.Name = "ruanjian"
        Me.ruanjian.Size = New System.Drawing.Size(56, 16)
        Me.ruanjian.TabIndex = 8
        Me.ruanjian.Text = "软件课"
        '
        'shijuan
        '
        Me.shijuan.AutoSize = True
        Me.shijuan.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.shijuan.Location = New System.Drawing.Point(33, 114)
        Me.shijuan.Name = "shijuan"
        Me.shijuan.Size = New System.Drawing.Size(56, 16)
        Me.shijuan.TabIndex = 9
        Me.shijuan.Text = "试  卷"
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(95, 19)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(89, 21)
        Me.TextBox1.TabIndex = 0
        '
        'TextBox2
        '
        Me.TextBox2.Location = New System.Drawing.Point(95, 49)
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Size = New System.Drawing.Size(89, 21)
        Me.TextBox2.TabIndex = 1
        '
        'TextBox3
        '
        Me.TextBox3.Location = New System.Drawing.Point(95, 79)
        Me.TextBox3.Name = "TextBox3"
        Me.TextBox3.Size = New System.Drawing.Size(89, 21)
        Me.TextBox3.TabIndex = 2
        '
        'TextBox4
        '
        Me.TextBox4.Location = New System.Drawing.Point(95, 109)
        Me.TextBox4.Name = "TextBox4"
        Me.TextBox4.Size = New System.Drawing.Size(89, 21)
        Me.TextBox4.TabIndex = 3
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(190, 28)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(11, 12)
        Me.Label1.TabIndex = 12
        Me.Label1.Text = "%"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(190, 58)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(11, 12)
        Me.Label2.TabIndex = 13
        Me.Label2.Text = "%"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(190, 88)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(11, 12)
        Me.Label3.TabIndex = 14
        Me.Label3.Text = "%"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(190, 118)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(11, 12)
        Me.Label4.TabIndex = 15
        Me.Label4.Text = "%"
        '
        'Quit
        '
        Me.Quit.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Quit.Location = New System.Drawing.Point(228, 14)
        Me.Quit.Name = "Quit"
        Me.Quit.Size = New System.Drawing.Size(0, 0)
        Me.Quit.TabIndex = 16
        Me.Quit.Text = "Button1"
        Me.Quit.UseVisualStyleBackColor = True
        '
        'scorecaculate
        '
        Me.AcceptButton = Me.daochuwj
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.Quit
        Me.ClientSize = New System.Drawing.Size(234, 201)
        Me.Controls.Add(Me.Quit)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.TextBox4)
        Me.Controls.Add(Me.TextBox3)
        Me.Controls.Add(Me.TextBox2)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.shijuan)
        Me.Controls.Add(Me.ruanjian)
        Me.Controls.Add(Me.yingjian)
        Me.Controls.Add(Me.lilun)
        Me.Controls.Add(Me.daochuwj)
        Me.Controls.Add(Me.chongzhi)
        Me.DoubleBuffered = True
        Me.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(250, 240)
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(250, 240)
        Me.Name = "scorecaculate"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "成绩统计"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents chongzhi As System.Windows.Forms.Button
    Friend WithEvents daochuwj As System.Windows.Forms.Button
    Friend WithEvents lilun As System.Windows.Forms.Label
    Friend WithEvents yingjian As System.Windows.Forms.Label
    Friend WithEvents ruanjian As System.Windows.Forms.Label
    Friend WithEvents shijuan As System.Windows.Forms.Label
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox2 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox3 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox4 As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Quit As System.Windows.Forms.Button
End Class
