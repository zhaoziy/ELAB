<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Sign_Time
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
        Me.Sign_Time_Panel = New System.Windows.Forms.Panel
        Me.DataGrid1 = New System.Windows.Forms.DataGrid
        Me.Button1 = New System.Windows.Forms.Button
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.Rdo_dd = New System.Windows.Forms.RadioButton
        Me.Rdo_dm = New System.Windows.Forms.RadioButton
        Me.Rdo_dw = New System.Windows.Forms.RadioButton
        Me.ComboBox1 = New System.Windows.Forms.ComboBox
        Me.Grp_dd = New System.Windows.Forms.GroupBox
        Me.DateTimePicker2 = New System.Windows.Forms.DateTimePicker
        Me.Grp_dw = New System.Windows.Forms.GroupBox
        Me.Grp_dm = New System.Windows.Forms.GroupBox
        Me.ckd_dm = New System.Windows.Forms.ListBox
        Me.but_dm = New System.Windows.Forms.Button
        Me.ckd_dw = New System.Windows.Forms.ListBox
        Me.but_dw = New System.Windows.Forms.Button
        Me.DateTimePicker1 = New System.Windows.Forms.DateTimePicker
        Me.but_dd = New System.Windows.Forms.Button
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.RadioButton6 = New System.Windows.Forms.RadioButton
        Me.RadioButton5 = New System.Windows.Forms.RadioButton
        Me.ComboBox2 = New System.Windows.Forms.ComboBox
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.ComboBox3 = New System.Windows.Forms.ComboBox
        Me.RadioButton3 = New System.Windows.Forms.RadioButton
        Me.RadioButton2 = New System.Windows.Forms.RadioButton
        Me.RadioButton1 = New System.Windows.Forms.RadioButton
        Me.RadioButton4 = New System.Windows.Forms.RadioButton
        Me.Sign_Time_Panel.SuspendLayout()
        CType(Me.DataGrid1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        Me.Grp_dd.SuspendLayout()
        Me.Grp_dw.SuspendLayout()
        Me.Grp_dm.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Sign_Time_Panel
        '
        Me.Sign_Time_Panel.Controls.Add(Me.DataGrid1)
        Me.Sign_Time_Panel.Controls.Add(Me.Button1)
        Me.Sign_Time_Panel.Controls.Add(Me.GroupBox2)
        Me.Sign_Time_Panel.Controls.Add(Me.GroupBox1)
        Me.Sign_Time_Panel.Location = New System.Drawing.Point(0, 0)
        Me.Sign_Time_Panel.Margin = New System.Windows.Forms.Padding(0)
        Me.Sign_Time_Panel.Name = "Sign_Time_Panel"
        Me.Sign_Time_Panel.Size = New System.Drawing.Size(728, 565)
        Me.Sign_Time_Panel.TabIndex = 0
        '
        'DataGrid1
        '
        Me.DataGrid1.AlternatingBackColor = System.Drawing.Color.White
        Me.DataGrid1.BackColor = System.Drawing.Color.White
        Me.DataGrid1.BackgroundColor = System.Drawing.Color.Ivory
        Me.DataGrid1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.DataGrid1.CaptionBackColor = System.Drawing.Color.DarkSlateBlue
        Me.DataGrid1.CaptionFont = New System.Drawing.Font("微软雅黑", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DataGrid1.CaptionForeColor = System.Drawing.Color.Lavender
        Me.DataGrid1.DataMember = ""
        Me.DataGrid1.FlatMode = True
        Me.DataGrid1.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.DataGrid1.ForeColor = System.Drawing.Color.Black
        Me.DataGrid1.GridLineColor = System.Drawing.Color.Wheat
        Me.DataGrid1.HeaderBackColor = System.Drawing.Color.CadetBlue
        Me.DataGrid1.HeaderFont = New System.Drawing.Font("微软雅黑", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DataGrid1.HeaderForeColor = System.Drawing.Color.Black
        Me.DataGrid1.LinkColor = System.Drawing.Color.DarkSlateBlue
        Me.DataGrid1.Location = New System.Drawing.Point(164, 12)
        Me.DataGrid1.Name = "DataGrid1"
        Me.DataGrid1.ParentRowsBackColor = System.Drawing.Color.Ivory
        Me.DataGrid1.ParentRowsForeColor = System.Drawing.Color.Black
        Me.DataGrid1.SelectionBackColor = System.Drawing.Color.Wheat
        Me.DataGrid1.SelectionForeColor = System.Drawing.Color.DarkSlateBlue
        Me.DataGrid1.Size = New System.Drawing.Size(552, 539)
        Me.DataGrid1.TabIndex = 14
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(12, 522)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(136, 29)
        Me.Button1.TabIndex = 13
        Me.Button1.Text = "导出到Excel"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Rdo_dd)
        Me.GroupBox2.Controls.Add(Me.Rdo_dm)
        Me.GroupBox2.Controls.Add(Me.Rdo_dw)
        Me.GroupBox2.Controls.Add(Me.ComboBox1)
        Me.GroupBox2.Controls.Add(Me.Grp_dd)
        Me.GroupBox2.Controls.Add(Me.RadioButton6)
        Me.GroupBox2.Controls.Add(Me.RadioButton5)
        Me.GroupBox2.Controls.Add(Me.ComboBox2)
        Me.GroupBox2.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.GroupBox2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.GroupBox2.Location = New System.Drawing.Point(12, 178)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(136, 338)
        Me.GroupBox2.TabIndex = 12
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "统计方式"
        '
        'Rdo_dd
        '
        Me.Rdo_dd.AutoSize = True
        Me.Rdo_dd.Location = New System.Drawing.Point(16, 136)
        Me.Rdo_dd.Name = "Rdo_dd"
        Me.Rdo_dd.Size = New System.Drawing.Size(90, 20)
        Me.Rdo_dd.TabIndex = 6
        Me.Rdo_dd.TabStop = True
        Me.Rdo_dd.Text = "多日统计"
        Me.Rdo_dd.UseVisualStyleBackColor = True
        '
        'Rdo_dm
        '
        Me.Rdo_dm.AutoSize = True
        Me.Rdo_dm.Location = New System.Drawing.Point(16, 188)
        Me.Rdo_dm.Name = "Rdo_dm"
        Me.Rdo_dm.Size = New System.Drawing.Size(90, 20)
        Me.Rdo_dm.TabIndex = 5
        Me.Rdo_dm.TabStop = True
        Me.Rdo_dm.Text = "多月统计"
        Me.Rdo_dm.UseVisualStyleBackColor = True
        '
        'Rdo_dw
        '
        Me.Rdo_dw.AutoSize = True
        Me.Rdo_dw.Location = New System.Drawing.Point(16, 162)
        Me.Rdo_dw.Name = "Rdo_dw"
        Me.Rdo_dw.Size = New System.Drawing.Size(90, 20)
        Me.Rdo_dw.TabIndex = 4
        Me.Rdo_dw.TabStop = True
        Me.Rdo_dw.Text = "多周统计"
        Me.Rdo_dw.UseVisualStyleBackColor = True
        '
        'ComboBox1
        '
        Me.ComboBox1.Location = New System.Drawing.Point(16, 52)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(96, 24)
        Me.ComboBox1.TabIndex = 3
        '
        'Grp_dd
        '
        Me.Grp_dd.Controls.Add(Me.DateTimePicker2)
        Me.Grp_dd.Controls.Add(Me.Grp_dw)
        Me.Grp_dd.Controls.Add(Me.DateTimePicker1)
        Me.Grp_dd.Controls.Add(Me.but_dd)
        Me.Grp_dd.Controls.Add(Me.Label2)
        Me.Grp_dd.Controls.Add(Me.Label1)
        Me.Grp_dd.Location = New System.Drawing.Point(5, 215)
        Me.Grp_dd.Name = "Grp_dd"
        Me.Grp_dd.Size = New System.Drawing.Size(124, 118)
        Me.Grp_dd.TabIndex = 15
        Me.Grp_dd.TabStop = False
        Me.Grp_dd.Text = "多日统计"
        '
        'DateTimePicker2
        '
        Me.DateTimePicker2.CustomFormat = "yyyy-MM-dd"
        Me.DateTimePicker2.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DateTimePicker2.Location = New System.Drawing.Point(23, 57)
        Me.DateTimePicker2.Name = "DateTimePicker2"
        Me.DateTimePicker2.Size = New System.Drawing.Size(95, 26)
        Me.DateTimePicker2.TabIndex = 8
        Me.DateTimePicker2.Value = New Date(2015, 5, 28, 0, 0, 0, 0)
        '
        'Grp_dw
        '
        Me.Grp_dw.Controls.Add(Me.Grp_dm)
        Me.Grp_dw.Controls.Add(Me.ckd_dw)
        Me.Grp_dw.Controls.Add(Me.but_dw)
        Me.Grp_dw.Location = New System.Drawing.Point(33, 0)
        Me.Grp_dw.Name = "Grp_dw"
        Me.Grp_dw.Size = New System.Drawing.Size(124, 118)
        Me.Grp_dw.TabIndex = 17
        Me.Grp_dw.TabStop = False
        Me.Grp_dw.Text = "多周统计"
        Me.Grp_dw.Visible = False
        '
        'Grp_dm
        '
        Me.Grp_dm.Controls.Add(Me.ckd_dm)
        Me.Grp_dm.Controls.Add(Me.but_dm)
        Me.Grp_dm.Location = New System.Drawing.Point(28, 5)
        Me.Grp_dm.Name = "Grp_dm"
        Me.Grp_dm.Size = New System.Drawing.Size(124, 118)
        Me.Grp_dm.TabIndex = 16
        Me.Grp_dm.TabStop = False
        Me.Grp_dm.Text = "多月统计"
        Me.Grp_dm.Visible = False
        '
        'ckd_dm
        '
        Me.ckd_dm.FormattingEnabled = True
        Me.ckd_dm.ItemHeight = 16
        Me.ckd_dm.Location = New System.Drawing.Point(6, 17)
        Me.ckd_dm.Name = "ckd_dm"
        Me.ckd_dm.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended
        Me.ckd_dm.Size = New System.Drawing.Size(111, 68)
        Me.ckd_dm.TabIndex = 2
        '
        'but_dm
        '
        Me.but_dm.Location = New System.Drawing.Point(7, 88)
        Me.but_dm.Name = "but_dm"
        Me.but_dm.Size = New System.Drawing.Size(111, 23)
        Me.but_dm.TabIndex = 1
        Me.but_dm.Text = "查询"
        Me.but_dm.UseVisualStyleBackColor = True
        '
        'ckd_dw
        '
        Me.ckd_dw.FormattingEnabled = True
        Me.ckd_dw.ItemHeight = 16
        Me.ckd_dw.Location = New System.Drawing.Point(6, 17)
        Me.ckd_dw.Name = "ckd_dw"
        Me.ckd_dw.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended
        Me.ckd_dw.Size = New System.Drawing.Size(112, 68)
        Me.ckd_dw.TabIndex = 2
        '
        'but_dw
        '
        Me.but_dw.Location = New System.Drawing.Point(6, 89)
        Me.but_dw.Name = "but_dw"
        Me.but_dw.Size = New System.Drawing.Size(112, 23)
        Me.but_dw.TabIndex = 1
        Me.but_dw.Text = "查询"
        Me.but_dw.UseVisualStyleBackColor = True
        '
        'DateTimePicker1
        '
        Me.DateTimePicker1.CustomFormat = "yyyy-MM-dd"
        Me.DateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DateTimePicker1.Location = New System.Drawing.Point(23, 20)
        Me.DateTimePicker1.Name = "DateTimePicker1"
        Me.DateTimePicker1.Size = New System.Drawing.Size(95, 26)
        Me.DateTimePicker1.TabIndex = 7
        Me.DateTimePicker1.Value = New Date(2015, 5, 19, 0, 0, 0, 0)
        '
        'but_dd
        '
        Me.but_dd.Location = New System.Drawing.Point(6, 89)
        Me.but_dd.Name = "but_dd"
        Me.but_dd.Size = New System.Drawing.Size(112, 23)
        Me.but_dd.TabIndex = 9
        Me.but_dd.Text = "查询"
        Me.but_dd.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(3, 62)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(24, 16)
        Me.Label2.TabIndex = 11
        Me.Label2.Text = "终"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(3, 25)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(24, 16)
        Me.Label1.TabIndex = 10
        Me.Label1.Text = "始"
        '
        'RadioButton6
        '
        Me.RadioButton6.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.RadioButton6.Location = New System.Drawing.Point(16, 79)
        Me.RadioButton6.Name = "RadioButton6"
        Me.RadioButton6.Size = New System.Drawing.Size(96, 24)
        Me.RadioButton6.TabIndex = 2
        Me.RadioButton6.Text = "按月统计"
        '
        'RadioButton5
        '
        Me.RadioButton5.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.RadioButton5.Location = New System.Drawing.Point(16, 25)
        Me.RadioButton5.Name = "RadioButton5"
        Me.RadioButton5.Size = New System.Drawing.Size(96, 24)
        Me.RadioButton5.TabIndex = 1
        Me.RadioButton5.Text = "按周统计"
        '
        'ComboBox2
        '
        Me.ComboBox2.Location = New System.Drawing.Point(16, 106)
        Me.ComboBox2.Name = "ComboBox2"
        Me.ComboBox2.Size = New System.Drawing.Size(96, 24)
        Me.ComboBox2.TabIndex = 3
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.ComboBox3)
        Me.GroupBox1.Controls.Add(Me.RadioButton3)
        Me.GroupBox1.Controls.Add(Me.RadioButton2)
        Me.GroupBox1.Controls.Add(Me.RadioButton1)
        Me.GroupBox1.Controls.Add(Me.RadioButton4)
        Me.GroupBox1.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.GroupBox1.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.GroupBox1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.GroupBox1.Location = New System.Drawing.Point(12, 11)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(136, 160)
        Me.GroupBox1.TabIndex = 11
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "统计对象"
        '
        'ComboBox3
        '
        Me.ComboBox3.Location = New System.Drawing.Point(16, 122)
        Me.ComboBox3.Name = "ComboBox3"
        Me.ComboBox3.Size = New System.Drawing.Size(96, 24)
        Me.ComboBox3.TabIndex = 4
        '
        'RadioButton3
        '
        Me.RadioButton3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.RadioButton3.Location = New System.Drawing.Point(16, 71)
        Me.RadioButton3.Name = "RadioButton3"
        Me.RadioButton3.Size = New System.Drawing.Size(96, 21)
        Me.RadioButton3.TabIndex = 3
        Me.RadioButton3.Text = "集体统计"
        '
        'RadioButton2
        '
        Me.RadioButton2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.RadioButton2.Location = New System.Drawing.Point(16, 47)
        Me.RadioButton2.Name = "RadioButton2"
        Me.RadioButton2.Size = New System.Drawing.Size(96, 21)
        Me.RadioButton2.TabIndex = 2
        Me.RadioButton2.Text = "电子组"
        '
        'RadioButton1
        '
        Me.RadioButton1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.RadioButton1.Location = New System.Drawing.Point(16, 23)
        Me.RadioButton1.Name = "RadioButton1"
        Me.RadioButton1.Size = New System.Drawing.Size(96, 21)
        Me.RadioButton1.TabIndex = 0
        Me.RadioButton1.Text = "软件组"
        '
        'RadioButton4
        '
        Me.RadioButton4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.RadioButton4.Location = New System.Drawing.Point(16, 95)
        Me.RadioButton4.Name = "RadioButton4"
        Me.RadioButton4.Size = New System.Drawing.Size(96, 21)
        Me.RadioButton4.TabIndex = 3
        Me.RadioButton4.Text = "个人统计"
        '
        'Sign_Time
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(792, 625)
        Me.Controls.Add(Me.Sign_Time_Panel)
        Me.DoubleBuffered = True
        Me.Name = "Sign_Time"
        Me.Text = "Sign_Time"
        Me.Sign_Time_Panel.ResumeLayout(False)
        CType(Me.DataGrid1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.Grp_dd.ResumeLayout(False)
        Me.Grp_dd.PerformLayout()
        Me.Grp_dw.ResumeLayout(False)
        Me.Grp_dm.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Sign_Time_Panel As System.Windows.Forms.Panel
    Friend WithEvents DataGrid1 As System.Windows.Forms.DataGrid
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents ComboBox1 As System.Windows.Forms.ComboBox
    Friend WithEvents RadioButton6 As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButton5 As System.Windows.Forms.RadioButton
    Friend WithEvents ComboBox2 As System.Windows.Forms.ComboBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents ComboBox3 As System.Windows.Forms.ComboBox
    Friend WithEvents RadioButton3 As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButton2 As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButton1 As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButton4 As System.Windows.Forms.RadioButton
    Friend WithEvents Rdo_dm As System.Windows.Forms.RadioButton
    Friend WithEvents Rdo_dw As System.Windows.Forms.RadioButton
    Friend WithEvents Rdo_dd As System.Windows.Forms.RadioButton
    Friend WithEvents DateTimePicker2 As System.Windows.Forms.DateTimePicker
    Friend WithEvents DateTimePicker1 As System.Windows.Forms.DateTimePicker
    Friend WithEvents Grp_dw As System.Windows.Forms.GroupBox
    Friend WithEvents Grp_dm As System.Windows.Forms.GroupBox
    Friend WithEvents Grp_dd As System.Windows.Forms.GroupBox
    Friend WithEvents but_dd As System.Windows.Forms.Button
    Friend WithEvents but_dw As System.Windows.Forms.Button
    Friend WithEvents but_dm As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents ckd_dw As System.Windows.Forms.ListBox
    Friend WithEvents ckd_dm As System.Windows.Forms.ListBox
End Class
