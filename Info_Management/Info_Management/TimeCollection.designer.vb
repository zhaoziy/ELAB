<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class TimeCollection
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
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.Label1 = New System.Windows.Forms.Label
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.SaveButton = New System.Windows.Forms.Button
        Me.ListBox1 = New System.Windows.Forms.ListBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.ListBox2 = New System.Windows.Forms.ListBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.out = New System.Windows.Forms.Button
        Me.Panel2 = New System.Windows.Forms.Panel
        Me.btAutoArrangeAssist = New System.Windows.Forms.Button
        Me.btAutoArrangeDuty = New System.Windows.Forms.Button
        Me.btDelete = New System.Windows.Forms.Button
        Me.BTRefresh = New System.Windows.Forms.Button
        Me.Button1 = New System.Windows.Forms.Button
        Me.TextBox1 = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'LblStandard
        '
        Me.LblStandard.BackColor = System.Drawing.Color.DodgerBlue
        Me.LblStandard.Location = New System.Drawing.Point(2, 2)
        Me.LblStandard.Name = "LblStandard"
        Me.LblStandard.Size = New System.Drawing.Size(71, 55)
        Me.LblStandard.TabIndex = 0
        Me.LblStandard.Text = "Label1"
        Me.LblStandard.Visible = False
        '
        'PanelTime
        '
        Me.PanelTime.AutoScroll = True
        Me.PanelTime.Location = New System.Drawing.Point(51, 130)
        Me.PanelTime.Name = "PanelTime"
        Me.PanelTime.Size = New System.Drawing.Size(674, 499)
        Me.PanelTime.TabIndex = 1
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.LblStandard)
        Me.Panel1.Location = New System.Drawing.Point(51, 12)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(674, 117)
        Me.Panel1.TabIndex = 2
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(0, 5)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(41, 12)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Label1"
        '
        'SaveButton
        '
        Me.SaveButton.Location = New System.Drawing.Point(15, 12)
        Me.SaveButton.Name = "SaveButton"
        Me.SaveButton.Size = New System.Drawing.Size(67, 23)
        Me.SaveButton.TabIndex = 3
        Me.SaveButton.Text = "保存"
        Me.SaveButton.UseVisualStyleBackColor = True
        '
        'ListBox1
        '
        Me.ListBox1.FormattingEnabled = True
        Me.ListBox1.ItemHeight = 12
        Me.ListBox1.Location = New System.Drawing.Point(15, 191)
        Me.ListBox1.Name = "ListBox1"
        Me.ListBox1.Size = New System.Drawing.Size(146, 244)
        Me.ListBox1.TabIndex = 4
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(13, 172)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(41, 12)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "已填写"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(13, 438)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(41, 12)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "未填写"
        '
        'ListBox2
        '
        Me.ListBox2.FormattingEnabled = True
        Me.ListBox2.ItemHeight = 12
        Me.ListBox2.Location = New System.Drawing.Point(15, 453)
        Me.ListBox2.Name = "ListBox2"
        Me.ListBox2.Size = New System.Drawing.Size(146, 244)
        Me.ListBox2.TabIndex = 7
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("宋体", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label4.Location = New System.Drawing.Point(11, 140)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(109, 20)
        Me.Label4.TabIndex = 8
        Me.Label4.Text = "当前显示："
        '
        'out
        '
        Me.out.Location = New System.Drawing.Point(99, 12)
        Me.out.Name = "out"
        Me.out.Size = New System.Drawing.Size(67, 23)
        Me.out.TabIndex = 9
        Me.out.Text = "输出"
        Me.out.UseVisualStyleBackColor = True
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.btAutoArrangeAssist)
        Me.Panel2.Controls.Add(Me.btAutoArrangeDuty)
        Me.Panel2.Controls.Add(Me.btDelete)
        Me.Panel2.Controls.Add(Me.BTRefresh)
        Me.Panel2.Controls.Add(Me.SaveButton)
        Me.Panel2.Controls.Add(Me.out)
        Me.Panel2.Controls.Add(Me.ListBox1)
        Me.Panel2.Controls.Add(Me.Label4)
        Me.Panel2.Controls.Add(Me.Label2)
        Me.Panel2.Controls.Add(Me.ListBox2)
        Me.Panel2.Controls.Add(Me.Label3)
        Me.Panel2.Location = New System.Drawing.Point(727, 10)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(192, 728)
        Me.Panel2.TabIndex = 10
        '
        'btAutoArrangeAssist
        '
        Me.btAutoArrangeAssist.Location = New System.Drawing.Point(15, 105)
        Me.btAutoArrangeAssist.Name = "btAutoArrangeAssist"
        Me.btAutoArrangeAssist.Size = New System.Drawing.Size(105, 23)
        Me.btAutoArrangeAssist.TabIndex = 13
        Me.btAutoArrangeAssist.Text = "自动安排助课"
        Me.btAutoArrangeAssist.UseVisualStyleBackColor = True
        '
        'btAutoArrangeDuty
        '
        Me.btAutoArrangeDuty.Location = New System.Drawing.Point(15, 74)
        Me.btAutoArrangeDuty.Name = "btAutoArrangeDuty"
        Me.btAutoArrangeDuty.Size = New System.Drawing.Size(105, 23)
        Me.btAutoArrangeDuty.TabIndex = 12
        Me.btAutoArrangeDuty.Text = "自动安排值班"
        Me.btAutoArrangeDuty.UseVisualStyleBackColor = True
        '
        'btDelete
        '
        Me.btDelete.Location = New System.Drawing.Point(99, 43)
        Me.btDelete.Name = "btDelete"
        Me.btDelete.Size = New System.Drawing.Size(67, 23)
        Me.btDelete.TabIndex = 11
        Me.btDelete.Text = "批量清除"
        Me.btDelete.UseVisualStyleBackColor = True
        '
        'BTRefresh
        '
        Me.BTRefresh.Location = New System.Drawing.Point(15, 43)
        Me.BTRefresh.Name = "BTRefresh"
        Me.BTRefresh.Size = New System.Drawing.Size(67, 23)
        Me.BTRefresh.TabIndex = 10
        Me.BTRefresh.Text = "刷新"
        Me.BTRefresh.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(637, 658)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 11
        Me.Button1.Text = "保存"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(51, 658)
        Me.TextBox1.Multiline = True
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(553, 80)
        Me.TextBox1.TabIndex = 12
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(52, 638)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(269, 12)
        Me.Label5.TabIndex = 13
        Me.Label5.Text = "备注：（时间不确定的或其他问题，可在此留言）"
        '
        'TimeCollection
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(923, 750)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.PanelTime)
        Me.DoubleBuffered = True
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(939, 800)
        Me.MinimumSize = New System.Drawing.Size(100, 672)
        Me.Name = "TimeCollection"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "空闲时间统计"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents LblStandard As System.Windows.Forms.Label
    Friend WithEvents PanelTime As System.Windows.Forms.Panel
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents SaveButton As System.Windows.Forms.Button
    Friend WithEvents ListBox1 As System.Windows.Forms.ListBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents ListBox2 As System.Windows.Forms.ListBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents out As System.Windows.Forms.Button
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents BTRefresh As System.Windows.Forms.Button
    Friend WithEvents btDelete As System.Windows.Forms.Button
    Friend WithEvents btAutoArrangeDuty As System.Windows.Forms.Button
    Friend WithEvents btAutoArrangeAssist As System.Windows.Forms.Button
End Class
