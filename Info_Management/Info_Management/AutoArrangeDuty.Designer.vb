<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AutoArrangeDuty
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
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.GB_Dual = New System.Windows.Forms.GroupBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.LB_All_Dual_Standard = New System.Windows.Forms.ListBox
        Me.LB_Auto_Dual_Standard = New System.Windows.Forms.ListBox
        Me.GB_Singular = New System.Windows.Forms.GroupBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.LB_Auto_Singular_Standard = New System.Windows.Forms.ListBox
        Me.LB_All_Singular_Standard = New System.Windows.Forms.ListBox
        Me.BT_Auto = New System.Windows.Forms.Button
        Me.Label5 = New System.Windows.Forms.Label
        Me.NumericUpDown1 = New System.Windows.Forms.NumericUpDown
        Me.NumericUpDown2 = New System.Windows.Forms.NumericUpDown
        Me.Label6 = New System.Windows.Forms.Label
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.Export_Excel = New System.Windows.Forms.Button
        Me.Panel1.SuspendLayout()
        Me.GB_Dual.SuspendLayout()
        Me.GB_Singular.SuspendLayout()
        CType(Me.NumericUpDown1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NumericUpDown2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox3.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.AutoScroll = True
        Me.Panel1.Controls.Add(Me.GB_Dual)
        Me.Panel1.Controls.Add(Me.GB_Singular)
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1057, 617)
        Me.Panel1.TabIndex = 0
        '
        'GB_Dual
        '
        Me.GB_Dual.Controls.Add(Me.Label3)
        Me.GB_Dual.Controls.Add(Me.Label4)
        Me.GB_Dual.Controls.Add(Me.LB_All_Dual_Standard)
        Me.GB_Dual.Controls.Add(Me.LB_Auto_Dual_Standard)
        Me.GB_Dual.Location = New System.Drawing.Point(26, 325)
        Me.GB_Dual.Name = "GB_Dual"
        Me.GB_Dual.Size = New System.Drawing.Size(986, 286)
        Me.GB_Dual.TabIndex = 8
        Me.GB_Dual.TabStop = False
        Me.GB_Dual.Text = "双周"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(27, 152)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(77, 12)
        Me.Label3.TabIndex = 15
        Me.Label3.Text = "自动选择结果"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(27, 26)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(29, 12)
        Me.Label4.TabIndex = 14
        Me.Label4.Text = "备选"
        '
        'LB_All_Dual_Standard
        '
        Me.LB_All_Dual_Standard.FormattingEnabled = True
        Me.LB_All_Dual_Standard.ItemHeight = 12
        Me.LB_All_Dual_Standard.Location = New System.Drawing.Point(17, 47)
        Me.LB_All_Dual_Standard.Name = "LB_All_Dual_Standard"
        Me.LB_All_Dual_Standard.Size = New System.Drawing.Size(120, 88)
        Me.LB_All_Dual_Standard.TabIndex = 13
        '
        'LB_Auto_Dual_Standard
        '
        Me.LB_Auto_Dual_Standard.FormattingEnabled = True
        Me.LB_Auto_Dual_Standard.ItemHeight = 12
        Me.LB_Auto_Dual_Standard.Location = New System.Drawing.Point(17, 177)
        Me.LB_Auto_Dual_Standard.Name = "LB_Auto_Dual_Standard"
        Me.LB_Auto_Dual_Standard.Size = New System.Drawing.Size(120, 88)
        Me.LB_Auto_Dual_Standard.TabIndex = 6
        '
        'GB_Singular
        '
        Me.GB_Singular.Controls.Add(Me.Label2)
        Me.GB_Singular.Controls.Add(Me.Label1)
        Me.GB_Singular.Controls.Add(Me.LB_Auto_Singular_Standard)
        Me.GB_Singular.Controls.Add(Me.LB_All_Singular_Standard)
        Me.GB_Singular.Location = New System.Drawing.Point(26, 22)
        Me.GB_Singular.Name = "GB_Singular"
        Me.GB_Singular.Size = New System.Drawing.Size(986, 286)
        Me.GB_Singular.TabIndex = 7
        Me.GB_Singular.TabStop = False
        Me.GB_Singular.Text = "单周"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(27, 152)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(77, 12)
        Me.Label2.TabIndex = 15
        Me.Label2.Text = "自动选择结果"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(27, 26)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(29, 12)
        Me.Label1.TabIndex = 14
        Me.Label1.Text = "备选"
        '
        'LB_Auto_Singular_Standard
        '
        Me.LB_Auto_Singular_Standard.FormattingEnabled = True
        Me.LB_Auto_Singular_Standard.ItemHeight = 12
        Me.LB_Auto_Singular_Standard.Location = New System.Drawing.Point(17, 177)
        Me.LB_Auto_Singular_Standard.Name = "LB_Auto_Singular_Standard"
        Me.LB_Auto_Singular_Standard.Size = New System.Drawing.Size(120, 88)
        Me.LB_Auto_Singular_Standard.TabIndex = 13
        '
        'LB_All_Singular_Standard
        '
        Me.LB_All_Singular_Standard.FormattingEnabled = True
        Me.LB_All_Singular_Standard.ItemHeight = 12
        Me.LB_All_Singular_Standard.Location = New System.Drawing.Point(17, 50)
        Me.LB_All_Singular_Standard.Name = "LB_All_Singular_Standard"
        Me.LB_All_Singular_Standard.Size = New System.Drawing.Size(120, 88)
        Me.LB_All_Singular_Standard.TabIndex = 0
        '
        'BT_Auto
        '
        Me.BT_Auto.Location = New System.Drawing.Point(449, 634)
        Me.BT_Auto.Name = "BT_Auto"
        Me.BT_Auto.Size = New System.Drawing.Size(131, 39)
        Me.BT_Auto.TabIndex = 1
        Me.BT_Auto.Text = "试试手气"
        Me.BT_Auto.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(167, 27)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(17, 12)
        Me.Label5.TabIndex = 12
        Me.Label5.Text = "周"
        '
        'NumericUpDown1
        '
        Me.NumericUpDown1.Location = New System.Drawing.Point(16, 25)
        Me.NumericUpDown1.Maximum = New Decimal(New Integer() {20, 0, 0, 0})
        Me.NumericUpDown1.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.NumericUpDown1.Name = "NumericUpDown1"
        Me.NumericUpDown1.Size = New System.Drawing.Size(43, 21)
        Me.NumericUpDown1.TabIndex = 11
        Me.NumericUpDown1.Value = New Decimal(New Integer() {3, 0, 0, 0})
        '
        'NumericUpDown2
        '
        Me.NumericUpDown2.Location = New System.Drawing.Point(118, 25)
        Me.NumericUpDown2.Maximum = New Decimal(New Integer() {20, 0, 0, 0})
        Me.NumericUpDown2.Minimum = New Decimal(New Integer() {2, 0, 0, 0})
        Me.NumericUpDown2.Name = "NumericUpDown2"
        Me.NumericUpDown2.Size = New System.Drawing.Size(43, 21)
        Me.NumericUpDown2.TabIndex = 10
        Me.NumericUpDown2.Value = New Decimal(New Integer() {16, 0, 0, 0})
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(65, 27)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(47, 12)
        Me.Label6.TabIndex = 9
        Me.Label6.Text = "周 ——"
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.NumericUpDown1)
        Me.GroupBox3.Controls.Add(Me.Label5)
        Me.GroupBox3.Controls.Add(Me.Label6)
        Me.GroupBox3.Controls.Add(Me.NumericUpDown2)
        Me.GroupBox3.Location = New System.Drawing.Point(146, 624)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(200, 51)
        Me.GroupBox3.TabIndex = 13
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "时间区段"
        '
        'Export_Excel
        '
        Me.Export_Excel.Location = New System.Drawing.Point(612, 634)
        Me.Export_Excel.Name = "Export_Excel"
        Me.Export_Excel.Size = New System.Drawing.Size(131, 39)
        Me.Export_Excel.TabIndex = 14
        Me.Export_Excel.Text = "导出到Excel"
        Me.Export_Excel.UseVisualStyleBackColor = True
        '
        'AutoArrangeDuty
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1058, 687)
        Me.Controls.Add(Me.Export_Excel)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.BT_Auto)
        Me.Controls.Add(Me.Panel1)
        Me.DoubleBuffered = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "AutoArrangeDuty"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "自动安排值班"
        Me.Panel1.ResumeLayout(False)
        Me.GB_Dual.ResumeLayout(False)
        Me.GB_Dual.PerformLayout()
        Me.GB_Singular.ResumeLayout(False)
        Me.GB_Singular.PerformLayout()
        CType(Me.NumericUpDown1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NumericUpDown2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents GB_Singular As System.Windows.Forms.GroupBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents LB_Auto_Singular_Standard As System.Windows.Forms.ListBox
    Friend WithEvents LB_All_Singular_Standard As System.Windows.Forms.ListBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents GB_Dual As System.Windows.Forms.GroupBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents LB_All_Dual_Standard As System.Windows.Forms.ListBox
    Friend WithEvents LB_Auto_Dual_Standard As System.Windows.Forms.ListBox
    Friend WithEvents BT_Auto As System.Windows.Forms.Button
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents NumericUpDown1 As System.Windows.Forms.NumericUpDown
    Friend WithEvents NumericUpDown2 As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents Export_Excel As System.Windows.Forms.Button
End Class
