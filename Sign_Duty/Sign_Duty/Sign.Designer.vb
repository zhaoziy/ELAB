<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Sign
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
        Me.components = New System.ComponentModel.Container
        Me.Sign_Panel = New System.Windows.Forms.Panel
        Me.Lb显示在线 = New System.Windows.Forms.ListView
        Me.ColumnHeader9 = New System.Windows.Forms.ColumnHeader
        Me.DateTimePicker1 = New System.Windows.Forms.DateTimePicker
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.ListView1 = New System.Windows.Forms.ListView
        Me.ColumnHeader1 = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader2 = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader3 = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader6 = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader8 = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader4 = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader5 = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader7 = New System.Windows.Forms.ColumnHeader
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.Sign_Panel.SuspendLayout()
        Me.SuspendLayout()
        '
        'Sign_Panel
        '
        Me.Sign_Panel.Controls.Add(Me.Lb显示在线)
        Me.Sign_Panel.Controls.Add(Me.DateTimePicker1)
        Me.Sign_Panel.Controls.Add(Me.Label5)
        Me.Sign_Panel.Controls.Add(Me.Label4)
        Me.Sign_Panel.Controls.Add(Me.Label1)
        Me.Sign_Panel.Controls.Add(Me.ListView1)
        Me.Sign_Panel.Controls.Add(Me.Label2)
        Me.Sign_Panel.Controls.Add(Me.Label3)
        Me.Sign_Panel.Location = New System.Drawing.Point(0, 0)
        Me.Sign_Panel.Margin = New System.Windows.Forms.Padding(0)
        Me.Sign_Panel.Name = "Sign_Panel"
        Me.Sign_Panel.Size = New System.Drawing.Size(728, 565)
        Me.Sign_Panel.TabIndex = 0
        '
        'Lb显示在线
        '
        Me.Lb显示在线.BackColor = System.Drawing.SystemColors.Control
        Me.Lb显示在线.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.Lb显示在线.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader9})
        Me.Lb显示在线.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Lb显示在线.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None
        Me.Lb显示在线.LabelWrap = False
        Me.Lb显示在线.Location = New System.Drawing.Point(12, 215)
        Me.Lb显示在线.MultiSelect = False
        Me.Lb显示在线.Name = "Lb显示在线"
        Me.Lb显示在线.Size = New System.Drawing.Size(112, 346)
        Me.Lb显示在线.TabIndex = 32
        Me.Lb显示在线.UseCompatibleStateImageBehavior = False
        Me.Lb显示在线.View = System.Windows.Forms.View.List
        '
        'ColumnHeader9
        '
        Me.ColumnHeader9.Text = "姓名"
        Me.ColumnHeader9.Width = 100
        '
        'DateTimePicker1
        '
        Me.DateTimePicker1.Location = New System.Drawing.Point(12, 21)
        Me.DateTimePicker1.Name = "DateTimePicker1"
        Me.DateTimePicker1.Size = New System.Drawing.Size(112, 21)
        Me.DateTimePicker1.TabIndex = 31
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("微软雅黑", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label5.Location = New System.Drawing.Point(12, 175)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(74, 22)
        Me.Label5.TabIndex = 30
        Me.Label5.Text = "当前在线"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("微软雅黑", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label4.Location = New System.Drawing.Point(12, 119)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(58, 22)
        Me.Label4.TabIndex = 29
        Me.Label4.Text = "刚下："
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("微软雅黑", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label1.Location = New System.Drawing.Point(12, 56)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(58, 22)
        Me.Label1.TabIndex = 28
        Me.Label1.Text = "新到："
        '
        'ListView1
        '
        Me.ListView1.BackColor = System.Drawing.Color.White
        Me.ListView1.BackgroundImageTiled = True
        Me.ListView1.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.ColumnHeader2, Me.ColumnHeader3, Me.ColumnHeader6, Me.ColumnHeader8, Me.ColumnHeader4, Me.ColumnHeader5, Me.ColumnHeader7})
        Me.ListView1.Font = New System.Drawing.Font("宋体", 10.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.ListView1.FullRowSelect = True
        Me.ListView1.GridLines = True
        Me.ListView1.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable
        Me.ListView1.Location = New System.Drawing.Point(130, 12)
        Me.ListView1.Name = "ListView1"
        Me.ListView1.Size = New System.Drawing.Size(595, 549)
        Me.ListView1.TabIndex = 27
        Me.ListView1.UseCompatibleStateImageBehavior = False
        Me.ListView1.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = "学号"
        Me.ColumnHeader1.Width = 75
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.Text = "姓名"
        Me.ColumnHeader2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.ColumnHeader2.Width = 68
        '
        'ColumnHeader3
        '
        Me.ColumnHeader3.Text = "组别"
        Me.ColumnHeader3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'ColumnHeader6
        '
        Me.ColumnHeader6.Text = "日期"
        Me.ColumnHeader6.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.ColumnHeader6.Width = 75
        '
        'ColumnHeader8
        '
        Me.ColumnHeader8.Text = "周次"
        Me.ColumnHeader8.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.ColumnHeader8.Width = 40
        '
        'ColumnHeader4
        '
        Me.ColumnHeader4.Text = "登入"
        Me.ColumnHeader4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.ColumnHeader4.Width = 88
        '
        'ColumnHeader5
        '
        Me.ColumnHeader5.Text = "离开"
        Me.ColumnHeader5.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.ColumnHeader5.Width = 88
        '
        'ColumnHeader7
        '
        Me.ColumnHeader7.Text = "合计时间"
        Me.ColumnHeader7.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.ColumnHeader7.Width = 77
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("微软雅黑", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.SteelBlue
        Me.Label2.Location = New System.Drawing.Point(26, 88)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(63, 22)
        Me.Label2.TabIndex = 25
        Me.Label2.Text = "Label2"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("微软雅黑", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.SteelBlue
        Me.Label3.Location = New System.Drawing.Point(26, 147)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(63, 22)
        Me.Label3.TabIndex = 26
        Me.Label3.Text = "Label3"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Timer1
        '
        '
        'Sign
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(752, 573)
        Me.Controls.Add(Me.Sign_Panel)
        Me.DoubleBuffered = True
        Me.Name = "Sign"
        Me.Text = "Sign"
        Me.Sign_Panel.ResumeLayout(False)
        Me.Sign_Panel.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Sign_Panel As System.Windows.Forms.Panel
    Friend WithEvents ListView1 As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader1 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader2 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader3 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader6 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader8 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader4 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader5 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader7 As System.Windows.Forms.ColumnHeader
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents DateTimePicker1 As System.Windows.Forms.DateTimePicker
    Friend WithEvents Lb显示在线 As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader9 As System.Windows.Forms.ColumnHeader
End Class
