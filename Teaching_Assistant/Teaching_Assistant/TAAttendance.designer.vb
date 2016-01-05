<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class TAAttendance
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
        Me.TAAttendancePanel = New System.Windows.Forms.Panel
        Me.DateTimePicker1 = New System.Windows.Forms.DateTimePicker
        Me.PictureBox2 = New System.Windows.Forms.PictureBox
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.上课信息统计 = New System.Windows.Forms.GroupBox
        Me.Label15 = New System.Windows.Forms.Label
        Me.Label14 = New System.Windows.Forms.Label
        Me.rb5 = New System.Windows.Forms.RadioButton
        Me.rb4 = New System.Windows.Forms.RadioButton
        Me.ListBox3 = New System.Windows.Forms.ListBox
        Me.ListBox2 = New System.Windows.Forms.ListBox
        Me.TextBox4 = New System.Windows.Forms.TextBox
        Me.ListBox1 = New System.Windows.Forms.ListBox
        Me.Label13 = New System.Windows.Forms.Label
        Me.Label12 = New System.Windows.Forms.Label
        Me.Label11 = New System.Windows.Forms.Label
        Me.TextBox3 = New System.Windows.Forms.TextBox
        Me.TAAttendancePanel.SuspendLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.上课信息统计.SuspendLayout()
        Me.SuspendLayout()
        '
        'TAAttendancePanel
        '
        Me.TAAttendancePanel.BackColor = System.Drawing.Color.Transparent
        Me.TAAttendancePanel.Controls.Add(Me.DateTimePicker1)
        Me.TAAttendancePanel.Controls.Add(Me.PictureBox2)
        Me.TAAttendancePanel.Controls.Add(Me.PictureBox1)
        Me.TAAttendancePanel.Controls.Add(Me.上课信息统计)
        Me.TAAttendancePanel.Location = New System.Drawing.Point(0, 0)
        Me.TAAttendancePanel.Margin = New System.Windows.Forms.Padding(0)
        Me.TAAttendancePanel.Name = "TAAttendancePanel"
        Me.TAAttendancePanel.Size = New System.Drawing.Size(728, 565)
        Me.TAAttendancePanel.TabIndex = 20
        '
        'DateTimePicker1
        '
        Me.DateTimePicker1.CalendarFont = New System.Drawing.Font("宋体", 10.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.DateTimePicker1.Location = New System.Drawing.Point(84, 11)
        Me.DateTimePicker1.Name = "DateTimePicker1"
        Me.DateTimePicker1.Size = New System.Drawing.Size(190, 21)
        Me.DateTimePicker1.TabIndex = 15
        '
        'PictureBox2
        '
        Me.PictureBox2.Location = New System.Drawing.Point(368, 517)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(32, 32)
        Me.PictureBox2.TabIndex = 16
        Me.PictureBox2.TabStop = False
        '
        'PictureBox1
        '
        Me.PictureBox1.Location = New System.Drawing.Point(287, 517)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(32, 32)
        Me.PictureBox1.TabIndex = 15
        Me.PictureBox1.TabStop = False
        '
        '上课信息统计
        '
        Me.上课信息统计.Controls.Add(Me.Label15)
        Me.上课信息统计.Controls.Add(Me.Label14)
        Me.上课信息统计.Controls.Add(Me.rb5)
        Me.上课信息统计.Controls.Add(Me.rb4)
        Me.上课信息统计.Controls.Add(Me.ListBox3)
        Me.上课信息统计.Controls.Add(Me.ListBox2)
        Me.上课信息统计.Controls.Add(Me.TextBox4)
        Me.上课信息统计.Controls.Add(Me.ListBox1)
        Me.上课信息统计.Controls.Add(Me.Label13)
        Me.上课信息统计.Controls.Add(Me.Label12)
        Me.上课信息统计.Controls.Add(Me.Label11)
        Me.上课信息统计.Controls.Add(Me.TextBox3)
        Me.上课信息统计.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.上课信息统计.Location = New System.Drawing.Point(70, 56)
        Me.上课信息统计.Name = "上课信息统计"
        Me.上课信息统计.Size = New System.Drawing.Size(574, 455)
        Me.上课信息统计.TabIndex = 22
        Me.上课信息统计.TabStop = False
        Me.上课信息统计.Text = "上课信息统计"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(13, 92)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(72, 16)
        Me.Label15.TabIndex = 14
        Me.Label15.Text = "双击选择"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(13, 28)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(152, 16)
        Me.Label14.TabIndex = 13
        Me.Label14.Text = "查询（输入首字母）"
        '
        'rb5
        '
        Me.rb5.AutoSize = True
        Me.rb5.Location = New System.Drawing.Point(146, 243)
        Me.rb5.Name = "rb5"
        Me.rb5.Size = New System.Drawing.Size(58, 20)
        Me.rb5.TabIndex = 12
        Me.rb5.TabStop = True
        Me.rb5.Text = "助教"
        Me.rb5.UseVisualStyleBackColor = True
        '
        'rb4
        '
        Me.rb4.AutoSize = True
        Me.rb4.Location = New System.Drawing.Point(65, 243)
        Me.rb4.Name = "rb4"
        Me.rb4.Size = New System.Drawing.Size(58, 20)
        Me.rb4.TabIndex = 11
        Me.rb4.TabStop = True
        Me.rb4.Text = "主讲"
        Me.rb4.UseVisualStyleBackColor = True
        '
        'ListBox3
        '
        Me.ListBox3.FormattingEnabled = True
        Me.ListBox3.ItemHeight = 16
        Me.ListBox3.Location = New System.Drawing.Point(298, 121)
        Me.ListBox3.Name = "ListBox3"
        Me.ListBox3.Size = New System.Drawing.Size(240, 116)
        Me.ListBox3.TabIndex = 10
        '
        'ListBox2
        '
        Me.ListBox2.FormattingEnabled = True
        Me.ListBox2.ItemHeight = 16
        Me.ListBox2.Location = New System.Drawing.Point(298, 55)
        Me.ListBox2.Name = "ListBox2"
        Me.ListBox2.Size = New System.Drawing.Size(240, 20)
        Me.ListBox2.TabIndex = 9
        '
        'TextBox4
        '
        Me.TextBox4.Location = New System.Drawing.Point(15, 55)
        Me.TextBox4.Name = "TextBox4"
        Me.TextBox4.Size = New System.Drawing.Size(240, 26)
        Me.TextBox4.TabIndex = 8
        '
        'ListBox1
        '
        Me.ListBox1.FormattingEnabled = True
        Me.ListBox1.ItemHeight = 16
        Me.ListBox1.Location = New System.Drawing.Point(16, 121)
        Me.ListBox1.Name = "ListBox1"
        Me.ListBox1.Size = New System.Drawing.Size(240, 116)
        Me.ListBox1.TabIndex = 7
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(13, 271)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(104, 16)
        Me.Label13.TabIndex = 5
        Me.Label13.Text = "上课所遇情况"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(296, 92)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(120, 16)
        Me.Label12.TabIndex = 4
        Me.Label12.Text = "助教(双击去除)"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(296, 28)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(136, 16)
        Me.Label11.TabIndex = 3
        Me.Label11.Text = "主讲人(双击去除)"
        '
        'TextBox3
        '
        Me.TextBox3.Location = New System.Drawing.Point(16, 305)
        Me.TextBox3.Multiline = True
        Me.TextBox3.Name = "TextBox3"
        Me.TextBox3.Size = New System.Drawing.Size(522, 114)
        Me.TextBox3.TabIndex = 2
        '
        'TAAttendance
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(775, 589)
        Me.Controls.Add(Me.TAAttendancePanel)
        Me.DoubleBuffered = True
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.KeyPreview = True
        Me.MaximumSize = New System.Drawing.Size(1000, 900)
        Me.MinimumSize = New System.Drawing.Size(55, 55)
        Me.Name = "TAAttendance"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "成绩录入"
        Me.TAAttendancePanel.ResumeLayout(False)
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.上课信息统计.ResumeLayout(False)
        Me.上课信息统计.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TAAttendancePanel As System.Windows.Forms.Panel
    Friend WithEvents 上课信息统计 As System.Windows.Forms.GroupBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents TextBox3 As System.Windows.Forms.TextBox
    Friend WithEvents ListBox3 As System.Windows.Forms.ListBox
    Friend WithEvents ListBox2 As System.Windows.Forms.ListBox
    Friend WithEvents TextBox4 As System.Windows.Forms.TextBox
    Friend WithEvents ListBox1 As System.Windows.Forms.ListBox
    Friend WithEvents rb5 As System.Windows.Forms.RadioButton
    Friend WithEvents rb4 As System.Windows.Forms.RadioButton
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents DateTimePicker1 As System.Windows.Forms.DateTimePicker

End Class