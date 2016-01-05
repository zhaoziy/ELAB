<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Auto_Submit
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
        Me.WebBrowser1 = New System.Windows.Forms.WebBrowser
        Me.Button1 = New System.Windows.Forms.Button
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog
        Me.Button2 = New System.Windows.Forms.Button
        Me.Button3 = New System.Windows.Forms.Button
        Me.Button4 = New System.Windows.Forms.Button
        Me.ComboBox1 = New System.Windows.Forms.ComboBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.Auto_Submit_Panel = New System.Windows.Forms.Panel
        Me.Auto_Submit_Panel.SuspendLayout()
        Me.SuspendLayout()
        '
        'WebBrowser1
        '
        Me.WebBrowser1.Location = New System.Drawing.Point(10, 49)
        Me.WebBrowser1.MinimumSize = New System.Drawing.Size(20, 20)
        Me.WebBrowser1.Name = "WebBrowser1"
        Me.WebBrowser1.Size = New System.Drawing.Size(709, 509)
        Me.WebBrowser1.TabIndex = 0
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(567, 13)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(111, 30)
        Me.Button1.TabIndex = 1
        Me.Button1.Text = "自动填写"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(59, 13)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(64, 30)
        Me.Button2.TabIndex = 2
        Me.Button2.Text = "后退"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(145, 13)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(63, 30)
        Me.Button3.TabIndex = 3
        Me.Button3.Text = "刷新"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'Button4
        '
        Me.Button4.Location = New System.Drawing.Point(235, 13)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(67, 30)
        Me.Button4.TabIndex = 4
        Me.Button4.Text = "前进"
        Me.Button4.UseVisualStyleBackColor = True
        '
        'ComboBox1
        '
        Me.ComboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox1.FormattingEnabled = True
        Me.ComboBox1.Items.AddRange(New Object() {"实验成绩", "实践成绩"})
        Me.ComboBox1.Location = New System.Drawing.Point(395, 17)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(121, 20)
        Me.ComboBox1.TabIndex = 5
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(336, 22)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(53, 12)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = "科目选择"
        '
        'Auto_Submit_Panel
        '
        Me.Auto_Submit_Panel.Controls.Add(Me.Button2)
        Me.Auto_Submit_Panel.Controls.Add(Me.Label1)
        Me.Auto_Submit_Panel.Controls.Add(Me.WebBrowser1)
        Me.Auto_Submit_Panel.Controls.Add(Me.ComboBox1)
        Me.Auto_Submit_Panel.Controls.Add(Me.Button1)
        Me.Auto_Submit_Panel.Controls.Add(Me.Button4)
        Me.Auto_Submit_Panel.Controls.Add(Me.Button3)
        Me.Auto_Submit_Panel.Location = New System.Drawing.Point(0, 0)
        Me.Auto_Submit_Panel.Margin = New System.Windows.Forms.Padding(0)
        Me.Auto_Submit_Panel.Name = "Auto_Submit_Panel"
        Me.Auto_Submit_Panel.Size = New System.Drawing.Size(728, 565)
        Me.Auto_Submit_Panel.TabIndex = 7
        '
        'Auto_Submit
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(765, 578)
        Me.Controls.Add(Me.Auto_Submit_Panel)
        Me.DoubleBuffered = True
        Me.Name = "Auto_Submit"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "自动填写成绩"
        Me.Auto_Submit_Panel.ResumeLayout(False)
        Me.Auto_Submit_Panel.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents WebBrowser1 As System.Windows.Forms.WebBrowser
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents Button4 As System.Windows.Forms.Button
    Friend WithEvents ComboBox1 As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Auto_Submit_Panel As System.Windows.Forms.Panel

End Class
