<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class coursesinfo
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
        Me.welcomeinfo = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.CoursesInfoPanel = New System.Windows.Forms.Panel
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.CoursesInfoPanel.SuspendLayout()
        Me.SuspendLayout()
        '
        'welcomeinfo
        '
        Me.welcomeinfo.AutoSize = True
        Me.welcomeinfo.Font = New System.Drawing.Font("宋体", 25.0!)
        Me.welcomeinfo.Location = New System.Drawing.Point(105, 119)
        Me.welcomeinfo.Name = "welcomeinfo"
        Me.welcomeinfo.Size = New System.Drawing.Size(117, 34)
        Me.welcomeinfo.TabIndex = 0
        Me.welcomeinfo.Text = "Label1"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("宋体", 20.0!)
        Me.Label1.Location = New System.Drawing.Point(117, 196)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(66, 27)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "姓名"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("宋体", 20.0!)
        Me.Label2.Location = New System.Drawing.Point(117, 236)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(66, 27)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "学号"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("宋体", 20.0!)
        Me.Label3.Location = New System.Drawing.Point(117, 276)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(66, 27)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "院系"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("宋体", 20.0!)
        Me.Label4.Location = New System.Drawing.Point(117, 316)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(120, 27)
        Me.Label4.TabIndex = 4
        Me.Label4.Text = "硬件时间"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("宋体", 20.0!)
        Me.Label5.Location = New System.Drawing.Point(117, 356)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(120, 27)
        Me.Label5.TabIndex = 5
        Me.Label5.Text = "软件时间"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("宋体", 20.0!)
        Me.Label6.Location = New System.Drawing.Point(275, 196)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(96, 27)
        Me.Label6.TabIndex = 6
        Me.Label6.Text = "Label6"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("宋体", 20.0!)
        Me.Label7.Location = New System.Drawing.Point(275, 236)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(96, 27)
        Me.Label7.TabIndex = 7
        Me.Label7.Text = "Label7"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("宋体", 20.0!)
        Me.Label8.Location = New System.Drawing.Point(275, 276)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(96, 27)
        Me.Label8.TabIndex = 8
        Me.Label8.Text = "Label8"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("宋体", 20.0!)
        Me.Label9.Location = New System.Drawing.Point(275, 316)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(96, 27)
        Me.Label9.TabIndex = 9
        Me.Label9.Text = "Label9"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("宋体", 20.0!)
        Me.Label10.Location = New System.Drawing.Point(275, 356)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(110, 27)
        Me.Label10.TabIndex = 10
        Me.Label10.Text = "Label10"
        '
        'CoursesInfoPanel
        '
        Me.CoursesInfoPanel.BackColor = System.Drawing.Color.Transparent
        Me.CoursesInfoPanel.Controls.Add(Me.welcomeinfo)
        Me.CoursesInfoPanel.Controls.Add(Me.Label10)
        Me.CoursesInfoPanel.Controls.Add(Me.Label1)
        Me.CoursesInfoPanel.Controls.Add(Me.Label9)
        Me.CoursesInfoPanel.Controls.Add(Me.Label2)
        Me.CoursesInfoPanel.Controls.Add(Me.Label8)
        Me.CoursesInfoPanel.Controls.Add(Me.Label3)
        Me.CoursesInfoPanel.Controls.Add(Me.Label7)
        Me.CoursesInfoPanel.Controls.Add(Me.Label4)
        Me.CoursesInfoPanel.Controls.Add(Me.Label6)
        Me.CoursesInfoPanel.Controls.Add(Me.Label5)
        Me.CoursesInfoPanel.Location = New System.Drawing.Point(-1, 0)
        Me.CoursesInfoPanel.Name = "CoursesInfoPanel"
        Me.CoursesInfoPanel.Size = New System.Drawing.Size(728, 571)
        Me.CoursesInfoPanel.TabIndex = 11
        '
        'Timer1
        '
        '
        'coursesinfo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(956, 640)
        Me.Controls.Add(Me.CoursesInfoPanel)
        Me.DoubleBuffered = True
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(1000, 1000)
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(382, 212)
        Me.Name = "coursesinfo"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "选课信息查询"
        Me.CoursesInfoPanel.ResumeLayout(False)
        Me.CoursesInfoPanel.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents welcomeinfo As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents CoursesInfoPanel As System.Windows.Forms.Panel
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
End Class
