<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Config
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
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.ReturnZero = New System.Windows.Forms.Button
        Me.NumericUpDown4 = New System.Windows.Forms.NumericUpDown
        Me.Total = New System.Windows.Forms.TextBox
        Me.NumericUpDown3 = New System.Windows.Forms.NumericUpDown
        Me.Label11 = New System.Windows.Forms.Label
        Me.NumericUpDown2 = New System.Windows.Forms.NumericUpDown
        Me.NumericUpDown1 = New System.Windows.Forms.NumericUpDown
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.DateTimePicker1 = New System.Windows.Forms.DateTimePicker
        Me.Save1 = New System.Windows.Forms.Button
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.RBno = New System.Windows.Forms.RadioButton
        Me.RByes = New System.Windows.Forms.RadioButton
        Me.Label10 = New System.Windows.Forms.Label
        Me.quit = New System.Windows.Forms.Button
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.Save2 = New System.Windows.Forms.Button
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.GroupBox1.SuspendLayout()
        CType(Me.NumericUpDown4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NumericUpDown3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NumericUpDown2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NumericUpDown1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.ReturnZero)
        Me.GroupBox1.Controls.Add(Me.NumericUpDown4)
        Me.GroupBox1.Controls.Add(Me.Total)
        Me.GroupBox1.Controls.Add(Me.NumericUpDown3)
        Me.GroupBox1.Controls.Add(Me.Label11)
        Me.GroupBox1.Controls.Add(Me.NumericUpDown2)
        Me.GroupBox1.Controls.Add(Me.NumericUpDown1)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.DateTimePicker1)
        Me.GroupBox1.Controls.Add(Me.Save1)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(268, 180)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "初始设定"
        '
        'ReturnZero
        '
        Me.ReturnZero.Location = New System.Drawing.Point(35, 148)
        Me.ReturnZero.Name = "ReturnZero"
        Me.ReturnZero.Size = New System.Drawing.Size(107, 21)
        Me.ReturnZero.TabIndex = 25
        Me.ReturnZero.Text = "所有数据初始化"
        Me.ReturnZero.UseVisualStyleBackColor = True
        '
        'NumericUpDown4
        '
        Me.NumericUpDown4.Location = New System.Drawing.Point(178, 88)
        Me.NumericUpDown4.Maximum = New Decimal(New Integer() {18, 0, 0, 0})
        Me.NumericUpDown4.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.NumericUpDown4.Name = "NumericUpDown4"
        Me.NumericUpDown4.Size = New System.Drawing.Size(35, 21)
        Me.NumericUpDown4.TabIndex = 19
        Me.NumericUpDown4.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'Total
        '
        Me.Total.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.Total.Location = New System.Drawing.Point(80, 117)
        Me.Total.MaxLength = 2
        Me.Total.Name = "Total"
        Me.Total.Size = New System.Drawing.Size(156, 21)
        Me.Total.TabIndex = 24
        '
        'NumericUpDown3
        '
        Me.NumericUpDown3.Location = New System.Drawing.Point(96, 88)
        Me.NumericUpDown3.Maximum = New Decimal(New Integer() {18, 0, 0, 0})
        Me.NumericUpDown3.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.NumericUpDown3.Name = "NumericUpDown3"
        Me.NumericUpDown3.Size = New System.Drawing.Size(35, 21)
        Me.NumericUpDown3.TabIndex = 18
        Me.NumericUpDown3.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(20, 122)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(41, 12)
        Me.Label11.TabIndex = 23
        Me.Label11.Text = "课容量"
        '
        'NumericUpDown2
        '
        Me.NumericUpDown2.Location = New System.Drawing.Point(178, 58)
        Me.NumericUpDown2.Maximum = New Decimal(New Integer() {18, 0, 0, 0})
        Me.NumericUpDown2.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.NumericUpDown2.Name = "NumericUpDown2"
        Me.NumericUpDown2.Size = New System.Drawing.Size(35, 21)
        Me.NumericUpDown2.TabIndex = 17
        Me.NumericUpDown2.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'NumericUpDown1
        '
        Me.NumericUpDown1.Location = New System.Drawing.Point(96, 58)
        Me.NumericUpDown1.Maximum = New Decimal(New Integer() {18, 0, 0, 0})
        Me.NumericUpDown1.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.NumericUpDown1.Name = "NumericUpDown1"
        Me.NumericUpDown1.Size = New System.Drawing.Size(35, 21)
        Me.NumericUpDown1.TabIndex = 16
        Me.NumericUpDown1.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(219, 92)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(17, 12)
        Me.Label7.TabIndex = 14
        Me.Label7.Text = "周"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(137, 92)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(35, 12)
        Me.Label8.TabIndex = 12
        Me.Label8.Text = "周 到"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(73, 92)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(17, 12)
        Me.Label9.TabIndex = 11
        Me.Label9.Text = "从"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(219, 62)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(17, 12)
        Me.Label6.TabIndex = 9
        Me.Label6.Text = "周"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(137, 62)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(35, 12)
        Me.Label5.TabIndex = 7
        Me.Label5.Text = "周 到"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(73, 62)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(17, 12)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "从"
        '
        'DateTimePicker1
        '
        Me.DateTimePicker1.Location = New System.Drawing.Point(89, 27)
        Me.DateTimePicker1.MaxDate = New Date(2050, 12, 31, 0, 0, 0, 0)
        Me.DateTimePicker1.MinDate = New Date(2012, 1, 1, 0, 0, 0, 0)
        Me.DateTimePicker1.Name = "DateTimePicker1"
        Me.DateTimePicker1.Size = New System.Drawing.Size(147, 21)
        Me.DateTimePicker1.TabIndex = 4
        '
        'Save1
        '
        Me.Save1.Location = New System.Drawing.Point(170, 148)
        Me.Save1.Name = "Save1"
        Me.Save1.Size = New System.Drawing.Size(66, 21)
        Me.Save1.TabIndex = 3
        Me.Save1.Text = "保存数据"
        Me.Save1.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(20, 92)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(41, 12)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "软件周"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(20, 62)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(41, 12)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "硬件周"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(20, 31)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(53, 12)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "开学日期"
        '
        'RBno
        '
        Me.RBno.AutoSize = True
        Me.RBno.Location = New System.Drawing.Point(190, 22)
        Me.RBno.Name = "RBno"
        Me.RBno.Size = New System.Drawing.Size(35, 16)
        Me.RBno.TabIndex = 22
        Me.RBno.TabStop = True
        Me.RBno.Text = "否"
        Me.RBno.UseVisualStyleBackColor = True
        '
        'RByes
        '
        Me.RByes.AutoSize = True
        Me.RByes.Location = New System.Drawing.Point(137, 22)
        Me.RByes.Name = "RByes"
        Me.RByes.Size = New System.Drawing.Size(35, 16)
        Me.RByes.TabIndex = 21
        Me.RByes.TabStop = True
        Me.RByes.Text = "是"
        Me.RByes.UseVisualStyleBackColor = True
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(20, 25)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(89, 12)
        Me.Label10.TabIndex = 20
        Me.Label10.Text = "是否关闭选课："
        '
        'quit
        '
        Me.quit.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.quit.Location = New System.Drawing.Point(163, 311)
        Me.quit.Name = "quit"
        Me.quit.Size = New System.Drawing.Size(74, 21)
        Me.quit.TabIndex = 15
        Me.quit.Text = "关闭"
        Me.quit.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Save2)
        Me.GroupBox2.Controls.Add(Me.Label10)
        Me.GroupBox2.Controls.Add(Me.RBno)
        Me.GroupBox2.Controls.Add(Me.RByes)
        Me.GroupBox2.Location = New System.Drawing.Point(12, 209)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(268, 82)
        Me.GroupBox2.TabIndex = 1
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "选课开关"
        '
        'Save2
        '
        Me.Save2.Location = New System.Drawing.Point(113, 53)
        Me.Save2.Name = "Save2"
        Me.Save2.Size = New System.Drawing.Size(112, 21)
        Me.Save2.TabIndex = 25
        Me.Save2.Text = "保存选课开关数据"
        Me.Save2.UseVisualStyleBackColor = True
        '
        'Config
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.quit
        Me.ClientSize = New System.Drawing.Size(286, 348)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.quit)
        Me.DoubleBuffered = True
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(302, 387)
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(302, 387)
        Me.Name = "Config"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "系统初始化设定"
        Me.TopMost = True
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.NumericUpDown4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NumericUpDown3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NumericUpDown2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NumericUpDown1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents quit As System.Windows.Forms.Button
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents DateTimePicker1 As System.Windows.Forms.DateTimePicker
    Friend WithEvents Save1 As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents NumericUpDown4 As System.Windows.Forms.NumericUpDown
    Friend WithEvents NumericUpDown3 As System.Windows.Forms.NumericUpDown
    Friend WithEvents NumericUpDown2 As System.Windows.Forms.NumericUpDown
    Friend WithEvents NumericUpDown1 As System.Windows.Forms.NumericUpDown
    Friend WithEvents RBno As System.Windows.Forms.RadioButton
    Friend WithEvents RByes As System.Windows.Forms.RadioButton
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Total As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Save2 As System.Windows.Forms.Button
    Friend WithEvents ReturnZero As System.Windows.Forms.Button
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
End Class
