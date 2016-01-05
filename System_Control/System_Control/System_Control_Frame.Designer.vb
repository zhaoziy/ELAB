<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class System_Control_Frame
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
        Me.TabPage5 = New System.Windows.Forms.TabPage
        Me.TabPage4 = New System.Windows.Forms.TabPage
        Me.TabPage3 = New System.Windows.Forms.TabPage
        Me.TabPage2 = New System.Windows.Forms.TabPage
        Me.TabPage1 = New System.Windows.Forms.TabPage
        Me.System_Control_Tab = New System_Control.TabControlEx_2
        Me.System_Control_Tab.SuspendLayout()
        Me.SuspendLayout()
        '
        'TabPage5
        '
        Me.TabPage5.BackColor = System.Drawing.Color.Transparent
        Me.TabPage5.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.TabPage5.Location = New System.Drawing.Point(174, 4)
        Me.TabPage5.Name = "TabPage5"
        Me.TabPage5.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage5.Size = New System.Drawing.Size(727, 567)
        Me.TabPage5.TabIndex = 5
        Me.TabPage5.Text = "重要通知"
        '
        'TabPage4
        '
        Me.TabPage4.BackColor = System.Drawing.Color.Transparent
        Me.TabPage4.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.TabPage4.Location = New System.Drawing.Point(174, 4)
        Me.TabPage4.Name = "TabPage4"
        Me.TabPage4.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage4.Size = New System.Drawing.Size(727, 567)
        Me.TabPage4.TabIndex = 4
        Me.TabPage4.Text = "局域网远程控制"
        '
        'TabPage3
        '
        Me.TabPage3.BackColor = System.Drawing.Color.Transparent
        Me.TabPage3.Location = New System.Drawing.Point(174, 4)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage3.Size = New System.Drawing.Size(727, 567)
        Me.TabPage3.TabIndex = 3
        Me.TabPage3.Text = "指定管理员"
        '
        'TabPage2
        '
        Me.TabPage2.BackColor = System.Drawing.Color.Transparent
        Me.TabPage2.Location = New System.Drawing.Point(174, 4)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(727, 567)
        Me.TabPage2.TabIndex = 2
        Me.TabPage2.Text = "指定非选课时间"
        '
        'TabPage1
        '
        Me.TabPage1.BackColor = System.Drawing.Color.Transparent
        Me.TabPage1.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.TabPage1.Location = New System.Drawing.Point(174, 4)
        Me.TabPage1.Margin = New System.Windows.Forms.Padding(0)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Size = New System.Drawing.Size(727, 567)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Log信息查看"
        '
        'System_Control_Tab
        '
        Me.System_Control_Tab.Alignment = System.Windows.Forms.TabAlignment.Left
        Me.System_Control_Tab.Controls.Add(Me.TabPage1)
        Me.System_Control_Tab.Controls.Add(Me.TabPage2)
        Me.System_Control_Tab.Controls.Add(Me.TabPage3)
        Me.System_Control_Tab.Controls.Add(Me.TabPage4)
        Me.System_Control_Tab.Controls.Add(Me.TabPage5)
        Me.System_Control_Tab.ItemSize = New System.Drawing.Size(40, 170)
        Me.System_Control_Tab.Location = New System.Drawing.Point(0, 0)
        Me.System_Control_Tab.Margin = New System.Windows.Forms.Padding(0)
        Me.System_Control_Tab.Multiline = True
        Me.System_Control_Tab.Name = "System_Control_Tab"
        Me.System_Control_Tab.SelectedIndex = 0
        Me.System_Control_Tab.Size = New System.Drawing.Size(905, 575)
        Me.System_Control_Tab.SizeMode = System.Windows.Forms.TabSizeMode.Fixed
        Me.System_Control_Tab.TabIndex = 0
        '
        'System_Control_Frame
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(929, 598)
        Me.Controls.Add(Me.System_Control_Tab)
        Me.DoubleBuffered = True
        Me.Name = "System_Control_Frame"
        Me.Text = "Form2"
        Me.System_Control_Tab.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TabPage5 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage4 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage3 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents System_Control_Tab As System_Control.TabControlEx_2
End Class
