<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class TheoryCourses
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
        Me.ListView1 = New System.Windows.Forms.ListView
        Me.ColumnHeader1 = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader2 = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader3 = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader4 = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader5 = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader6 = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader7 = New System.Windows.Forms.ColumnHeader
        Me.RadioButton1 = New System.Windows.Forms.RadioButton
        Me.RadioButton2 = New System.Windows.Forms.RadioButton
        Me.InfoGB = New System.Windows.Forms.GroupBox
        Me.selecttime = New System.Windows.Forms.Label
        Me.liluntime = New System.Windows.Forms.Label
        Me.phonelb = New System.Windows.Forms.Label
        Me.Maillb = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.TxtName = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.TxtNum = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.DateTimePicker1 = New System.Windows.Forms.DateTimePicker
        Me.Label2 = New System.Windows.Forms.Label
        Me.CBTime = New System.Windows.Forms.ComboBox
        Me.quit = New System.Windows.Forms.Button
        Me.InfoGB.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'ListView1
        '
        Me.ListView1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.ListView1.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.ColumnHeader2, Me.ColumnHeader3, Me.ColumnHeader4, Me.ColumnHeader5, Me.ColumnHeader6, Me.ColumnHeader7})
        Me.ListView1.FullRowSelect = True
        Me.ListView1.Location = New System.Drawing.Point(12, 54)
        Me.ListView1.MultiSelect = False
        Me.ListView1.Name = "ListView1"
        Me.ListView1.Size = New System.Drawing.Size(682, 557)
        Me.ListView1.TabIndex = 2
        Me.ListView1.UseCompatibleStateImageBehavior = False
        Me.ListView1.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = "学号"
        Me.ColumnHeader1.Width = 80
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.Text = "姓名"
        Me.ColumnHeader2.Width = 75
        '
        'ColumnHeader3
        '
        Me.ColumnHeader3.Text = "院系"
        Me.ColumnHeader3.Width = 187
        '
        'ColumnHeader4
        '
        Me.ColumnHeader4.Text = "选课时间"
        Me.ColumnHeader4.Width = 120
        '
        'ColumnHeader5
        '
        Me.ColumnHeader5.Text = "硬件时间"
        Me.ColumnHeader5.Width = 65
        '
        'ColumnHeader6
        '
        Me.ColumnHeader6.Text = "软件时间"
        Me.ColumnHeader6.Width = 65
        '
        'ColumnHeader7
        '
        Me.ColumnHeader7.Text = "是否签到"
        Me.ColumnHeader7.Width = 65
        '
        'RadioButton1
        '
        Me.RadioButton1.AutoSize = True
        Me.RadioButton1.Location = New System.Drawing.Point(46, 77)
        Me.RadioButton1.Name = "RadioButton1"
        Me.RadioButton1.Size = New System.Drawing.Size(53, 18)
        Me.RadioButton1.TabIndex = 2
        Me.RadioButton1.TabStop = True
        Me.RadioButton1.Text = "签到"
        Me.RadioButton1.UseVisualStyleBackColor = True
        '
        'RadioButton2
        '
        Me.RadioButton2.AutoSize = True
        Me.RadioButton2.Location = New System.Drawing.Point(128, 77)
        Me.RadioButton2.Name = "RadioButton2"
        Me.RadioButton2.Size = New System.Drawing.Size(53, 18)
        Me.RadioButton2.TabIndex = 3
        Me.RadioButton2.TabStop = True
        Me.RadioButton2.Text = "未到"
        Me.RadioButton2.UseVisualStyleBackColor = True
        '
        'InfoGB
        '
        Me.InfoGB.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.InfoGB.Controls.Add(Me.selecttime)
        Me.InfoGB.Controls.Add(Me.liluntime)
        Me.InfoGB.Controls.Add(Me.phonelb)
        Me.InfoGB.Controls.Add(Me.Maillb)
        Me.InfoGB.Controls.Add(Me.Label10)
        Me.InfoGB.Controls.Add(Me.Label9)
        Me.InfoGB.Controls.Add(Me.Label8)
        Me.InfoGB.Controls.Add(Me.Label6)
        Me.InfoGB.Font = New System.Drawing.Font("宋体", 10.5!)
        Me.InfoGB.Location = New System.Drawing.Point(38, 629)
        Me.InfoGB.Name = "InfoGB"
        Me.InfoGB.Size = New System.Drawing.Size(358, 101)
        Me.InfoGB.TabIndex = 21
        Me.InfoGB.TabStop = False
        Me.InfoGB.Text = "学生信息"
        '
        'selecttime
        '
        Me.selecttime.AutoSize = True
        Me.selecttime.Location = New System.Drawing.Point(83, 76)
        Me.selecttime.Name = "selecttime"
        Me.selecttime.Size = New System.Drawing.Size(14, 14)
        Me.selecttime.TabIndex = 7
        Me.selecttime.Text = ":"
        '
        'liluntime
        '
        Me.liluntime.AutoSize = True
        Me.liluntime.Location = New System.Drawing.Point(83, 36)
        Me.liluntime.Name = "liluntime"
        Me.liluntime.Size = New System.Drawing.Size(14, 14)
        Me.liluntime.TabIndex = 6
        Me.liluntime.Text = ":"
        '
        'phonelb
        '
        Me.phonelb.AutoSize = True
        Me.phonelb.Location = New System.Drawing.Point(83, 57)
        Me.phonelb.Name = "phonelb"
        Me.phonelb.Size = New System.Drawing.Size(14, 14)
        Me.phonelb.TabIndex = 5
        Me.phonelb.Text = ":"
        '
        'Maillb
        '
        Me.Maillb.AutoSize = True
        Me.Maillb.Location = New System.Drawing.Point(83, 17)
        Me.Maillb.Name = "Maillb"
        Me.Maillb.Size = New System.Drawing.Size(14, 14)
        Me.Maillb.TabIndex = 4
        Me.Maillb.Text = ":"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(24, 76)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(63, 14)
        Me.Label10.TabIndex = 3
        Me.Label10.Text = "选课时间"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(24, 36)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(63, 14)
        Me.Label9.TabIndex = 2
        Me.Label9.Text = "理 论 课"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(24, 57)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(63, 14)
        Me.Label8.TabIndex = 1
        Me.Label8.Text = "电    话"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(24, 17)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(63, 14)
        Me.Label6.TabIndex = 0
        Me.Label6.Text = "邮    箱"
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox1.Controls.Add(Me.RadioButton2)
        Me.GroupBox1.Controls.Add(Me.RadioButton1)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.TxtName)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.TxtNum)
        Me.GroupBox1.Font = New System.Drawing.Font("宋体", 10.5!)
        Me.GroupBox1.Location = New System.Drawing.Point(414, 629)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(235, 110)
        Me.GroupBox1.TabIndex = 22
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "查询并统计"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("新宋体", 9.0!)
        Me.Label7.Location = New System.Drawing.Point(20, 52)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(53, 12)
        Me.Label7.TabIndex = 7
        Me.Label7.Text = "输入姓名"
        '
        'TxtName
        '
        Me.TxtName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtName.Font = New System.Drawing.Font("新宋体", 9.0!)
        Me.TxtName.ImeMode = System.Windows.Forms.ImeMode.[On]
        Me.TxtName.Location = New System.Drawing.Point(89, 50)
        Me.TxtName.Name = "TxtName"
        Me.TxtName.Size = New System.Drawing.Size(117, 21)
        Me.TxtName.TabIndex = 1
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("新宋体", 9.0!)
        Me.Label3.Location = New System.Drawing.Point(20, 27)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(53, 12)
        Me.Label3.TabIndex = 7
        Me.Label3.Text = "输入学号"
        '
        'TxtNum
        '
        Me.TxtNum.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtNum.Font = New System.Drawing.Font("新宋体", 9.0!)
        Me.TxtNum.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.TxtNum.Location = New System.Drawing.Point(89, 23)
        Me.TxtNum.MaxLength = 9
        Me.TxtNum.Name = "TxtNum"
        Me.TxtNum.Size = New System.Drawing.Size(117, 21)
        Me.TxtNum.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(291, 21)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(41, 12)
        Me.Label1.TabIndex = 23
        Me.Label1.Text = "Label1"
        '
        'DateTimePicker1
        '
        Me.DateTimePicker1.Location = New System.Drawing.Point(38, 17)
        Me.DateTimePicker1.Name = "DateTimePicker1"
        Me.DateTimePicker1.Size = New System.Drawing.Size(200, 21)
        Me.DateTimePicker1.TabIndex = 24
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(424, 21)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(53, 12)
        Me.Label2.TabIndex = 25
        Me.Label2.Text = "选课时间"
        '
        'CBTime
        '
        Me.CBTime.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CBTime.FormattingEnabled = True
        Me.CBTime.Location = New System.Drawing.Point(483, 18)
        Me.CBTime.Name = "CBTime"
        Me.CBTime.Size = New System.Drawing.Size(166, 20)
        Me.CBTime.TabIndex = 26
        '
        'quit
        '
        Me.quit.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.quit.Location = New System.Drawing.Point(340, 755)
        Me.quit.Name = "quit"
        Me.quit.Size = New System.Drawing.Size(0, 0)
        Me.quit.TabIndex = 27
        Me.quit.Text = "quit"
        Me.quit.UseVisualStyleBackColor = True
        '
        'TheoryCourses
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.quit
        Me.ClientSize = New System.Drawing.Size(701, 770)
        Me.Controls.Add(Me.quit)
        Me.Controls.Add(Me.CBTime)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.DateTimePicker1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.InfoGB)
        Me.Controls.Add(Me.ListView1)
        Me.DoubleBuffered = True
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(717, 1000)
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(717, 804)
        Me.Name = "TheoryCourses"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "理论课情况统计"
        Me.InfoGB.ResumeLayout(False)
        Me.InfoGB.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ListView1 As System.Windows.Forms.ListView
    Friend WithEvents RadioButton1 As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButton2 As System.Windows.Forms.RadioButton
    Friend WithEvents InfoGB As System.Windows.Forms.GroupBox
    Friend WithEvents selecttime As System.Windows.Forms.Label
    Friend WithEvents liluntime As System.Windows.Forms.Label
    Friend WithEvents phonelb As System.Windows.Forms.Label
    Friend WithEvents Maillb As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents TxtName As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents TxtNum As System.Windows.Forms.TextBox
    Friend WithEvents ColumnHeader1 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader2 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader3 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader4 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader5 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader6 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader7 As System.Windows.Forms.ColumnHeader
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents DateTimePicker1 As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents CBTime As System.Windows.Forms.ComboBox
    Friend WithEvents quit As System.Windows.Forms.Button
End Class
