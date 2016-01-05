<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SelectDate
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
        Me.PanelTime = New System.Windows.Forms.Panel
        Me.TextStandard_Assist = New System.Windows.Forms.TextBox
        Me.TextStandard = New System.Windows.Forms.TextBox
        Me.LblStandard = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.Button1 = New System.Windows.Forms.Button
        Me.PanelTime.SuspendLayout()
        Me.SuspendLayout()
        '
        'PanelTime
        '
        Me.PanelTime.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.PanelTime.Controls.Add(Me.TextStandard_Assist)
        Me.PanelTime.Controls.Add(Me.TextStandard)
        Me.PanelTime.Controls.Add(Me.LblStandard)
        Me.PanelTime.Location = New System.Drawing.Point(22, 57)
        Me.PanelTime.Name = "PanelTime"
        Me.PanelTime.Size = New System.Drawing.Size(819, 650)
        Me.PanelTime.TabIndex = 0
        '
        'TextStandard_Assist
        '
        Me.TextStandard_Assist.Location = New System.Drawing.Point(58, 50)
        Me.TextStandard_Assist.Name = "TextStandard_Assist"
        Me.TextStandard_Assist.Size = New System.Drawing.Size(35, 21)
        Me.TextStandard_Assist.TabIndex = 2
        '
        'TextStandard
        '
        Me.TextStandard.BackColor = System.Drawing.Color.White
        Me.TextStandard.Location = New System.Drawing.Point(17, 50)
        Me.TextStandard.MaxLength = 1
        Me.TextStandard.Name = "TextStandard"
        Me.TextStandard.Size = New System.Drawing.Size(35, 21)
        Me.TextStandard.TabIndex = 1
        '
        'LblStandard
        '
        Me.LblStandard.BackColor = System.Drawing.SystemColors.Highlight
        Me.LblStandard.Font = New System.Drawing.Font("微软雅黑", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.LblStandard.Location = New System.Drawing.Point(5, 6)
        Me.LblStandard.Name = "LblStandard"
        Me.LblStandard.Size = New System.Drawing.Size(101, 41)
        Me.LblStandard.TabIndex = 0
        Me.LblStandard.Text = "周\星期"
        Me.LblStandard.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("宋体", 23.0!)
        Me.Label2.Location = New System.Drawing.Point(56, 15)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(138, 31)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "上课日期"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("微软雅黑", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label3.Location = New System.Drawing.Point(210, 20)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(532, 27)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "双击可修改可否选课，左文本框中为课容量，右为助教容量"
        '
        'Button1
        '
        Me.Button1.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Button1.Font = New System.Drawing.Font("微软雅黑", 12.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Button1.Location = New System.Drawing.Point(672, 719)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(107, 44)
        Me.Button1.TabIndex = 3
        Me.Button1.Text = "关闭"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'SelectDate
        '
        Me.AcceptButton = Me.Button1
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.Button1
        Me.ClientSize = New System.Drawing.Size(863, 774)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.PanelTime)
        Me.DoubleBuffered = True
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(879, 813)
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(879, 813)
        Me.Name = "SelectDate"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "指定上课日期"
        Me.PanelTime.ResumeLayout(False)
        Me.PanelTime.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents PanelTime As System.Windows.Forms.Panel
    Friend WithEvents LblStandard As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents TextStandard As System.Windows.Forms.TextBox
    Friend WithEvents TextStandard_Assist As System.Windows.Forms.TextBox
End Class
