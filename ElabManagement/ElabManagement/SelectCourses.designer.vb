<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class selectcourses
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
        Me.LblStandard = New System.Windows.Forms.Label
        Me.PanelTime = New System.Windows.Forms.Panel
        Me.Label191 = New System.Windows.Forms.Label
        Me.lblinfo = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.lblhard = New System.Windows.Forms.Label
        Me.lblsoft = New System.Windows.Forms.Label
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.Label5 = New System.Windows.Forms.Label
        Me.SelectCoursesPanel = New System.Windows.Forms.Panel
        Me.quit = New System.Windows.Forms.Button
        Me.PanelTime.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SelectCoursesPanel.SuspendLayout()
        Me.SuspendLayout()
        '
        'LblStandard
        '
        Me.LblStandard.BackColor = System.Drawing.Color.FloralWhite
        Me.LblStandard.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LblStandard.Font = New System.Drawing.Font("宋体", 12.0!)
        Me.LblStandard.Location = New System.Drawing.Point(5, 6)
        Me.LblStandard.Name = "LblStandard"
        Me.LblStandard.Size = New System.Drawing.Size(87, 37)
        Me.LblStandard.TabIndex = 0
        Me.LblStandard.Text = "周\星期"
        Me.LblStandard.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'PanelTime
        '
        Me.PanelTime.BackColor = System.Drawing.Color.Transparent
        Me.PanelTime.Controls.Add(Me.LblStandard)
        Me.PanelTime.Location = New System.Drawing.Point(6, 46)
        Me.PanelTime.Name = "PanelTime"
        Me.PanelTime.Size = New System.Drawing.Size(717, 343)
        Me.PanelTime.TabIndex = 1
        '
        'Label191
        '
        Me.Label191.Font = New System.Drawing.Font("宋体", 23.0!)
        Me.Label191.Location = New System.Drawing.Point(28, 9)
        Me.Label191.Name = "Label191"
        Me.Label191.Size = New System.Drawing.Size(191, 31)
        Me.Label191.TabIndex = 6
        Me.Label191.Text = "课程信息"
        Me.Label191.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblinfo
        '
        Me.lblinfo.AutoSize = True
        Me.lblinfo.Font = New System.Drawing.Font("宋体", 12.0!)
        Me.lblinfo.Location = New System.Drawing.Point(5, 3)
        Me.lblinfo.Name = "lblinfo"
        Me.lblinfo.Size = New System.Drawing.Size(64, 16)
        Me.lblinfo.TabIndex = 0
        Me.lblinfo.Text = "lblinfo"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("宋体", 15.0!)
        Me.Label2.Location = New System.Drawing.Point(75, 29)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(169, 20)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "计算机安装与调试"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label3
        '
        Me.Label3.Font = New System.Drawing.Font("宋体", 15.0!)
        Me.Label3.Location = New System.Drawing.Point(404, 24)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(190, 30)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "计算机安装与调试"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblhard
        '
        Me.lblhard.Font = New System.Drawing.Font("宋体", 14.0!)
        Me.lblhard.Location = New System.Drawing.Point(56, 62)
        Me.lblhard.Name = "lblhard"
        Me.lblhard.Size = New System.Drawing.Size(188, 60)
        Me.lblhard.TabIndex = 11
        Me.lblhard.Text = "硬件拆装"
        Me.lblhard.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblsoft
        '
        Me.lblsoft.Font = New System.Drawing.Font("宋体", 14.0!)
        Me.lblsoft.Location = New System.Drawing.Point(404, 62)
        Me.lblsoft.Name = "lblsoft"
        Me.lblsoft.Size = New System.Drawing.Size(188, 60)
        Me.lblsoft.TabIndex = 11
        Me.lblsoft.Text = "软件安装"
        Me.lblsoft.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel1.Controls.Add(Me.lblinfo)
        Me.Panel1.Controls.Add(Me.lblsoft)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.lblhard)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Location = New System.Drawing.Point(25, 404)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(678, 141)
        Me.Panel1.TabIndex = 12
        '
        'ErrorProvider1
        '
        Me.ErrorProvider1.ContainerControl = Me
        '
        'ToolTip1
        '
        Me.ToolTip1.AutomaticDelay = 1000
        Me.ToolTip1.AutoPopDelay = 100000
        Me.ToolTip1.ForeColor = System.Drawing.SystemColors.WindowText
        Me.ToolTip1.InitialDelay = 1
        Me.ToolTip1.ReshowDelay = 1
        Me.ToolTip1.ShowAlways = True
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("宋体", 15.0!)
        Me.Label5.Location = New System.Drawing.Point(225, 14)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(329, 20)
        Me.Label5.TabIndex = 14
        Me.Label5.Text = "双击选课或调课，红色表示人数已满"
        '
        'SelectCoursesPanel
        '
        Me.SelectCoursesPanel.BackColor = System.Drawing.Color.Transparent
        Me.SelectCoursesPanel.Controls.Add(Me.Label191)
        Me.SelectCoursesPanel.Controls.Add(Me.Panel1)
        Me.SelectCoursesPanel.Controls.Add(Me.PanelTime)
        Me.SelectCoursesPanel.Controls.Add(Me.Label5)
        Me.SelectCoursesPanel.Location = New System.Drawing.Point(0, 0)
        Me.SelectCoursesPanel.Margin = New System.Windows.Forms.Padding(0)
        Me.SelectCoursesPanel.Name = "SelectCoursesPanel"
        Me.SelectCoursesPanel.Size = New System.Drawing.Size(728, 571)
        Me.SelectCoursesPanel.TabIndex = 18
        '
        'quit
        '
        Me.quit.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.quit.Location = New System.Drawing.Point(169, 3)
        Me.quit.Name = "quit"
        Me.quit.Size = New System.Drawing.Size(0, 0)
        Me.quit.TabIndex = 19
        Me.quit.Text = "quit"
        Me.quit.UseVisualStyleBackColor = True
        '
        'selectcourses
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.CancelButton = Me.quit
        Me.ClientSize = New System.Drawing.Size(866, 588)
        Me.Controls.Add(Me.quit)
        Me.Controls.Add(Me.SelectCoursesPanel)
        Me.DoubleBuffered = True
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(1200, 800)
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(876, 526)
        Me.Name = "selectcourses"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "选课系统"
        Me.PanelTime.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SelectCoursesPanel.ResumeLayout(False)
        Me.SelectCoursesPanel.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents LblStandard As System.Windows.Forms.Label
    Friend WithEvents PanelTime As System.Windows.Forms.Panel
    Friend WithEvents Label191 As System.Windows.Forms.Label
    Friend WithEvents lblinfo As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents lblhard As System.Windows.Forms.Label
    Friend WithEvents lblsoft As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
    Public WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Public WithEvents SelectCoursesPanel As System.Windows.Forms.Panel
    Friend WithEvents quit As System.Windows.Forms.Button

End Class
