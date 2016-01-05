<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class IP_MAC
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
        Me.Lbl_IP = New System.Windows.Forms.Label
        Me.TB_num = New System.Windows.Forms.TextBox
        Me.Button2 = New System.Windows.Forms.Button
        Me.Lbl_Name_Standard = New System.Windows.Forms.Label
        Me.ListView1 = New System.Windows.Forms.ListView
        Me.ColumnHeader1 = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader2 = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader3 = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader4 = New System.Windows.Forms.ColumnHeader
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.TextBox1 = New System.Windows.Forms.TextBox
        Me.TextBox3 = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.TextBox4 = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Lbl_IP
        '
        Me.Lbl_IP.AutoSize = True
        Me.Lbl_IP.Location = New System.Drawing.Point(11, 30)
        Me.Lbl_IP.Name = "Lbl_IP"
        Me.Lbl_IP.Size = New System.Drawing.Size(53, 12)
        Me.Lbl_IP.TabIndex = 123
        Me.Lbl_IP.Text = "IP地址："
        '
        'TB_num
        '
        Me.TB_num.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.TB_num.Location = New System.Drawing.Point(6, 116)
        Me.TB_num.MaxLength = 9
        Me.TB_num.Name = "TB_num"
        Me.TB_num.Size = New System.Drawing.Size(166, 21)
        Me.TB_num.TabIndex = 60
        '
        'Button2
        '
        Me.Button2.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Button2.Location = New System.Drawing.Point(495, 314)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(75, 23)
        Me.Button2.TabIndex = 121
        Me.Button2.Text = "退出"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Lbl_Name_Standard
        '
        Me.Lbl_Name_Standard.AutoSize = True
        Me.Lbl_Name_Standard.Location = New System.Drawing.Point(11, 206)
        Me.Lbl_Name_Standard.Name = "Lbl_Name_Standard"
        Me.Lbl_Name_Standard.Size = New System.Drawing.Size(47, 12)
        Me.Lbl_Name_Standard.TabIndex = 122
        Me.Lbl_Name_Standard.Text = "MAC地址"
        '
        'ListView1
        '
        Me.ListView1.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.ColumnHeader2, Me.ColumnHeader3, Me.ColumnHeader4})
        Me.ListView1.Font = New System.Drawing.Font("宋体", 10.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.ListView1.FullRowSelect = True
        Me.ListView1.GridLines = True
        Me.ListView1.Location = New System.Drawing.Point(12, 12)
        Me.ListView1.MultiSelect = False
        Me.ListView1.Name = "ListView1"
        Me.ListView1.Size = New System.Drawing.Size(422, 600)
        Me.ListView1.TabIndex = 0
        Me.ListView1.UseCompatibleStateImageBehavior = False
        Me.ListView1.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = "IP"
        Me.ColumnHeader1.Width = 50
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.Text = "学号"
        Me.ColumnHeader2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.ColumnHeader2.Width = 100
        '
        'ColumnHeader3
        '
        Me.ColumnHeader3.Text = "姓名"
        Me.ColumnHeader3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.ColumnHeader3.Width = 100
        '
        'ColumnHeader4
        '
        Me.ColumnHeader4.Text = "MAC"
        Me.ColumnHeader4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.ColumnHeader4.Width = 150
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.TextBox1)
        Me.GroupBox1.Controls.Add(Me.TextBox3)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.TextBox4)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.Lbl_IP)
        Me.GroupBox1.Controls.Add(Me.TB_num)
        Me.GroupBox1.Controls.Add(Me.Lbl_Name_Standard)
        Me.GroupBox1.Location = New System.Drawing.Point(440, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(178, 273)
        Me.GroupBox1.TabIndex = 124
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "信息"
        '
        'TextBox1
        '
        Me.TextBox1.Enabled = False
        Me.TextBox1.Location = New System.Drawing.Point(6, 55)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(166, 21)
        Me.TextBox1.TabIndex = 127
        '
        'TextBox3
        '
        Me.TextBox3.Enabled = False
        Me.TextBox3.Location = New System.Drawing.Point(6, 172)
        Me.TextBox3.Name = "TextBox3"
        Me.TextBox3.Size = New System.Drawing.Size(166, 21)
        Me.TextBox3.TabIndex = 126
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(11, 149)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(41, 12)
        Me.Label2.TabIndex = 125
        Me.Label2.Text = "姓名："
        '
        'TextBox4
        '
        Me.TextBox4.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.TextBox4.Location = New System.Drawing.Point(6, 230)
        Me.TextBox4.Name = "TextBox4"
        Me.TextBox4.Size = New System.Drawing.Size(166, 21)
        Me.TextBox4.TabIndex = 124
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(11, 92)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(41, 12)
        Me.Label1.TabIndex = 123
        Me.Label1.Text = "学号："
        '
        'IP_MAC
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(630, 624)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.ListView1)
        Me.Controls.Add(Me.Button2)
        Me.DoubleBuffered = True
        Me.Name = "IP_MAC"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "修改IP_NUM"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Lbl_IP As System.Windows.Forms.Label
    Friend WithEvents TB_num As System.Windows.Forms.TextBox
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Lbl_Name_Standard As System.Windows.Forms.Label
    Friend WithEvents ListView1 As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader1 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader2 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader3 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader4 As System.Windows.Forms.ColumnHeader
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TextBox4 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox3 As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox

End Class
