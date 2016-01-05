<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Appoint_Admin
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
        Me.Appoint_Admin_Panel = New System.Windows.Forms.Panel
        Me.指定班委 = New System.Windows.Forms.GroupBox
        Me.Label15 = New System.Windows.Forms.Label
        Me.Label14 = New System.Windows.Forms.Label
        Me.ListBox3 = New System.Windows.Forms.ListBox
        Me.TextBox4 = New System.Windows.Forms.TextBox
        Me.ListBox1 = New System.Windows.Forms.ListBox
        Me.Label12 = New System.Windows.Forms.Label
        Me.Appoint_Admin_Panel.SuspendLayout()
        Me.指定班委.SuspendLayout()
        Me.SuspendLayout()
        '
        'Appoint_Admin_Panel
        '
        Me.Appoint_Admin_Panel.BackColor = System.Drawing.Color.Transparent
        Me.Appoint_Admin_Panel.Controls.Add(Me.指定班委)
        Me.Appoint_Admin_Panel.Location = New System.Drawing.Point(0, 0)
        Me.Appoint_Admin_Panel.Margin = New System.Windows.Forms.Padding(0)
        Me.Appoint_Admin_Panel.Name = "Appoint_Admin_Panel"
        Me.Appoint_Admin_Panel.Size = New System.Drawing.Size(728, 565)
        Me.Appoint_Admin_Panel.TabIndex = 20
        '
        '指定班委
        '
        Me.指定班委.Controls.Add(Me.Label15)
        Me.指定班委.Controls.Add(Me.Label14)
        Me.指定班委.Controls.Add(Me.ListBox3)
        Me.指定班委.Controls.Add(Me.TextBox4)
        Me.指定班委.Controls.Add(Me.ListBox1)
        Me.指定班委.Controls.Add(Me.Label12)
        Me.指定班委.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.指定班委.Location = New System.Drawing.Point(23, 21)
        Me.指定班委.Name = "指定班委"
        Me.指定班委.Size = New System.Drawing.Size(672, 518)
        Me.指定班委.TabIndex = 22
        Me.指定班委.TabStop = False
        Me.指定班委.Text = "指定班委"
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
        'ListBox3
        '
        Me.ListBox3.FormattingEnabled = True
        Me.ListBox3.ItemHeight = 16
        Me.ListBox3.Location = New System.Drawing.Point(354, 55)
        Me.ListBox3.Name = "ListBox3"
        Me.ListBox3.Size = New System.Drawing.Size(290, 436)
        Me.ListBox3.TabIndex = 10
        '
        'TextBox4
        '
        Me.TextBox4.Location = New System.Drawing.Point(15, 55)
        Me.TextBox4.Name = "TextBox4"
        Me.TextBox4.Size = New System.Drawing.Size(292, 26)
        Me.TextBox4.TabIndex = 8
        '
        'ListBox1
        '
        Me.ListBox1.FormattingEnabled = True
        Me.ListBox1.ItemHeight = 16
        Me.ListBox1.Location = New System.Drawing.Point(16, 121)
        Me.ListBox1.Name = "ListBox1"
        Me.ListBox1.Size = New System.Drawing.Size(291, 372)
        Me.ListBox1.TabIndex = 7
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(351, 28)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(152, 16)
        Me.Label12.TabIndex = 4
        Me.Label12.Text = "班委列表(双击去除)"
        '
        'Appoint_Admin
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(775, 589)
        Me.Controls.Add(Me.Appoint_Admin_Panel)
        Me.DoubleBuffered = True
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.KeyPreview = True
        Me.MaximumSize = New System.Drawing.Size(1000, 900)
        Me.MinimumSize = New System.Drawing.Size(55, 55)
        Me.Name = "Appoint_Admin"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "指定班委"
        Me.Appoint_Admin_Panel.ResumeLayout(False)
        Me.指定班委.ResumeLayout(False)
        Me.指定班委.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Appoint_Admin_Panel As System.Windows.Forms.Panel
    Friend WithEvents 指定班委 As System.Windows.Forms.GroupBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents ListBox3 As System.Windows.Forms.ListBox
    Friend WithEvents TextBox4 As System.Windows.Forms.TextBox
    Friend WithEvents ListBox1 As System.Windows.Forms.ListBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label

End Class