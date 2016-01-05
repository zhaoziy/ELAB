<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Duty_Table
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
        Me.Duty_Table_Panel = New System.Windows.Forms.Panel
        Me.Duty_Table_show = New System.Windows.Forms.DataGridView
        Me.Duty_Table_Panel.SuspendLayout()
        CType(Me.Duty_Table_show, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Duty_Table_Panel
        '
        Me.Duty_Table_Panel.BackColor = System.Drawing.Color.Transparent
        Me.Duty_Table_Panel.Controls.Add(Me.Duty_Table_show)
        Me.Duty_Table_Panel.Location = New System.Drawing.Point(8, 9)
        Me.Duty_Table_Panel.Margin = New System.Windows.Forms.Padding(0)
        Me.Duty_Table_Panel.Name = "Duty_Table_Panel"
        Me.Duty_Table_Panel.Size = New System.Drawing.Size(728, 565)
        Me.Duty_Table_Panel.TabIndex = 0
        '
        'Duty_Table_show
        '
        Me.Duty_Table_show.AllowUserToAddRows = False
        Me.Duty_Table_show.AllowUserToDeleteRows = False
        Me.Duty_Table_show.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.Duty_Table_show.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.Duty_Table_show.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.Duty_Table_show.Location = New System.Drawing.Point(4, 3)
        Me.Duty_Table_show.Name = "Duty_Table_show"
        Me.Duty_Table_show.RowTemplate.Height = 23
        Me.Duty_Table_show.Size = New System.Drawing.Size(711, 559)
        Me.Duty_Table_show.TabIndex = 0
        '
        'Duty_Table
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(745, 584)
        Me.Controls.Add(Me.Duty_Table_Panel)
        Me.DoubleBuffered = True
        Me.Name = "Duty_Table"
        Me.Text = "Duty_Table"
        Me.Duty_Table_Panel.ResumeLayout(False)
        CType(Me.Duty_Table_show, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Duty_Table_Panel As System.Windows.Forms.Panel
    Friend WithEvents Duty_Table_show As System.Windows.Forms.DataGridView
End Class
