<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class LogRead
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
        Me.LogReadPanel = New System.Windows.Forms.Panel
        Me.Refreshbt = New System.Windows.Forms.Button
        Me.DateTimePicker1 = New System.Windows.Forms.DateTimePicker
        Me.Button1 = New System.Windows.Forms.Button
        Me.Label5 = New System.Windows.Forms.Label
        Me.TextBox2 = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.TextBox1 = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.ComboBox1 = New System.Windows.Forms.ComboBox
        Me.ListView1 = New System.Windows.Forms.ListView
        Me.ColumnHeader1 = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader2 = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader3 = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader4 = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader5 = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader6 = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader7 = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader8 = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader9 = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader10 = New System.Windows.Forms.ColumnHeader
        Me.Label1 = New System.Windows.Forms.Label
        Me.LogReadPanel.SuspendLayout()
        Me.SuspendLayout()
        '
        'LogReadPanel
        '
        Me.LogReadPanel.Controls.Add(Me.Refreshbt)
        Me.LogReadPanel.Controls.Add(Me.DateTimePicker1)
        Me.LogReadPanel.Controls.Add(Me.Button1)
        Me.LogReadPanel.Controls.Add(Me.Label5)
        Me.LogReadPanel.Controls.Add(Me.TextBox2)
        Me.LogReadPanel.Controls.Add(Me.Label4)
        Me.LogReadPanel.Controls.Add(Me.TextBox1)
        Me.LogReadPanel.Controls.Add(Me.Label3)
        Me.LogReadPanel.Controls.Add(Me.Label2)
        Me.LogReadPanel.Controls.Add(Me.ComboBox1)
        Me.LogReadPanel.Controls.Add(Me.ListView1)
        Me.LogReadPanel.Controls.Add(Me.Label1)
        Me.LogReadPanel.Location = New System.Drawing.Point(0, 0)
        Me.LogReadPanel.Margin = New System.Windows.Forms.Padding(0)
        Me.LogReadPanel.Name = "LogReadPanel"
        Me.LogReadPanel.Size = New System.Drawing.Size(728, 563)
        Me.LogReadPanel.TabIndex = 0
        '
        'Refreshbt
        '
        Me.Refreshbt.Location = New System.Drawing.Point(351, 537)
        Me.Refreshbt.Name = "Refreshbt"
        Me.Refreshbt.Size = New System.Drawing.Size(54, 20)
        Me.Refreshbt.TabIndex = 12
        Me.Refreshbt.Text = "刷新"
        Me.Refreshbt.UseVisualStyleBackColor = True
        '
        'DateTimePicker1
        '
        Me.DateTimePicker1.Location = New System.Drawing.Point(135, 506)
        Me.DateTimePicker1.Name = "DateTimePicker1"
        Me.DateTimePicker1.Size = New System.Drawing.Size(118, 21)
        Me.DateTimePicker1.TabIndex = 11
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(424, 537)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(70, 20)
        Me.Button1.TabIndex = 10
        Me.Button1.Text = "导出到TXT"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(143, 543)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(53, 12)
        Me.Label5.TabIndex = 9
        Me.Label5.Text = "登录信息"
        '
        'TextBox2
        '
        Me.TextBox2.Location = New System.Drawing.Point(544, 506)
        Me.TextBox2.MaxLength = 9
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Size = New System.Drawing.Size(92, 21)
        Me.TextBox2.TabIndex = 8
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(461, 512)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(77, 12)
        Me.Label4.TabIndex = 7
        Me.Label4.Text = "被修改人学号"
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(340, 506)
        Me.TextBox1.MaxLength = 9
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(83, 21)
        Me.TextBox1.TabIndex = 6
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(269, 512)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(65, 12)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "操作人学号"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(76, 512)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(53, 12)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "操作时间"
        '
        'ComboBox1
        '
        Me.ComboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox1.FormattingEnabled = True
        Me.ComboBox1.Location = New System.Drawing.Point(202, 537)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(128, 20)
        Me.ComboBox1.TabIndex = 3
        '
        'ListView1
        '
        Me.ListView1.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.ListView1.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.ColumnHeader2, Me.ColumnHeader3, Me.ColumnHeader4, Me.ColumnHeader5, Me.ColumnHeader6, Me.ColumnHeader7, Me.ColumnHeader8, Me.ColumnHeader9, Me.ColumnHeader10})
        Me.ListView1.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.ListView1.FullRowSelect = True
        Me.ListView1.Location = New System.Drawing.Point(3, 5)
        Me.ListView1.MultiSelect = False
        Me.ListView1.Name = "ListView1"
        Me.ListView1.Size = New System.Drawing.Size(713, 498)
        Me.ListView1.TabIndex = 2
        Me.ListView1.UseCompatibleStateImageBehavior = False
        Me.ListView1.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = "ID"
        Me.ColumnHeader1.Width = 26
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.Text = "操作人学号"
        Me.ColumnHeader2.Width = 77
        '
        'ColumnHeader3
        '
        Me.ColumnHeader3.Text = "操作时间"
        Me.ColumnHeader3.Width = 130
        '
        'ColumnHeader4
        '
        Me.ColumnHeader4.Text = "操作人IP"
        Me.ColumnHeader4.Width = 110
        '
        'ColumnHeader5
        '
        Me.ColumnHeader5.Text = "被修改人学号"
        Me.ColumnHeader5.Width = 89
        '
        'ColumnHeader6
        '
        Me.ColumnHeader6.Text = "硬件成绩"
        Me.ColumnHeader6.Width = 63
        '
        'ColumnHeader7
        '
        Me.ColumnHeader7.Text = "软件成绩"
        Me.ColumnHeader7.Width = 63
        '
        'ColumnHeader8
        '
        Me.ColumnHeader8.Text = "试卷成绩"
        Me.ColumnHeader8.Width = 63
        '
        'ColumnHeader9
        '
        Me.ColumnHeader9.Text = "登录信息"
        Me.ColumnHeader9.Width = 120
        '
        'ColumnHeader10
        '
        Me.ColumnHeader10.Text = "版本号"
        Me.ColumnHeader10.Width = 51
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(99, 516)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(0, 12)
        Me.Label1.TabIndex = 1
        '
        'LogRead
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(917, 722)
        Me.Controls.Add(Me.LogReadPanel)
        Me.DoubleBuffered = True
        Me.Name = "LogRead"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.Text = "LogRead"
        Me.LogReadPanel.ResumeLayout(False)
        Me.LogReadPanel.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents LogReadPanel As System.Windows.Forms.Panel
    Friend WithEvents ListView1 As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader1 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader2 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader3 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader4 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader5 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader6 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader7 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader8 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader9 As System.Windows.Forms.ColumnHeader
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents ComboBox1 As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents TextBox2 As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents DateTimePicker1 As System.Windows.Forms.DateTimePicker
    Friend WithEvents Refreshbt As System.Windows.Forms.Button
    Friend WithEvents ColumnHeader10 As System.Windows.Forms.ColumnHeader
End Class
