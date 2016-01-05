<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Info_Management_Frame
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
        Me.Info_Management_Tab = New Info_Management.TabControlEx_2
        Me.TabPage1 = New System.Windows.Forms.TabPage
        Me.TabPage2 = New System.Windows.Forms.TabPage
        Me.TabPage3 = New System.Windows.Forms.TabPage
        Me.Info_Management_Tab.SuspendLayout()
        Me.SuspendLayout()
        '
        'Info_Management_Tab
        '
        Me.Info_Management_Tab.Alignment = System.Windows.Forms.TabAlignment.Left
        Me.Info_Management_Tab.Controls.Add(Me.TabPage1)
        Me.Info_Management_Tab.Controls.Add(Me.TabPage2)
        Me.Info_Management_Tab.Controls.Add(Me.TabPage3)
        Me.Info_Management_Tab.ItemSize = New System.Drawing.Size(40, 170)
        Me.Info_Management_Tab.Location = New System.Drawing.Point(0, 0)
        Me.Info_Management_Tab.Margin = New System.Windows.Forms.Padding(0)
        Me.Info_Management_Tab.Multiline = True
        Me.Info_Management_Tab.Name = "Info_Management_Tab"
        Me.Info_Management_Tab.SelectedIndex = 0
        Me.Info_Management_Tab.Size = New System.Drawing.Size(905, 575)
        Me.Info_Management_Tab.SizeMode = System.Windows.Forms.TabSizeMode.Fixed
        Me.Info_Management_Tab.TabIndex = 0
        '
        'TabPage1
        '
        Me.TabPage1.BackColor = System.Drawing.Color.Transparent
        Me.TabPage1.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.TabPage1.Location = New System.Drawing.Point(174, 4)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(727, 567)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "用户信息管理"
        '
        'TabPage2
        '
        Me.TabPage2.BackColor = System.Drawing.Color.Transparent
        Me.TabPage2.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.TabPage2.Location = New System.Drawing.Point(174, 4)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(727, 567)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "个人信息管理"
        '
        'TabPage3
        '
        Me.TabPage3.BackColor = System.Drawing.Color.Transparent
        Me.TabPage3.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.TabPage3.Location = New System.Drawing.Point(174, 4)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage3.Size = New System.Drawing.Size(727, 567)
        Me.TabPage3.TabIndex = 2
        Me.TabPage3.Text = "空闲时间统计"
        '
        'Info_Management_Frame
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(997, 617)
        Me.Controls.Add(Me.Info_Management_Tab)
        Me.DoubleBuffered = True
        Me.Name = "Info_Management_Frame"
        Me.Text = "Info_Management_Frame"
        Me.Info_Management_Tab.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Info_Management_Tab As Info_Management.TabControlEx_2
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage3 As System.Windows.Forms.TabPage
End Class
