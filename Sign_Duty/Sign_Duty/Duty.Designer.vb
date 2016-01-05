<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Duty
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
        Me.Duty_Panel = New System.Windows.Forms.Panel
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.ListView1 = New System.Windows.Forms.ListView
        Me.Label4 = New System.Windows.Forms.Label
        Me.Duty_Panel.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Duty_Panel
        '
        Me.Duty_Panel.Controls.Add(Me.Label4)
        Me.Duty_Panel.Controls.Add(Me.ListView1)
        Me.Duty_Panel.Controls.Add(Me.Label3)
        Me.Duty_Panel.Controls.Add(Me.Label2)
        Me.Duty_Panel.Controls.Add(Me.Label1)
        Me.Duty_Panel.Controls.Add(Me.PictureBox1)
        Me.Duty_Panel.Location = New System.Drawing.Point(0, 0)
        Me.Duty_Panel.Margin = New System.Windows.Forms.Padding(0)
        Me.Duty_Panel.Name = "Duty_Panel"
        Me.Duty_Panel.Size = New System.Drawing.Size(728, 565)
        Me.Duty_Panel.TabIndex = 0
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("宋体", 10.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label3.Location = New System.Drawing.Point(24, 274)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(49, 14)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "Label3"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label2.Location = New System.Drawing.Point(24, 239)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(56, 16)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Label2"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("宋体", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label1.Location = New System.Drawing.Point(23, 22)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(94, 21)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "当前值班"
        '
        'PictureBox1
        '
        Me.PictureBox1.BackgroundImage = Global.Sign_Duty.My.Resources.Resources.person
        Me.PictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PictureBox1.Location = New System.Drawing.Point(22, 81)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(100, 134)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.PictureBox1.TabIndex = 0
        Me.PictureBox1.TabStop = False
        '
        'Timer1
        '
        '
        'ListView1
        '
        Me.ListView1.Location = New System.Drawing.Point(170, 56)
        Me.ListView1.Name = "ListView1"
        Me.ListView1.Size = New System.Drawing.Size(477, 437)
        Me.ListView1.TabIndex = 4
        Me.ListView1.UseCompatibleStateImageBehavior = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Location = New System.Drawing.Point(182, 31)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(53, 12)
        Me.Label4.TabIndex = 5
        Me.Label4.Text = "值班情况"
        '
        'Duty
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(745, 584)
        Me.Controls.Add(Me.Duty_Panel)
        Me.DoubleBuffered = True
        Me.Name = "Duty"
        Me.Text = "Duty"
        Me.Duty_Panel.ResumeLayout(False)
        Me.Duty_Panel.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Duty_Panel As System.Windows.Forms.Panel
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents ListView1 As System.Windows.Forms.ListView
End Class
