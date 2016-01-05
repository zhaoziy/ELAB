<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Data_IO
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
        Me.Data_IO_Panel = New System.Windows.Forms.Panel
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.Button1 = New System.Windows.Forms.Button
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.PictureBox4 = New System.Windows.Forms.PictureBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.PictureBox3 = New System.Windows.Forms.PictureBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.PictureBox2 = New System.Windows.Forms.PictureBox
        Me.Data_IO_Panel.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Data_IO_Panel
        '
        Me.Data_IO_Panel.Controls.Add(Me.GroupBox2)
        Me.Data_IO_Panel.Controls.Add(Me.GroupBox1)
        Me.Data_IO_Panel.Location = New System.Drawing.Point(0, 0)
        Me.Data_IO_Panel.Margin = New System.Windows.Forms.Padding(0)
        Me.Data_IO_Panel.Name = "Data_IO_Panel"
        Me.Data_IO_Panel.Size = New System.Drawing.Size(728, 565)
        Me.Data_IO_Panel.TabIndex = 0
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Button1)
        Me.GroupBox2.Font = New System.Drawing.Font("微软雅黑", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.GroupBox2.Location = New System.Drawing.Point(32, 1)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(661, 73)
        Me.GroupBox2.TabIndex = 9
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "数据导入"
        '
        'Button1
        '
        Me.Button1.Font = New System.Drawing.Font("微软雅黑", 10.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Button1.Location = New System.Drawing.Point(101, 28)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(131, 31)
        Me.Button1.TabIndex = 0
        Me.Button1.Text = "导入上课名单"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.PictureBox1)
        Me.GroupBox1.Controls.Add(Me.PictureBox4)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.PictureBox3)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.PictureBox2)
        Me.GroupBox1.Font = New System.Drawing.Font("微软雅黑", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(32, 80)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(661, 471)
        Me.GroupBox1.TabIndex = 8
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "数据导出"
        '
        'PictureBox1
        '
        Me.PictureBox1.BackgroundImage = Global.Teaching_Assistant.My.Resources.Resources._1
        Me.PictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PictureBox1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.PictureBox1.Location = New System.Drawing.Point(25, 58)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(280, 180)
        Me.PictureBox1.TabIndex = 0
        Me.PictureBox1.TabStop = False
        '
        'PictureBox4
        '
        Me.PictureBox4.BackgroundImage = Global.Teaching_Assistant.My.Resources.Resources._4
        Me.PictureBox4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PictureBox4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PictureBox4.Cursor = System.Windows.Forms.Cursors.Hand
        Me.PictureBox4.Location = New System.Drawing.Point(356, 283)
        Me.PictureBox4.Name = "PictureBox4"
        Me.PictureBox4.Size = New System.Drawing.Size(280, 180)
        Me.PictureBox4.TabIndex = 3
        Me.PictureBox4.TabStop = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("微软雅黑", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label4.Location = New System.Drawing.Point(435, 249)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(112, 27)
        Me.Label4.TabIndex = 7
        Me.Label4.Text = "上课成绩单"
        '
        'PictureBox3
        '
        Me.PictureBox3.BackgroundImage = Global.Teaching_Assistant.My.Resources.Resources._3
        Me.PictureBox3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PictureBox3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PictureBox3.Cursor = System.Windows.Forms.Cursors.Hand
        Me.PictureBox3.Location = New System.Drawing.Point(25, 283)
        Me.PictureBox3.Name = "PictureBox3"
        Me.PictureBox3.Size = New System.Drawing.Size(280, 180)
        Me.PictureBox3.TabIndex = 2
        Me.PictureBox3.TabStop = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("微软雅黑", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label1.Location = New System.Drawing.Point(96, 24)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(132, 27)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "理论课签到单"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("微软雅黑", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label3.Location = New System.Drawing.Point(78, 249)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(172, 27)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "助教出勤次数统计"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("微软雅黑", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label2.Location = New System.Drawing.Point(435, 24)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(112, 27)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "实验签到单"
        '
        'PictureBox2
        '
        Me.PictureBox2.BackgroundImage = Global.Teaching_Assistant.My.Resources.Resources._2
        Me.PictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PictureBox2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PictureBox2.Cursor = System.Windows.Forms.Cursors.Hand
        Me.PictureBox2.Location = New System.Drawing.Point(356, 58)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(280, 180)
        Me.PictureBox2.TabIndex = 1
        Me.PictureBox2.TabStop = False
        '
        'Data_IO
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(893, 619)
        Me.Controls.Add(Me.Data_IO_Panel)
        Me.DoubleBuffered = True
        Me.Name = "Data_IO"
        Me.Text = "Data_IO"
        Me.Data_IO_Panel.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Data_IO_Panel As System.Windows.Forms.Panel
    Friend WithEvents PictureBox4 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox3 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
End Class
