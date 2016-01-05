<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SheetOut
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
        Me.Button1 = New System.Windows.Forms.Button
        Me.Button2 = New System.Windows.Forms.Button
        Me.NumericUpDown1 = New System.Windows.Forms.NumericUpDown
        Me.NumericUpDown2 = New System.Windows.Forms.NumericUpDown
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Button3 = New System.Windows.Forms.Button
        Me.Button4 = New System.Windows.Forms.Button
        Me.Button5 = New System.Windows.Forms.Button
        Me.Button6 = New System.Windows.Forms.Button
        CType(Me.NumericUpDown1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NumericUpDown2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(21, 94)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(173, 23)
        Me.Button1.TabIndex = 0
        Me.Button1.Text = "助课空闲时间输出（分页）"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(214, 94)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(133, 23)
        Me.Button2.TabIndex = 1
        Me.Button2.Text = "值班空闲时间输出"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'NumericUpDown1
        '
        Me.NumericUpDown1.Location = New System.Drawing.Point(147, 44)
        Me.NumericUpDown1.Maximum = New Decimal(New Integer() {20, 0, 0, 0})
        Me.NumericUpDown1.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.NumericUpDown1.Name = "NumericUpDown1"
        Me.NumericUpDown1.Size = New System.Drawing.Size(38, 21)
        Me.NumericUpDown1.TabIndex = 2
        Me.NumericUpDown1.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'NumericUpDown2
        '
        Me.NumericUpDown2.Location = New System.Drawing.Point(253, 44)
        Me.NumericUpDown2.Maximum = New Decimal(New Integer() {20, 0, 0, 0})
        Me.NumericUpDown2.Minimum = New Decimal(New Integer() {2, 0, 0, 0})
        Me.NumericUpDown2.Name = "NumericUpDown2"
        Me.NumericUpDown2.Size = New System.Drawing.Size(38, 21)
        Me.NumericUpDown2.TabIndex = 3
        Me.NumericUpDown2.Value = New Decimal(New Integer() {2, 0, 0, 0})
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(64, 48)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(77, 12)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "输出范围：第"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(194, 48)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(53, 12)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "周——第"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(297, 48)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(17, 12)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "周"
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(21, 134)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(173, 23)
        Me.Button3.TabIndex = 7
        Me.Button3.Text = "助课空闲时间输出（不分页）"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'Button4
        '
        Me.Button4.Location = New System.Drawing.Point(214, 134)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(133, 23)
        Me.Button4.TabIndex = 8
        Me.Button4.Text = "总表输出"
        Me.Button4.UseVisualStyleBackColor = True
        '
        'Button5
        '
        Me.Button5.Location = New System.Drawing.Point(21, 174)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(173, 23)
        Me.Button5.TabIndex = 9
        Me.Button5.Text = "助课安排输出"
        Me.Button5.UseVisualStyleBackColor = True
        '
        'Button6
        '
        Me.Button6.Location = New System.Drawing.Point(214, 174)
        Me.Button6.Name = "Button6"
        Me.Button6.Size = New System.Drawing.Size(133, 23)
        Me.Button6.TabIndex = 10
        Me.Button6.Text = "值班安排输出"
        Me.Button6.UseVisualStyleBackColor = True
        '
        'SheetOut
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(375, 226)
        Me.Controls.Add(Me.Button6)
        Me.Controls.Add(Me.Button5)
        Me.Controls.Add(Me.Button4)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.NumericUpDown2)
        Me.Controls.Add(Me.NumericUpDown1)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.DoubleBuffered = True
        Me.MaximizeBox = False
        Me.Name = "SheetOut"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "输出"
        CType(Me.NumericUpDown1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NumericUpDown2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents NumericUpDown1 As System.Windows.Forms.NumericUpDown
    Friend WithEvents NumericUpDown2 As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents Button4 As System.Windows.Forms.Button
    Friend WithEvents Button5 As System.Windows.Forms.Button
    Friend WithEvents Button6 As System.Windows.Forms.Button
End Class
