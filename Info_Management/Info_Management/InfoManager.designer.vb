<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class infomanager
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
        Me.InfoManagerPanel = New System.Windows.Forms.Panel
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.Addmember = New System.Windows.Forms.Button
        Me.Upmember = New System.Windows.Forms.Button
        Me.Delmember = New System.Windows.Forms.Button
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.RadioButton2 = New System.Windows.Forms.RadioButton
        Me.RadioButton1 = New System.Windows.Forms.RadioButton
        Me.Search = New System.Windows.Forms.Button
        Me.ComboBDept = New System.Windows.Forms.ComboBox
        Me.LabDept = New System.Windows.Forms.Label
        Me.TextBName = New System.Windows.Forms.TextBox
        Me.LabName = New System.Windows.Forms.Label
        Me.TextBNum = New System.Windows.Forms.TextBox
        Me.LabNum = New System.Windows.Forms.Label
        Me.Info = New System.Windows.Forms.TabControl
        Me.AllMemeber = New System.Windows.Forms.TabPage
        Me.ListView1 = New System.Windows.Forms.ListView
        Me.ColumnHeader1 = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader2 = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader3 = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader4 = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader5 = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader6 = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader7 = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader8 = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader17 = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader18 = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader30 = New System.Windows.Forms.ColumnHeader
        Me.AClass = New System.Windows.Forms.TabPage
        Me.ListView3 = New System.Windows.Forms.ListView
        Me.ColumnHeader21 = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader22 = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader23 = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader24 = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader25 = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader26 = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader27 = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader28 = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader29 = New System.Windows.Forms.ColumnHeader
        Me.Searchresult = New System.Windows.Forms.TabPage
        Me.ListView2 = New System.Windows.Forms.ListView
        Me.ColumnHeader9 = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader10 = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader11 = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader12 = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader13 = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader14 = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader15 = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader16 = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader19 = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader20 = New System.Windows.Forms.ColumnHeader
        Me.InfoManagerPanel.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.Info.SuspendLayout()
        Me.AllMemeber.SuspendLayout()
        Me.AClass.SuspendLayout()
        Me.Searchresult.SuspendLayout()
        Me.SuspendLayout()
        '
        'InfoManagerPanel
        '
        Me.InfoManagerPanel.BackColor = System.Drawing.SystemColors.Control
        Me.InfoManagerPanel.Controls.Add(Me.GroupBox2)
        Me.InfoManagerPanel.Controls.Add(Me.GroupBox1)
        Me.InfoManagerPanel.Controls.Add(Me.Info)
        Me.InfoManagerPanel.Location = New System.Drawing.Point(0, 0)
        Me.InfoManagerPanel.Name = "InfoManagerPanel"
        Me.InfoManagerPanel.Size = New System.Drawing.Size(728, 560)
        Me.InfoManagerPanel.TabIndex = 12
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Addmember)
        Me.GroupBox2.Controls.Add(Me.Upmember)
        Me.GroupBox2.Controls.Add(Me.Delmember)
        Me.GroupBox2.Location = New System.Drawing.Point(49, 454)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(240, 101)
        Me.GroupBox2.TabIndex = 18
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "管理"
        '
        'Addmember
        '
        Me.Addmember.Location = New System.Drawing.Point(24, 20)
        Me.Addmember.Name = "Addmember"
        Me.Addmember.Size = New System.Drawing.Size(91, 31)
        Me.Addmember.TabIndex = 13
        Me.Addmember.Text = "添加用户"
        Me.Addmember.UseVisualStyleBackColor = True
        '
        'Upmember
        '
        Me.Upmember.Location = New System.Drawing.Point(134, 20)
        Me.Upmember.Name = "Upmember"
        Me.Upmember.Size = New System.Drawing.Size(91, 31)
        Me.Upmember.TabIndex = 14
        Me.Upmember.Text = "更新用户"
        Me.Upmember.UseVisualStyleBackColor = True
        '
        'Delmember
        '
        Me.Delmember.Location = New System.Drawing.Point(24, 57)
        Me.Delmember.Name = "Delmember"
        Me.Delmember.Size = New System.Drawing.Size(91, 31)
        Me.Delmember.TabIndex = 15
        Me.Delmember.Text = "删除用户"
        Me.Delmember.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.RadioButton2)
        Me.GroupBox1.Controls.Add(Me.RadioButton1)
        Me.GroupBox1.Controls.Add(Me.Search)
        Me.GroupBox1.Controls.Add(Me.ComboBDept)
        Me.GroupBox1.Controls.Add(Me.LabDept)
        Me.GroupBox1.Controls.Add(Me.TextBName)
        Me.GroupBox1.Controls.Add(Me.LabName)
        Me.GroupBox1.Controls.Add(Me.TextBNum)
        Me.GroupBox1.Controls.Add(Me.LabNum)
        Me.GroupBox1.Location = New System.Drawing.Point(329, 450)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(339, 107)
        Me.GroupBox1.TabIndex = 17
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "查询"
        '
        'RadioButton2
        '
        Me.RadioButton2.AutoSize = True
        Me.RadioButton2.Location = New System.Drawing.Point(241, 45)
        Me.RadioButton2.Name = "RadioButton2"
        Me.RadioButton2.Size = New System.Drawing.Size(71, 16)
        Me.RadioButton2.TabIndex = 33
        Me.RadioButton2.TabStop = True
        Me.RadioButton2.Text = "科中同学"
        Me.RadioButton2.UseVisualStyleBackColor = True
        '
        'RadioButton1
        '
        Me.RadioButton1.AutoSize = True
        Me.RadioButton1.Location = New System.Drawing.Point(241, 23)
        Me.RadioButton1.Name = "RadioButton1"
        Me.RadioButton1.Size = New System.Drawing.Size(71, 16)
        Me.RadioButton1.TabIndex = 32
        Me.RadioButton1.TabStop = True
        Me.RadioButton1.Text = "上课同学"
        Me.RadioButton1.UseVisualStyleBackColor = True
        '
        'Search
        '
        Me.Search.Location = New System.Drawing.Point(241, 72)
        Me.Search.Name = "Search"
        Me.Search.Size = New System.Drawing.Size(77, 24)
        Me.Search.TabIndex = 30
        Me.Search.Text = "查询"
        Me.Search.UseVisualStyleBackColor = True
        '
        'ComboBDept
        '
        Me.ComboBDept.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBDept.FormattingEnabled = True
        Me.ComboBDept.Location = New System.Drawing.Point(58, 76)
        Me.ComboBDept.Name = "ComboBDept"
        Me.ComboBDept.Size = New System.Drawing.Size(164, 20)
        Me.ComboBDept.TabIndex = 29
        '
        'LabDept
        '
        Me.LabDept.AutoSize = True
        Me.LabDept.Location = New System.Drawing.Point(20, 79)
        Me.LabDept.Name = "LabDept"
        Me.LabDept.Size = New System.Drawing.Size(41, 12)
        Me.LabDept.TabIndex = 28
        Me.LabDept.Text = "院系："
        '
        'TextBName
        '
        Me.TextBName.Location = New System.Drawing.Point(58, 49)
        Me.TextBName.Name = "TextBName"
        Me.TextBName.Size = New System.Drawing.Size(164, 21)
        Me.TextBName.TabIndex = 27
        '
        'LabName
        '
        Me.LabName.AutoSize = True
        Me.LabName.Location = New System.Drawing.Point(20, 52)
        Me.LabName.Name = "LabName"
        Me.LabName.Size = New System.Drawing.Size(41, 12)
        Me.LabName.TabIndex = 26
        Me.LabName.Text = "姓名："
        '
        'TextBNum
        '
        Me.TextBNum.Location = New System.Drawing.Point(58, 22)
        Me.TextBNum.Name = "TextBNum"
        Me.TextBNum.Size = New System.Drawing.Size(164, 21)
        Me.TextBNum.TabIndex = 25
        '
        'LabNum
        '
        Me.LabNum.AutoSize = True
        Me.LabNum.Location = New System.Drawing.Point(20, 25)
        Me.LabNum.Name = "LabNum"
        Me.LabNum.Size = New System.Drawing.Size(41, 12)
        Me.LabNum.TabIndex = 24
        Me.LabNum.Text = "学号："
        '
        'Info
        '
        Me.Info.Controls.Add(Me.AllMemeber)
        Me.Info.Controls.Add(Me.AClass)
        Me.Info.Controls.Add(Me.Searchresult)
        Me.Info.Font = New System.Drawing.Font("宋体", 11.5!)
        Me.Info.Location = New System.Drawing.Point(11, 12)
        Me.Info.Name = "Info"
        Me.Info.SelectedIndex = 0
        Me.Info.Size = New System.Drawing.Size(704, 436)
        Me.Info.TabIndex = 12
        '
        'AllMemeber
        '
        Me.AllMemeber.BackColor = System.Drawing.SystemColors.Control
        Me.AllMemeber.Controls.Add(Me.ListView1)
        Me.AllMemeber.Location = New System.Drawing.Point(4, 25)
        Me.AllMemeber.Name = "AllMemeber"
        Me.AllMemeber.Padding = New System.Windows.Forms.Padding(3)
        Me.AllMemeber.Size = New System.Drawing.Size(696, 407)
        Me.AllMemeber.TabIndex = 0
        Me.AllMemeber.Text = "所有成员"
        '
        'ListView1
        '
        Me.ListView1.Activation = System.Windows.Forms.ItemActivation.OneClick
        Me.ListView1.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.ListView1.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.ColumnHeader2, Me.ColumnHeader3, Me.ColumnHeader4, Me.ColumnHeader5, Me.ColumnHeader6, Me.ColumnHeader7, Me.ColumnHeader8, Me.ColumnHeader17, Me.ColumnHeader18, Me.ColumnHeader30})
        Me.ListView1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ListView1.Font = New System.Drawing.Font("宋体", 10.0!)
        Me.ListView1.FullRowSelect = True
        Me.ListView1.Location = New System.Drawing.Point(3, 3)
        Me.ListView1.Margin = New System.Windows.Forms.Padding(0)
        Me.ListView1.MultiSelect = False
        Me.ListView1.Name = "ListView1"
        Me.ListView1.Size = New System.Drawing.Size(690, 401)
        Me.ListView1.TabIndex = 0
        Me.ListView1.TabStop = False
        Me.ListView1.UseCompatibleStateImageBehavior = False
        Me.ListView1.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = "学号"
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.Text = "登录用户名"
        '
        'ColumnHeader3
        '
        Me.ColumnHeader3.Text = "姓名"
        '
        'ColumnHeader4
        '
        Me.ColumnHeader4.Text = "性别"
        Me.ColumnHeader4.Width = 75
        '
        'ColumnHeader5
        '
        Me.ColumnHeader5.Text = "主讲次数"
        '
        'ColumnHeader6
        '
        Me.ColumnHeader6.Text = "助教次数"
        '
        'ColumnHeader7
        '
        Me.ColumnHeader7.Text = "院系"
        '
        'ColumnHeader8
        '
        Me.ColumnHeader8.Text = "年级"
        '
        'ColumnHeader17
        '
        Me.ColumnHeader17.Text = "电话"
        '
        'ColumnHeader18
        '
        Me.ColumnHeader18.Text = "职务"
        '
        'ColumnHeader30
        '
        Me.ColumnHeader30.Text = "组别"
        '
        'AClass
        '
        Me.AClass.BackColor = System.Drawing.SystemColors.Control
        Me.AClass.Controls.Add(Me.ListView3)
        Me.AClass.Location = New System.Drawing.Point(4, 25)
        Me.AClass.Name = "AClass"
        Me.AClass.Size = New System.Drawing.Size(696, 407)
        Me.AClass.TabIndex = 2
        Me.AClass.Text = "上课同学"
        '
        'ListView3
        '
        Me.ListView3.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader21, Me.ColumnHeader22, Me.ColumnHeader23, Me.ColumnHeader24, Me.ColumnHeader25, Me.ColumnHeader26, Me.ColumnHeader27, Me.ColumnHeader28, Me.ColumnHeader29})
        Me.ListView3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ListView3.Font = New System.Drawing.Font("宋体", 10.0!)
        Me.ListView3.FullRowSelect = True
        Me.ListView3.Location = New System.Drawing.Point(0, 0)
        Me.ListView3.Margin = New System.Windows.Forms.Padding(0)
        Me.ListView3.MultiSelect = False
        Me.ListView3.Name = "ListView3"
        Me.ListView3.Size = New System.Drawing.Size(696, 407)
        Me.ListView3.TabIndex = 0
        Me.ListView3.UseCompatibleStateImageBehavior = False
        Me.ListView3.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader21
        '
        Me.ColumnHeader21.Text = "学号"
        '
        'ColumnHeader22
        '
        Me.ColumnHeader22.Text = "姓名"
        '
        'ColumnHeader23
        '
        Me.ColumnHeader23.Text = "院系"
        Me.ColumnHeader23.Width = 150
        '
        'ColumnHeader24
        '
        Me.ColumnHeader24.Text = "硬件时间"
        Me.ColumnHeader24.Width = 75
        '
        'ColumnHeader25
        '
        Me.ColumnHeader25.Text = "软件时间"
        Me.ColumnHeader25.Width = 75
        '
        'ColumnHeader26
        '
        Me.ColumnHeader26.Text = "硬件成绩"
        Me.ColumnHeader26.Width = 75
        '
        'ColumnHeader27
        '
        Me.ColumnHeader27.Text = "软件成绩"
        Me.ColumnHeader27.Width = 75
        '
        'ColumnHeader28
        '
        Me.ColumnHeader28.Text = "试卷成绩"
        Me.ColumnHeader28.Width = 75
        '
        'ColumnHeader29
        '
        Me.ColumnHeader29.Text = "联系电话"
        Me.ColumnHeader29.Width = 75
        '
        'Searchresult
        '
        Me.Searchresult.Controls.Add(Me.ListView2)
        Me.Searchresult.Location = New System.Drawing.Point(4, 25)
        Me.Searchresult.Name = "Searchresult"
        Me.Searchresult.Padding = New System.Windows.Forms.Padding(3)
        Me.Searchresult.Size = New System.Drawing.Size(696, 407)
        Me.Searchresult.TabIndex = 1
        Me.Searchresult.Text = "搜索结果"
        Me.Searchresult.UseVisualStyleBackColor = True
        '
        'ListView2
        '
        Me.ListView2.Activation = System.Windows.Forms.ItemActivation.OneClick
        Me.ListView2.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.ListView2.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader9, Me.ColumnHeader10, Me.ColumnHeader11, Me.ColumnHeader12, Me.ColumnHeader13, Me.ColumnHeader14, Me.ColumnHeader15, Me.ColumnHeader16, Me.ColumnHeader19, Me.ColumnHeader20})
        Me.ListView2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ListView2.Font = New System.Drawing.Font("宋体", 9.0!)
        Me.ListView2.FullRowSelect = True
        Me.ListView2.Location = New System.Drawing.Point(3, 3)
        Me.ListView2.Margin = New System.Windows.Forms.Padding(0)
        Me.ListView2.MultiSelect = False
        Me.ListView2.Name = "ListView2"
        Me.ListView2.Size = New System.Drawing.Size(690, 401)
        Me.ListView2.TabIndex = 0
        Me.ListView2.TabStop = False
        Me.ListView2.UseCompatibleStateImageBehavior = False
        Me.ListView2.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader9
        '
        Me.ColumnHeader9.Text = "学号"
        '
        'ColumnHeader10
        '
        Me.ColumnHeader10.Text = "姓名"
        '
        'ColumnHeader11
        '
        Me.ColumnHeader11.Text = "性别"
        '
        'ColumnHeader12
        '
        Me.ColumnHeader12.Text = "院系"
        '
        'ColumnHeader13
        '
        Me.ColumnHeader13.Text = "年级"
        '
        'ColumnHeader14
        '
        Me.ColumnHeader14.Text = "电话"
        '
        'ColumnHeader15
        '
        Me.ColumnHeader15.Text = "职务"
        '
        'ColumnHeader16
        '
        Me.ColumnHeader16.Text = "组别"
        '
        'ColumnHeader19
        '
        Me.ColumnHeader19.Text = "主讲次数"
        Me.ColumnHeader19.Width = 75
        '
        'ColumnHeader20
        '
        Me.ColumnHeader20.Text = "助教次数"
        Me.ColumnHeader20.Width = 75
        '
        'infomanager
        '
        Me.AcceptButton = Me.Search
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(764, 587)
        Me.Controls.Add(Me.InfoManagerPanel)
        Me.DoubleBuffered = True
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "infomanager"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.Text = "成员信息管理"
        Me.InfoManagerPanel.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.Info.ResumeLayout(False)
        Me.AllMemeber.ResumeLayout(False)
        Me.AClass.ResumeLayout(False)
        Me.Searchresult.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents InfoManagerPanel As System.Windows.Forms.Panel
    Friend WithEvents Info As System.Windows.Forms.TabControl
    Friend WithEvents AllMemeber As System.Windows.Forms.TabPage
    Friend WithEvents Searchresult As System.Windows.Forms.TabPage
    Friend WithEvents ListView2 As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader9 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader10 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader11 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader12 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader13 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader14 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader15 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader16 As System.Windows.Forms.ColumnHeader
    Friend WithEvents Delmember As System.Windows.Forms.Button
    Friend WithEvents Upmember As System.Windows.Forms.Button
    Friend WithEvents Addmember As System.Windows.Forms.Button
    Friend WithEvents ListView1 As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader1 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader2 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader3 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader4 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader5 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader6 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader7 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader8 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader17 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader18 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader19 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader20 As System.Windows.Forms.ColumnHeader
    Friend WithEvents AClass As System.Windows.Forms.TabPage
    Friend WithEvents ListView3 As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader21 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader22 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader23 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader24 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader25 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader26 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader27 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader28 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader29 As System.Windows.Forms.ColumnHeader
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents RadioButton2 As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButton1 As System.Windows.Forms.RadioButton
    Friend WithEvents Search As System.Windows.Forms.Button
    Friend WithEvents ComboBDept As System.Windows.Forms.ComboBox
    Friend WithEvents LabDept As System.Windows.Forms.Label
    Friend WithEvents TextBName As System.Windows.Forms.TextBox
    Friend WithEvents LabName As System.Windows.Forms.Label
    Friend WithEvents TextBNum As System.Windows.Forms.TextBox
    Friend WithEvents LabNum As System.Windows.Forms.Label
    Friend WithEvents ColumnHeader30 As System.Windows.Forms.ColumnHeader

End Class
