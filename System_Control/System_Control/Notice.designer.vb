<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Notice
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
        Me.Label1 = New System.Windows.Forms.Label
        Me.TextBox1 = New System.Windows.Forms.TextBox
        Me.Button1 = New System.Windows.Forms.Button
        Me.Button2 = New System.Windows.Forms.Button
        Me.Notice_Panel = New System.Windows.Forms.Panel
        Me.Notice_Panel.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("宋体", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label1.Location = New System.Drawing.Point(28, 18)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(275, 19)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "通知：直接填写通知，前台显示"
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(30, 53)
        Me.TextBox1.Multiline = True
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(660, 435)
        Me.TextBox1.TabIndex = 1
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(246, 512)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(67, 25)
        Me.Button1.TabIndex = 2
        Me.Button1.Text = "保存"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(381, 512)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(67, 25)
        Me.Button2.TabIndex = 3
        Me.Button2.Text = "取消显示"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Notice_Panel
        '
        Me.Notice_Panel.Controls.Add(Me.Label1)
        Me.Notice_Panel.Controls.Add(Me.TextBox1)
        Me.Notice_Panel.Controls.Add(Me.Button2)
        Me.Notice_Panel.Controls.Add(Me.Button1)
        Me.Notice_Panel.Location = New System.Drawing.Point(0, 0)
        Me.Notice_Panel.Margin = New System.Windows.Forms.Padding(0)
        Me.Notice_Panel.Name = "Notice_Panel"
        Me.Notice_Panel.Size = New System.Drawing.Size(728, 560)
        Me.Notice_Panel.TabIndex = 5
        '
        'Notice
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(885, 613)
        Me.Controls.Add(Me.Notice_Panel)
        Me.DoubleBuffered = True
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(1000, 1000)
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(276, 343)
        Me.Name = "Notice"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "通知编辑框"
        Me.Notice_Panel.ResumeLayout(False)
        Me.Notice_Panel.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Notice_Panel As System.Windows.Forms.Panel
End Class
